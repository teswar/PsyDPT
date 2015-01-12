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
    [Table("PredictionSettings")]
    public class PredictionSetting : EntityBase
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string PuntuationIdsToUse { set; get; }

        [NotMapped]
        public List<Guid> PuntuationIdListToUse { get; set; }
    

    }
}
