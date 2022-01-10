using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC.Validate
{
    static class Library
    {
        public static bool isNumber(TextBox txt)
        {
            String str = txt.Text.ToString().Trim();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 48 || str[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isEmpty(TextBox txt)
        {
            if (txt.Text.ToString().Trim() == "")
            {
                return true;
            }
            return false;
        }

        public static bool isRightFloat(TextBox txt, float value)
        {
            if (float.Parse(txt.Text.ToString().Trim().Replace(",", "")) < value)
            {
                return false;
            }
            return true;
        }

        public static bool isRightInt(TextBox txt, int value)
        {
            if (int.Parse(txt.Text.ToString().Trim()) < value)
            {
                return false;
            }
            return true;
        }
    }
}
