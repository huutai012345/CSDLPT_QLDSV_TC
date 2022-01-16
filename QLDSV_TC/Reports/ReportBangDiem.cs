using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC.Reports
{
    public partial class ReportBangDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportBangDiem()
        {
            InitializeComponent();
        }

        public ReportBangDiem(string NK, int HK, string maMH, string tenMN, int nhom)
        {
            InitializeComponent();

            lbNK.Text = "Niên Khóa: " + NK;
            lbHK.Text = "Học Kì: " + HK;
            lbKhoa.Text = "Khoa: " + Program.maKhoa;
            lbMH.Text = "Môn Học: " + tenMN;
            lbNhom.Text = "Nhóm: " + nhom;

            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = NK;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = HK;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = nhom;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = maMH;
            this.sqlDataSource1.Fill();
        }
    }
}
