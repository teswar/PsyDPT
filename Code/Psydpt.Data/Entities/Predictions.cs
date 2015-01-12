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
    [Table("Predictions")]
    public class Prediction: EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DisorderId { get; set; }

        public string PatientId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Symptoms { get; set; }


        [ForeignKey("PatientId")]
        public virtual AppUser Patient { get; set; }

        [ForeignKey("DisorderId")]
        public virtual Disorder Disorder { get; set; }
        
    }
}
