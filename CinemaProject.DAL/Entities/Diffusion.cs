using CinemaProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Entities
{
    [Table("Diffusions")]
    public class Diffusion
    {
        [Key]
        [Column("id_diffusion", TypeName = "INTEGER")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Diffusion { get; set; }

        [Column("diffusionDate", TypeName = "DATE")]
        [Required]
        public DateTime DiffusionDate { get; set; }

        [Column("diffusionTime", TypeName = "TIME")]
        [Required]
        public TimeSpan DiffusionTime { get; set; }

        [Column("audLang", TypeName = "INTEGER")]
        [Required]
        public Languages AudLang { get; set; }

        [Column("subTitleLang", TypeName = "INTEGER")]
        public Languages? SubTitleLang { get; set; }

        [Column("id_cinemaRoom", TypeName = "INT")]
        [Required]
        public int Id_CinemaRoom { get; set; }
        
        [Column("id_movie", TypeName = "INT")]
        [Required]
        public int Id_Movie { get; set; }
        
        [ForeignKey(nameof(Id_CinemaRoom))]
        public CinemaRoom CinemaRoom { get; set; }
        [ForeignKey(nameof(Id_Movie))]
        public Movie Movie { get; set; }

    }
}
