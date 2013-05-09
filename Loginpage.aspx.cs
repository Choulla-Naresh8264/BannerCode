using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SampleModel;

public partial class Loginpage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString);

    SampleEntities1 ObjEntity;

    protected void Page_Load(object sender, EventArgs e)
    {

        ObjEntity = new SampleEntities1();
        if (!IsPostBack)
        {
            LoadReligionCombo();
        }

    }
    /*protected void Button1_Click(object sender, EventArgs e)
    {

        var query = (from m in ObjEntity.LOGINs
                     where m.UserName == TxtBox_name.Text && m.Password == TxtBox_Pwd.Text
                     select m).ToList();

        
        if (query.Count==1)
        {

            Response.Write("<script >alert('valid UserName or Password  Go to SignUP')</script>");
        }
        else
        {
            Response.Write("<script >alert('Invalid UserName or Password  Go to SignUP')</script>");
        }


    }*/



    protected void LoadReligionCombo()
    {
        ddl_1.DataSource = ObjEntity.StateDetails;
        ddl_1.DataTextField = "StateName";
        ddl_1.DataValueField = "StateID";
        ddl_1.DataBind();
        ddl_1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(500);//for update panel
        if (int.Parse(ddl_1.SelectedValue) > 0)
        {

            LoadCasteCombo();
        }

    }





    protected void LoadCasteCombo()
    {
        int intReligionID;
        bool blnCheck = int.TryParse(ddl_1.SelectedValue, out intReligionID);

        var query = (from m in ObjEntity.Cities
                     where m.StateID == intReligionID
                     select m).ToList();

        ddl_2.DataSource = query;
        ddl_2.DataTextField = "CityName";
        ddl_2.DataValueField = "CityID";
        ddl_2.DataBind();
        ddl_2.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}