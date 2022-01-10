using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    class ValidateLogin
    {
        public static bool validate(TextBox txtUserName, TextBox txtPass)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Tài khoản không được rỗng", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtUserName.Focus();
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Vui lòng điền mật khẩu", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtPass.Focus();
                return false;
            }

            if (txtUserName.Text == "sa" || txtUserName.Text == "HTKN")
            {
                MessageBox.Show("Tài Khoản Không Đúng", "Báo lỗi đăng nhập", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
