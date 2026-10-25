using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sarah10415WebApp.App_Code;

namespace Sarah10415WebApp.demo
{
    public partial class myDdlCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatecblGymServices();
                populaterblMembership();
            }


        }

        public void populaterblMembership()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select  MembershipId , Membership from Membership";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            rblMembership.DataValueField = "MembershipId";
            rblMembership.DataTextField = "Membership";
            rblMembership.DataSource = dr;
            rblMembership.DataBind();
        }

        public void populatecblGymServices()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select ServicesId,GymServices from GymServices";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            cblGymServices.DataValueField = "ServicesId";
            cblGymServices.DataTextField = "GymServices";
            cblGymServices.DataSource = dr;
            cblGymServices.DataBind();
        }



          protected void btnSubmit_Click(object sender, EventArgs e)
          {
              if (String.IsNullOrEmpty(txtUserId.Text))
              {
                  LblOutput.Text = "Please Enter your Id!";
                  LblOutput.ForeColor = System.Drawing.Color.Red;
                  txtUserId.Focus();
                  return;
              }
              if (String.IsNullOrEmpty(rblMembership.SelectedValue))
              {
                  LblOutput.Text = "Please choose your Membership!";
                  LblOutput.ForeColor = System.Drawing.Color.Red;
                  rblMembership.Focus();
                  return;
              }
              if (String.IsNullOrEmpty(cblGymServices.Text))
              {
                  LblOutput.Text = "Please choose at least one Service!";
                  LblOutput.ForeColor = System.Drawing.Color.Red;
                  cblGymServices.Focus();
                  return;
              }

               string selectedServices = "";    // declare variable to capture selected items from cbl 
              for (int i = 0; i < cblGymServices.Items.Count; i++)    // you need to loop checkBoxList to capture the selected values 
              {
                if (cblGymServices.Items[i].Selected)
                  //selectedHobby += cblGymServices.Items[i].Value.ToString() + ","; // capture the value only
                  selectedServices += cblGymServices.Items[i].Text + ",";   // capture the Text instead of the value 
              }

            // LblOutput.Text = txtUserId.Text + " selected :  " + selectedServices.TrimEnd(',');
            // LblOutput.ForeColor = System.Drawing.Color.Red;

             CRUD myCrud = new CRUD();

             string mySql = @"insert into UserServices (ServicesId,MembershipId)
                      values (@ServicesId,@MembershipId)";
             Dictionary<string, object> myPara = new Dictionary<string, object>();
            // myPara.Add("@UserId", txtUserId.Text);
             myPara.Add("@ServicesId", selectedServices.TrimEnd(','));
             myPara.Add("@MembershipId", rblMembership.SelectedValue);
             int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
             if (rtn >= 1)
             { LblOutput.Text = "Operation Successful"; }
             else
             { LblOutput.Text = "Operation Failed"; } 
           
            /* CRUD myCrud = new CRUD();

            for (int i = 0; i < cblGymServices.Items.Count; i++)
            {
                if (cblGymServices.Items[i].Selected)
                {
                    string mySql = @"INSERT INTO UserServices (ServicesId, MembershipId)
                         VALUES (@ServicesId, @MembershipId)";

                    Dictionary<string, object> myPara = new Dictionary<string, object>();
                    myPara.Add("@ServicesId", cblGymServices.Items[i].Value);
                    myPara.Add("@MembershipId", rblMembership.SelectedValue);

                    myCrud.InsertUpdateDelete(mySql, myPara);
                }
            }

            LblOutput.Text = "Operation Successful";*/
        }
       

    }// cls
}// ns