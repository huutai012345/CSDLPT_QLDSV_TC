using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    class ValidateLopTC
    {
        public static bool validate(TextBox txtSLSVTC, TextBox txtNhom)
        {
            if (Library.isEmpty(txtSLSVTC))
            {
                MessageBox.Show("Số lượng sinh viên tối thiểu không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtSLSVTC.Focus();
                return false;
            }
            if (Library.isEmpty(txtNhom))
            {
                MessageBox.Show("Nhóm không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtNhom.Focus();
                return false;
            }

            if (!Library.isNumber(txtSLSVTC) || int.Parse(txtSLSVTC.Text) <= 0)
            {
                MessageBox.Show("Số lượng sinh viên tối thiểu phải là số lớn hơn 0", "THÔNG BÁO", MessageBoxButtons.OK);
                txtNhom.Focus();
                return false;
            }
            if (!Library.isNumber(txtNhom) || int.Parse(txtNhom.Text) <= 0)
            {
                MessageBox.Show("Nhóm phải là số và lớn hơn 0", "THÔNG BÁO", MessageBoxButtons.OK);
                txtNhom.Focus();
                return false;
            }

            return true;
        }
    }
}
