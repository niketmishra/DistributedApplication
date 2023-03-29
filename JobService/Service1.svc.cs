using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace JobService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public class JobRootObject
        {
            public Job[] jobs { get; set; }
        }

        public class Job
        {
            public string jobId { get; set; }
            public string jobRoleName { get; set; }
            public string location { get; set; }
            public string skillSet { get; set; }
            public string minWorkEx { get; set; }
            public string vacantPosition { get; set; }

        }
        public Boolean CreateJob(string jobId, string jobRoleName, string location, string skillSet, string minWorkEx, string vacantPosition)
        {
            Job newJob = new Job(); // User object for new user
            JobRootObject jobObj = new JobRootObject(); // Object of user
            List<Job> jobList = new List<Job>(); // List of users to read in existing data and add new users
            Boolean created = false;
            string jobjson;
            string path = "C:\\Users\\niket\\Downloads\\JobDetails.txt"; // File path to user credentials 

            string jobjsonData = File.ReadAllText(path); // reads in the JSON file into a string

            jobObj = JsonConvert.DeserializeObject<JobRootObject>(jobjsonData); // transfers jsonData to the usersObj

            if (jobObj != null && jobObj.jobs != null) // makes sure that there is at least one existing user to iterate through accounts
            {
                jobList = jobObj.jobs.ToList<Job>();
            }

            newJob.jobId = jobId;
            newJob.jobRoleName = jobRoleName;
            newJob.location = location;
            newJob.skillSet = skillSet;
            newJob.minWorkEx = minWorkEx;
            newJob.vacantPosition = vacantPosition;

            jobList.Add(newJob);

            jobObj.jobs = jobList.ToArray<Job>();
            jobjson = JsonConvert.SerializeObject(jobObj, Formatting.Indented);
            File.WriteAllText(path, jobjson);

            created = true;

            return created;
        }

        public List<Job> ViewJob(string skillset)
        {
            List<Job> jobs = new List<Job>();
            JobRootObject jobObj = new JobRootObject(); // Object of user
            string path = "C:\\Users\\niket\\Downloads\\JobDetails.txt"; // File path to user credentials 

            string jobjsonData = File.ReadAllText(path); // reads in the JSON file into a string

            jobObj = JsonConvert.DeserializeObject<JobRootObject>(jobjsonData); // transfers jsonData to the usersObj

            if (jobObj != null && jobObj.jobs != null) // makes sure that there is at least one existing user to iterate through accounts
            {
                jobs = jobObj.jobs.ToList<Job>();
            }

            return jobs;

        }
    }
}
