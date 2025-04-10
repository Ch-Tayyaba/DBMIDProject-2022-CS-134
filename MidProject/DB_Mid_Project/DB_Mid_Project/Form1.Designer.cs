namespace DB_Mid_Project
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tlpSubPanelForTime = new System.Windows.Forms.TableLayoutPanel();
            this.tlpChangeable = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.tlpSidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblAssessment = new System.Windows.Forms.Label();
            this.lblRubric = new System.Windows.Forms.Label();
            this.lblClo = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
            this.ForDateTime = new System.Windows.Forms.Timer(this.components);
            this.tlpSubPanelForTime.SuspendLayout();
            this.tlpChangeable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpSidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tlpBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSubPanelForTime
            // 
            this.tlpSubPanelForTime.ColumnCount = 1;
            this.tlpSubPanelForTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubPanelForTime.Controls.Add(this.tlpChangeable, 0, 0);
            this.tlpSubPanelForTime.Controls.Add(this.lblDateTime, 0, 1);
            this.tlpSubPanelForTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSubPanelForTime.Location = new System.Drawing.Point(143, 21);
            this.tlpSubPanelForTime.Name = "tlpSubPanelForTime";
            this.tlpSubPanelForTime.RowCount = 2;
            this.tlpSubPanelForTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.05882F));
            this.tlpSubPanelForTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.941176F));
            this.tlpSubPanelForTime.Size = new System.Drawing.Size(654, 426);
            this.tlpSubPanelForTime.TabIndex = 1;
            // 
            // tlpChangeable
            // 
            this.tlpChangeable.ColumnCount = 1;
            this.tlpChangeable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChangeable.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpChangeable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChangeable.Location = new System.Drawing.Point(3, 3);
            this.tlpChangeable.Name = "tlpChangeable";
            this.tlpChangeable.RowCount = 1;
            this.tlpChangeable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChangeable.Size = new System.Drawing.Size(648, 398);
            this.tlpChangeable.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 392);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDateTime.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Lavender;
            this.lblDateTime.Location = new System.Drawing.Point(511, 404);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(140, 22);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Date       Time";
            // 
            // tlpSidePanel
            // 
            this.tlpSidePanel.BackColor = System.Drawing.Color.PowderBlue;
            this.tlpSidePanel.ColumnCount = 1;
            this.tlpSidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidePanel.Controls.Add(this.lblExit, 0, 9);
            this.tlpSidePanel.Controls.Add(this.lblReport, 0, 8);
            this.tlpSidePanel.Controls.Add(this.lblResult, 0, 7);
            this.tlpSidePanel.Controls.Add(this.lblAttendance, 0, 6);
            this.tlpSidePanel.Controls.Add(this.lblAssessment, 0, 5);
            this.tlpSidePanel.Controls.Add(this.lblRubric, 0, 4);
            this.tlpSidePanel.Controls.Add(this.lblClo, 0, 3);
            this.tlpSidePanel.Controls.Add(this.pbLogo, 0, 0);
            this.tlpSidePanel.Controls.Add(this.lblStudent, 0, 2);
            this.tlpSidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSidePanel.Location = new System.Drawing.Point(3, 21);
            this.tlpSidePanel.Name = "tlpSidePanel";
            this.tlpSidePanel.RowCount = 10;
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.41084F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.225224F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.295492F));
            this.tlpSidePanel.Size = new System.Drawing.Size(134, 426);
            this.tlpSidePanel.TabIndex = 0;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExit.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Navy;
            this.lblExit.Location = new System.Drawing.Point(3, 381);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(128, 45);
            this.lblExit.TabIndex = 9;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReport.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.Color.Navy;
            this.lblReport.Location = new System.Drawing.Point(3, 342);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(128, 39);
            this.lblReport.TabIndex = 8;
            this.lblReport.Text = "Report";
            this.lblReport.Click += new System.EventHandler(this.lblReport_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Navy;
            this.lblResult.Location = new System.Drawing.Point(3, 303);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(128, 39);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Result";
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // lblAttendance
            // 
            this.lblAttendance.AutoSize = true;
            this.lblAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAttendance.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendance.ForeColor = System.Drawing.Color.Navy;
            this.lblAttendance.Location = new System.Drawing.Point(3, 264);
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Size = new System.Drawing.Size(128, 39);
            this.lblAttendance.TabIndex = 6;
            this.lblAttendance.Text = "Attendance";
            this.lblAttendance.Click += new System.EventHandler(this.lblAttendance_Click);
            // 
            // lblAssessment
            // 
            this.lblAssessment.AutoSize = true;
            this.lblAssessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAssessment.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssessment.ForeColor = System.Drawing.Color.Navy;
            this.lblAssessment.Location = new System.Drawing.Point(3, 225);
            this.lblAssessment.Name = "lblAssessment";
            this.lblAssessment.Size = new System.Drawing.Size(128, 39);
            this.lblAssessment.TabIndex = 5;
            this.lblAssessment.Text = "Assessment";
            this.lblAssessment.Click += new System.EventHandler(this.lblAssessment_Click);
            // 
            // lblRubric
            // 
            this.lblRubric.AutoSize = true;
            this.lblRubric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRubric.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRubric.ForeColor = System.Drawing.Color.Navy;
            this.lblRubric.Location = new System.Drawing.Point(3, 186);
            this.lblRubric.Name = "lblRubric";
            this.lblRubric.Size = new System.Drawing.Size(128, 39);
            this.lblRubric.TabIndex = 4;
            this.lblRubric.Text = "Rubric";
            this.lblRubric.Click += new System.EventHandler(this.lblRubric_Click);
            // 
            // lblClo
            // 
            this.lblClo.AutoSize = true;
            this.lblClo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClo.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClo.ForeColor = System.Drawing.Color.Navy;
            this.lblClo.Location = new System.Drawing.Point(3, 147);
            this.lblClo.Name = "lblClo";
            this.lblClo.Size = new System.Drawing.Size(128, 39);
            this.lblClo.TabIndex = 3;
            this.lblClo.Text = "CLO\'s";
            this.lblClo.Click += new System.EventHandler(this.lblClo_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.ErrorImage = null;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = null;
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(128, 84);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStudent.Font = new System.Drawing.Font("Rockwell Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.Navy;
            this.lblStudent.Location = new System.Drawing.Point(3, 108);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(128, 39);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Student";
            this.lblStudent.Click += new System.EventHandler(this.lblStudent_Click);
            // 
            // tlpBackground
            // 
            this.tlpBackground.BackColor = System.Drawing.Color.Navy;
            this.tlpBackground.ColumnCount = 2;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.5F));
            this.tlpBackground.Controls.Add(this.tlpSidePanel, 0, 1);
            this.tlpBackground.Controls.Add(this.tlpSubPanelForTime, 1, 1);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(0, 0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 2;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.222222F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.77778F));
            this.tlpBackground.Size = new System.Drawing.Size(800, 450);
            this.tlpBackground.TabIndex = 0;
            // 
            // ForDateTime
            // 
            this.ForDateTime.Interval = 1000;
            this.ForDateTime.Tick += new System.EventHandler(this.ForDateTime_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpBackground);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpSubPanelForTime.ResumeLayout(false);
            this.tlpSubPanelForTime.PerformLayout();
            this.tlpChangeable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpSidePanel.ResumeLayout(false);
            this.tlpSidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tlpBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSubPanelForTime;
        private System.Windows.Forms.TableLayoutPanel tlpChangeable;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TableLayoutPanel tlpSidePanel;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblAssessment;
        private System.Windows.Forms.Label lblRubric;
        private System.Windows.Forms.Label lblClo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TableLayoutPanel tlpBackground;
        private System.Windows.Forms.Timer ForDateTime;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

