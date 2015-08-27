using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Crossover.Service.Ldap
{
    [DataContract]
    public class UserInfo
    {
        private IList<string> userGroups;

        [DataMember]
        public IList<string> UserGroups
        {
            get { return userGroups; }
            set { userGroups = value; }
        }
    }
}