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
    public partial class FormHocPhi : Form
    {
        private string maSV;
        private string NK;
        private int HK;

        public FormHocPhi()
        {
            InitializeComponent();
            gvHP.OptionsBehavior.Editable = false;
            gvCTDHP.OptionsBehavior.Editable = false;
            gcCTDHP.Enabled = false;

            this.panel1.Enabled = false;
            this.panel2.Visible = false;
            this.bar1.Visible = false;

            this.confrimMode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbHK.SelectedIndex = 0;
            cmbNK.SelectedIndex = 0;
        }

        private void modifyMode()
        {
            gcDSHP.Enabled = false;
            cmbHK.Enabled = cmbNK.Enabled =txtHocPhi.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = false;
        }

        private void confrimMode()
        {
            gcDSHP.Enabled = true;
            cmbHK.Enabled = cmbNK.Enabled = txtHocPhi.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
        }

        private void refesh()
        {
           this.hocPhiTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_HOCPHI,this.maSV);
            gcCTDHP.Enabled = false;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvCTDHP.OptionsBehavior.Editable = true;
            this.modifyMode();
            bdsHP.AddNew();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateHocPhi.validate(txtHocPhi))
            {
                return;
            }

            if (Utils.addHocPhi(this.maSV, cmbNK.Text, int.Parse(cmbHK.Text), int.Parse(txtHocPhi.Text)))
            {
                MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                this.confrimMode();
                this.refesh();
            }
            else
            {
                MessageBox.Show("Học phí đã tồn tại", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsHP.RemoveCurrent();
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

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.maSV = txtMaSV.Text;
                this.panel1.Enabled = true;
                this.bar1.Visible = true;

                this.hocPhiTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_HOCPHI, txtMaSV.Text);
                if (gvHP.RowCount > 0)
                {
                    this.NK = gvHP.GetRowCellValue(0, "NIENKHOA").ToString();
                    this.HK = int.Parse(gvHP.GetRowCellValue(0, "HOCKY").ToString());

                    cmbHK.SelectedIndex = cmbHK.FindStringExact(this.HK.ToString());
                    cmbNK.SelectedIndex = cmbNK.FindStringExact(this.NK);

                    gcCTDHP.Enabled = true;
                    gcCTDHP.DataSource = Utils.getCTHP(this.maSV, this.NK, this.HK);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void gcDSHP_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gvHP.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                try
                {
                    this.NK = gvHP.GetRowCellValue(selectedRowHandles[0], "NIENKHOA").ToString();
                    this.HK = int.Parse(gvHP.GetRowCellValue(selectedRowHandles[0], "HOCKY").ToString());

                    cmbHK.SelectedIndex = cmbHK.FindStringExact(this.HK.ToString());
                    cmbNK.SelectedIndex = cmbNK.FindStringExact(this.NK);

                    gcCTDHP.Enabled = true;
                    gcCTDHP.DataSource = Utils.getCTHP(this.maSV, this.NK, this.HK);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddCTDHP_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            this.gcDSHP.Enabled = false;
            this.bar1.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            this.gcDSHP.Enabled = true;
            this.bar1.Visible = true;
        }

        private void btnSaveCTHP_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("MASV", typeof(string));
            //dt.Columns.Add("NIENKHOA", typeof(string));
            //dt.Columns.Add("HOCKY", typeof(int));
            //dt.Columns.Add("NGAYDONG", typeof(string));
            //dt.Columns.Add("SOTIENDONG", typeof(int));

            //for (int i = 0; i < gvCTDHP.RowCount; i++)
            //{
            //    string ngayDong = gvCTDHP.GetRowCellValue(i, "NGAYDONG").ToString().Trim();
            //    int soTienDong = int.Parse(gvCTDHP.GetRowCellValue(i, "SOTIENDONG").ToString().Trim());

            //    dt.Rows.Add(this.maSV, this.NK, this.HK, ngayDong,soTienDong);
            //}

            //if (dt.Rows.Count > 0)
            //{
            //    Utils.updateHocPhi(dt);
            //}
            if (!ValidateCTDHP.validate(txtSoTienDong))
            {
                return;
            }

            if (Utils.checkAddCTDHP(this.NK, this.HK, this.maSV, txtNgayDong.Text,int.Parse(txtHocPhi.Text)))
            {
                Utils.addCTHP(this.maSV, this.NK, this.HK, int.Parse(txtSoTienDong.Text), txtNgayDong.Text);
                MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                gcCTDHP.DataSource = Utils.getCTHP(this.maSV, this.NK, this.HK);
                gcCTDHP.Enabled = false;

                panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Chi tiết đóng học phí tồn tại hoặc số tiền học phí đã đủ", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

       
    }
}
