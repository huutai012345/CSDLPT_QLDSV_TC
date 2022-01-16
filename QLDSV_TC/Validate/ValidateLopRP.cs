using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    class ValidateRP
    {
        public static bool validate(TextBox txtNhom)
        {
            if (Library.isEmpty(txtNhom))
            {
                MessageBox.Show("Nhóm không được để trống", "THÔNG BÁO", MessageBoxButtons.OK);
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
