using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [Column("id_movie", TypeName = "INTEGER")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Movie { get; set; }
        
        [Column("title", TypeName = "NVARCHAR")]
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        
        [Column("subTitle", TypeName = "NVARCHAR")]
        [MaxLength(64)]
        public string SubTitle { get; set; }

        [Column("synopsis", TypeName = "NVARCHAR")]
        [MaxLength(4000)]
        [Required]
        public string Synopsis { get; set; }

        [Column("releaseYear", TypeName = "INTEGER")]
        [Required]
        public int ReleaseYear { get; set; }

        [Column("duration", TypeName = "INTEGER")]
        [Required]
        public int Duration { get; set; }

        [Column("posterUrl", TypeName = "NVARCHAR")]
        [MaxLength(256)]
        [Required]
        public string PosterUrl { get; set; }

        public ICollection<Diffusion> Diffusions { get; set; }
    }
}
