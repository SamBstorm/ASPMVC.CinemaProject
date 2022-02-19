using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Entities
{
    [Table("CinemaPlaces")]
    public class CinemaPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_cinemaPlace", TypeName ="INTEGER")]
        public int Id_CinemaPlace { get; set; }
        [Column("name", TypeName ="NVARCHAR")]
        [MaxLength(64)]
        [Required]
        public string Name { get; set; }
        [Column("city", TypeName = "NVARCHAR")]
        [MaxLength(64)]
        [Required]
        public string City { get; set; }
        [Column("street", TypeName = "NVARCHAR")]
        [MaxLength(128)]
        [Required]
        public string Street { get; set; }
        [Column("number", TypeName = "NVARCHAR")]
        [MaxLength(8)]
        public string Number { get; set; }
        [Column("zipCode", TypeName = "INTEGER")]
        public int ZipCode { get; set; }

        public ICollection<CinemaRoom> CinemaRooms { get; set; }
    }
}
