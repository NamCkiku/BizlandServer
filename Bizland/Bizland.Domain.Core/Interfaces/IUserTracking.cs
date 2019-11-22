using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Core
{
   public interface IUserTracking
    {
        string CreatedBy { set; get; }

        string UpdatedBy { set; get; }
    }
}
