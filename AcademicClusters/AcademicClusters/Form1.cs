using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Globalization;


namespace AcademicClusters
{
    public partial class Form1 : Form
    {

        static string connectionstring = "Data Source=db-tgsanalys-test.du.se;Initial Catalog=dbTGSAnalysTest;Integrated Security=True;Pooling=False";
        static DbTGSAnalysTest db = null;

        public static CultureInfo culture_en = CultureInfo.CreateSpecificCulture("en-US");

        static Dictionary<string, int> prind = new Dictionary<string, int>();
        static Dictionary<string, int> subind = new Dictionary<string, int>();
        static int nprofile = 6;
        static int nsubject = 60;
        static double[,] connections = new double[nprofile,nsubject];
        static double[,] ssconnections = new double[nsubject,nsubject];

        public Form1()
        {
            InitializeComponent();
            db = new DbTGSAnalysTest(connectionstring);
            fill_dicts();
        }

        private void fill_dicts()
        {
            int ip = 0;
            foreach (string pp in (from c in db.Researchprofile select c.Id))
            {
                prind.Add(pp, ip);
                ip++;
            }
            int iss=0;
            foreach (string sp in (from c in db.Orgsubject select c.OrgsubjectID))
            {
                subind.Add(sp,iss);
                iss++;
            }
        }



        public void memo(string line)
        {
            richTextBox1.AppendText(line + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static int tryconvert(string word)
        {
            int i = -1;

            if (word.Length == 0)
                return i;

            try
            {
                i = Convert.ToInt32(word);
            }
            catch (OverflowException)
            {
                Console.WriteLine("i Outside the range of the Int32 type: " + word);
            }
            catch (FormatException)
            {
                //if ( !String.IsNullOrEmpty(word))
                //    Console.WriteLine("i Not in a recognizable format: " + word);
                if (word.Contains(" "))
                    i = tryconvert(word.Replace(" ", ""));
            }
            return i;
        }


        private double teacherprofile_strength(Teacher tt,Researchprofile rp)
        {
            double f = 0;
            double ftot = 0;
            double utot = 0;
            double w = TB_teachres.Value/(850*850);
            double wf = TB_res.Value/ 8500;
            double presence = 1;
            int n = 0;
            foreach (Teacherbudget tb in tt.Teacherbudget)
            {
                ftot += (double)tb.Forskningklt;
                utot += (double)tb.Undervisningklt;
                n++;
            }
            f = ftot * utot * w + ftot*wf + n*presence;

            return f;
        }

        private int courselevel(string coursecode)
        {
            if (String.IsNullOrEmpty(coursecode))
                return 0;

            int cl = 1;

            if ( coursecode.Length > 2)
            {
                string cc = coursecode.Substring(2, 1);
                cl = tryconvert(cc);
                if ( cl < 0)
                {
                    if (cc == "D")
                        cl = 3;
                    else if (cc == "C")
                        cl = 2;
                    else
                        cl = 1;
                }
            }
            return cl;
        }

        private void ClusterButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nprofile; i++)
                for (int j = 0; j < nsubject; j++)
                    connections[i, j] = 0;
            for (int i = 0; i < nsubject; i++)
                for (int j = 0; j < nsubject; j++)
                    ssconnections[i, j] = 0;

            foreach (Profileteacher pt in (from c in db.Profileteacher select c))
            {
                double f = teacherprofile_strength(pt.TeacherTeacher, pt.ResearchprofileResearchprofile);
                int pi = prind[pt.Researchprofile];
                int si = subind[pt.TeacherTeacher.Subject];
                connections[pi, si] += f;
            }

            foreach (Programtable pp in db.Programtable)
            {
                memo(pp.Name);
                double wlevel = 1;
                if (pp.Level == "avancerad")
                    wlevel = 3;
                else if (pp.Level == "preparand")
                    wlevel = 0.5;
                var qcp = (from c in db.Programcourse where c.Program == pp.ProgID select c);
                foreach (Programcourse cp in qcp)
                {
                    memo(cp.Coursecode);
                    string cs = cp.Coursecode.Substring(0, 2);
                    string os = (from c in db.Coursesubject where c.SubjectID == cs select c.Orgsubject).FirstOrDefault();
                    int si = subind[os];

                    var qcp2 = (from c in qcp where c.Coursecode.Substring(0,2) != cs select c);
                    foreach (Programcourse cp2 in qcp2)
                    {
                        string cs2 = cp2.Coursecode.Substring(0, 2);
                        string os2 = (from c in db.Coursesubject where c.SubjectID == cs2 select c.Orgsubject).FirstOrDefault();
                        if ( os != os2)
                        {
                            int si2 = subind[os2];
                            ssconnections[si, si2]+= 0.01*wlevel*TB_program.Value;
                        }
                    }
                }

            }
            memo("Done with programs");


            //string header = "Ämne";
            //foreach (string pr in prind.Keys)
            //    header += "\t" + pr;
            //memo(header);

            //foreach (string sb in subind.Keys)
            //{
            //    string s = sb;
            //    foreach (string pr in prind.Keys)
            //    {
            //        s += "\t" + connections[prind[pr], subind[sb]];
            //    }
            //    memo(s);
            //}

            memo("NODE TABLE for Gephi");
            memo("Id;Label");
            
            foreach (string pr in prind.Keys)
            {
                memo("n"+prind[pr] + ";" + pr);
            }
            foreach (string sb in subind.Keys)
            {
                string nname = "n" + (subind[sb] + 6).ToString();
                memo(nname + ";" + sb);
            }

            memo("EDGE TABLE for Gephi");
            memo("Source;Target;Weight");
            foreach (string sb in subind.Keys)
            {
                string prefix = "";
                double generalweight = 0.001*TB_total.Value;
                string nname = prefix + (subind[sb] + 6).ToString();
                foreach (string pr in prind.Keys)
                {
                    string pname = prefix + prind[pr].ToString();
                    if ( connections[prind[pr],subind[sb]] > 0)
                    {
                        memo(nname + ";" + pname + ";" + (generalweight*connections[prind[pr], subind[sb]]).ToString(culture_en));
                    }
                }
                foreach (string sb2 in subind.Keys)
                {
                    string nname2 = prefix + (subind[sb2] + 6).ToString();
                    if (ssconnections[subind[sb], subind[sb2]] > 0)
                    {
                        memo(nname + ";" + nname2 + ";" + (generalweight * ssconnections[subind[sb], subind[sb2]]).ToString(culture_en));
                    }

                }
            }

        }

        private void addict(Dictionary<string, Dictionary<string, double>> tdict,string t1,string t2,double w)
        {
            if ( !tdict.ContainsKey(t1) && !tdict.ContainsKey(t2))
            {
                Dictionary<string, double> tdd = new Dictionary<string, double>();
                tdict.Add(t1, tdd);
                tdict[t1].Add(t2, w);
                
            }
            else if (!tdict.ContainsKey(t1))
            {
                addict(tdict, t2, t1, w);
                return;
            }
            else if (tdict.ContainsKey(t2))
            { 
                if ( tdict[t1].ContainsKey(t2))
                {
                    tdict[t1][t2] += w;
                }
                else if ( tdict[t2].ContainsKey(t1))
                {
                    tdict[t2][t1] += w;
                    //memo(t2 + " " + t1 + " " + w + " " + tdict[t2][t1]);
                    return;
                }
                else
                {
                    Dictionary<string, double> tdd = new Dictionary<string, double>();
                    tdict[t1].Add(t2, w);
                }
            }
            else
            {
                if (tdict[t1].ContainsKey(t2))
                {
                    tdict[t1][t2] += w;
                }
                else
                {
                    Dictionary<string, double> tdd = new Dictionary<string, double>();
                    tdict[t1].Add(t2, w);
                }

            }
            //memo(t1 + " " + t2 + " " + w + " " + tdict[t1][t2]);
        }

        private string colornode(string tt) //produces hex color string #00ff00 per profile
        {
            string profile = (from c in db.Profileteacher where c.Teacher == tt select c.Researchprofile).FirstOrDefault();
            if (String.IsNullOrEmpty(profile))
                return "#505050"; //grey
            else if (profile == "ESBM")
                return "#FF0000";
            else if (profile == "HV")
                return "#00FF00";
            else if (profile == "ISTUD")
                return "#0000FF";
            else if (profile == "MD")
                return "#FFFF00";
            else if (profile == "Stål")
                return "#FF00FF";
            else if (profile == "UL")
                return "#00FFFF";

            return "#505050"; //grey
        }

        private void TeacherClusterButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, double>> tdict = new Dictionary<string, Dictionary<string, double>>();

            //for now, use only data from HT16
            int year = 2016;
            bool ht = true;

            double wsumcourse = 0;
            int nsumcourse = 0;
            double wsumprog = 0;
            int nsumprog = 0;
            double wsumpub = 0;
            int nsumpub = 0;

            foreach (Teacher tt1 in db.Teacher)
            {
                memo(tt1.Name);
                List<int> proglist = new List<int>();
                double researchklt = 0;
                var q = (from c in db.TGS where c.Teacher == tt1.TeacherID where c.Year == year where c.Ht == ht select c);
                //memo("q " + q.Count());
                foreach (TGS tg in q)
                {
                    memo("tg.TGSitem " + tg.TGSitem.Count);
                    foreach (TGSitem ti in tg.TGSitem)
                    {
                        if ( ti.Category == 0 )
                        {
                            if (CB_coteaching.Checked)
                            {
                                //memo("ti.ctgs " + ti.CourseTGS.Count);
                                foreach (CourseTGS ctgs in ti.CourseTGS)
                                {
                                    Course cc = ctgs.CourseCourse;
                                    double cw = (1 + courselevel(cc.Coursecode)) * TB_coteach.Value * (ti.Hours + 20);
                                    foreach (CourseTGS ctgs2 in cc.CourseTGS)
                                    {
                                        TGS tgs2 = ctgs2.TgsitemTGSitem.TgsTGS;
                                        if (tgs2.Teacher != tt1.TeacherID)
                                        {
                                            addict(tdict, tt1.TeacherID, tgs2.Teacher, cw);
                                            nsumcourse++;
                                            wsumcourse += cw;
                                        }
                                    }

                                    if ( CB_program.Checked)
                                    {
                                        foreach (int progid in (from c in db.Programcourse where c.Coursecode == cc.Coursecode select c.Program))
                                        {
                                            if ( !proglist.Contains(progid))
                                                proglist.Add(progid);
                                        }
                                    }
                                }
                            }
                        }
                        else if ( ti.Category == 1)
                        {
                            researchklt += ti.Hours;
                        }
                    }
                }

                if ( CB_program.Checked)
                {
                    memo("Program loop for " + tt1.Name);
                    foreach (int progid in proglist)
                    {
                        foreach (string coursecode in (from c in db.Programcourse where c.Program == progid select c.Coursecode))
                        {
                            foreach (Course ccp in (from c in db.Course where c.Coursecode == coursecode where c.Year == year where c.Ht == ht select c))
                            {
                                foreach (CourseTGS ctgs2 in ccp.CourseTGS)
                                {
                                    TGS tgs2 = ctgs2.TgsitemTGSitem.TgsTGS;
                                    double cw = 5*(1 + courselevel(ccp.Coursecode)) * TB_coteach.Value;
                                    if (tgs2.Teacher != tt1.TeacherID)
                                    {
                                        addict(tdict, tt1.TeacherID, tgs2.Teacher, cw);
                                        nsumprog++;
                                        wsumprog += cw;
                                    }
                                }
                            }
                        }
                    }
                }

                if ( researchklt == 0)
                {
                    Teacherbudget tb = tt1.Teacherbudget.FirstOrDefault();
                    if ( tb != null && tb.Forskningklt != null)
                        researchklt = (double)tb.Forskningklt;
                }

                if (CB_teachres.Checked)
                {
                    memo("Research loop for " + tt1.Name);
                    if (researchklt > 0 && tt1.Profileteacher.Count > 0)
                    {
                        //memo("tt1.pt " + tt1.Profileteacher.Count);
                        foreach (Profileteacher pt in tt1.Profileteacher)
                        {
                            //memo("ptrppt " + pt.ResearchprofileResearchprofile.Profileteacher.Count);
                            foreach (Profileteacher pt2 in pt.ResearchprofileResearchprofile.Profileteacher)
                            {
                                if (pt2.Teacher != tt1.TeacherID)
                                {
                                    addict(tdict, tt1.TeacherID, pt2.Teacher, TB_res.Value * (researchklt + 50));
                                }
                            }
                        }
                    }
                }

                if ( CB_copublishing.Checked)
                {
                    memo("Copublishing loop for " + tt1.Name);
                    foreach (Author au in tt1.Author)
                    {
                        double cw = 400 * TB_copublish.Value;
                        foreach (string tid2 in (from c in db.Author where c.DivaID == au.DivaID where c.Teacher != tt1.TeacherID select c.Teacher))
                        {

                            addict(tdict, tt1.TeacherID, tid2,cw);
                            nsumpub++;
                            wsumpub += cw;
                        }
                    }
                }
                //break;
            }

            int nnode = 0;
            Dictionary<string, int> nodedict = new Dictionary<string, int>();
            foreach (string tt1 in tdict.Keys)
            {
                if ( !nodedict.ContainsKey(tt1))
                {
                    nodedict.Add(tt1, nnode);
                    nnode++;
                }
                foreach (string tt2 in tdict[tt1].Keys)
                {
                    if (!nodedict.ContainsKey(tt2))
                    {
                        nodedict.Add(tt2, nnode);
                        nnode++;
                    }
                }
            }

            memo("NODE TABLE for Gephi");

            string nodefn = "teachernodes";
            int nn=1;
            while (File.Exists(nodefn + nn + ".csv"))
                nn++;
            nodefn = nodefn+nn+".csv";
            memo(nodefn);
            using (StreamWriter sw = new StreamWriter(nodefn))
            {
                sw.WriteLine("Id;Label;Color");

                foreach (string tt in nodedict.Keys)
                {
                    string tnode = tt;
                    if (CB_profsubjname.Checked)
                    {
                        Teacher qt = (from c in db.Teacher where c.TeacherID == tt select c).First();
                        if (qt.Profileteacher.Count == 1)
                            tnode = qt.Profileteacher.First().Researchprofile;
                        else
                        {
                            tnode = qt.Orgsubject.OrgsubjectID;
                            if (tnode == "ämne saknas")
                                tnode = tt;
                        }
                    }
                    else if (CB_subjname.Checked)
                    {
                        Teacher qt = (from c in db.Teacher where c.TeacherID == tt select c).First();
                        tnode = qt.Orgsubject.OrgsubjectID;
                        if (tnode == "ämne saknas")
                            tnode = tt;
                    }
                    else if ( CB_fullname.Checked)
                    {
                        tnode = (from c in db.Teacher where c.TeacherID == tt select c.Name).First();
                    }
                    sw.WriteLine(nodedict[tt] + ";" + tnode + ";"+colornode(tt));
                }
            }

            memo("EDGE TABLE for Gephi");
            string edgefn = "teacheredges";
            nn = 1;
            while (File.Exists(edgefn + nn + ".csv"))
                nn++;
            edgefn = edgefn + nn + ".csv";
            memo(edgefn);
            double gw = 0.00001 * TB_total.Value;
            using (StreamWriter sw = new StreamWriter(edgefn))
            {
                sw.WriteLine("Source;Target;Weight");
                foreach (string tt1 in tdict.Keys)
                {
                    foreach (string tt2 in tdict[tt1].Keys)
                    {
                        sw.WriteLine(nodedict[tt1] + ";" + nodedict[tt2] + ";" + (gw * tdict[tt1][tt2]).ToString(culture_en));
                    }
                }
            }

            if ( nsumcourse > 0)
                memo("Course: " + nsumcourse + "\t" + wsumcourse + "\tavg " + wsumcourse / nsumcourse);
            if (nsumprog > 0)
                memo("Prog:  " + nsumprog + "\t" + wsumprog + "\tavg " + wsumprog / nsumprog);
            if (nsumpub > 0)
                memo("Pub:   " + nsumpub + "\t" + wsumpub + "\tavg " + wsumpub / nsumpub);
            memo("DONE");
        }
    }
}
