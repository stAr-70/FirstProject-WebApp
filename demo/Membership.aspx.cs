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
    public partial class Membership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populdateCblServices();
            populdateRblMembership();
        }

        protected void populdateRblMembership()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select  MembershipId , Membership from Membership";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            RblMembership.DataValueField = "MembershipId";
            RblMembership.DataTextField = "Membership";
            RblMembership.DataSource = dr;
            RblMembership.DataBind();
        }



        protected void populdateCblServices()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select ServicesId,GymServices from GymServices";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            CblServices.DataValueField = "ServicesId";
            CblServices.DataTextField = "GymServices";
            CblServices.DataSource = dr;
            CblServices.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedMembershipID = RblMembership.SelectedValue;

            foreach (ListItem item in CblServices.Items)
            {
                if (item.Selected)
                {
                    string selectedServiceID = item.Value;


                    CRUD myCrud = new CRUD();
                    string sql = @"insert into MemberSelections (MembershipID, ServicesID)
                           values (@MembershipID, @ServicesID)";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                      {"@MembershipID", selectedMembershipID},
                      {"@ServicesID", selectedServiceID}
                    };

                    myCrud.ExecuteNonQuery(sql, parameters);
                }
            }
        }
    }
}
