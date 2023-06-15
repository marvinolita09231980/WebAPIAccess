using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess
{
    public class GlobalClass
    {
        public const string connetionString_pay = @"Data Source=HRIS-DO-BACKUP\HRIS_DEV;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_DEV123";
        public const string connetionString_ats = @"Data Source=HRIS-DO-BACKUP\HRIS_DEV;Initial Catalog=HRIS_ATS;User ID=sa;Password=SystemAdmin_DEV123";
    }
}