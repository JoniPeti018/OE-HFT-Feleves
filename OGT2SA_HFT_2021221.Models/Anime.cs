using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OGT2SA_HFT_2021221.Models
{
    [Table("Animes")]
    public class Anime
    {
        [Key]
        public int anime_id { get; set; }
        [ForeignKey(nameof(Studio))]
        public int studio_id { get; set; }
        [Required]
        public string anime_name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string aired { get; set; }
        [Required]
        public string source { get; set; }

    }
}
