using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Entities
{
    public abstract class EntityBase
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }


        public EntityBase() 
        {
            CreatedOn = DateTime.Now;
        }

    }
}
