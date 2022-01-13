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

        public FormHocPhi()
        {
            InitializeComponent();
            gvHP.OptionsBehavior.Editable = false;
            gvCTDHP.OptionsBehavior.Editable = false;
            this.panel1.Enabled = false;

            this.confrimMode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbHK.SelectedIndex = 0;
            cmbNK.SelectedIndex = 0;
        }

        private void modifyMode()
        {
            //gcDSHP.Enabled = false;
            cmbHK.Enabled = cmbNK.Enabled = true;

            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = false;
        }

        private void confrimMode()
        {
           // gcDSHP.Enabled = false;
            cmbHK.Enabled = cmbNK.Enabled = false;

            btnSave.Enabled = btnCancel.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled
                = btnRefesh.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnClose.Enabled = true;
        }

        private void refesh()
        {
           // this.tableAdapter.Fill(this.qLDSV_TCDataSet.MONHOC);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvCTDHP.OptionsBehavior.Editable = true;
            this.modifyMode();
            bdsHP.AddNew();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
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
            //bds.RemoveCurrent();
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
                this.hocPhiTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_HOCPHI, txtMaSV.Text);
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
                    string NK = gvHP.GetRowCellValue(selectedRowHandles[0], "NIENKHOA").ToString();
                    int HK = int.Parse(gvHP.GetRowCellValue(selectedRowHandles[0], "HOCKY").ToString());

                    cmbHK.SelectedIndex = cmbHK.FindStringExact(HK.ToString());
                    cmbNK.SelectedIndex = cmbNK.FindStringExact(NK);

                    this.cDHPTableAdapter.Fill(this.qLDSV_TCDataSet2.SP_LAY_DS_CTDHP, this.maSV, NK, HK);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bdsCTDHP.AddNew();
        }
    }
}
