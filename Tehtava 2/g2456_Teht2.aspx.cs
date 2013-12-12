using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tehtava_2_g2456_Teht2 : System.Web.UI.Page
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
        string path = ConfigurationManager.AppSettings["path"];
        int palkka = 0;
        int vakkarit = 0;

        tyontekijat kaikki = new tyontekijat();
        List<tyontekija> tekijat = new List<tyontekija>();

        BLteht2.DeSerialisoiXml(path, ref kaikki);

        foreach (tyontekija item in kaikki.tekija)
        {
            tekijat.Add(item);
        }

        grdtekijat.DataSource = tekijat;
        grdtekijat.DataBind();

        foreach (tyontekija item in tekijat)
        {
            if (item.tyosuhde == "vakituinen")
            {
                vakkarit++;
                palkka += item.palkka;
            }
        }

        lbltekijat.Text = "Vakituisia yhteensä: "+vakkarit;
        lblpalkat.Text = "Ja ne saavat palkkaa yhteensä: "+palkka;
    }
}