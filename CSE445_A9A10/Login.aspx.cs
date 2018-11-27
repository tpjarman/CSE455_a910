using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSE445_A9A10.AccountService;
using BusinessLogic;

namespace CSE445_A9A10
{
    public partial class _Default : Page
    {
        ControlClient validateService = new ControlClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_result.Text = "";//<p>For member testing use Username:Test Password:Test</p><p>For staff testing use Username:TA Password:Cse445ta!</p>";
            lbl_result2.Text = "";
            //Cookies!:
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if(p5C == null || p5C["Username"] == "" || p5C["Password"] == "")
            {//New User...
                lbl_result.Text = "Welcome New User!";
            }
            else
            {//Retrieve existing username and password from cookie.
                if (!validateService.ValidateStaff(p5C["Username"], p5C["Password"]) || !validateService.ValidateUser(p5C["Username"], p5C["Password"]))
                {//Expire the cookie if it is invalid.
                    p5C.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(p5C);
                }
                else
                {//Have user click in order to use regular login system.
                    txt_loginUser.Text = p5C["Username"];
                    txt_loginPass.Text = SecurityManager.Decrypt(p5C["Password"]); //2b by Tydin Jarman
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string encryptPass = SecurityManager.Encrypt(txt_loginPass.Text); //2b by Tydin Jarman
            if (validateService.ValidateStaff(txt_loginUser.Text, encryptPass/*txt_loginPass.Text*/))
            {
                //HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
                //if (p5C == null)// || p5C["Username"] == "" && p5C["Password"] == "")
                //{//Create cookie when logging in if none exist.
                    HttpCookie p5C = new HttpCookie("P5-A9A10-Cookie");
                    if (p5C["Username"] != txt_loginUser.Text) p5C["Username"] = txt_loginUser.Text;
                    if (p5C["Password"] != txt_loginPass.Text) p5C["Password"] = encryptPass;// txt_loginPass.Text;
                    p5C.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(p5C);
                //}
                lbl_result.Text = "Logging in as Staff...";
                //Response.Redirect("~/Members/Staff.aspx");
                Response.Redirect("~/Default.aspx");
            }
            else if (validateService.ValidateUser(txt_loginUser.Text, encryptPass/*txt_loginPass.Text*/))
            {
                //HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
                //if (p5C == null)// || p5C["Username"] == "" && p5C["Password"] == "")
                //{//Create cookie when logging in if none exist.
                    HttpCookie p5C = new HttpCookie("P5-A9A10-Cookie");
                    if(p5C["Username"] != txt_loginUser.Text) p5C["Username"] = txt_loginUser.Text;
                    if (p5C["Password"] != txt_loginPass.Text) p5C["Password"] = encryptPass;// txt_loginPass.Text;
                    p5C.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(p5C);
                //}
                lbl_result.Text = "Logging in as Member...";
                //Response.Redirect("~/Members/Members.aspx");
                Response.Redirect("~/Default.aspx");
            }/*
            else if(FormsAuthentication.Authenticate(txt_loginUser.Text, txt_loginPass.Text))
            {
                Response.Redirect("~/Members/Members.aspx");
            }*/
            else
            {
                HttpContext.Current.Request.Cookies.Clear();
                lbl_result.Text = "Invalid Account Information!";
                //Update cookie for invalid information to prevent logons, due to cookie when text is wrong.
                HttpCookie p5C = new HttpCookie("P5-A9A10-Cookie");
                p5C["Username"] = txt_loginUser.Text;
                p5C["Password"] = encryptPass;// txt_loginPass.Text;
                p5C.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(p5C);
            }
        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            if (txt_regFirst.Text != "" && txt_regLast.Text != "" && txt_regUser.Text != "" && txt_regPass.Text != "")
            {
                string encryptPass = SecurityManager.Encrypt(txt_regPass.Text); //2b by Tydin Jarman
                if (validateService.CreateUser(txt_regFirst.Text, txt_regLast.Text, txt_regUser.Text, encryptPass/*txt_regPass.Text*/))
                {
                    lbl_result2.Text = "User successfully created!";
                    HttpCookie p5C = new HttpCookie("P5-A9A10-Cookie");
                    p5C["Username"] = txt_regUser.Text;
                    p5C["Password"] = encryptPass;// txt_regPass.Text;
                    p5C.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(p5C);
                }
                else
                    lbl_result2.Text = "User not created!";
            }
            else
                lbl_result2.Text = "Please fill in all details.";
        }
    }
}