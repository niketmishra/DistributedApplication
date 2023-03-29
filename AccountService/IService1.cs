using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AccountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Boolean createAccount(string username, string password, string firstName, string lastName, string mobileNumber, string address, string jobProfile, string skills, string workExperience, string universityName, string cgpa, string degreeName);

        [OperationContract]
        Boolean signIn(string username, string password, Boolean isAdmin);
    }
}
