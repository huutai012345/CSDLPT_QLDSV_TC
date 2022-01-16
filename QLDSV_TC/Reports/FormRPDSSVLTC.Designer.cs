
namespace QLDSV_TC.Reports
{
    partial class FormRPDSSVLTC
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
            System.Windows.Forms.Label hOCKYLabel;
            System.Windows.Forms.Label nIENKHOALabel;
            System.Windows.Forms.Label nHOMLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNhom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaMonHoc = new System.Windows.Forms.ComboBox();
            this.mONHOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSV_TCDataSet = new QLDSV_TC.QLDSV_TCDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tENCNLabel = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.vDSKHOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSVTCDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSV_TCDataSet1 = new QLDSV_TC.QLDSV_TCDataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbNK = new System.Windows.Forms.ComboBox();
            this.cmbHK = new System.Windows.Forms.ComboBox();
            this.v_DS_KHOATableAdapter = new QLDSV_TC.QLDSV_TCDataSet1TableAdapters.V_DS_KHOATableAdapter();
            this.mONHOCTableAdapter = new QLDSV_TC.QLDSV_TCDataSetTableAdapters.MONHOCTableAdapter();
            hOCKYLabel = new System.Windows.Forms.Label();
            nIENKHOALabel = new System.Windows.Forms.Label();
            nHOMLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vDSKHOABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVTCDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // hOCKYLabel
            // 
            hOCKYLabel.AutoSize = true;
            hOCKYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hOCKYLabel.Location = new System.Drawing.Point(30, 225);
            hOCKYLabel.Name = "hOCKYLabel";
            hOCKYLabel.Size = new System.Drawing.Size(63, 20);
            hOCKYLabel.TabIndex = 39;
            hOCKYLabel.Text = "Học Kỳ:";
            // 
            // nIENKHOALabel
            // 
            nIENKHOALabel.AutoSize = true;
            nIENKHOALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nIENKHOALabel.Location = new System.Drawing.Point(30, 184);
            nIENKHOALabel.Name = "nIENKHOALabel";
            nIENKHOALabel.Size = new System.Drawing.Size(86, 20);
            nIENKHOALabel.TabIndex = 38;
            nIENKHOALabel.Text = "Niên Khóa:";
            // 
            // nHOMLabel
            // 
            nHOMLabel.AutoSize = true;
            nHOMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nHOMLabel.Location = new System.Drawing.Point(359, 225);
            nHOMLabel.Name = "nHOMLabel";
            nHOMLabel.Size = new System.Drawing.Size(55, 20);
            nHOMLabel.TabIndex = 1015;
            nHOMLabel.Text = "Nhóm:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(nHOMLabel);
            this.groupBox1.Controls.Add(this.txtNhom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMaMonHoc);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.cmbNK);
            this.groupBox1.Controls.Add(this.cmbHK);
            this.groupBox1.Controls.Add(hOCKYLabel);
            this.groupBox1.Controls.Add(nIENKHOALabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 366);
            this.groupBox1.TabIndex = 1002;
            this.groupBox1.TabStop = false;
            // 
            // txtNhom
            // 
            this.txtNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhom.Location = new System.Drawing.Point(468, 227);
            this.txtNhom.Name = "txtNhom";
            this.txtNhom.Size = new System.Drawing.Size(174, 26);
            this.txtNhom.TabIndex = 1016;
            this.txtNhom.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1014;
            this.label2.Text = "Mã Môn Học:";
            // 
            // cmbMaMonHoc
            // 
            this.cmbMaMonHoc.DataSource = this.mONHOCBindingSource;
            this.cmbMaMonHoc.DisplayMember = "TENMH";
            this.cmbMaMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaMonHoc.FormattingEnabled = true;
            this.cmbMaMonHoc.Location = new System.Drawing.Point(468, 184);
            this.cmbMaMonHoc.Name = "cmbMaMonHoc";
            this.cmbMaMonHoc.Size = new System.Drawing.Size(174, 28);
            this.cmbMaMonHoc.TabIndex = 1013;
            this.cmbMaMonHoc.ValueMember = "MAMH";
            // 
            // mONHOCBindingSource
            // 
            this.mONHOCBindingSource.DataMember = "MONHOC";
            this.mONHOCBindingSource.DataSource = this.qLDSV_TCDataSet;
            // 
            // qLDSV_TCDataSet
            // 
            this.qLDSV_TCDataSet.DataSetName = "QLDSV_TCDataSet";
            this.qLDSV_TCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tENCNLabel);
            this.panel1.Controls.Add(this.cmbKhoa);
            this.panel1.Location = new System.Drawing.Point(25, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 60);
            this.panel1.TabIndex = 1012;
            // 
            // tENCNLabel
            // 
            this.tENCNLabel.AutoSize = true;
            this.tENCNLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tENCNLabel.Location = new System.Drawing.Point(5, 15);
            this.tENCNLabel.Name = "tENCNLabel";
            this.tENCNLabel.Size = new System.Drawing.Size(54, 21);
            this.tENCNLabel.TabIndex = 0;
            this.tENCNLabel.Text = "Khoa:";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DataSource = this.vDSKHOABindingSource;
            this.cmbKhoa.DisplayMember = "TENCN";
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(107, 15);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(174, 28);
            this.cmbKhoa.TabIndex = 1;
            this.cmbKhoa.ValueMember = "TENSERVER";
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // vDSKHOABindingSource
            // 
            this.vDSKHOABindingSource.DataMember = "V_DS_KHOA";
            this.vDSKHOABindingSource.DataSource = this.qLDSVTCDataSet1BindingSource;
            // 
            // qLDSVTCDataSet1BindingSource
            // 
            this.qLDSVTCDataSet1BindingSource.DataSource = this.qLDSV_TCDataSet1;
            this.qLDSVTCDataSet1BindingSource.Position = 0;
            // 
            // qLDSV_TCDataSet1
            // 
            this.qLDSV_TCDataSet1.DataSetName = "QLDSV_TCDataSet1";
            this.qLDSV_TCDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(46, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 31);
            this.label1.TabIndex = 1009;
            this.label1.Text = "Danh Sách Sinh Viên Lớp Tín Chỉ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(364, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 41);
            this.btnClose.TabIndex = 1008;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(244, 290);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(98, 41);
            this.btnXem.TabIndex = 1007;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbNK
            // 
            this.cmbNK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNK.FormattingEnabled = true;
            this.cmbNK.Items.AddRange(new object[] {
            "2012-2013",
            "2013-2014",
            "2014-2015",
            "2015-2016",
            "2016-2017",
            "2017-2018",
            "2018-2019",
            "2019-2020",
            "2020-2021",
            "2021-2022",
            "2022-2023"});
            this.cmbNK.Location = new System.Drawing.Point(132, 181);
            this.cmbNK.Name = "cmbNK";
            this.cmbNK.Size = new System.Drawing.Size(174, 28);
            this.cmbNK.TabIndex = 48;
            // 
            // cmbHK
            // 
            this.cmbHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHK.FormattingEnabled = true;
            this.cmbHK.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbHK.Location = new System.Drawing.Point(132, 225);
            this.cmbHK.Name = "cmbHK";
            this.cmbHK.Size = new System.Drawing.Size(174, 28);
            this.cmbHK.TabIndex = 47;
            // 
            // v_DS_KHOATableAdapter
            // 
            this.v_DS_KHOATableAdapter.ClearBeforeFill = true;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // FormRPDSSVLTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 661);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRPDSSVLTC";
            this.Text = "Danh sách sinh viên lớp tín chỉ";
            this.Load += new System.EventHandler(this.FormRPDSSVLTC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vDSKHOABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVTCDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSV_TCDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbNK;
        private System.Windows.Forms.ComboBox cmbHK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tENCNLabel;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.BindingSource qLDSVTCDataSet1BindingSource;
        private QLDSV_TCDataSet1 qLDSV_TCDataSet1;
        private System.Windows.Forms.BindingSource vDSKHOABindingSource;
        private QLDSV_TCDataSet1TableAdapters.V_DS_KHOATableAdapter v_DS_KHOATableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMaMonHoc;
        private System.Windows.Forms.TextBox txtNhom;
        private QLDSV_TCDataSet qLDSV_TCDataSet;
        private System.Windows.Forms.BindingSource mONHOCBindingSource;
        private QLDSV_TCDataSetTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
    }
}