using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class ValidateDiem
    {
        public static bool validate(int? diem, string name)
        {
            if (diem < 0 || diem > 10)
            {
                MessageBox.Show(name + " không hợp lệ", "THÔNG BÁO", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        public static bool validate(float? diem,string name)
        {
            if (diem < 0 || diem > 10)
            {
                MessageBox.Show( name+" không hợp lệ", "THÔNG BÁO", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}
