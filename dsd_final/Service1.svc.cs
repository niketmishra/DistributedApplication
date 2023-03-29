using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Web.Hosting;
using System.Net.Mail;
using System.Net;

namespace dsd_final
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {


        public void addUser(string name, string password, string email, string phoneNumber, string zip, string city, string state,
             string jobProfile, string skills, string workExperience, string universityName, string cgpa, string degreeName)
        {
            string xmlFilePath = (HostingEnvironment.MapPath(@"/Page8/App_Data/members.xml"));
            XDocument doc;
            try // checking if file exists
            {
                doc = XDocument.Load(xmlFilePath);
            }
            catch (Exception exc) // creating new file if not found
            {
                doc = new XDocument(new XElement("members"));
            }
            XElement members = doc.Element("members");
            if (members == null) doc = new XDocument(members = new XElement("members")); // creating new element if it doesn't exist

            //creating a structure for the user element
            XElement member = new XElement("member",
                                new XElement("name", name),
                                new XElement("Password", password),
                                new XElement("email", email),
                                new XElement("Phone", phoneNumber),
                                new XElement("zip", zip),
                                new XElement("city", city),
                                new XElement("state", state),
                                new XElement("jobProfile", jobProfile),
                                new XElement("skills", skills),
                                new XElement("workExperience", workExperience),
                                new XElement("universityName", universityName),
                                new XElement("cgpa", cgpa),
                                new XElement("degreeName", degreeName)

                    );



            members.Add(member);
            // saving the updates to the xml file
            doc.Save(xmlFilePath);
        }

        public Boolean signIn(string username, string password, bool isAdmin)
        {
            bool success = false;
            try
            {
                if (isAdmin && username == "admin" && password == "admin")
                    success = true;

                else if (!isAdmin)
                {

                    string xmlFilePath = (HostingEnvironment.MapPath(@"/Page8/App_Data/users.xml"));
                    var stringBuilder = new StringBuilder();
                    StringBuilder str = new StringBuilder();
                    try
                    {

                        System.Diagnostics.Debug.WriteLine("File Path:", xmlFilePath);
                        XDocument doc;
                        doc = XDocument.Load(xmlFilePath);

                        foreach (XElement node in doc.Descendants("name"))
                        {
                            string name = node.Value;
                            //System.Diagnostics.Debug.WriteLine("Current User:", username);

                            if (name == username)
                            {
                                // System.Diagnostics.Debug.WriteLine("Found name! Gathering details");
                                XElement parent = node.Parent;


                                if (parent.Descendants("password").FirstOrDefault().Value == password)
                                {
                                    return success = true;
                                }

                            }
                        }
                        str.Append("No node found");
                        return success = false;
                    }
                    catch (Exception)
                    {
                        return success = false;
                    }




                }
            }} }
                  
   
}
