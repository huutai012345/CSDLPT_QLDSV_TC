using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class ValidateHocPhi
    {
        public static bool validate(TextBox txtHocPHi)
        {
            if (Library.isEmpty(txtHocPHi)) 
            {
                MessageBox.Show("Học phí không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
                txtHocPHi.Focus();
                return false;
            }

            if (!Library.isNumber(txtHocPHi) || !Library.isFloat(txtHocPHi,0))
            {
                MessageBox.Show("Học phí phải là số", "THÔNG BÁO", MessageBoxButtons.OK);
                txtHocPHi.Focus();
                return false;
            }

            return true;
        }
    }
}
