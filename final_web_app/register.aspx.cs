using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using Encrypt;


namespace final_web_app
{
    public partial class Contact : Page
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
            System.Diagnostics.Debug.WriteLine(textToCheck, randomstring);
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



       

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void phoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void zip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void city_TextChanged(object sender, EventArgs e)
        {

        }

        protected void state_TextChanged(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            verifierappend.Service1Client inputs = new verifierappend.Service1Client();
            inputs.addUser(name.Text, Class1.Encrypt(password.Text), email.Text, phoneNumber.Text, zip.Text, city.Text, state.Text);
        }

        protected void stringtocheck_TextChanged(object sender, EventArgs e)
        {

        }
    }
}