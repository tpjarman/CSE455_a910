using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSE445_A9A10.AccountService;

namespace CSE445_A9A10
{
    public partial class Default : System.Web.UI.Page
    {
        ControlClient accountService = new ControlClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Result.Text = "";
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if (p5C == null || p5C["Username"] == "" && p5C["Password"] == "")
            {//New User...
                Response.Redirect("~/Login.aspx");
            }
            else
            {//Retrieve existing username and password from cookie.
                //txt_loginUser.Text = p5C["Username"];
                //txt_loginPass.Text = p5C["Password"];
                if (accountService.ValidateStaff(p5C["Username"], p5C["Password"]))
                {//Valid
                    //Response.Redirect("~/Login.aspx");
                }
                else if (accountService.ValidateUser(p5C["Username"], p5C["Password"]))
                {//Valid
                }
                else
                    Response.Redirect("~/Login.aspx");
            }
            int sessionCounter = (int)Application["SessionCounter"];
            lbl_SessionCount.Text = "Session counter is: " + sessionCounter;
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btn_Member_Click(object sender, EventArgs e)
        {
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if (accountService.ValidateUser(p5C["Username"], p5C["Password"]))
            {
                p5C.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(p5C);
                Response.Redirect("~/Members/Members.aspx");
            }
            else if (accountService.ValidateStaff(p5C["Username"], p5C["Password"]))
            {
                p5C.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(p5C);
                Response.Redirect("~/Members/Members.aspx");
            }
            else
            {
                lbl_Result.Text = "Error logging in, as user!";
            }
        }

        protected void btn_Staff_Click(object sender, EventArgs e)
        {
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if (accountService.ValidateStaff(p5C["Username"], p5C["Password"]))
            {
                p5C.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(p5C);
                Response.Redirect("~/Members/Staff.aspx");
            }
            else
            {
                lbl_Result.Text = "Error logging in, as staff!";
            }
        }

        protected void btn_Out_Click(object sender, EventArgs e)
        {
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            p5C.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(p5C);
            Response.Redirect("~/Login.aspx");
        }
    }
}