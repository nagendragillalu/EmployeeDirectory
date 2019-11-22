using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Authorization
{
    public class Auth
    {
       public String iss { get; set; }
       public String azp { get; set; }
        public String aud { get; set; }
        public String sub { get; set; }
        public String email { get; set; }
        public Boolean email_verified { get; set; }
        public String at_hash { get; set; }
        public String name { get; set; }
        public String picture { get; set; }
        public String given_name { get; set; }
        public String family_nameud { get; set; }
        public String locale { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }
        public String alg { get; set; }
        public String typ { get; set; }
    }
}
