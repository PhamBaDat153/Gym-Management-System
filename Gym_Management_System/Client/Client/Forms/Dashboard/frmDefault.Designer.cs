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
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tableCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotalMembers = new System.Windows.Forms.Panel();
            this.lblTotalMembersValue = new System.Windows.Forms.Label();
            this.lblTotalMembersTitle = new System.Windows.Forms.Label();
            this.cardNewThisMonth = new System.Windows.Forms.Panel();
            this.lblNewThisMonthValue = new System.Windows.Forms.Label();
            this.lblNewThisMonthTitle = new System.Windows.Forms.Label();
            this.cardExpiringSoon = new System.Windows.Forms.Panel();
            this.lblExpiringSoonValue = new System.Windows.Forms.Label();
            this.lblExpiringSoonTitle = new System.Windows.Forms.Label();
            this.cardRevenueMonth = new System.Windows.Forms.Panel();
            this.lblRevenueMonthValue = new System.Windows.Forms.Label();
            this.lblRevenueMonthTitle = new System.Windows.Forms.Label();
            this.panelChartHost = new System.Windows.Forms.Panel();
            this.chartRevenueDaily = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tableRoot.SuspendLayout();
            this.tableCards.SuspendLayout();
            this.cardTotalMembers.SuspendLayout();
            this.cardNewThisMonth.SuspendLayout();
            this.cardExpiringSoon.SuspendLayout();
            this.cardRevenueMonth.SuspendLayout();
            this.panelChartHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.tableRoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableRoot.Name = "tableRoot";
            this.tableRoot.RowCount = 2;
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRoot.Size = new System.Drawing.Size(2540, 1384);
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
            this.tableCards.Location = new System.Drawing.Point(18, 19);
            this.tableCards.Margin = new System.Windows.Forms.Padding(18, 19, 18, 19);
            this.tableCards.Name = "tableCards";
            this.tableCards.RowCount = 1;
            this.tableCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCards.Size = new System.Drawing.Size(2504, 196);
            this.tableCards.TabIndex = 0;
            // 
            // cardTotalMembers
            // 
            this.cardTotalMembers.BackColor = System.Drawing.Color.Gold;
            this.cardTotalMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalMembers.Controls.Add(this.pictureBox1);
            this.cardTotalMembers.Controls.Add(this.lblTotalMembersValue);
            this.cardTotalMembers.Controls.Add(this.lblTotalMembersTitle);
            this.cardTotalMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalMembers.Location = new System.Drawing.Point(12, 12);
            this.cardTotalMembers.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.cardTotalMembers.Name = "cardTotalMembers";
            this.cardTotalMembers.Padding = new System.Windows.Forms.Padding(21, 19, 21, 19);
            this.cardTotalMembers.Size = new System.Drawing.Size(602, 172);
            this.cardTotalMembers.TabIndex = 0;
            // 
            // lblTotalMembersValue
            // 
            this.lblTotalMembersValue.AutoSize = true;
            this.lblTotalMembersValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalMembersValue.Location = new System.Drawing.Point(18, 69);
            this.lblTotalMembersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMembersValue.Name = "lblTotalMembersValue";
            this.lblTotalMembersValue.Size = new System.Drawing.Size(67, 78);
            this.lblTotalMembersValue.TabIndex = 1;
            this.lblTotalMembersValue.Text = "0";
            // 
            // lblTotalMembersTitle
            // 
            this.lblTotalMembersTitle.AutoSize = true;
            this.lblTotalMembersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblTotalMembersTitle.Location = new System.Drawing.Point(21, 19);
            this.lblTotalMembersTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMembersTitle.Name = "lblTotalMembersTitle";
            this.lblTotalMembersTitle.Size = new System.Drawing.Size(213, 37);
            this.lblTotalMembersTitle.TabIndex = 0;
            this.lblTotalMembersTitle.Text = "Tổng số hội viên";
            // 
            // cardNewThisMonth
            // 
            this.cardNewThisMonth.BackColor = System.Drawing.Color.Cyan;
            this.cardNewThisMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNewThisMonth.Controls.Add(this.pictureBox2);
            this.cardNewThisMonth.Controls.Add(this.lblNewThisMonthValue);
            this.cardNewThisMonth.Controls.Add(this.lblNewThisMonthTitle);
            this.cardNewThisMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardNewThisMonth.Location = new System.Drawing.Point(638, 12);
            this.cardNewThisMonth.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.cardNewThisMonth.Name = "cardNewThisMonth";
            this.cardNewThisMonth.Padding = new System.Windows.Forms.Padding(21, 19, 21, 19);
            this.cardNewThisMonth.Size = new System.Drawing.Size(602, 172);
            this.cardNewThisMonth.TabIndex = 1;
            // 
            // lblNewThisMonthValue
            // 
            this.lblNewThisMonthValue.AutoSize = true;
            this.lblNewThisMonthValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblNewThisMonthValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblNewThisMonthValue.Location = new System.Drawing.Point(18, 69);
            this.lblNewThisMonthValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewThisMonthValue.Name = "lblNewThisMonthValue";
            this.lblNewThisMonthValue.Size = new System.Drawing.Size(67, 78);
            this.lblNewThisMonthValue.TabIndex = 1;
            this.lblNewThisMonthValue.Text = "0";
            // 
            // lblNewThisMonthTitle
            // 
            this.lblNewThisMonthTitle.AutoSize = true;
            this.lblNewThisMonthTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewThisMonthTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblNewThisMonthTitle.Location = new System.Drawing.Point(21, 19);
            this.lblNewThisMonthTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewThisMonthTitle.Name = "lblNewThisMonthTitle";
            this.lblNewThisMonthTitle.Size = new System.Drawing.Size(316, 37);
            this.lblNewThisMonthTitle.TabIndex = 0;
            this.lblNewThisMonthTitle.Text = "Hội viên mới trong tháng";
            // 
            // cardExpiringSoon
            // 
            this.cardExpiringSoon.BackColor = System.Drawing.Color.Tomato;
            this.cardExpiringSoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardExpiringSoon.Controls.Add(this.pictureBox4);
            this.cardExpiringSoon.Controls.Add(this.lblExpiringSoonValue);
            this.cardExpiringSoon.Controls.Add(this.lblExpiringSoonTitle);
            this.cardExpiringSoon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardExpiringSoon.Location = new System.Drawing.Point(1264, 12);
            this.cardExpiringSoon.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.cardExpiringSoon.Name = "cardExpiringSoon";
            this.cardExpiringSoon.Padding = new System.Windows.Forms.Padding(21, 19, 21, 19);
            this.cardExpiringSoon.Size = new System.Drawing.Size(602, 172);
            this.cardExpiringSoon.TabIndex = 2;
            // 
            // lblExpiringSoonValue
            // 
            this.lblExpiringSoonValue.AutoSize = true;
            this.lblExpiringSoonValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblExpiringSoonValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblExpiringSoonValue.Location = new System.Drawing.Point(18, 69);
            this.lblExpiringSoonValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiringSoonValue.Name = "lblExpiringSoonValue";
            this.lblExpiringSoonValue.Size = new System.Drawing.Size(67, 78);
            this.lblExpiringSoonValue.TabIndex = 1;
            this.lblExpiringSoonValue.Text = "0";
            // 
            // lblExpiringSoonTitle
            // 
            this.lblExpiringSoonTitle.AutoSize = true;
            this.lblExpiringSoonTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExpiringSoonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblExpiringSoonTitle.Location = new System.Drawing.Point(21, 19);
            this.lblExpiringSoonTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiringSoonTitle.Name = "lblExpiringSoonTitle";
            this.lblExpiringSoonTitle.Size = new System.Drawing.Size(259, 37);
            this.lblExpiringSoonTitle.TabIndex = 0;
            this.lblExpiringSoonTitle.Text = "Hội viên sắp hết hạn";
            // 
            // cardRevenueMonth
            // 
            this.cardRevenueMonth.BackColor = System.Drawing.Color.LightGreen;
            this.cardRevenueMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardRevenueMonth.Controls.Add(this.pictureBox3);
            this.cardRevenueMonth.Controls.Add(this.lblRevenueMonthValue);
            this.cardRevenueMonth.Controls.Add(this.lblRevenueMonthTitle);
            this.cardRevenueMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRevenueMonth.Location = new System.Drawing.Point(1890, 12);
            this.cardRevenueMonth.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.cardRevenueMonth.Name = "cardRevenueMonth";
            this.cardRevenueMonth.Padding = new System.Windows.Forms.Padding(21, 19, 21, 19);
            this.cardRevenueMonth.Size = new System.Drawing.Size(602, 172);
            this.cardRevenueMonth.TabIndex = 3;
            // 
            // lblRevenueMonthValue
            // 
            this.lblRevenueMonthValue.AutoSize = true;
            this.lblRevenueMonthValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblRevenueMonthValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblRevenueMonthValue.Location = new System.Drawing.Point(18, 69);
            this.lblRevenueMonthValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueMonthValue.Name = "lblRevenueMonthValue";
            this.lblRevenueMonthValue.Size = new System.Drawing.Size(120, 78);
            this.lblRevenueMonthValue.TabIndex = 1;
            this.lblRevenueMonthValue.Text = "0 đ";
            // 
            // lblRevenueMonthTitle
            // 
            this.lblRevenueMonthTitle.AutoSize = true;
            this.lblRevenueMonthTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRevenueMonthTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(64)))), ((int)(((byte)(98)))));
            this.lblRevenueMonthTitle.Location = new System.Drawing.Point(21, 19);
            this.lblRevenueMonthTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueMonthTitle.Name = "lblRevenueMonthTitle";
            this.lblRevenueMonthTitle.Size = new System.Drawing.Size(218, 37);
            this.lblRevenueMonthTitle.TabIndex = 0;
            this.lblRevenueMonthTitle.Text = "Doanh thu tháng";
            // 
            // panelChartHost
            // 
            this.panelChartHost.BackColor = System.Drawing.Color.White;
            this.panelChartHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChartHost.Controls.Add(this.chartRevenueDaily);
            this.panelChartHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartHost.Location = new System.Drawing.Point(18, 234);
            this.panelChartHost.Margin = new System.Windows.Forms.Padding(18, 0, 18, 19);
            this.panelChartHost.Name = "panelChartHost";
            this.panelChartHost.Padding = new System.Windows.Forms.Padding(18, 19, 18, 19);
            this.panelChartHost.Size = new System.Drawing.Size(2504, 1131);
            this.panelChartHost.TabIndex = 1;
            // 
            // chartRevenueDaily
            // 
            this.chartRevenueDaily.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chartRevenueDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRevenueDaily.Location = new System.Drawing.Point(18, 19);
            this.chartRevenueDaily.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartRevenueDaily.Name = "chartRevenueDaily";
            this.chartRevenueDaily.Size = new System.Drawing.Size(2466, 1091);
            this.chartRevenueDaily.TabIndex = 0;
            this.chartRevenueDaily.Text = "chartRevenueDaily";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Client.Properties.Resources.Screenshot_2026_04_20_223302;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(450, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 125);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Client.Properties.Resources.Screenshot_2026_04_20_223302;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(450, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 125);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Client.Properties.Resources.Screenshot_2026_04_20_223302;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(450, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(126, 125);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Client.Properties.Resources.Screenshot_2026_04_20_223801;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(450, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(126, 125);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // frmDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2540, 1384);
            this.Controls.Add(this.tableRoot);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDefault";
            this.Text = "frmDefault";
            this.Load += new System.EventHandler(this.frmDefault_Load);
            this.tableRoot.ResumeLayout(false);
            this.tableCards.ResumeLayout(false);
            this.cardTotalMembers.ResumeLayout(false);
            this.cardTotalMembers.PerformLayout();
            this.cardNewThisMonth.ResumeLayout(false);
            this.cardNewThisMonth.PerformLayout();
            this.cardExpiringSoon.ResumeLayout(false);
            this.cardExpiringSoon.PerformLayout();
            this.cardRevenueMonth.ResumeLayout(false);
            this.cardRevenueMonth.PerformLayout();
            this.panelChartHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}