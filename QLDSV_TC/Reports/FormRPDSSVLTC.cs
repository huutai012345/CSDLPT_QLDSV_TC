using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_TC.Validate;

namespace QLDSV_TC.Reports
{
    public partial class FormRPDSSVLTC : Form
    {
        public FormRPDSSVLTC()
        {
            InitializeComponent();
            if (Program.mGroup != Program.nhomQuyen[0])
            {
                this.panel1.Visible = false;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!ValidateRP.validate(txtNhom))
            {
                return;
            }

            ReportDSSVLTC rp = new ReportDSSVLTC(cmbNK.Text,int.Parse(cmbHK.Text),cmbMaMonHoc.SelectedValue.ToString(),cmbMaMonHoc.Text,int.Parse(txtNhom.Text));
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }

        private void FormRPDSSVLTC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.qLDSV_TCDataSet.MONHOC);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);

            cmbMaMonHoc.SelectedIndex = 0;
            cmbNK.SelectedIndex = 0;
            cmbHK.SelectedIndex = 0;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue != null)
            {
                Program.servername = cmbKhoa.SelectedValue.ToString();
                Program.maKhoa = cmbKhoa.Text;

                if (cmbKhoa.SelectedIndex != Program.mChinhanh)
                {
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                }
                else
                {
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                }

                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Loi");
                }
            }
        }
    }
}
