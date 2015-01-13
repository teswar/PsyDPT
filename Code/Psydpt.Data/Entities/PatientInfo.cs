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
    [Table("PatientInfos")]
    public class PatientInfo: EntityBase
    {
        public const double DAYS_IN_YEAR = 365;

   
        [Key]
        public string  PatientInfoId { get; set; }

        public DateTime DateofBirth { get; set; }

        [NotMapped]
        public int Age
        {
            get { return (int)(DateTime.Now.Subtract(DateofBirth).TotalDays / DAYS_IN_YEAR); }
        }

        public Gender Gender { get; set; }

        public MatialStatus MatialStatus { get; set; }

        public BloodType BloodType { get; set; }

        public int? NumberOfChildren { get; set; }

        public string DescriptionAboutSelf { get; set; }

        public decimal WeightInKg { get; set; }

        public decimal HeightInCm { get; set; }


        [ForeignKey("PatientInfoId")]
        public virtual AppUser UserPatient {get; set;}

    }
}
