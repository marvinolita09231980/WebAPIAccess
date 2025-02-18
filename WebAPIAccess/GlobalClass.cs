using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess
{
    public class GlobalClass
    {
        public const string connetionString_pay = @"Data Source=192.168.80.49\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        public const string connetionString_ats = @"Data Source=192.168.80.49\HRIS;Initial Catalog=HRIS_ATS;User ID=sa;Password=SystemAdmin_PRD123";
    }
}