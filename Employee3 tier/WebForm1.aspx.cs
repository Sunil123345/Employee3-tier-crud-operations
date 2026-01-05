using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;

namespace Employee3_tier
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BLL objbll = new BLL();
        Dll objdal = new Dll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindGrid();
            }

        }

        private void BindGrid()
        {
            DataTable dt = objbll.GetAllEmployees();
            gridemp.DataSource = dt;
            gridemp.DataBind();
        }


        private void BindCountries()
        {
            DataTable dt = objbll.Getcountries();
            ddlcountry.DataSource = dt;
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataBind();

            ddlcountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(ddlcountry.SelectedValue);
            DataTable dt = objbll.Getstates(cid);
            ddlstate.DataSource = dt;
            ddlstate.DataTextField = "stname";
            ddlstate.DataValueField = "stid";
            ddlstate.DataBind();

            ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stid = Convert.ToInt32(ddlstate.SelectedValue);
            DataTable dt = objbll.Getcities(stid);
            ddlcity.DataSource = dt;
            ddlcity.DataTextField = "cityname";
            ddlcity.DataValueField = "cityid";
            ddlcity.DataBind();

            ddlcity.Items.Insert(0, new ListItem("--Select City--", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Empid = Convert.ToInt32(txtEmpid.Text);
            string Empname = txtEmpname.Text;
            string Email = txtEmail.Text;
            double salary = Convert.ToDouble(txtSalary.Text);
            int cid = Convert.ToInt32(ddlcountry.SelectedValue);
            int stid = Convert.ToInt32(ddlstate.SelectedValue);
            int cityid = Convert.ToInt32(ddlcity.SelectedValue);

            int i = objbll.InsertEmployee(Empid, Empname, Email, salary, cid, stid, cityid);

            if (i > 0)
            {
                lblmsg.Text = "Employee Inserted Successfully!";
                BindGrid();
            }
            else
            {
                lblmsg.Text = "Insert Failed!";
            }
        }

        private void ClearControls()
        {
            txtEmpid.Text = "";
            txtEmpname.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
            ddlcountry.ClearSelection();
            ddlstate.Items.Clear();
            ddlcity.Items.Clear();

            lblmsg.Text = "";
        }

        //protected void gridemp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int Empid = Convert.ToInt32(gridemp.DataKeys[e.RowIndex].Value);
        //    int i = objbll.DeleteEmployee(Empid);
        //    if(i>0)
        //    {
        //        lblmsg.Text = "Employee Deleted successfully";
        //    }
        //    else
        //    {
        //        lblmsg.Text = "Employee is not Deleted successfully";
        //    }

        //}

        protected void gridemp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(txtEmpid.Text);
            string name = txtEmpname.Text;
            string email = txtEmail.Text;
            double salary = Convert.ToDouble(txtSalary.Text);
            int cid = Convert.ToInt32(ddlcountry.SelectedValue);
            int stid = Convert.ToInt32(ddlstate.SelectedValue);
            int cityid = Convert.ToInt32(ddlcity.SelectedValue);

            int i = objbll.UpdateEmployee(id, name, email, salary, cid, stid, cityid);

            if (i > 0)
            {
                lblmsg.Text = "Employee Updated Successfully!";
                BindGrid();
            }
        }
    }
    }


    
