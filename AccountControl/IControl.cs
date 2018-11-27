using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AccountControl
{// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IControl
    {
        [OperationContract]
        bool ValidateStaff(string user, string pass);
        [OperationContract]
        bool ValidateUser(string user, string pass);
        [OperationContract]
        bool CreateUser(string first, string last, string user, string pass);
        [OperationContract]
        bool RemoveUser(string first, string last);
        [OperationContract]
        List<string> ListMembers();
    }
}
