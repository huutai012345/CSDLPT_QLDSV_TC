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
    public partial class FormMonHoc : Form
    {
        private int vitri = 0;

        public FormMonHoc()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;

            this.confrimMode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.tableAdapter.Connection.ConnectionString = Program.connstr;
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.MONHOC);

        }

        private void modifyMode()
        {
            gc.Enabled = false;
            txtMaMonHoc.Enabled = txtTenMonHoc.Enabled = txtSTLT.Enabled = txtSTTT.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = false;
        }

        private void confrimMode()
        {
            gc.Enabled = true;
            txtMaMonHoc.Enabled = txtTenMonHoc.Enabled = txtSTLT.Enabled = txtSTTT.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
        }

        private void updateTableAdapter()
        {
            bds.EndEdit();
            bds.ResetCurrentItem();
            this.tableAdapter.Connection.ConnectionString = Program.connstr;
            this.tableAdapter.Update(this.qLDSV_TCDataSet.MONHOC);
        }

        private void refesh()
        {
            this.tableAdapter.Fill(this.qLDSV_TCDataSet.MONHOC);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.modifyMode();
            vitri = bds.Position;
            bds.AddNew();
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
            txtMaMonHoc.Text = txtMaMonHoc.Text.Trim();
            txtTenMonHoc.Text = txtTenMonHoc.Text.Trim();
            txtSTLT.Text = txtSTLT.Text.Trim();
            txtSTTT.Text = txtSTTT.Text.Trim();

            if (!ValidateMonHoc.validate(txtMaMonHoc, txtTenMonHoc, txtSTLT, txtSTTT))
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
                MessageBox.Show("Mă hoặc tên môn học đã tồn tại", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bds.RemoveCurrent();
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
    }
}
