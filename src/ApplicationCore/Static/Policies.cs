using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Static
{
    public static class Policies
    {
        public const string CanViewOnly = "CanViewOnly";
        public const string CanWrite = "CanWrite"; 
        public const string CanUpdate = "CanUpdate"; 
        public const string AdminOnly = "AdminOnly";  
        public const string AdminManager = "AdminManager"; 
    }
}
