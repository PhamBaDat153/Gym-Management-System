namespace Client.Forms.ScheduleManage
{
    partial class frmSchedule
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
            this.rdoKichHoat = new System.Windows.Forms.RadioButton();
            this.rdoChuaKichHoat = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTrainer = new System.Windows.Forms.ComboBox();
            this.txtScheduleId = new System.Windows.Forms.TextBox();
            this.dgvScheduleManage = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleManage)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoKichHoat
            // 
            this.rdoKichHoat.AutoSize = true;
            this.rdoKichHoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoKichHoat.Location = new System.Drawing.Point(345, 552);
            this.rdoKichHoat.Name = "rdoKichHoat";
            this.rdoKichHoat.Size = new System.Drawing.Size(142, 22);
            this.rdoKichHoat.TabIndex = 43;
            this.rdoKichHoat.TabStop = true;
            this.rdoKichHoat.Text = "ĐÃ KÍCH HOẠT";
            this.rdoKichHoat.UseVisualStyleBackColor = true;
            // 
            // rdoChuaKichHoat
            // 
            this.rdoChuaKichHoat.AutoSize = true;
            this.rdoChuaKichHoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChuaKichHoat.Location = new System.Drawing.Point(345, 580);
            this.rdoChuaKichHoat.Name = "rdoChuaKichHoat";
            this.rdoChuaKichHoat.Size = new System.Drawing.Size(166, 22);
            this.rdoChuaKichHoat.TabIndex = 42;
            this.rdoChuaKichHoat.TabStop = true;
            this.rdoChuaKichHoat.Text = "CHƯA KÍCH HOẠT";
            this.rdoChuaKichHoat.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(176, 552);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Giờ kết thúc";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndTime.Location = new System.Drawing.Point(345, 517);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(100, 26);
            this.txtEndTime.TabIndex = 39;
            // 
            // cmbMember
            // 
            this.cmbMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(345, 387);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(261, 28);
            this.cmbMember.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Chọn hội viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(176, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Mã lịch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Giờ bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Chọn ngày tập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Chọn Huấn luyện viên";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(204, 627);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 34);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(408, 627);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 34);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Cập nhập";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(306, 627);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 34);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(510, 627);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 34);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(345, 485);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 26);
            this.txtTime.TabIndex = 28;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(345, 453);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(261, 26);
            this.dtpDate.TabIndex = 27;
            // 
            // cmbTrainer
            // 
            this.cmbTrainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrainer.FormattingEnabled = true;
            this.cmbTrainer.Location = new System.Drawing.Point(345, 419);
            this.cmbTrainer.Name = "cmbTrainer";
            this.cmbTrainer.Size = new System.Drawing.Size(261, 28);
            this.cmbTrainer.TabIndex = 26;
            // 
            // txtScheduleId
            // 
            this.txtScheduleId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScheduleId.Location = new System.Drawing.Point(345, 356);
            this.txtScheduleId.Name = "txtScheduleId";
            this.txtScheduleId.ReadOnly = true;
            this.txtScheduleId.Size = new System.Drawing.Size(261, 26);
            this.txtScheduleId.TabIndex = 25;
            // 
            // dgvScheduleManage
            // 
            this.dgvScheduleManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScheduleManage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScheduleManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvScheduleManage.Location = new System.Drawing.Point(12, 65);
            this.dgvScheduleManage.Name = "dgvScheduleManage";
            this.dgvScheduleManage.Size = new System.Drawing.Size(826, 270);
            this.dgvScheduleManage.TabIndex = 24;
            this.dgvScheduleManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScheduleManage_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(318, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "quản lý lịch tập";
            // 
            // frmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 695);
            this.Controls.Add(this.rdoKichHoat);
            this.Controls.Add(this.rdoChuaKichHoat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbTrainer);
            this.Controls.Add(this.txtScheduleId);
            this.Controls.Add(this.dgvScheduleManage);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSchedule";
            this.Text = "frmSchedule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleManage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoKichHoat;
        private System.Windows.Forms.RadioButton rdoChuaKichHoat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbTrainer;
        private System.Windows.Forms.TextBox txtScheduleId;
        private System.Windows.Forms.DataGridView dgvScheduleManage;
        private System.Windows.Forms.Label label9;
    }
}