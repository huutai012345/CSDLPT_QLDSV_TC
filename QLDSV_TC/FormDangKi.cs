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

namespace QLDSV_TC
{
    public partial class FormDangKi : Form
    {
        private string maSV;

        public FormDangKi()
        {
            InitializeComponent();

            this.btnSave.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils.getListNKLopTC(this.cmbNK);

            this.cmbNK.SelectedIndex = 0;
            this.cmbHK.SelectedIndex = 0;
        }

        private void refesh()
        {
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_DS_LTC_DANGKY, cmbNK.Text,int.Parse(cmbHK.Text), this.maSV);
            this.btnSave.Enabled = false;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn ghi điểm", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MALTC", typeof(int));
                dt.Columns.Add("MASV", typeof(string));
                dt.Columns.Add("DANGKY", typeof(bool));
              

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool isDK = bool.Parse(gridView1.GetRowCellValue(i, "DADK").ToString().Trim());
                    string maLTC = gridView1.GetRowCellValue(i, "MALTC").ToString().Trim();
                    dt.Rows.Add(this.maSV, maLTC, isDK);
                }

               
                MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                this.btnSave.Enabled = false;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.refesh();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLaySV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (maSV == "")
            {
                MessageBox.Show("Mã Sinh Viên Không Hợp Lệ", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }

            if(Utils.getListTTSV(maSV, this.txtTen, this.txtLop))
            {
                panel2.Visible = true;
                this.maSV = maSV;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_DS_LTC_DANGKY, cmbNK.Text, int.Parse(cmbHK.Text), this.maSV);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
