namespace Client.Forms.Dashboard
{
    partial class frmDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefault));
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tableCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotalMembers = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblTotalMembersValue = new System.Windows.Forms.Label();
            this.lblTotalMembersTitle = new System.Windows.Forms.Label();
            this.cardNewThisMonth = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblNewThisMonthValue = new System.Windows.Forms.Label();
            this.lblNewThisMonthTitle = new System.Windows.Forms.Label();
            this.cardExpiringSoon = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblExpiringSoonValue = new System.Windows.Forms.Label();
            this.lblExpiringSoonTitle = new System.Windows.Forms.Label();
            this.cardRevenueMonth = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblRevenueMonthValue = new System.Windows.Forms.Label();
            this.lblRevenueMonthTitle = new System.Windows.Forms.Label();
            this.panelChartHost = new System.Windows.Forms.Panel();
            this.chartRevenueDaily = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableRoot.SuspendLayout();
            this.tableCards.SuspendLayout();
            this.cardTotalMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.cardNewThisMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.cardExpiringSoon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.cardRevenueMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panelChartHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueDaily)).BeginInit();
            this.SuspendLayout();
            // 
            // tableRoot
            // 
            this.tableRoot.BackColor = System.Drawing.Color.White;
            this.tableRoot.ColumnCount = 1;
            this.tableRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Controls.Add(this.tableCards, 0, 0);
            this.tableRoot.Controls.Add(this.panelChartHost, 0, 1);
            this.tableRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRoot.Location = new System.Drawing.Point(0, 0);
            this.tableRoot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableRoot.Name = "tableRoot";
            this.tableRoot.RowCount = 2;
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Size = new System.Drawing.Size(804, 432);
            this.tableRoot.TabIndex = 0;
            // 
            // tableCards
            // 
            this.tableCards.ColumnCount = 4;
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.Controls.Add(this.cardTotalMembers, 0, 0);
            this.tableCards.Controls.Add(this.cardNewThisMonth, 1, 0);
            this.tableCards.Controls.Add(this.cardExpiringSoon, 2, 0);
            this.tableCards.Controls.Add(this.cardRevenueMonth, 3, 0);
            this.tableCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCards.Location = new System.Drawing.Point(9, 10);
            this.tableCards.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.tableCards.Name = "tableCards";
            this.tableCards.RowCount = 1;
            this.tableCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCards.Size = new System.Drawing.Size(786, 102);
            this.tableCards.TabIndex = 0;
            // 
            // cardTotalMembers
            // 
            this.cardTotalMembers.BackColor = System.Drawing.Color.Gold;
            this.cardTotalMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalMembers.Controls.Add(this.pictureBox5);
            this.cardTotalMembers.Controls.Add(this.lblTotalMembersValue);
            this.cardTotalMembers.Controls.Add(this.lblTotalMembersTitle);
            this.cardTotalMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalMembers.Location = new System.Drawing.Point(6, 6);
            this.cardTotalMembers.Margin = new System.Windows.Forms.Padding(6);
            this.cardTotalMembers.Name = "cardTotalMembers";
            this.cardTotalMembers.Padding = new System.Windows.Forms.Padding(10);
            this.cardTotalMembers.Size = new System.Drawing.Size(184, 90);
            this.cardTotalMembers.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Client.Properties.Resources.people_16419568;
            this.pictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.InitialImage")));
            this.pictureBox5.Location = new System.Drawing.Point(133, 36);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 53);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // lblTotalMembersValue
            // 
            this.lblTotalMembersValue.AutoSize = true;
            this.lblTotalMembersValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalMembersValue.Location = new System.Drawing.Point(9, 36);
            this.lblTotalMembersValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMembersValue.Name = "lblTotalMembersValue";
            this.lblTotalMembersValue.Size = new System.Drawing.Size(35, 41);
            this.lblTotalMembersValue.TabIndex = 1;
            this.lblTotalMembersValue.Text = "0";
            // 
            // lblTotalMembersTitle
            // 
            this.lblTotalMembersTitle.AutoSize = true;
            this.lblTotalMembersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblTotalMembersTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTotalMembersTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMembersTitle.Name = "lblTotalMembersTitle";
            this.lblTotalMembersTitle.Size = new System.Drawing.Size(110, 19);
            this.lblTotalMembersTitle.TabIndex = 0;
            this.lblTotalMembersTitle.Text = "Tổng số hội viên";
            // 
            // cardNewThisMonth
            // 
            this.cardNewThisMonth.BackColor = System.Drawing.Color.Cyan;
            this.cardNewThisMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNewThisMonth.Controls.Add(this.pictureBox6);
            this.cardNewThisMonth.Controls.Add(this.lblNewThisMonthValue);
            this.cardNewThisMonth.Controls.Add(this.lblNewThisMonthTitle);
            this.cardNewThisMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardNewThisMonth.Location = new System.Drawing.Point(202, 6);
            this.cardNewThisMonth.Margin = new System.Windows.Forms.Padding(6);
            this.cardNewThisMonth.Name = "cardNewThisMonth";
            this.cardNewThisMonth.Padding = new System.Windows.Forms.Padding(10);
            this.cardNewThisMonth.Size = new System.Drawing.Size(184, 90);
            this.cardNewThisMonth.TabIndex = 1;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Client.Properties.Resources.people_16419568;
            this.pictureBox6.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.InitialImage")));
            this.pictureBox6.Location = new System.Drawing.Point(133, 36);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 53);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // lblNewThisMonthValue
            // 
            this.lblNewThisMonthValue.AutoSize = true;
            this.lblNewThisMonthValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblNewThisMonthValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblNewThisMonthValue.Location = new System.Drawing.Point(9, 36);
            this.lblNewThisMonthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewThisMonthValue.Name = "lblNewThisMonthValue";
            this.lblNewThisMonthValue.Size = new System.Drawing.Size(35, 41);
            this.lblNewThisMonthValue.TabIndex = 1;
            this.lblNewThisMonthValue.Text = "0";
            // 
            // lblNewThisMonthTitle
            // 
            this.lblNewThisMonthTitle.AutoSize = true;
            this.lblNewThisMonthTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewThisMonthTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblNewThisMonthTitle.Location = new System.Drawing.Point(10, 10);
            this.lblNewThisMonthTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewThisMonthTitle.Name = "lblNewThisMonthTitle";
            this.lblNewThisMonthTitle.Size = new System.Drawing.Size(164, 19);
            this.lblNewThisMonthTitle.TabIndex = 0;
            this.lblNewThisMonthTitle.Text = "Hội viên mới trong tháng";
            // 
            // cardExpiringSoon
            // 
            this.cardExpiringSoon.BackColor = System.Drawing.Color.Tomato;
            this.cardExpiringSoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardExpiringSoon.Controls.Add(this.pictureBox7);
            this.cardExpiringSoon.Controls.Add(this.lblExpiringSoonValue);
            this.cardExpiringSoon.Controls.Add(this.lblExpiringSoonTitle);
            this.cardExpiringSoon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardExpiringSoon.Location = new System.Drawing.Point(398, 6);
            this.cardExpiringSoon.Margin = new System.Windows.Forms.Padding(6);
            this.cardExpiringSoon.Name = "cardExpiringSoon";
            this.cardExpiringSoon.Padding = new System.Windows.Forms.Padding(10);
            this.cardExpiringSoon.Size = new System.Drawing.Size(184, 90);
            this.cardExpiringSoon.TabIndex = 2;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::Client.Properties.Resources.people_16419568;
            this.pictureBox7.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.InitialImage")));
            this.pictureBox7.Location = new System.Drawing.Point(133, 36);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 53);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // lblExpiringSoonValue
            // 
            this.lblExpiringSoonValue.AutoSize = true;
            this.lblExpiringSoonValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblExpiringSoonValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblExpiringSoonValue.Location = new System.Drawing.Point(9, 36);
            this.lblExpiringSoonValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpiringSoonValue.Name = "lblExpiringSoonValue";
            this.lblExpiringSoonValue.Size = new System.Drawing.Size(35, 41);
            this.lblExpiringSoonValue.TabIndex = 1;
            this.lblExpiringSoonValue.Text = "0";
            // 
            // lblExpiringSoonTitle
            // 
            this.lblExpiringSoonTitle.AutoSize = true;
            this.lblExpiringSoonTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExpiringSoonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblExpiringSoonTitle.Location = new System.Drawing.Point(10, 10);
            this.lblExpiringSoonTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpiringSoonTitle.Name = "lblExpiringSoonTitle";
            this.lblExpiringSoonTitle.Size = new System.Drawing.Size(135, 19);
            this.lblExpiringSoonTitle.TabIndex = 0;
            this.lblExpiringSoonTitle.Text = "Hội viên sắp hết hạn";
            // 
            // cardRevenueMonth
            // 
            this.cardRevenueMonth.BackColor = System.Drawing.Color.LightGreen;
            this.cardRevenueMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardRevenueMonth.Controls.Add(this.pictureBox8);
            this.cardRevenueMonth.Controls.Add(this.lblRevenueMonthValue);
            this.cardRevenueMonth.Controls.Add(this.lblRevenueMonthTitle);
            this.cardRevenueMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRevenueMonth.Location = new System.Drawing.Point(594, 6);
            this.cardRevenueMonth.Margin = new System.Windows.Forms.Padding(6);
            this.cardRevenueMonth.Name = "cardRevenueMonth";
            this.cardRevenueMonth.Padding = new System.Windows.Forms.Padding(10);
            this.cardRevenueMonth.Size = new System.Drawing.Size(186, 90);
            this.cardRevenueMonth.TabIndex = 3;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::Client.Properties.Resources.money_4322197;
            this.pictureBox8.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.InitialImage")));
            this.pictureBox8.Location = new System.Drawing.Point(131, 36);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 53);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 3;
            this.pictureBox8.TabStop = false;
            // 
            // lblRevenueMonthValue
            // 
            this.lblRevenueMonthValue.AutoSize = true;
            this.lblRevenueMonthValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblRevenueMonthValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblRevenueMonthValue.Location = new System.Drawing.Point(9, 36);
            this.lblRevenueMonthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRevenueMonthValue.Name = "lblRevenueMonthValue";
            this.lblRevenueMonthValue.Size = new System.Drawing.Size(62, 41);
            this.lblRevenueMonthValue.TabIndex = 1;
            this.lblRevenueMonthValue.Text = "0 đ";
            // 
            // lblRevenueMonthTitle
            // 
            this.lblRevenueMonthTitle.AutoSize = true;
            this.lblRevenueMonthTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRevenueMonthTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblRevenueMonthTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRevenueMonthTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRevenueMonthTitle.Name = "lblRevenueMonthTitle";
            this.lblRevenueMonthTitle.Size = new System.Drawing.Size(115, 19);
            this.lblRevenueMonthTitle.TabIndex = 0;
            this.lblRevenueMonthTitle.Text = "Doanh thu tháng";
            // 
            // panelChartHost
            // 
            this.panelChartHost.BackColor = System.Drawing.Color.White;
            this.panelChartHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChartHost.Controls.Add(this.chartRevenueDaily);
            this.panelChartHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartHost.Location = new System.Drawing.Point(9, 122);
            this.panelChartHost.Margin = new System.Windows.Forms.Padding(9, 0, 9, 10);
            this.panelChartHost.Name = "panelChartHost";
            this.panelChartHost.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.panelChartHost.Size = new System.Drawing.Size(786, 300);
            this.panelChartHost.TabIndex = 1;
            // 
            // chartRevenueDaily
            // 
            this.chartRevenueDaily.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chartRevenueDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRevenueDaily.Location = new System.Drawing.Point(9, 10);
            this.chartRevenueDaily.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chartRevenueDaily.Name = "chartRevenueDaily";
            this.chartRevenueDaily.Size = new System.Drawing.Size(766, 278);
            this.chartRevenueDaily.TabIndex = 0;
            this.chartRevenueDaily.Text = "chartRevenueDaily";
            // 
            // frmDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.tableRoot);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmDefault";
            this.Text = "frmDefault";
            this.Load += new System.EventHandler(this.frmDefault_Load);
            this.tableRoot.ResumeLayout(false);
            this.tableCards.ResumeLayout(false);
            this.cardTotalMembers.ResumeLayout(false);
            this.cardTotalMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.cardNewThisMonth.ResumeLayout(false);
            this.cardNewThisMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.cardExpiringSoon.ResumeLayout(false);
            this.cardExpiringSoon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.cardRevenueMonth.ResumeLayout(false);
            this.cardRevenueMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panelChartHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueDaily)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableRoot;
        private System.Windows.Forms.TableLayoutPanel tableCards;
        private System.Windows.Forms.Panel cardTotalMembers;
        private System.Windows.Forms.Label lblTotalMembersTitle;
        private System.Windows.Forms.Label lblTotalMembersValue;
        private System.Windows.Forms.Panel cardNewThisMonth;
        private System.Windows.Forms.Label lblNewThisMonthTitle;
        private System.Windows.Forms.Label lblNewThisMonthValue;
        private System.Windows.Forms.Panel cardExpiringSoon;
        private System.Windows.Forms.Label lblExpiringSoonTitle;
        private System.Windows.Forms.Label lblExpiringSoonValue;
        private System.Windows.Forms.Panel cardRevenueMonth;
        private System.Windows.Forms.Label lblRevenueMonthTitle;
        private System.Windows.Forms.Label lblRevenueMonthValue;
        private System.Windows.Forms.Panel panelChartHost;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueDaily;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}