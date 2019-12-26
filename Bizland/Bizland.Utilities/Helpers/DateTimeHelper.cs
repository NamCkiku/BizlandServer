using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Utilities.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GenerateDateTime()
        {
            return DateTimeOffset.Now.UtcDateTime;
        }
    }
}
