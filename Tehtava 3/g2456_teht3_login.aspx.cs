using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tehtava_3_g2456_teht3_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
        else
        {

        }
    }

    protected void LoginWindow_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (BLteht3.authenticateUser(
            BLteht3.regexString(LoginWindow.UserName.ToString(), "userName"),
            BLteht3.regexString(LoginWindow.Password.ToString(), "password")))
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }
    protected void LoginWindow_LoginError(object sender, EventArgs e)
    {
        Session["UserAuthentication"] = null;
    }
    protected void LoginWindow_LoggedIn(object sender, EventArgs e)
    {
        var response = base.Response;

        Session["UserAuthentication"] = LoginWindow.UserName.ToString();
        response.Redirect("~/Tehtava 3/g2456_teht3_mainpage.aspx");
    }
}