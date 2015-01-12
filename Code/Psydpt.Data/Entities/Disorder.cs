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
    [Table("Disorders")]
    public class Disorder : EntityBase
    {
        public const string KEYWORDS_SPLITTES = ",|";

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Guid  Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        [NotMapped]
        public  IEnumerable<string> KeywordCollection 
        {
            get 
            {
                var result = new List<string>();
                if (!string.IsNullOrWhiteSpace(Keywords)) 
                {
                   result = Keywords.Split(KEYWORDS_SPLITTES.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                    .Select(m => m.Trim()).ToList();
                }
                return result;
            }
            set
            {
                Keywords = (value == null) ? null : string.Join(KEYWORDS_SPLITTES.ToCharArray()[0].ToString(), value.Where(m => m != null).Select(m => m.Trim()).ToList());
            }
        }

    }
}
