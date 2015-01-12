using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psydpt.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Psydpt.Data.Entities
{
    [Table("PatientSigeCaps")]
    public class PatientSigeCaps: EntityBase
    {
        [Key]
        public string PatientSigeCapId { get; set; }

        public SigeCapVariantType Sleepiness { get; set; }
        public SigeCapVariantType Interest { get; set; }
        public SigeCapVariantType EnergyLevel { get; set; }
        public SigeCapVariantType Concentration { get; set; }
        public SigeCapVariantType Appetite { get; set; }
        public SigeCapVariantType Agitation { get; set; }
        public SigeCapBooleanType GuiltyFeelings { get; set; }
        public SigeCapBooleanType SucidalThoughts { get; set; }


        [ForeignKey("PatientSigeCapId")]
        public virtual AppUser UserPatient {get; set;}
    }
}
