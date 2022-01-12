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
    public partial class FormSinhVien : Form
    {
        private int vitri = 0;
        private bool isEdit;
        private string khoaHoc;
        private string maSV;

        public FormSinhVien()
        {
            InitializeComponent();
            gridViewLop.OptionsBehavior.Editable = false;
            gridViewSV.OptionsBehavior.Editable = false;

            this.confrimMode();
            if (Program.mGroup != Program.nhomQuyen[0])
            {
                this.panel1.Visible = false;
            }
            txtMaSV.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.svTableAdapter.Connection.ConnectionString = Program.connstr;
            this.svTableAdapter.Fill(this.qLDSV_TCDataSet.SINHVIEN);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.LOP' table. You can move, or remove it, as needed.
            this.lopTCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lopTCTableAdapter.Fill(this.qLDSV_TCDataSet.LOP);

            if (bdsLop.Count > 0)
            {
                khoaHoc = ((DataRowView)bdsLop[0])["KHOAHOC"].ToString();

                string nghiHoc = ((DataRowView)bdsSV[0])["DANGHIHOC"].ToString();
                if (nghiHoc == "True")
                {
                    btnNghiHoc.Enabled = false;
                }
                else
                {
                    btnNghiHoc.Enabled = true;
                }
            }
            else if(bdsLop.Count == 0)
            {
                btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnNghiHoc.Enabled=false;
            }
        }

        private void modifyMode()
        {
            gcSV.Enabled = false;
            txtHo.Enabled = txtTen.Enabled = txtDiaChi.Enabled = txtNgaySinh.Enabled = txtMatKhau.Enabled = panelPhai.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = false;
            cmbKhoa.Enabled = false;
        }

        private void confrimMode()
        {
            gcSV.Enabled = true;
            txtHo.Enabled = txtTen.Enabled = txtDiaChi.Enabled = txtNgaySinh.Enabled = txtMatKhau.Enabled = panelPhai.Enabled= false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
            cmbKhoa.Enabled = false;
        }

        private void updateTableAdapter()
        {
            bdsSV.EndEdit();
            bdsSV.ResetCurrentItem();
            this.svTableAdapter.Connection.ConnectionString = Program.connstr;
            this.svTableAdapter.Update(this.qLDSV_TCDataSet.SINHVIEN);
        }

        private void refesh()
        {
            this.svTableAdapter.Fill(this.qLDSV_TCDataSet.SINHVIEN);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            this.vitri = bdsSV.Position;
            bdsSV.AddNew();
            string maSV = Utils.generateMaSV(this.khoaHoc);
            if (maSV == "")
            {
                MessageBox.Show("Lớp Không Tồn Tại", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }

            txtMaSV.Text = maSV;
            this.isEdit = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.vitri = bdsLop.Position;
            this.isEdit = true;

            this.modifyMode();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bdsSV.RemoveCurrent();

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
            txtHo.Text = txtHo.Text.Trim();
            txtTen.Text = txtTen.Text.Trim();
            txtDiaChi.Text = txtDiaChi.Text.Trim();
            txtMatKhau.Text = txtMatKhau.Text.Trim();

            if (!ValidateSinhVien.validate(txtHo, txtTen, txtDiaChi, txtMatKhau))
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
            if (!this.isEdit)
            {
                bdsSV.RemoveCurrent();
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

        private void radioButtonNam_CheckedChanged(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridViewSV.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                gridViewSV.SetRowCellValue(selectedRowHandles[0], "PHAI", 0);
            }
        }

        private void radioButtonNu_CheckedChanged(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridViewSV.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                gridViewSV.SetRowCellValue(selectedRowHandles[0], "PHAI", 1);
            }
        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewSV.SetRowCellValue(e.RowHandle, gridViewSV.Columns["MASV"], txtMaSV.Text);
            gridViewSV.SetRowCellValue(e.RowHandle, gridViewSV.Columns["DANGHIHOC"], 0);
            gridViewSV.SetRowCellValue(e.RowHandle, gridViewSV.Columns["PHAI"], 0);
        }

        private void gcLop_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridViewLop.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                this.khoaHoc = gridViewLop.GetRowCellValue(selectedRowHandles[0], "KHOAHOC").ToString();
            }
        }

        private void gcSV_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridViewSV.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                this.maSV = gridViewSV.GetRowCellValue(selectedRowHandles[0], "MASV").ToString();
                string nghiHoc = ((DataRowView)bdsSV[0])["DANGHIHOC"].ToString();
                if (nghiHoc == "True")
                {
                    btnNghiHoc.Enabled = false;
                }
                else
                {
                    btnNghiHoc.Enabled = true;
                }
            }
        }

        private void btnNghiHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận nghĩ học", "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (Utils.nghiHoc(this.maSV)) 
                    {
                        MessageBox.Show("Cập Nhật Thành Công", "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhật Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK);
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
                    this.lopTCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lopTCTableAdapter.Fill(this.qLDSV_TCDataSet.LOP);

                    this.svTableAdapter.Connection.ConnectionString = Program.connstr;
                }
            }
        }
    }
}
