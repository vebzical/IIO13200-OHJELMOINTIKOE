using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tehtava_4_g2456_teht4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            myIni();
        }
    }

    public void myIni() 
    {
        try
        {
            DataView dv1 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);

            DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            lblInfo.Text = "Eri oppilaita yhteensä: " + dv.Count.ToString() + " Ja ilmoittautumisia yhteensä: " + dv1.Count.ToString();

            GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataBind();

        }
        catch (Exception)
        {
            lblInfo.Text = "Tietokanta yhteys epäonnistui!";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        
            GridView1.DataSourceID = "SqlDataSource4";
            GridView1.DataBind();

        }
        catch (Exception)
        {
            lblInfo.Text = "Tietokanta yhteys epäonnistui!";
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            GridView1.DataSourceID = "SqlDataSource5";
            GridView1.DataBind();

        }
        catch (Exception)
        {
            lblInfo.Text = "Tietokanta yhteys epäonnistui!";
        }
    }
}