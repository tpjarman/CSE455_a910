using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSE445_A9A10.AccountService;
using BusinessLogic;

namespace CSE445_A9A10.Members
{
    public partial class Staff : System.Web.UI.Page
    {
        ControlClient accountService = new ControlClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Members.Text = "";
            lbl_Result.Text = ""; //For use by add/remove user
            //Cookies!:
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if(p5C == null || p5C["Username"] == "" && p5C["Password"] == "")
            {//New User...
                Response.Redirect("~/Login.aspx");
            }
            else
            {//Retrieve existing username and password from cookie.
                //txt_loginUser.Text = p5C["Username"];
                //txt_loginPass.Text = p5C["Password"];
                if(accountService.ValidateStaff(p5C["Username"], p5C["Password"]))
                {//Valid
                }
                else
                    Response.Redirect("~/Login.aspx");
            }
        }

        protected void btn_ShowMembers_Click(object sender, EventArgs e)
        {
            string[] members;
            members = accountService.ListMembers();
            if (members.Length == 0)
                lbl_Members.Text = "No Members!";
            else
            {
                foreach (string mem in members)
                {//Add every member as a html paragraph.
                    lbl_Members.Text += "<p>" + mem + "</p>";
                }
            }
        }

        protected void btn_AddUser_Click(object sender, EventArgs e)
        {//Default username = first+last, default password = last+first;
            if (accountService.CreateUser(txt_AddFirst.Text, txt_AddLast.Text, txt_AddFirst.Text + txt_AddLast.Text, SecurityManager.Encrypt(txt_AddLast.Text + txt_AddFirst.Text)))
            {
                lbl_Result.Text = "New User Created! Inform User(Username:" + txt_AddFirst.Text + txt_AddLast.Text + ", Password:" + txt_AddLast.Text + txt_AddFirst.Text + ").";
            }
            else
                lbl_Result.Text = "Error creating user!";
        }

        protected void btn_RemoveUser_Click(object sender, EventArgs e)
        {//Remove user's with matching name or return error if none found.
            if(accountService.RemoveUser(txt_AddFirst.Text, txt_AddLast.Text))
            {
                lbl_Result.Text = "User:" + txt_AddFirst.Text + ", " + txt_AddLast.Text + " Removed!";
            }
            else
                lbl_Result.Text = "User not found!";
        }

        protected void btn_Main_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}