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
    public partial class FormDiem : Form
    {
        private int maLopTC;

        public FormDiem()
        {
            InitializeComponent();
            gridViewLopTC.OptionsBehavior.Editable = false;

            this.btnSave.Enabled = false;
            if (Program.mGroup != Program.nhomQuyen[0])
            {
                this.panel1.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_KHOA' table. You can move, or remove it, as needed.
            this.v_DS_KHOATableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_KHOA);

            Utils.getListNKLopTC(this.cmbNK);
           
            this.cmbNK.SelectedIndex = 0;
            this.cmbHK.SelectedIndex = 0;

            if (bdsLTC.Count > 0)
            {
                maLopTC = int.Parse(((DataRowView)bdsLTC[0])["MALTC"].ToString());
            }
            else if (bdsLTC.Count == 0)
            {
               btnSave.Enabled = false;
            }
        }

        private void refesh()
        {
            this.dSSVTableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_DSSV_DANGKY, maLopTC);
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
                dt.Columns.Add("DIEM_CC", typeof(int));
                dt.Columns.Add("DIEM_GK", typeof(float));
                dt.Columns.Add("DIEM_CK", typeof(float));

                for (int i = 0; i < gridViewDSSV.RowCount; i++)
                {
                    try
                    {
                        string maSV = gridViewDSSV.GetRowCellValue(i, "MASV").ToString().Trim();
                        string strDiemCC = gridViewDSSV.GetRowCellValue(i, "DIEM_CC").ToString().Trim();
                        string strDiemGK = gridViewDSSV.GetRowCellValue(i, "DIEM_GK").ToString().Trim();
                        string strDiemCK = gridViewDSSV.GetRowCellValue(i, "DIEM_CK").ToString().Trim();

                        int? diemCC = null;
                        float? diemGK = null;
                        float? diemCK = null;
                        if (strDiemCC.Length>0)
                        {
                            diemCC = int.Parse(strDiemCC);
                            if (!ValidateDiem.validate(diemCC, "Điểm chuyên cần"))
                            {
                                return;
                            }
                        }
                        if (strDiemGK.Length > 0)
                        {
                            diemGK = float.Parse(strDiemGK);
                            if (!ValidateDiem.validate(diemGK, "Điểm giữa kì"))
                            {
                                return;
                            }
                        }
                        if (strDiemCK.Length > 0)
                        {
                            diemCK = float.Parse(strDiemCK);
                            if (!ValidateDiem.validate(diemCK, "Điểm cuối kì"))
                            {
                                return;
                            }
                        }
                       

                        dt.Rows.Add(this.maLopTC, maSV, diemCC, diemGK, diemCK);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Điểm Không Đúng Định Dạng", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }

                Utils.updateDiem(dt);
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

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.lopTCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lopTCTableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_DS_LTC, cmbNK.Text, new System.Nullable<int>(((int)(System.Convert.ChangeType(cmbHK.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void gcLTC_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridViewLopTC.GetSelectedRows();
            if (selectedRowHandles.Length > 0)
            {
                try
                {
                    this.btnSave.Enabled = false;
                    this.maLopTC = int.Parse(gridViewLopTC.GetRowCellValue(selectedRowHandles[0], "MALTC").ToString());
                    this.dSSVTableAdapter.Fill(this.qLDSV_TCDataSet.SP_LAY_DSSV_DANGKY, new System.Nullable<int>(((int)(System.Convert.ChangeType(this.maLopTC, typeof(int))))));
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }         
        }

        private void gridViewDSSV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.btnSave.Enabled = true;
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
            }
        }
    }
}
