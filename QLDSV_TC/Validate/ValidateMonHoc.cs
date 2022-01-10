using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class ValidateMonHoc
    {
        public static bool validate(TextBox txtMaMonHoc, TextBox txtTenMonHoc, TextBox txtSTLT, TextBox txtSTTT)
        {
            if (Library.isEmpty(txtMaMonHoc))
            {
                MessageBox.Show("Mã môn học không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtMaMonHoc.Focus();
                return false;
            }
            if (Library.isEmpty(txtTenMonHoc))
            {
                MessageBox.Show("Tên môn học không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtTenMonHoc.Focus();
                return false;
            }
            if (Library.isEmpty(txtSTLT))
            {
                MessageBox.Show("Số tiết lý thuyết không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtSTLT.Focus();
                return false;
            }
            if (Library.isEmpty(txtSTTT))
            {
                MessageBox.Show("Số tiết thực hành không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtSTTT.Focus();
                return false;
            }
            if (!Library.isNumber(txtSTLT) || int.Parse(txtSTLT.Text) < 0)
            {
                MessageBox.Show("Số tiết lý thuyết phải là số lớn hơn hoặc bằng 0", "THÔNG BÁO", MessageBoxButtons.OK);
                txtSTLT.Focus();
                return false;
            }
            if (!Library.isNumber(txtSTTT) || int.Parse(txtSTTT.Text) < 0)
            {
                MessageBox.Show("Số tiết thực hành phải là số lớn hơn hoặc bằng 0", "THÔNG BÁO", MessageBoxButtons.OK);
                txtSTTT.Focus();
                return false;
            }

            return true;
        }
    }
}
