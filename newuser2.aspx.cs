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

public partial class newuser2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString);

    SampleEntities1 ObjEntity;


    protected void Page_Load(object sender, EventArgs e)
    {
        ObjEntity = new SampleEntities1();

        
        

        if (!IsPostBack)
        {
            LoadProfileForCombo();
            LoadReligionCombo();
            LoadCountryCombo();
            LoadMotherTongueCombo();
        }
    }

    // populate profileFor
    protected void LoadProfileForCombo()
    {
        DDl_ProfileFor.Items.Insert(0, new ListItem("--Select--", "0"));
        DDl_ProfileFor.Items.Insert(1, new ListItem("Myself", "1"));
        DDl_ProfileFor.Items.Insert(2, new ListItem("Son", "2"));
        DDl_ProfileFor.Items.Insert(3, new ListItem("Daughter", "3"));
        DDl_ProfileFor.Items.Insert(4, new ListItem("Brother", "4"));
        DDl_ProfileFor.Items.Insert(5, new ListItem("Sister", "5"));
        DDl_ProfileFor.Items.Insert(6, new ListItem("Friend", "6"));
        DDl_ProfileFor.Items.Insert(7, new ListItem("Relative", "7"));
    }

    //Populate Religion
    protected void LoadReligionCombo()
    {
        DDL_Religion.DataSource = ObjEntity.Religions;
        DDL_Religion.DataTextField = "ReligionName";
        DDL_Religion.DataValueField = "ReligionId";
        DDL_Religion.DataBind();
        DDL_Religion.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //Mother Tongue
    protected void LoadMotherTongueCombo()
    {
        DDL_MotherTongue.DataSource = ObjEntity.MotherTongues;
        DDL_MotherTongue.DataTextField = "TongueName";
        DDL_MotherTongue.DataValueField = "TongueID";
        DDL_MotherTongue.DataBind();
        DDL_MotherTongue.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //Caste
    protected void LoadCasteCombo()
    {
        int intReligionID;
        bool blnCheck = int.TryParse(DDL_Religion.SelectedValue, out intReligionID);

        var query = (from m in ObjEntity.Castes
                     where m.ReligionID == intReligionID
                     select m).ToList();

        DDL_Caste.DataSource = query;
        DDL_Caste.DataTextField = "CasteName";
        DDL_Caste.DataValueField = "CasteID";
        DDL_Caste.DataBind();
        DDL_Caste.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //Country
    protected void LoadCountryCombo()
    {
        DDL_Country.DataSource = ObjEntity.Countries;
        DDL_Country.DataTextField = "CountryName";
        DDL_Country.DataValueField = "CountryID";
        DDL_Country.DataBind();
        DDL_Country.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //CountryCode
    protected void LoadCountryCodeCombo()
    {
        int intCountryID;
        bool blnCheck = int.TryParse(DDL_Country.SelectedValue, out intCountryID);

        var query = (from m in ObjEntity.Countries
                     where m.CountryID == intCountryID
                     select m).ToList();

        DDL_MobileCode.DataSource = query;
        DDL_MobileCode.DataTextField = "CountryCode";
        DDL_MobileCode.DataValueField = "CountryName";
        DDL_MobileCode.DataBind();
        
    }


    protected void DDL_Religion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCasteCombo();

    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {


        Session["Sessionname"] = Txt_Name.Text.ToString();
       // Session["SessionGender"] = Rbtn_Gender.SelectedValue;
       // Session["SessionDOB"] = Txt_DOB.Text.ToString();
        Session["SessionReligion"] = DDL_Religion.SelectedItem;
        Session["SessionMotherTon"] = DDL_MotherTongue.SelectedItem;
        //Session["SessionCaste"] = DDL_Caste.SelectedValue.ToList();
        Session["SessionCaste"] = DDL_Caste.SelectedItem;
        Session["SessionCountry"] = DDL_Country.SelectedItem;
        Session["SessionMobile"] = Txt_Phoneno.Text;
        Session["SessionEmail"] = Txt_Mail.Text;
        Session["SessionPSW"] = Txt_Pwd.Text;
        Response.Redirect("Second.aspx");
    }

    protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCountryCodeCombo();
    }



    

    protected void DDl_ProfileFor_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DDl_ProfileFor.SelectedItem.Text == "Son" || DDl_ProfileFor.SelectedItem.Text == "Brother")
        {
            Lblname.Text = "Groom's Name";
            LblGender.Text = "Gender";
        }
        

        if (DDl_ProfileFor.SelectedItem.Text == "Daughter" || DDl_ProfileFor.SelectedItem.Text == "sister")
        {
            Lblname.Text = " Bride's Name";
            LblGender.Text = "Gender";
        }

        if (DDl_ProfileFor.SelectedItem.Text == "myself" || DDl_ProfileFor.SelectedItem.Text == "Relative" || DDl_ProfileFor.SelectedItem.Text == "Friends")
        {
            Lblname.Text = "  Name";
            LblGender.Text = " Matrimony profile for";
        }

    }

    private void PopulateDay()
    {
        ddlDay.Items.Clear();
        ListItem lt = new ListItem();
        lt.Text = "DD";
        lt.Value = "0";
        ddlDay.Items.Add(lt);
        int days = DateTime.DaysInMonth(this.Year, this.Month);
        for (int i = 1; i <= days; i++)
        {
            lt = new ListItem();
            lt.Text = i.ToString();
            lt.Value = i.ToString();
            ddlDay.Items.Add(lt);
        }
        ddlDay.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
    }




    private void PopulateMonth()
    {
        ddlMonth.Items.Clear();
        ListItem lt = new ListItem();
        lt.Text = "MM";
        lt.Value = "0";
        ddlMonth.Items.Add(lt);
        for (int i = 1; i <= 12; i++)
        {
            lt = new ListItem();
            lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
            lt.Value = i.ToString();
            ddlMonth.Items.Add(lt);
        }
        ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
    }

    private void PopulateYear()
    {
        ddlYear.Items.Clear();
        ListItem lt = new ListItem();
        lt.Text = "YYYY";
        lt.Value = "0";
        ddlYear.Items.Add(lt);
        for (int i = DateTime.Now.Year; i >= 1950; i--)
        {
            lt = new ListItem();
            lt.Text = i.ToString();
            lt.Value = i.ToString();
            ddlYear.Items.Add(lt);
        }
        ddlYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
    }

    private int Day
    {
        get
        {
            if (Request.Form[ddlDay.UniqueID] != null)
            {
                return int.Parse(Request.Form[ddlDay.UniqueID]);
            }
            else
            {
                return int.Parse(ddlDay.SelectedItem.Value);
            }
        }
        set
        {
            this.PopulateDay();
            ddlDay.ClearSelection();
            ddlDay.Items.FindByValue(value.ToString()).Selected = true;
        }
    }
    private int Month
    {
        get
        {
            return int.Parse(ddlMonth.SelectedItem.Value);
        }
        set
        {
            this.PopulateMonth();
            ddlMonth.ClearSelection();
            ddlMonth.Items.FindByValue(value.ToString()).Selected = true;
        }
    }
    private int Year
    {
        get
        {
            return int.Parse(ddlYear.SelectedItem.Value);
        }
        set
        {
            this.PopulateYear();
            ddlYear.ClearSelection();
            ddlYear.Items.FindByValue(value.ToString()).Selected = true;
        }
    }

    public DateTime SelectedDate
    {
        get
        {
            try
            {
                return DateTime.Parse(this.Month + "/" + this.Day + "/" + this.Year);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        set
        {
            if (!value.Equals(DateTime.MinValue))
            {
                this.Year = value.Year;
                this.Month = value.Month;
                this.Day = value.Day;
            }
        }
    }
 




}

