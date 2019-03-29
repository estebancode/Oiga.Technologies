
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Oiga.Technologies.Module.Commons.Utilities
{
    public static class DatetimeHelper
    {
        public static DateTime GetCurrentColombianTime()
        {
            return DateTime.Now.ToUniversalTime().AddHours(-5);
        }
    }
}
