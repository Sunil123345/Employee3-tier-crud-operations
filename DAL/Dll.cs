using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dll
    {
        public int Empid { get; set; }
        public string Empname { get; set; }

        public string Email { get; set; }
        public double salary { get; set; }

        public int cid { get; set; }
        public int stid { get; set; }
        public int cityid { get; set; }

        SqlConnection conn = new SqlConnection("Server=DESKTOP-U0SB5MV\\SUNILEXPRESS;database=employee3;uid=sa;pwd=abc;");
        SqlCommand cmd;

        public DataTable Getcountries()
        {
            cmd = new SqlCommand("SELECT * FROM Country", conn);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Getstates(int cid)
        {
            cmd = new SqlCommand("Select * from State where cid=@cid", conn);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Getcities(int stid)
        {
            cmd = new SqlCommand("Select * from City where stid=@stid", conn);
            cmd.Parameters.AddWithValue("@stid", stid);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable GetAllEmployees()
        {
            cmd = new SqlCommand(@"
        SELECT e.Empid, e.Empname, e.Email, e.salary,
               c.cname, s.stname, ct.cityname
        FROM employee3 e
        INNER JOIN country c ON e.cid = c.cid
        INNER JOIN state s ON e.stid = s.stid
        INNER JOIN city ct ON e.city = ct.cityid", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int InsertEmployee(int Empid, string Empname, string Email, double salary, int cid, int stid, int cityid)
        {
            cmd = new SqlCommand("insert into employee3(Empid,Empname,Email,salary,cid,stid,city) " +
                     "values(@Empid,@Empname,@Email,@salary,@cid,@stid,@city)", conn);
            cmd.Parameters.AddWithValue("@Empid", Empid);
            cmd.Parameters.AddWithValue("@Empname", Empname);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@stid", stid);
            cmd.Parameters.AddWithValue("@city", cityid);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }


        public int UpdateEmployee(int Empid, string Empname, string Email, double salary, int cid, int stid, int cityid)
        {
            cmd = new SqlCommand(@"update employee set Empname=@Empname,Email=@Email,salary=@salary,cid=@cid,stid=@stid,cityid=@cityid,where Empid=@Empid", conn);
            cmd.Parameters.AddWithValue("@Empid", Empid);
            cmd.Parameters.AddWithValue("@Empname", Empname);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@stid", stid);
            cmd.Parameters.AddWithValue("@cityid", cityid);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }


        public int DeleteEmployee(int Empid)
        {
            cmd = new SqlCommand("delete from employee3 where Empid=@Empid", conn);
            cmd.Parameters.AddWithValue("@Empid", Empid);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }


    }
}
