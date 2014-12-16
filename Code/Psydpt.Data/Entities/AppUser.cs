using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Entities
{

    public class AppUser : IdentityUser
    {
        public string Name { get; set; }


        public virtual PatientInfo PatientInfo {get; set;}
        public virtual PatientSigeCaps PatientSigeCaps { get; set; }
    }
}
