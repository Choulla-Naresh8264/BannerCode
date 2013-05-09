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

public partial class Second : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString);

    SampleEntities1 ObjEntity;

    protected void Page_Load(object sender, EventArgs e)
    {
        ObjEntity = new SampleEntities1();

        string TxtName = Convert.ToString(Session["Sessionname"]);
        string TxtDob = Convert.ToString(Session["SessionDOB"]);
        string TxtGender = Convert.ToString(Session["SessionGender"]);
        string Txtreligion = Convert.ToString(Session["SessionReligion"]);
        string TxtMotherTon = Convert.ToString(Session["SessionMotherTon"]);
        string TxtCaste = Convert.ToString(Session["SessionCaste"]);
        string TxtCountry = Convert.ToString(Session["SessionCountry"]);
        string TxtMobile = Convert.ToString(Session["SessionMobile"]);
        string TxtEmail = Convert.ToString(Session["SessionEmail"]);
        string TxtPwd = Convert.ToString(Session["SessionPSW"]);
        Lbl_CountryName.Text = TxtCountry;
        Lbl_CasteName.Text = TxtCaste;

        LoadHigherEduCombo();
        LoadOccupCombo();
        LoadCurrencyCombo();
        SubCaste();
        RegionalSitesn();

        //according to religion caste will be change to dropdown or textbox

        if (Txtreligion == "Hindu")
        {
            Txt_Caste.Visible= false;
            DDL_SubCaste.Visible = true;
        }
        else
        {
            Txt_Caste.Visible = true;
            DDL_SubCaste.Visible = false;
        }

        if (!IsPostBack)
        {
            LoadStarCombo();
            LoadStateCombo();
        }

    }
    //noofchildren
    //protected void NoofChild()
    //{
    //    DDL_NoOfChild.Items.Insert(0, new ListItem("--Select--", "0"));
    //    DDL_NoOfChild.Items.Insert(0, new ListItem("1", 1));

    //}



    //RegionalSites
    protected void RegionalSitesn()
    {
       
    }

    //Education
    protected void LoadHigherEduCombo()
    {
        DDL_HighestEdu.DataSource =  ObjEntity.HighEducations;
        DDL_HighestEdu.DataTextField = "EducationName";
        DDL_HighestEdu.DataValueField = "EducationID";
        DDL_HighestEdu.DataBind();
        DDL_HighestEdu.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //Occupation
    protected void LoadOccupCombo()
    {
        DDL_Occupation.DataSource =  ObjEntity.Occupations;
        DDL_Occupation.DataTextField = "OccupName";
        DDL_Occupation.DataValueField = "OccupID";
        DDL_Occupation.DataBind();
        DDL_Occupation.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //Currency
    protected void LoadCurrencyCombo()
    {
        DDL_IncomeType.DataSource =  ObjEntity.Currencies;
        DDL_IncomeType.DataTextField = "CurrName";
        DDL_IncomeType.DataValueField = "CurrID";
        DDL_IncomeType.DataBind();
        DDL_IncomeType.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //State
    protected void LoadStateCombo()
    {
        DDL_State.DataSource =  ObjEntity.StateDetails;
        DDL_State.DataTextField = "StateName";
        DDL_State.DataValueField = "StateID";
        DDL_State.DataBind();
        DDL_State.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void DDL_State_SelectedIndexChanged1(object sender, EventArgs e)
    {
        LoadCityCombo();
    }

    //City
    protected void LoadCityCombo()
    {
        int intStateID;
        bool blnCheck = int.TryParse(DDL_State.SelectedValue, out intStateID);

        var query = (from m in  ObjEntity.Cities
                     where m.StateID == intStateID
                     select m).ToList();

        DDL_City.DataSource = query;
        DDL_City.DataTextField = "CityName";
        DDL_City.DataValueField = "CityID";
        DDL_City.DataBind();
        DDL_City.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //SubCaste
    protected void SubCaste()
    {

        
    }

    //Star
    protected void LoadStarCombo()
    {
        DDL_Star.DataSource =  ObjEntity.StarDetails;
        DDL_Star.DataTextField = "StarName";
        DDL_Star.DataValueField = "StarID";
        DDL_Star.DataBind();
        DDL_Star.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void DDL_Star_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRasiCombo();
    }

    //Rassi
    protected void LoadRasiCombo()
    {
        int intRasiID;
        bool blnCheck = int.TryParse(DDL_Star.SelectedValue, out intRasiID);

        var query = (from m in ObjEntity.Raasis
                     where m.StarID == intRasiID
                     select m).ToList();

        DDL_Moon.DataSource = query;
        DDL_Moon.DataTextField = "RaasiName";
        DDL_Moon.DataValueField = "RaasiID";
        DDL_Moon.DataBind();
        DDL_Moon.Items.Insert(0, new ListItem("--Select--", "0"));

        
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        SqlTransaction Transaction;
        con.Open();
        Transaction = con.BeginTransaction();
      /*  try
        {
            
            new SqlCommand("INSERT INTO Transact VALUES ('" + Convert.ToString(Session["Sessionname"]) + "','" + Convert.ToString(Session["SessionDOB"]) + "','" + Convert.ToString(Session["SessionGender"]) + "','" + Convert.ToString(Session["SessionMobile"]) + "','" + Convert.ToString(Session["SessionCountry"]) + "','" + DDL_State.SelectedItem + "','" + DDL_City.SelectedItem + "','" + Convert.ToString(Session["SessionReligion"]) + "','" + Convert.ToString(Session["SessionCaste"]) + "','" + DDL_SubCaste.SelectedItem + "','" + Txt_Gothram.Text + "','" + Convert.ToString(Session["SessionEmail"]) + "','" + Rbtn_PhysicalStatus.SelectedValue + "','" + Txt_Desc.Text + "');", con, Transaction).ExecuteNonQuery();

            new SqlCommand("INSERT INTO EduDetails values ('" + Txt_Height.Text + "','" + DDL_Occupation.SelectedItem + "','" + Rbtn_EmpIn.SelectedValue + "','" + Rbtn_IncomeType.SelectedValue + "','" + DDL_IncomeType.SelectedItem + "','" + Txt_Amount.Text + "');", con, Transaction).ExecuteNonQuery();

            new SqlCommand("INSERT INTO Habit values('" + Rbtn_Food.SelectedValue + "','" + Rbtn_Smoking.SelectedValue + "','" + Rbtn_Drinking.SelectedValue + "');", con, Transaction).ExecuteNonQuery();

            new SqlCommand("INSERT INTO AstrologicalInfo values('" + Rbtn_Dhosam.SelectedValue + "','" + DDL_Star.SelectedItem + "','" + DDL_Moon.SelectedItem + "');", con, Transaction).ExecuteNonQuery();

            new SqlCommand("insert into Family values('" + Rbtn_familystatus.SelectedValue + "','" + Rbtn_FamType.SelectedValue + "','" + Rbtn_FamValue.SelectedValue + "');", con, Transaction).ExecuteNonQuery();

            Transaction.Commit();

        }


        catch
        {
            Transaction.Rollback();
        }
        con.Close();*/
    }

   


    protected void Rbtn_MartialStatus1_CheckedChanged(object sender, EventArgs e)
    {
              
            Lbl_Child.Visible = false;
            DDL_NoOfChild.Visible = false;
            Rbtn_ChildLiving1.Visible = false;
            Rbt_childLiving2.Visible = false;
        
    }
    protected void Txt_Desc_TextChanged(object sender, EventArgs e)
    {



    }
    protected void Rbtn_MartialStatus2_CheckedChanged(object sender, EventArgs e)
    {

        Lbl_Child.Visible = true;
        DDL_NoOfChild.Visible = true;
        Rbtn_ChildLiving1.Visible = true;
        Rbt_childLiving2.Visible = true;
    }
    protected void Rbtn_MartialStatus3_CheckedChanged(object sender, EventArgs e)
    {

        Lbl_Child.Visible = true;
        DDL_NoOfChild.Visible = true;
        Rbtn_ChildLiving1.Visible = true;
        Rbt_childLiving2.Visible = true;
    }
    protected void Rbtn_MartialStatus4_CheckedChanged(object sender, EventArgs e)
    {

        Lbl_Child.Visible = true;
        DDL_NoOfChild.Visible = true;
        Rbtn_ChildLiving1.Visible = true;
        Rbt_childLiving2.Visible = true;
    }



}


