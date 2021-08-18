using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.DAL.Entities.Interfaces
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}
