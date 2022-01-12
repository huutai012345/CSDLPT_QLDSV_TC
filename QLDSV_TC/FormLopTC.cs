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
    public partial class FormLopTC : Form
    {
        private int vitri = 0;
        private bool isEdit;
        private int maLTC;

        public FormLopTC()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;

            this.confrimMode();
            if (Program.mGroup != Program.nhomQuyen[0])
            {
                this.panel1.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.V_DS_GIANGVIEN' table. You can move, or remove it, as needed.
            this.v_DS_GIANGVIENTableAdapter.Fill(this.qLDSV_TCDataSet.V_DS_GIANGVIEN);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.qLDSV_TCDataSet.MONHOC);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.LOPTINCHI' table. You can move, or remove it, as needed.
            this.tableAdapter.Connection.ConnectionString = Program.connstr;
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.LOPTINCHI);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);
          

            cmbMaGiangVien.SelectedIndex = 0;
            cmbMaMonHoc.SelectedIndex = 0;
            cmbHK.SelectedIndex = 0;
            cmbNK.SelectedIndex = 0;

            if (bds.Count > 0)
            {
                maLTC = int.Parse(((DataRowView)bds[0])["MALTC"].ToString());
                string huyLop = ((DataRowView)bds[0])["HUYLOP"].ToString();

                if (huyLop == "True")
                {
                    btnCancelLop.Enabled = false;
                }
                else if (huyLop == "False" && Utils.checkCancelLopTC(maLTC))
                {
                    btnCancelLop.Enabled = true;
                }
                else
                {
                    btnCancelLop.Enabled = false;
                }
            }
            else if (bds.Count == 0)
            {
                btnCancelLop.Enabled = false;
            }
        }

        private void modifyMode()
        {
            gc.Enabled = false;
            txtNhom.Enabled = txtSLSVTT.Enabled = true;
            cmbMaGiangVien.Enabled = cmbMaMonHoc.Enabled = cmbHK.Enabled = cmbNK.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = false;
            cmbKhoa.Enabled = false;
        }

        private void confrimMode()
        {
            gc.Enabled = true;
            txtNhom.Enabled = txtSLSVTT.Enabled = false;
            cmbMaGiangVien.Enabled = cmbMaMonHoc.Enabled = cmbHK.Enabled = cmbNK.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
            cmbKhoa.Enabled = true;
        }

        private void updateTableAdapter()
        {
            bds.EndEdit();
            bds.ResetCurrentItem();
            this.tableAdapter.Connection.ConnectionString = Program.connstr;
            this.tableAdapter.Update(this.qLDSV_TCDataSet.LOPTINCHI);
        }

        private void refesh()
        {
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.LOPTINCHI);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            vitri = bds.Position;
            this.cmbNK.SelectedIndex = 9;
            this.cmbHK.SelectedIndex = 0;
            bds.AddNew();
          
            isEdit = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bds.RemoveCurrent();

                try
                {
                    this.updateTableAdapter();
                    MessageBox.Show("Xóa Thành Công", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Không Thể Xóa", "THÔNG BÁO", MessageBoxButtons.OK);
                }

                this.refesh();
            }

            this.confrimMode();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtNhom.Text = txtNhom.Text.Trim();
            txtSLSVTT.Text = txtSLSVTT.Text.Trim();

            if (!ValidateLopTC.validate(txtSLSVTT, txtNhom))
            {
                return;
            }

            try
            {
                this.updateTableAdapter();
                MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                this.confrimMode();
                this.refesh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!isEdit)
            {
                bds.RemoveCurrent();
            }
            this.confrimMode();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.refesh();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["MAKHOA"], Program.maKhoa);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["MAMH"], cmbMaMonHoc.SelectedValue.ToString());
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["MAGV"], cmbMaGiangVien.SelectedValue.ToString());
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["NIENKHOA"], cmbNK.Items[cmbNK.SelectedIndex].ToString());
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["HOCKY"], cmbHK.Items[cmbHK.SelectedIndex].ToString());
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["HUYLOP"], 0);
        }

        private void gc_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                cmbMaGiangVien.SelectedValue = gridView1.GetRowCellValue(selectedRowHandles[0], "MAGV").ToString();
                cmbMaMonHoc.SelectedValue = gridView1.GetRowCellValue(selectedRowHandles[0], "MAMH").ToString();
                cmbHK.SelectedIndex = cmbHK.FindStringExact(gridView1.GetRowCellValue(selectedRowHandles[0], "HOCKY").ToString());
                cmbNK.SelectedIndex = cmbNK.FindStringExact(gridView1.GetRowCellValue(selectedRowHandles[0], "NIENKHOA").ToString());

                maLTC = int.Parse(gridView1.GetRowCellValue(selectedRowHandles[0], "MALTC").ToString());
                string huyLop=gridView1.GetRowCellValue(selectedRowHandles[0], "HUYLOP").ToString();
                if (huyLop == "True")
                {
                    btnCancelLop.Enabled = false;
                }
                else if (huyLop == "False" && Utils.checkCancelLopTC(maLTC))
                {
                    btnCancelLop.Enabled = true;
                }
                else
                {
                    btnCancelLop.Enabled = false;
                }
            }
        }

        private void cmbMaMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaMonHoc.SelectedValue != null)
            {
                int[] selectedRowHandles = gridView1.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    gridView1.SetRowCellValue(selectedRowHandles[0], "MAMH", cmbMaMonHoc.SelectedValue.ToString());
                }
            }
        }

        private void cmbMaGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaGiangVien.SelectedValue != null)
            {
                int[] selectedRowHandles = gridView1.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    gridView1.SetRowCellValue(selectedRowHandles[0], "MAGV", cmbMaGiangVien.SelectedValue.ToString());
                }
            }
        }

        private void cmbHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                gridView1.SetRowCellValue(selectedRowHandles[0], "HOCKY", cmbHK.Text);
            }
        }

        private void cmbNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                gridView1.SetRowCellValue(selectedRowHandles[0], "NIENKHOA", cmbNK.Text);
            }
        }

        private void btnCancelLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn hủy lớp", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (Utils.cancelLopTC(maLTC))
                    {
                        MessageBox.Show("Hủy Thành Công", "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Hủy Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                }

                this.refesh();
            }
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
                else
                {

                    this.tableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
                    this.tableAdapter.Fill(this.qLDSV_TCDataSet.LOPTINCHI);
                }
            }
        }
    }
}
