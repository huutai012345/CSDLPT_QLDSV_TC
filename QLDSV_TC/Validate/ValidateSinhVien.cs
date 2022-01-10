using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class ValidateSinhVien
    {
        public static bool validate(TextBox txtHo, TextBox txtTen, TextBox txtDiaChi, TextBox txtMatKhau)
        {
            if (Library.isEmpty(txtHo))
            {
                MessageBox.Show("Họ không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (Library.isEmpty(txtTen))
            {
                MessageBox.Show("Tên không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (Library.isEmpty(txtDiaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            if (Library.isEmpty(txtMatKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtMatKhau.Focus();
                return false;
            }

            return true;
        }
    }
}
