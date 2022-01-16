using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC.Reports
{
    public partial class ReportDSLTC : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportDSLTC()
        {
            InitializeComponent();
        }

        public ReportDSLTC(string NK, int HK)
        {
            InitializeComponent();

            lbNK.Text = "Niên Khóa: " + NK;
            lbHK.Text = "Học Kì: " + HK;
            lbKhoa.Text = "Khoa: " + Program.maKhoa;

            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = NK;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = HK;
            this.sqlDataSource1.Fill();
        }

    }
}
