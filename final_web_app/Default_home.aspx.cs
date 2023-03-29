using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using Encrypt;

namespace final_web_app
{
    public partial class _Default : Page
    {

        static string randomstring;
        static string textToCheck;
        static int captchaLength = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
            LoadCap();
        }
        private byte[] turnImageToByteArray(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
        private void LoadCap()
        {
            captchaservice.ServiceClient cap = new captchaservice.ServiceClient();
            // System.Diagnostics.Debug.WriteLine(textToCheck, randomstring);
            textToCheck = randomstring;
            randomstring = stringgenerator(5);
            System.Drawing.Image image = System.Drawing.Image.FromStream(cap.GetImage(randomstring));
            byte[] imgBytes = turnImageToByteArray(image);
            string imgString = Convert.ToBase64String(imgBytes);
            captchaimage.Src = "data:image/jpg;base64," + imgString;


        }

        private String stringgenerator(int length)
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        protected void stringtocheck_TextChanged(object sender, EventArgs e)
        {

        }

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void password_Entered(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {// captcha 
            if (stringtocheck.Text == textToCheck)
            {
                Label1.Text = "Text matched!";
            }
            else
            {
                Label1.Text = "Opss..Text did not match :(";
            }
            stringtocheck.Text = null;

            //captcha end
            verifierappend.Service1Client inputs = new verifierappend.Service1Client();
            search_result = inputs.getxml(name.Text, password.Text);

            verifierappend.Service1Client client = new verifierappend.Service1Client();
            if (!String.IsNullOrWhiteSpace(name.Text) && !String.IsNullOrWhiteSpace(password.Text))
            {

                //string username, ENCRYPTED password, string firstName, string lastName,string jobProfile, string skills, string workExperience, string universityName, float cgpa, string degreeName;
                Boolean success = client.signIn(name.Text, Class1.Encrypt(password.Text), RadioButton1.Checked);
                string word = RadioButton1.Checked ? "staff" : "member";

                if (success)
                {
                    HttpCookie myCookies = new HttpCookie("myCookieId");
                    myCookies["Name"] = name.Text;
                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies); //storing cookies

                    label1.Text = "Signed In as " + word + " " + name.Text + ". You'll be redirected to the staff/member page during assignment 9 ";
                    if (RadioButton1.Checked)
                    { Server.Transfer("StaffView.aspx", true); } //changing display as per user level
                    if (!RadioButton1.Checked)
                    { Server.Transfer("MemberView.aspx", true); }
                }
                else
                {
                    label1.Text = "Invalid Email Id and Password combination for any " + word;
                    RadioButton1.Checked = false;
                }
            }
            else
            {
                label1.Text = "Please enter Email Id and Password to attempt login";

                RadioButton1.Checked = false;
            }


        }
    }


}