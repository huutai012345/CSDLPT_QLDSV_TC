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
    public partial class FormLop : Form
    {
        private int vitri = 0;
        private bool isEdit;

        public FormLop()
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
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.LOP' table. You can move, or remove it, as needed.
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.LOP);

            cmbKhoaHoc.SelectedIndex = 0;
        }

        private void modifyMode()
        {
            gc.Enabled = false;
            txtMaLop.Enabled = txtTenLop.Enabled = cmbKhoaHoc.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled= btnClose.Enabled = false;
        }

        private void confrimMode()
        {
            gc.Enabled = true;
            txtMaLop.Enabled = txtTenLop.Enabled = cmbKhoaHoc.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
        }

        private void updateTableAdapter()
        {
            bds.EndEdit();
            bds.ResetCurrentItem();
            this.tableAdapter.Connection.ConnectionString = Program.connstr;
            this.tableAdapter.Update(this.qLDSV_TCDataSet.LOP);
        }

        private void refesh()
        {
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.LOP);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            vitri = bds.Position;
            this.cmbKhoaHoc.SelectedIndex = 9;
            bds.AddNew();

            isEdit = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bds.Position;
            isEdit = true;

            this.modifyMode();
            txtMaLop.Enabled = false;
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
            txtMaLop.Text = txtMaLop.Text.Trim();
            txtTenLop.Text = txtTenLop.Text.Trim();

            if (!ValidateLop.validate(txtMaLop, txtTenLop))
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
                MessageBox.Show("Mă hoặc tên lớp đã tồn tại", "THÔNG BÁO", MessageBoxButtons.OK);
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
            //System.Windows.Forms.Application.Exit();
        }
     
        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.refesh();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["MAKHOA"], Program.maKhoa);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["KHOAHOC"], cmbKhoaHoc.Text);
        }

        private void cmbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                gridView1.SetRowCellValue(selectedRowHandles[0], "KHOAHOC", cmbKhoaHoc.Text);
            }
        }

        private void gc_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                cmbKhoaHoc.SelectedIndex = cmbKhoaHoc.FindStringExact(gridView1.GetRowCellValue(selectedRowHandles[0], "KHOAHOC").ToString());
            }
        }
    }
}
