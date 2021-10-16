using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Models
{
    [Table("Characters")]
    public class Character
    {
        [Key]
        public int character_id { get; set; }
        [ForeignKey(nameof(Anime))]
        public int anime_id { get; set; }
        [ForeignKey(nameof(Studio))]
        public int studio_id { get; set; }
        [Required]
        public string character_name { get; set; }
        [Required]
        public string main_voice { get; set; }
        [Required]
        public string support_character { get; set; }
        [Required]
        public string support_voice { get; set; }
        [NotMapped]
        public virtual ICollection<Anime> Animes { get; set; }

        [NotMapped]
        public virtual ICollection<Studio> Studios { get; set; }
        public Character()
        {
            Studios = new HashSet<Studio>();
            Animes = new HashSet<Anime>();
        }
    }
}
