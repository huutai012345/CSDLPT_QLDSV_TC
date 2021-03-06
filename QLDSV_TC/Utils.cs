using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLDSV_TC
{
    static class Utils
    {
        public static string generateMaSV(string inputKhoaHoc) 
        {
            string result="";
            int stt = 0;
            string khoaHoc="";
            string maSV ="";
            string maKhoa = Program.maKhoa;
            string strLenh = "EXEC SP_GENERATE_MA_SV @KHOAHOC = N'"+ inputKhoaHoc + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                if (Program.myReader.Read())
                {
                    stt = int.Parse(Program.myReader.GetString(0)) + 1;
                    khoaHoc = Program.myReader.GetString(1);
                }

                Program.myReader.Close();

                int lengOfNum = stt.ToString().Length;
                for (int i = 0; i < 3 - lengOfNum; i++)
                {
                    maSV = maSV + "0";
                }
                maSV = maSV + stt;

                if (maKhoa == "CNTT")
                {
                    result = "N" + khoaHoc + "DCCN" + maSV;
                }
                else if (maKhoa == "VT")
                {
                    result = "N" + khoaHoc + "DCVT" + maSV;
                }
            }
            else
            {
                Program.myReader.Close();
                return "";
            }

            return result;
        }

        public static void getListNKLopTC(ToolStripComboBox cmb)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_GET_NIENKHOA");
            if (Program.myReader != null)
            {
                while (Program.myReader.Read())
                {
                    cmb.Items.Add(Program.myReader.GetString(0));
                }

                Program.myReader.Close();
            }
        }

        public static bool getListTTSV(string maSV, TextBox txtTen, TextBox txtMaLop)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_GET_TTSV @MASV =N'" + maSV +"'");
            if (Program.myReader != null)
            {
                if (Program.myReader.Read())
                {
                    txtTen.Text = Program.myReader.GetString(0);
                    txtMaLop.Text = Program.myReader.GetString(1);

                    Program.myReader.Close();
                    return true;
                }

                Program.myReader.Close();
            }
            return false;
        }
        public static bool getListTTSV(string maSV, ToolStripTextBox txtTen, ToolStripTextBox txtMaLop)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_GET_TTSV @MASV =N'" + maSV + "'");
            if (Program.myReader != null)
            {
                if (Program.myReader.Read())
                {
                    txtTen.Text = Program.myReader.GetString(0);
                    txtMaLop.Text = Program.myReader.GetString(1);

                    Program.myReader.Close();
                    return true;
                }

                Program.myReader.Close();
            }
            return false;
        }


        public static void updateDiem(DataTable dt)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "dbo.TYPE_DANGKY";
            parameter.ParameterName = "@DIEMTHI";
            parameter.Value = dt;
 
            SqlCommand sqlcmd = new SqlCommand("SP_UPDATE_DIEM", Program.conn);
            sqlcmd.Parameters.Clear();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandTimeout = 600;
            sqlcmd.Parameters.Add(parameter);

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void login()
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_LOGIN '" + Program.mlogin + "'");
            if (Program.myReader != null)
            {
                if (Program.myReader.Read())
                {
                    Program.username = Program.myReader.GetString(0);
                }

                if (Convert.IsDBNull(Program.username) == true)
                {
                    MessageBox.Show("Login bạn không có quyền truy cập dữ liệu\n Bạn xem lại username và password\n");
                    Program.myReader.Close();
                    return;
                }

                Program.mHoten = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.conn.Close();
            }
        }

        public static bool checkCancelLopTC(int maLopTC)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CHECK_CANCEL_LOPTC] @MALOPTC ="+ maLopTC +" "+
                "SELECT  'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static bool cancelLopTC(int maLopTC)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CANCEL_LOPTC] @MALOPTC =" + maLopTC + " " +
                "SELECT  'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static bool nghiHoc(string maSV)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_NGHI_HOC] @MASV =" + maSV + " " +
                "SELECT  'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static DataTable getListLTCDK(string maSV, string NK, int HK,bool DK)
        {
            return Program.ExecSqlDataTable("EXEC SP_LAY_DS_LTC_DANGKY @MASV =N'" + maSV + "', @NK =N'"+ NK + "', @DANGKY = "+DK+", @HK="+ HK);
        }

        public static bool dangKy(DataTable dt)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "dbo.TYPE_DANGKYLTC";
            parameter.ParameterName = "@DANGKYLTC";
            parameter.Value = dt;

            SqlCommand sqlcmd = new SqlCommand("SP_DANGKY", Program.conn);
            sqlcmd.Parameters.Clear();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandTimeout = 600;
            sqlcmd.Parameters.Add(parameter);

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool checkDKLopTC(int maLopTC,string NK,int HK,string maMH,string maSV)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CHECK_DANGKYLOPTC] @MALTC =" + maLopTC + ", @HK ="+HK+", @NK =N'"+NK+"', @MAMH =N'"+maMH+"', @MASV =N'"+maSV+"' " +
                "SELECT 'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static bool checkAddHocPhi(string NK, int HK, string maSV)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CHECK_ADD_HOCPHI] @HK =" + HK + ", @NK =N'" + NK + "', @MASV =N'" + maSV + "' " +
                "SELECT 'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static bool addHocPhi(string maSV, string NK, int HK, int hocPhi)
        {
            if (checkAddHocPhi(NK, HK, maSV))
            {
                Program.ExecSqlDataReader("INSERT INTO HOCPHI (MASV,NIENKHOA,HOCKY,HOCPHI) VALUES ('" + maSV + "', '" + NK + "', " + HK + ", " + hocPhi + " )");
                if (Program.myReader != null)
                {
                    Program.myReader.Close();
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool checkAddCTDHP(string NK, int HK, string maSV,string date,int soTienDong)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CHECK_ADD_CTDHP] @HK =" + HK + ", @NK =N'" + NK + "', @MASV =N'" + maSV + "', @NGAYDONG ='"+date+"', @SOTIENDONG= "+soTienDong+" "+
                "SELECT 'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public static bool addCTHP(string maSV, string NK, int HK, int soTienDOng,string ngayDong)
        {
            if (checkAddCTDHP(NK, HK, maSV, ngayDong, soTienDOng))
            {
                Program.ExecSqlDataReader("INSERT INTO CT_DONGHOCPHI (MASV,NIENKHOA,HOCKY,NGAYDONG,SOTIENDONG) VALUES ('" + maSV + "', '" + NK + "', " + HK + ", '" + ngayDong + "' ," + soTienDOng + ")");
                if (Program.myReader != null)
                {
                    Program.myReader.Close();
                    return true;
                }

                return false;
            }

            return false;
        }

        public static DataTable getCTHP(string maSV, string NK, int HK)
        {
            return Program.ExecSqlDataTable("EXEC SP_LAY_DS_CTDHP @MASV =N'" + maSV + "', @NK =N'" + NK + "', @HK= " + HK);
        }

        public static bool checkAddLop(string maLop,string tenLop)
        {
            String strLenh = "DECLARE @return_value int " +
                "EXEC @return_value = [dbo].[SP_CHECK_ADD_LOP] @MALOP =N'" + maLop + "', @TENLOP=N'"+tenLop+"' " +
                "SELECT  'Return Value' = @return_value";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader != null)
            {
                int returnValue = 0;
                if (Program.myReader.Read())
                {
                    returnValue = Program.myReader.GetInt32(0);
                }

                Program.myReader.Close();
                if (returnValue == 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
