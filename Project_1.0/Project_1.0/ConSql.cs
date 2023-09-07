using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Project_1._0
{

    class ConSql
    {
        public static SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-AM917UE\SQLEXPRESS; Initial Catalog = a1 ;Integrated Security = SSPI ");
        public  static SqlCommand com;

        public static void Zapros(string S)
        {
            con.Open();
            com = new SqlCommand(S, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable otr(string S)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(S, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return (ds.Tables[0]);
        }

        public static string GetData (string S)
        {
            con.Open();
            com = new SqlCommand(S, con);
            string data = (string)com.ExecuteScalar();
            con.Close();
            return (data);
        }

        public static double GetData_2(string S) 
        {
            con.Open();
            com = new SqlCommand(S, con);
            double data = (double)com.ExecuteScalar();
            con.Close();
            return (data);
        }

        public static string[] FioDeterminate(string s)
        {
            string[] FIO = new string[3];
            int k;

            for (int i = 0; i < 3; i++)
            {
                if (i<2)
                {
                    k = s.IndexOf(" ");
                    FIO[i] = s.Substring(0, k);
                    s = s.Remove(0, k + 1);
                }
                if (i == 2)
                {
                    FIO[i] = s;
                }
            }
            return (FIO);
        }

    }
}
