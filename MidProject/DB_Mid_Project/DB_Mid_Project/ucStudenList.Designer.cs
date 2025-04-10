namespace DB_Mid_Project
{
    partial class ucStudenList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.tlpStudedntList = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblInActive = new System.Windows.Forms.Label();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.lblInActiveCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvStudentList = new System.Windows.Forms.DataGridView();
            this.tlpHeader.SuspendLayout();
            this.tlpStudedntList.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.39349F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.07734F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.52917F));
            this.tlpHeader.Controls.Add(this.lblHeading, 1, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(3, 3);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpHeader.Size = new System.Drawing.Size(737, 52);
            this.tlpHeader.TabIndex = 0;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeading.Font = new System.Drawing.Font("Algerian", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHeading.Location = new System.Drawing.Point(227, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(281, 52);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Student Form";
            // 
            // tlpStudedntList
            // 
            this.tlpStudedntList.ColumnCount = 1;
            this.tlpStudedntList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStudedntList.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpStudedntList.Controls.Add(this.tlpFooter, 0, 2);
            this.tlpStudedntList.Controls.Add(this.dgvStudentList, 0, 1);
            this.tlpStudedntList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStudedntList.Location = new System.Drawing.Point(0, 0);
            this.tlpStudedntList.Name = "tlpStudedntList";
            this.tlpStudedntList.RowCount = 3;
            this.tlpStudedntList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.4346F));
            this.tlpStudedntList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.53911F));
            this.tlpStudedntList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.19873F));
            this.tlpStudedntList.Size = new System.Drawing.Size(743, 473);
            this.tlpStudedntList.TabIndex = 1;
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 3;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpFooter.Controls.Add(this.lblStatus, 1, 0);
            this.tlpFooter.Controls.Add(this.tlpStatus, 1, 1);
            this.tlpFooter.Controls.Add(this.btnClose, 0, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(3, 370);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 2;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
            this.tlpFooter.Size = new System.Drawing.Size(737, 100);
            this.tlpFooter.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(113, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(182, 36);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Student Status:";
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 6;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpStatus.Controls.Add(this.lblTotalCount, 5, 0);
            this.tlpStatus.Controls.Add(this.lblActive, 0, 0);
            this.tlpStatus.Controls.Add(this.lblTotal, 4, 0);
            this.tlpStatus.Controls.Add(this.lblInActive, 2, 0);
            this.tlpStatus.Controls.Add(this.lblActiveCount, 1, 0);
            this.tlpStatus.Controls.Add(this.lblInActiveCount, 3, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(113, 39);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 1;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Size = new System.Drawing.Size(509, 58);
            this.tlpStatus.TabIndex = 0;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Location = new System.Drawing.Point(423, 0);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(83, 58);
            this.lblTotalCount.TabIndex = 6;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActive.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.ForeColor = System.Drawing.Color.Navy;
            this.lblActive.Location = new System.Drawing.Point(3, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(78, 58);
            this.lblActive.TabIndex = 1;
            this.lblActive.Text = "Active";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblTotal.Location = new System.Drawing.Point(339, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 58);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            // 
            // lblInActive
            // 
            this.lblInActive.AutoSize = true;
            this.lblInActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInActive.Font = new System.Drawing.Font("Rockwell", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInActive.ForeColor = System.Drawing.Color.Navy;
            this.lblInActive.Location = new System.Drawing.Point(171, 0);
            this.lblInActive.Name = "lblInActive";
            this.lblInActive.Size = new System.Drawing.Size(78, 58);
            this.lblInActive.TabIndex = 2;
            this.lblInActive.Text = "Inactive";
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActiveCount.Location = new System.Drawing.Point(87, 0);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(78, 58);
            this.lblActiveCount.TabIndex = 4;
            // 
            // lblInActiveCount
            // 
            this.lblInActiveCount.AutoSize = true;
            this.lblInActiveCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInActiveCount.Location = new System.Drawing.Point(255, 0);
            this.lblInActiveCount.Name = "lblInActiveCount";
            this.lblInActiveCount.Size = new System.Drawing.Size(78, 58);
            this.lblInActiveCount.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvStudentList
            // 
            this.dgvStudentList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentList.GridColor = System.Drawing.Color.Lavender;
            this.dgvStudentList.Location = new System.Drawing.Point(3, 61);
            this.dgvStudentList.Name = "dgvStudentList";
            this.dgvStudentList.Size = new System.Drawing.Size(737, 303);
            this.dgvStudentList.TabIndex = 2;
            this.dgvStudentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentList_CellContentClick);
            this.dgvStudentList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStudentList_CellFormatting);
            this.dgvStudentList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStudentList_RowHeaderMouseClick);
            // 
            // ucStudenList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.tlpStudedntList);
            this.Name = "ucStudenList";
            this.Size = new System.Drawing.Size(743, 473);
            this.Load += new System.EventHandler(this.ucStudenList_Load);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.tlpStudedntList.ResumeLayout(false);
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            this.tlpStatus.ResumeLayout(false);
            this.tlpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TableLayoutPanel tlpStudedntList;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblInActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvStudentList;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblInActiveCount;
    }
}
