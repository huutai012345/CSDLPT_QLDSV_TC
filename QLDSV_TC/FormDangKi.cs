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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(this.saveDK() && this.saveDADK())
                {
                    MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                    gcDK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text), false);
                    gcDADK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text), true);
                    this.btnSave.Enabled = false;
                }
            }
        }

        private bool saveDK()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DANGKY", typeof(bool));
            dt.Columns.Add("HUYDANGKY", typeof(bool));

            for (int i = 0; i < gvDK.RowCount; i++)
            {
                bool isDK = bool.Parse(gvDK.GetRowCellValue(i, "DANGKY").ToString().Trim());
                if (isDK)
                {
                    string maLTC = gvDK.GetRowCellValue(i, "MALTC").ToString().Trim();
                    dt.Rows.Add(maLTC, this.maSV, true, false);
                }
            }

            return Utils.dangKy(dt);
        }

        private bool saveDADK()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DANGKY", typeof(bool));
            dt.Columns.Add("HUYDANGKY", typeof(bool));

            for (int i = 0; i < gvDADK.RowCount; i++)
            {
                bool isDK = bool.Parse(gvDADK.GetRowCellValue(i, "DANGKY").ToString().Trim());
                if (!isDK)
                {
                    string maLTC = gvDADK.GetRowCellValue(i, "MALTC").ToString().Trim();
                    dt.Rows.Add(maLTC, this.maSV, false, true);
                }
            }

            return Utils.dangKy(dt);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            gcDK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text),false);
            gcDADK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text), true);
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gvDK.Columns["DANGKY"])
            {
                btnSave.Enabled = true;
            }
        }

        private void gvDADK_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gvDADK.Columns["DANGKY"])
            {
                btnSave.Enabled = true;
            }
        }
    }
}
