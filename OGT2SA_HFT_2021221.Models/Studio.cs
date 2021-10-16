using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Models
{
    [Table("Studios")]
    public class Studio
    {
        [Key]
        public int studio_id { get; set; }
        [Required]
        public string founded { get; set; }
        [Required]
        public string studio_name { get; set; }
        [Required]
        public string founder { get; set; }
        [Required]
        public string headquarters { get; set; }
        [NotMapped]
        public virtual ICollection<Anime> Animes { get; set; }
        [NotMapped]
        public virtual ICollection<Character> Characters { get; set; }
        public Studio()
        {
            Animes = new HashSet<Anime>();
            Characters = new HashSet<Character>();
        }
    }
}
