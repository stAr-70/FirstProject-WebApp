using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sarah10415WebApp.App_Code;

namespace Sarah10415WebApp.demo
{
    public partial class client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                populdateDdlCity();
            }
            
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        public void populdateDdlCity()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select CityId,City from City";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCity.DataValueField = "CityId";
            ddlCity.DataTextField = "City";
            ddlCity.DataSource = dr;
            ddlCity.DataBind();
        }

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtFName.Text))
            {
                LblOutput.Text = "Please fill First Name field!";
                LblOutput.ForeColor = System.Drawing.Color.Red;
                txtFName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtLName.Text))
            {
                LblOutput.Text = "Please fill Last Name field!";
                LblOutput.ForeColor = System.Drawing.Color.Red;
                txtLName.Focus();
                return;
            }

            CRUD myCrud = new CRUD();
            string mySql = @"insert client (fName,lName,emeil,active,CityId)
                   values (@fName,@lName,@emeil,@active,@CityId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@fName",txtFName.Text);
            myPara.Add("@lName",txtLName.Text);
            myPara.Add("@emeil",txtEmeil.Text);
            myPara.Add("@active",cbActive.Checked);
            myPara.Add("@CityId",ddlCity.SelectedValue);
           

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if(rtn >= 1)
            { LblOutput.Text = "Operation Successful !"; }
            else
            { LblOutput.Text = "Operation Failed !"; }

            populateGvClient();
        }

        protected void btnGetClientInfo_Click(object sender, EventArgs e)
        {
            populateGvClient();
        }

        protected void populateGvClient()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from v_clientInfo4";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvClientInfo.DataSource = dr;
            gvClientInfo.DataBind();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"delete client
                             where clientId =@clientId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@clientId", txtClientId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                LblOutput.Text = "Operation Successful !";
            }
            else
            { 
                LblOutput.Text = "Operation Failed !";
            }

            populateGvClient();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"update client
                      set fName =@fName,lName =@lName,emeil = @emeil,active = @active,CityId =@CityId
                      where clientId = @clientId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@clientId",int.Parse(txtClientId.Text));                        // conv  from string to int
            myPara.Add("@fName", txtFName.Text);
            myPara.Add("@lName", txtLName.Text);
            myPara.Add("@emeil", txtEmeil.Text);
            myPara.Add("@active", cbActive.Checked);
            myPara.Add("@CityId", ddlCity.SelectedValue);
           
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { LblOutput.Text = "Operation Successful !"; }
            else
            { LblOutput.Text = "Operation Failed !"; }

            populateGvClient();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtClientId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmeil.Text = "";
            cbActive.Checked = false;           
        }

        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @" select clientId,fName,lName,emeil,active,CityId
                             from client
                             where clientId = @clientId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@clientId", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String clientId = dr["clientId"].ToString();
                        String fName = dr["fName"].ToString();
                        String lName = dr["lName"].ToString();
                        String emeil = dr["emeil"].ToString();
                        bool active = bool.Parse(dr["active"].ToString());
                        String CityId = dr["CityId"].ToString();
                       

                        txtClientId.Text = clientId;
                        txtFName.Text = fName;
                        txtLName.Text = lName;
                        txtEmeil.Text = emeil;
                        cbActive.Checked = active;
                        ddlCity.SelectedValue = CityId;
                        
                    }
                }
            }
        }

        public static void ExportGridToExcel(GridView myGv) // working 1
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "ExportedReport_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            myGv.GridLines = GridLines.Both;
            myGv.HeaderStyle.Font.Bold = true;
            myGv.RenderControl(htmltextwrtter);
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvClientInfo);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/demo/GymServices");
        }


    } //cls
} //ns