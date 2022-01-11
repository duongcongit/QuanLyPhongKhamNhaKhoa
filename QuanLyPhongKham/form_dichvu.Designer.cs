namespace QuanLyPhongKham
{
    partial class form_dichvu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_dichvu));
            this.label3 = new System.Windows.Forms.Label();
            this.lb_madichvu = new System.Windows.Forms.Label();
            this.dataview_hoadon_dichvu = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_xoadichvu = new System.Windows.Forms.Button();
            this.btn_suadichvu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_sohoadon_dichvu = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lb_mathietbi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_mota = new System.Windows.Forms.Label();
            this.lbbacssi = new System.Windows.Forms.Label();
            this.lb_tendichvu = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_tenthietbi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_dongia = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataview_hoadon_dichvu)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hóa đơn có sử dụng";
            // 
            // lb_madichvu
            // 
            this.lb_madichvu.AutoSize = true;
            this.lb_madichvu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_madichvu.Location = new System.Drawing.Point(177, 81);
            this.lb_madichvu.Name = "lb_madichvu";
            this.lb_madichvu.Size = new System.Drawing.Size(14, 15);
            this.lb_madichvu.TabIndex = 94;
            this.lb_madichvu.Text = "0";
            // 
            // dataview_hoadon_dichvu
            // 
            this.dataview_hoadon_dichvu.AllowUserToAddRows = false;
            this.dataview_hoadon_dichvu.AllowUserToDeleteRows = false;
            this.dataview_hoadon_dichvu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataview_hoadon_dichvu.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataview_hoadon_dichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataview_hoadon_dichvu.Location = new System.Drawing.Point(-1, 33);
            this.dataview_hoadon_dichvu.Name = "dataview_hoadon_dichvu";
            this.dataview_hoadon_dichvu.ReadOnly = true;
            this.dataview_hoadon_dichvu.Size = new System.Drawing.Size(1132, 381);
            this.dataview_hoadon_dichvu.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "edit.ico");
            this.imageList1.Images.SetKeyName(1, "edit_delete.ico");
            // 
            // btn_xoadichvu
            // 
            this.btn_xoadichvu.ImageIndex = 1;
            this.btn_xoadichvu.ImageList = this.imageList1;
            this.btn_xoadichvu.Location = new System.Drawing.Point(907, 192);
            this.btn_xoadichvu.Name = "btn_xoadichvu";
            this.btn_xoadichvu.Size = new System.Drawing.Size(162, 62);
            this.btn_xoadichvu.TabIndex = 84;
            this.btn_xoadichvu.Text = "Xóa dịch vụ";
            this.btn_xoadichvu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_xoadichvu.UseVisualStyleBackColor = true;
            // 
            // btn_suadichvu
            // 
            this.btn_suadichvu.Enabled = false;
            this.btn_suadichvu.ImageIndex = 0;
            this.btn_suadichvu.ImageList = this.imageList1;
            this.btn_suadichvu.Location = new System.Drawing.Point(907, 57);
            this.btn_suadichvu.Name = "btn_suadichvu";
            this.btn_suadichvu.Size = new System.Drawing.Size(162, 62);
            this.btn_suadichvu.TabIndex = 83;
            this.btn_suadichvu.Text = "Sửa thông tin dịch vụ";
            this.btn_suadichvu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_suadichvu.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataview_hoadon_dichvu);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(9, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1132, 415);
            this.panel3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "Số hóa đơn có sử dụng";
            // 
            // lb_sohoadon_dichvu
            // 
            this.lb_sohoadon_dichvu.AutoSize = true;
            this.lb_sohoadon_dichvu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sohoadon_dichvu.Location = new System.Drawing.Point(607, 175);
            this.lb_sohoadon_dichvu.Name = "lb_sohoadon_dichvu";
            this.lb_sohoadon_dichvu.Size = new System.Drawing.Size(14, 15);
            this.lb_sohoadon_dichvu.TabIndex = 74;
            this.lb_sohoadon_dichvu.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(33, 81);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 93;
            this.label16.Text = "Mã dịch vụ";
            // 
            // lb_mathietbi
            // 
            this.lb_mathietbi.AutoSize = true;
            this.lb_mathietbi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mathietbi.Location = new System.Drawing.Point(607, 81);
            this.lb_mathietbi.Name = "lb_mathietbi";
            this.lb_mathietbi.Size = new System.Drawing.Size(14, 15);
            this.lb_mathietbi.TabIndex = 92;
            this.lb_mathietbi.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 78;
            this.label1.Text = "Thông tin dịch vụ";
            // 
            // lb_mota
            // 
            this.lb_mota.AutoSize = true;
            this.lb_mota.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mota.Location = new System.Drawing.Point(177, 216);
            this.lb_mota.Name = "lb_mota";
            this.lb_mota.Size = new System.Drawing.Size(14, 15);
            this.lb_mota.TabIndex = 91;
            this.lb_mota.Text = "0";
            // 
            // lbbacssi
            // 
            this.lbbacssi.AutoSize = true;
            this.lbbacssi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbacssi.Location = new System.Drawing.Point(33, 215);
            this.lbbacssi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbbacssi.Name = "lbbacssi";
            this.lbbacssi.Size = new System.Drawing.Size(40, 16);
            this.lbbacssi.TabIndex = 82;
            this.lbbacssi.Text = "Mô tả";
            // 
            // lb_tendichvu
            // 
            this.lb_tendichvu.AutoSize = true;
            this.lb_tendichvu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tendichvu.Location = new System.Drawing.Point(177, 133);
            this.lb_tendichvu.Name = "lb_tendichvu";
            this.lb_tendichvu.Size = new System.Drawing.Size(14, 15);
            this.lb_tendichvu.TabIndex = 89;
            this.lb_tendichvu.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 133);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 80;
            this.label10.Text = "Tên dịch vụ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 79;
            this.label8.Text = "Đơn giá";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lb_tenthietbi);
            this.panel1.Controls.Add(this.lb_sohoadon_dichvu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_xoadichvu);
            this.panel1.Controls.Add(this.lb_madichvu);
            this.panel1.Controls.Add(this.btn_suadichvu);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lb_mathietbi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_mota);
            this.panel1.Controls.Add(this.lbbacssi);
            this.panel1.Controls.Add(this.lb_tendichvu);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lb_dongia);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 305);
            this.panel1.TabIndex = 9;
            // 
            // lb_tenthietbi
            // 
            this.lb_tenthietbi.AutoSize = true;
            this.lb_tenthietbi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tenthietbi.Location = new System.Drawing.Point(607, 123);
            this.lb_tenthietbi.Name = "lb_tenthietbi";
            this.lb_tenthietbi.Size = new System.Drawing.Size(14, 15);
            this.lb_tenthietbi.TabIndex = 101;
            this.lb_tenthietbi.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(451, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 100;
            this.label5.Text = "Tên thiết bị";
            // 
            // lb_dongia
            // 
            this.lb_dongia.AutoSize = true;
            this.lb_dongia.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dongia.Location = new System.Drawing.Point(177, 176);
            this.lb_dongia.Name = "lb_dongia";
            this.lb_dongia.Size = new System.Drawing.Size(14, 15);
            this.lb_dongia.TabIndex = 88;
            this.lb_dongia.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(455, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 86;
            this.label6.Text = "Mã thiết bi";
            // 
            // form_dichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1153, 742);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_dichvu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin dịch vụ";
            this.Load += new System.EventHandler(this.form_dichvu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataview_hoadon_dichvu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_madichvu;
        private System.Windows.Forms.DataGridView dataview_hoadon_dichvu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_xoadichvu;
        private System.Windows.Forms.Button btn_suadichvu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_sohoadon_dichvu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lb_mathietbi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_mota;
        private System.Windows.Forms.Label lbbacssi;
        private System.Windows.Forms.Label lb_tendichvu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_dongia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_tenthietbi;
        private System.Windows.Forms.Label label5;
    }
}