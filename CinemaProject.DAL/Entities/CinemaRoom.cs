using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Entities
{
    public class CinemaRoom
    {
        [Key]
        [Column("id_cinemaRoom", TypeName ="INTEGER")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_CinemaRoom { get; set; }

        [Column("sitsCount", TypeName = "INTEGER")]
        [Required]
        public int SitsCount { get; set; }

        [Column("screenWidth", TypeName = "INTEGER")]
        [Required]
        public int ScreenWidth { get; set; }

        [Column("screenHeight", TypeName = "INTEGER")]
        [Required]
        public int ScreenHeight { get; set; }

        [Column("can3D", TypeName = "BIT")]
        [Required]
        public bool Can3D { get; set; }

        [Column("can4DX", TypeName = "BIT")]
        [Required]
        public bool Can4DX { get; set; }

        [Column("number", TypeName = "INTEGER")]
        [Required]
        public int Number { get; set; }

        [Column("id_cinemaPlace", TypeName = "INTEGER")]
        [Required]
        public int Id_CinemaPlace { get; set; }

        [ForeignKey(nameof(Id_CinemaPlace))]
        public CinemaPlace CinemaPlace { get; set; }

        //public ICollection<CinemaSit> CinemaSits { get; set; }
    }
}
