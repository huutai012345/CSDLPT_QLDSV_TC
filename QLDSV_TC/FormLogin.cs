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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" && txtPass.Text.Trim() == "")
            {
                Close();
            }
            else
            {
                DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.Trim();
            txtPass.Text = txtPass.Text.Trim();

            if (!ValidateLogin.validate(txtUserName, txtPass))
            {
                return;
            }

            Program.mlogin = txtUserName.Text;
            Program.password = txtPass.Text;
            if (Program.KetNoi() == 0)
            {
                return;
            }

            Program.mChinhanh = cmbKhoa.SelectedIndex;
            Program.maKhoa = cmbKhoa.Text;

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            Utils.login();

            this.Hide();

            Program.fmChinh = new FormMain();
            Program.fmChinh.MANV.Text = "Mã: " + Program.username;
            Program.fmChinh.HOTEN.Text = "Họ Tên: " + Program.mHoten;
            Program.fmChinh.NHOM.Text = "Nhóm Quyền: " + Program.mGroup;

            if (Program.mGroup == Program.nhomQuyen[2])
            {
                FormDangKi f = new FormDangKi();
                f.Show();
            }
            else if (Program.mGroup == Program.nhomQuyen[0] || Program.mGroup == Program.nhomQuyen[1])
            {
                Program.fmChinh.Show();
            }
        }

        private void fmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSV_TCDataSet1.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSV_TCDataSet1.V_DS_PHANMANH);

            cmbKhoa.SelectedIndex = 0;
            Program.servername = cmbKhoa.SelectedValue.ToString();
        }

        private void fmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue == null)
            {
                return;
            }

            Program.servername = cmbKhoa.SelectedValue.ToString();
        }
    }
}
