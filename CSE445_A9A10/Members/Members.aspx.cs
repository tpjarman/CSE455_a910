using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //Rest
using System.Runtime.Serialization; //Rest
using CSE445_A9A10.AccountService;
using BusinessLogic;

namespace CSE445_A9A10.Members
{
    public partial class Members : System.Web.UI.Page
    {
        ControlClient accountService = new ControlClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblConvertedTemp.Text = "";
            //Cookies:
            HttpCookie p5C = Request.Cookies["P5-A9A10-Cookie"];
            if(p5C == null || p5C["Username"] == "" && p5C["Password"] == "")
            {//New User...
                Response.Redirect("~/Login.aspx");
            }
            else
            {//Retrieve existing username and password from cookie.
                //txt_loginUser.Text = p5C["Username"];
                //txt_loginPass.Text = p5C["Password"];
                if (accountService.ValidateStaff(p5C["Username"], p5C["Password"]))
                {//Valid
                }
                else if (accountService.ValidateUser(p5C["Username"], p5C["Password"]))
                {//Valid
                }
                else
                    Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {//http://localhost:49635/RestfulTempService.svc/TemperatureConversion?type=0&temp=15 test
            //lblConvertedTemp.Text = service.TemperatureConversion(lstConversions.SelectedValue, txtTemperature);
            string baseUri = "http://webstrar55.fulton.asu.edu/page4/RestfulTempService.svc/TemperatureConversion?";//type=0&temp=15)'
            baseUri += "type=" + lstConversions.SelectedValue + "&temp=" + txtTemperature.Text;
            float result = 0.0f;
            System.Net.WebClient client = new System.Net.WebClient();
            byte[] abc = client.DownloadData(baseUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(float));
            lblConvertedTemp.Text = obj.ReadObject(strm).ToString();
        }

        protected void btn_Main_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}