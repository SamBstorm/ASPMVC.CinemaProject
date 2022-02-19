using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Entities
{
    [Table("CinemaSits")]
    public class CinemaSit
    {
        [Key]
        [Column("id", TypeName = "INTEGER")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rowPosition", TypeName = "CHAR")]
        [MaxLength(1)]
        public char RowPosition { get; set; }

        [Column("sitPosition", TypeName = "INTEGER")]
        public int SitPosition { get; set; }
        [Column("cinemaRoomId", TypeName = "INTEGER")]
        public int CinemaRoomId { get; set; }
        [ForeignKey(nameof(CinemaRoomId))]
        public CinemaRoom CinemaRoom { get; set; }

    }
}
