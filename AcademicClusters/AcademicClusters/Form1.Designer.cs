namespace AcademicClusters
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.ClusterButton = new System.Windows.Forms.Button();
            this.TB_total = new System.Windows.Forms.TrackBar();
            this.TB_coteach = new System.Windows.Forms.TrackBar();
            this.TB_program = new System.Windows.Forms.TrackBar();
            this.TB_res = new System.Windows.Forms.TrackBar();
            this.TB_teachres = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TeacherClusterButton = new System.Windows.Forms.Button();
            this.CB_coteaching = new System.Windows.Forms.CheckBox();
            this.CB_copublishing = new System.Windows.Forms.CheckBox();
            this.TB_copublish = new System.Windows.Forms.TrackBar();
            this.CB_program = new System.Windows.Forms.CheckBox();
            this.CB_teachres = new System.Windows.Forms.CheckBox();
            this.CB_fullname = new System.Windows.Forms.CheckBox();
            this.CB_profsubjname = new System.Windows.Forms.CheckBox();
            this.CB_subjname = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TB_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_coteach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_program)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_res)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_teachres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_copublish)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 11);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(665, 798);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(716, 782);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(155, 98);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ClusterButton
            // 
            this.ClusterButton.Location = new System.Drawing.Point(716, 12);
            this.ClusterButton.Name = "ClusterButton";
            this.ClusterButton.Size = new System.Drawing.Size(155, 60);
            this.ClusterButton.TabIndex = 5;
            this.ClusterButton.Text = "Make clusters by subject/profile";
            this.ClusterButton.UseVisualStyleBackColor = true;
            this.ClusterButton.Click += new System.EventHandler(this.ClusterButton_Click);
            // 
            // TB_total
            // 
            this.TB_total.Location = new System.Drawing.Point(716, 162);
            this.TB_total.Maximum = 20;
            this.TB_total.Name = "TB_total";
            this.TB_total.Size = new System.Drawing.Size(155, 56);
            this.TB_total.TabIndex = 7;
            this.TB_total.Value = 10;
            // 
            // TB_coteach
            // 
            this.TB_coteach.Location = new System.Drawing.Point(716, 477);
            this.TB_coteach.Maximum = 20;
            this.TB_coteach.Name = "TB_coteach";
            this.TB_coteach.Size = new System.Drawing.Size(155, 56);
            this.TB_coteach.TabIndex = 8;
            this.TB_coteach.Value = 10;
            // 
            // TB_program
            // 
            this.TB_program.Location = new System.Drawing.Point(716, 398);
            this.TB_program.Maximum = 20;
            this.TB_program.Name = "TB_program";
            this.TB_program.Size = new System.Drawing.Size(155, 56);
            this.TB_program.TabIndex = 9;
            this.TB_program.Value = 10;
            // 
            // TB_res
            // 
            this.TB_res.Location = new System.Drawing.Point(716, 319);
            this.TB_res.Maximum = 20;
            this.TB_res.Name = "TB_res";
            this.TB_res.Size = new System.Drawing.Size(155, 56);
            this.TB_res.TabIndex = 10;
            this.TB_res.Value = 10;
            // 
            // TB_teachres
            // 
            this.TB_teachres.Location = new System.Drawing.Point(716, 233);
            this.TB_teachres.Maximum = 20;
            this.TB_teachres.Name = "TB_teachres";
            this.TB_teachres.Size = new System.Drawing.Size(155, 56);
            this.TB_teachres.TabIndex = 11;
            this.TB_teachres.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(732, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Overall weight scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(732, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Research-subject";
            // 
            // TeacherClusterButton
            // 
            this.TeacherClusterButton.Location = new System.Drawing.Point(716, 78);
            this.TeacherClusterButton.Name = "TeacherClusterButton";
            this.TeacherClusterButton.Size = new System.Drawing.Size(155, 53);
            this.TeacherClusterButton.TabIndex = 17;
            this.TeacherClusterButton.Text = "Make clusters by teacher";
            this.TeacherClusterButton.UseVisualStyleBackColor = true;
            this.TeacherClusterButton.Click += new System.EventHandler(this.TeacherClusterButton_Click);
            // 
            // CB_coteaching
            // 
            this.CB_coteaching.AutoSize = true;
            this.CB_coteaching.Location = new System.Drawing.Point(726, 449);
            this.CB_coteaching.Name = "CB_coteaching";
            this.CB_coteaching.Size = new System.Drawing.Size(101, 21);
            this.CB_coteaching.TabIndex = 18;
            this.CB_coteaching.Text = "Coteaching";
            this.CB_coteaching.UseVisualStyleBackColor = true;
            // 
            // CB_copublishing
            // 
            this.CB_copublishing.AutoSize = true;
            this.CB_copublishing.Location = new System.Drawing.Point(726, 535);
            this.CB_copublishing.Name = "CB_copublishing";
            this.CB_copublishing.Size = new System.Drawing.Size(111, 21);
            this.CB_copublishing.TabIndex = 19;
            this.CB_copublishing.Text = "Copublishing";
            this.CB_copublishing.UseVisualStyleBackColor = true;
            // 
            // TB_copublish
            // 
            this.TB_copublish.Location = new System.Drawing.Point(716, 562);
            this.TB_copublish.Maximum = 20;
            this.TB_copublish.Name = "TB_copublish";
            this.TB_copublish.Size = new System.Drawing.Size(155, 56);
            this.TB_copublish.TabIndex = 20;
            this.TB_copublish.Value = 10;
            // 
            // CB_program
            // 
            this.CB_program.AutoSize = true;
            this.CB_program.Location = new System.Drawing.Point(726, 371);
            this.CB_program.Name = "CB_program";
            this.CB_program.Size = new System.Drawing.Size(157, 21);
            this.CB_program.TabIndex = 21;
            this.CB_program.Text = "Program connection";
            this.CB_program.UseVisualStyleBackColor = true;
            // 
            // CB_teachres
            // 
            this.CB_teachres.AutoSize = true;
            this.CB_teachres.Location = new System.Drawing.Point(735, 206);
            this.CB_teachres.Name = "CB_teachres";
            this.CB_teachres.Size = new System.Drawing.Size(134, 21);
            this.CB_teachres.TabIndex = 22;
            this.CB_teachres.Text = "Research profile";
            this.CB_teachres.UseVisualStyleBackColor = true;
            // 
            // CB_fullname
            // 
            this.CB_fullname.AutoSize = true;
            this.CB_fullname.Location = new System.Drawing.Point(697, 757);
            this.CB_fullname.Name = "CB_fullname";
            this.CB_fullname.Size = new System.Drawing.Size(123, 21);
            this.CB_fullname.TabIndex = 23;
            this.CB_fullname.Text = "Use full names";
            this.CB_fullname.UseVisualStyleBackColor = true;
            // 
            // CB_profsubjname
            // 
            this.CB_profsubjname.AutoSize = true;
            this.CB_profsubjname.Location = new System.Drawing.Point(697, 730);
            this.CB_profsubjname.Name = "CB_profsubjname";
            this.CB_profsubjname.Size = new System.Drawing.Size(186, 21);
            this.CB_profsubjname.TabIndex = 24;
            this.CB_profsubjname.Text = "Use profile/subject name";
            this.CB_profsubjname.UseVisualStyleBackColor = true;
            // 
            // CB_subjname
            // 
            this.CB_subjname.AutoSize = true;
            this.CB_subjname.Location = new System.Drawing.Point(697, 703);
            this.CB_subjname.Name = "CB_subjname";
            this.CB_subjname.Size = new System.Drawing.Size(173, 21);
            this.CB_subjname.TabIndex = 25;
            this.CB_subjname.Text = "Use subject name only";
            this.CB_subjname.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 891);
            this.Controls.Add(this.CB_subjname);
            this.Controls.Add(this.CB_profsubjname);
            this.Controls.Add(this.CB_fullname);
            this.Controls.Add(this.CB_teachres);
            this.Controls.Add(this.CB_program);
            this.Controls.Add(this.TB_copublish);
            this.Controls.Add(this.CB_copublishing);
            this.Controls.Add(this.CB_coteaching);
            this.Controls.Add(this.TeacherClusterButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_teachres);
            this.Controls.Add(this.TB_res);
            this.Controls.Add(this.TB_program);
            this.Controls.Add(this.TB_coteach);
            this.Controls.Add(this.TB_total);
            this.Controls.Add(this.ClusterButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TB_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_coteach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_program)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_res)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_teachres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_copublish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button ClusterButton;
        private System.Windows.Forms.TrackBar TB_total;
        private System.Windows.Forms.TrackBar TB_coteach;
        private System.Windows.Forms.TrackBar TB_program;
        private System.Windows.Forms.TrackBar TB_res;
        private System.Windows.Forms.TrackBar TB_teachres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button TeacherClusterButton;
        private System.Windows.Forms.CheckBox CB_coteaching;
        private System.Windows.Forms.CheckBox CB_copublishing;
        private System.Windows.Forms.TrackBar TB_copublish;
        private System.Windows.Forms.CheckBox CB_program;
        private System.Windows.Forms.CheckBox CB_teachres;
        private System.Windows.Forms.CheckBox CB_fullname;
        private System.Windows.Forms.CheckBox CB_profsubjname;
        private System.Windows.Forms.CheckBox CB_subjname;
    }
}

