using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class ValidateLop
    {
        public static bool validate(TextBox txtMaLop, TextBox txtTenLop)
        {
            if (Library.isEmpty(txtMaLop))
            {
                MessageBox.Show("Mã lớp không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }
            if (Library.isEmpty(txtTenLop))
            {
                MessageBox.Show("Tên lớp không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return false;
            }

            return true;
        }
    }
}
