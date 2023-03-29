using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_web_app
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            CreateAccountService.Service1Client client = new CreateAccountService.Service1Client();
            if (!String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                //string username, string password, string firstName, string lastName,string jobProfile, string skills, string workExperience, string universityName, float cgpa, string degreeName
                Boolean success = client.signIn(textBox2.Text, textBox1.Text, RadioButton1.Checked);
                string word = RadioButton1.Checked ? "employer" : "applicant";
                if (success)
                {

                    label1.Text = "Signed In as " + word + " " + textBox2.Text;
                    if (RadioButton1.Checked)
                    { Server.Transfer("EmployerView.aspx", true); }
                    if (!RadioButton1.Checked)
                    { Server.Transfer("ApplicantView.aspx", true); }
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