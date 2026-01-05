using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class BLL
    {
        Dll objdal = new Dll();

        public DataTable Getcountries()
        {
            return objdal.Getcountries();
        }
        public DataTable Getstates(int cid)
        {
            return objdal.Getstates(cid);
        }
        public DataTable Getcities(int stid)
        {
            return objdal.Getcities(stid);
        }
        public DataTable GetAllEmployees()
        {
            return objdal.GetAllEmployees();
        }

        public int InsertEmployee(int Empid, string Empname, string Email, double salary, int cid, int stid, int cityid)
        {
            return objdal.InsertEmployee(Empid, Empname, Email, salary, cid, stid, cityid);
        }

        public int UpdateEmployee(int Empid, string Empname, string Email, double salary, int cid, int stid, int cityid)
        {
            return objdal.UpdateEmployee(Empid, Empname, Email, salary, cid, stid, cityid);
        }

        public int DeleteEmployee(int Empid)
        {
            return objdal.DeleteEmployee(Empid);
        }


    }
}
