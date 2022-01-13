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
        private string NK;
        private int HK;

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
            this.NK = cmbNK.Text;
            this.HK = int.Parse(cmbHK.Text);

            gcDK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text),false);
            gcDADK.DataSource = Utils.getListLTCDK(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text), true);
        }

        private void gvDK_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool value = bool.Parse(gvDK.GetRowCellValue(e.RowHandle, "DANGKY").ToString());
            if (e.Column == gvDK.Columns["DANGKY"] && value)
            {
                string maMH = gvDK.GetRowCellValue(e.RowHandle, "MAMH").ToString();
                int maLTC = int.Parse(gvDK.GetRowCellValue(e.RowHandle, "MALTC").ToString());
                if (!Utils.checkDKLopTC(maLTC, this.NK, this.HK, maMH, this.maSV))
                {
                    gvDK.SetRowCellValue(e.RowHandle, "DANGKY", 0);
                    MessageBox.Show("Không thể đăng kí môn học này");
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void gvDADK_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gvDADK.Columns["DANGKY"])
            {
                btnSave.Enabled = true;
            }
        }
    }
}
