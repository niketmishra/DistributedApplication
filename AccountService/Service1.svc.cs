using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace AccountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public class UsersRootObject
        {
            public User[] users { get; set; } // Array of users
        }

        // User class object
        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class ResumeRootObject
        {
            public Resume[] resumes { get; set; }
        }

        public class Resume
        {
            public string username { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string mobileNumber { get; set; }
            public string address { get; set; }
            public string jobProfile { get; set; }
            public string skills { get; set; }
            public string workExperience { get; set; }
            public string universityName { get; set; }
            public string cgpa { get; set; }
            public string degreeName { get; set; }

        }

        // Accepts username and password as parameters. Encrypts passwords and stores in a JSON file.
        // Creates an account; checks if the username already exists
        public Boolean createAccount(string username, string password, string firstName, string lastName, string mobileNumber, string address, string jobProfile, string skills, string workExperience, string universityName, string cgpa, string degreeName)
        {
            User newUser = new User(); // User object for new user
            UsersRootObject usersObj = new UsersRootObject(); // Object of user
            List<User> usersList = new List<User>(); // List of users to read in existing data and add new users

            Resume newResume = new Resume(); // User object for new user
            ResumeRootObject resumeObj = new ResumeRootObject(); // Object of user
            List<Resume> resumeList = new List<Resume>(); // List of users to read in existing data and add new users

            string json;
            string resumejson;// for the final JSON formatted list of users
            Boolean exists = false; // boolean value to check if the username exists
            Boolean created = false; // boolean value to return


            string path = "C:\\Users\\niket\\Downloads\\AccountDetails.txt"; // File path to user credentials 
            string resumePath = "C:\\Users\\niket\\Downloads\\ResumeDetails.txt"; // File path to user credentials 

            try
            {
                string jsonData = File.ReadAllText(path); // reads in the JSON file into a string

                usersObj = JsonConvert.DeserializeObject<UsersRootObject>(jsonData); // transfers jsonData to the usersObj

                if (usersObj != null && usersObj.users != null) // makes sure that there is at least one existing user to iterate through accounts
                {
                    usersList = usersObj.users.ToList<User>(); // transfers users to a List<User>

                    foreach (User user in usersList) // iterates through the users
                    {
                        if (user.username == username) // checks if the username already exists
                        {
                            exists = true;
                        }
                    }
                }

                if (!exists) // If username doesn't already exist
                {


                    newUser.username = username;
                    newUser.password = password;
                    usersList.Add(newUser); // adds the new user to the user list

                    usersObj.users = usersList.ToArray<User>(); // Converts the list to a User object array
                    json = JsonConvert.SerializeObject(usersObj, Formatting.Indented); // Converts object to JSON string
                    File.WriteAllText(path, json); // Writes JSON data to the file

                    string resumejsonData = File.ReadAllText(resumePath); // reads in the JSON file into a string

                    resumeObj = JsonConvert.DeserializeObject<ResumeRootObject>(resumejsonData); // transfers jsonData to the usersObj

                    if (resumeObj != null && resumeObj.resumes != null) // makes sure that there is at least one existing user to iterate through accounts
                    {
                        resumeList = resumeObj.resumes.ToList<Resume>();
                    }

                    newResume.username = username;
                    newResume.firstName = firstName;
                    newResume.lastName = lastName;
                    newResume.mobileNumber = mobileNumber;
                    newResume.address = address;
                    newResume.jobProfile = jobProfile;
                    newResume.skills = skills;
                    newResume.workExperience = workExperience;
                    newResume.universityName = universityName;
                    newResume.cgpa = cgpa;
                    newResume.degreeName = degreeName;

                    resumeList.Add(newResume);

                    resumeObj.resumes = resumeList.ToArray<Resume>();
                    resumejson = JsonConvert.SerializeObject(resumeObj, Formatting.Indented);
                    File.WriteAllText(resumePath, resumejson);

                    created = true;
                }
            }
            finally
            {

            }

            return created; // Returns creation confirmation
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
                    User newUser = new User(); // User object for new user
                    UsersRootObject usersObj = new UsersRootObject(); // Object of user
                    List<User> usersList = new List<User>(); // List of users to read in existing data and add new users
                    string path = "C:\\Users\\niket\\Downloads\\AccountDetails.txt"; // File path to user credentials 


                    string jsonData = File.ReadAllText(path); // reads in the JSON file into a string

                    usersObj = JsonConvert.DeserializeObject<UsersRootObject>(jsonData); // transfers jsonData to the usersObj

                    if (usersObj != null && usersObj.users != null) // makes sure that there is at least one existing user to iterate through accounts
                    {
                        usersList = usersObj.users.ToList<User>(); // transfers users to a List<User>

                        foreach (User user in usersList) // iterates through the users
                        {
                            if (user.username == username && user.password == password) // checks if the username already exists
                            {
                                success = true;
                            }
                        }
                    }
                }
            }
            finally
            { }

            return success;
        }
    }
}
