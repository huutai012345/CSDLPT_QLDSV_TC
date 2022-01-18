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
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnAddCTDHP.Enabled = false;
            this.btnLoadSV.Enabled = false;

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
                this.btnLoadSV.Enabled = true;
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
            this.btnLoadSV.Enabled = true;
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
            string maSV = txtMaSV.Text.Trim();
            if (maSV == "")
            {
                MessageBox.Show("Mã Sinh Viên Không Hợp Lệ", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }

            if (Utils.getListTTSV(maSV, this.txtHoTen, this.txtMaLop))
            {   
                this.maSV = maSV;
            }
            else
            {
                return;
            }

            try
            {
                this.panel1.Enabled = true;
                this.bar1.Visible = true;

                this.hocPhiTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_HOCPHI, txtMaSV.Text);
                if (gvHP.RowCount > 0)
                {
                    this.NK = gvHP.GetRowCellValue(0, "NIENKHOA").ToString();
                    this.HK = int.Parse(gvHP.GetRowCellValue(0, "HOCKY").ToString());

                    cmbHK.SelectedIndex = cmbHK.FindStringExact(this.HK.ToString());
                    cmbNK.SelectedIndex = cmbNK.FindStringExact(this.NK);

                    this.cTDHPTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_CTDHP, this.maSV, this.NK, new System.Nullable<int>(((int)(System.Convert.ChangeType(this.HK, typeof(int))))));
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

                    this.btnAddCTDHP.Enabled = true;
                    this.cTDHPTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_CTDHP, this.maSV, this.NK, new System.Nullable<int>(((int)(System.Convert.ChangeType(this.HK, typeof(int))))));
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
            this.btnLoadSV.Enabled = false;
            this.gcDSHP.Enabled = false;
            this.bar1.Visible = false;
            this.btnAddCTDHP.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            this.gcDSHP.Enabled = true;
            this.bar1.Visible = true;
            this.btnAddCTDHP.Enabled = true;
            this.btnLoadSV.Enabled = true;
        }

        private void btnSaveCTHP_Click(object sender, EventArgs e)
        {
            if (!ValidateCTDHP.validate(txtSoTienDong))
            {
                return;
            }

            if (Utils.addCTHP(this.maSV, this.NK, this.HK, int.Parse(txtSoTienDong.Text), txtNgayDong.Text))
            {
                MessageBox.Show("Ghi thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                this.cTDHPTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_CTDHP, this.maSV, this.NK, new System.Nullable<int>(((int)(System.Convert.ChangeType(this.HK, typeof(int))))));

                this.btnAddCTDHP.Enabled = true;
                this.bar1.Visible = true;
                panel2.Visible = false;
                gcDSHP.Enabled = true;
                this.btnLoadSV.Enabled = true;
                this.refesh();
            }
            else
            {
                MessageBox.Show("Chi tiết đóng học phí tồn tại hoặc số tiền học phí đã đủ", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }
    }
}
