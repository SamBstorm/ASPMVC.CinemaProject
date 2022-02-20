using CinemaProject.Common.Enums;
using CinemaProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL
{
    public class CinemaContext : DbContext
    {
        private IEnumerable<Movie> _movies = new Movie[] { 
            new Movie{ Id_Movie = 1, Title ="Encanto", SubTitle = "La fantastique famille Madrigal", Duration = 109, PosterUrl ="encanto.jpg", ReleaseYear=2021, Synopsis="Synopsis : Dans un mystérieux endroit niché au cœur des montagnes de Colombie, la fantastique famille Madrigal habite une maison enchantée dans une cité pleine de vie, un endroit merveilleux appelé Encanto. L’Encanto a doté chacun des enfants de la famille d’une faculté magique allant d’une force surhumaine au pouvoir de guérison."},
            new Movie{ Id_Movie = 2, Title ="Scream", SubTitle = null, Duration = 114, PosterUrl ="scream.jpg", ReleaseYear=2022, Synopsis="Interdit aux moins de 16 ans Vingt-cinq ans après que la paisible ville de Woodsboro a été frappée par une série de meurtres violents, un nouveau tueur revêt le masque de Ghostface et prend pour cible un groupe d'adolescents. Il est déterminé à faire ressurgir les sombres secrets du passé."},
            new Movie{ Id_Movie = 3, Title ="Uncharted", SubTitle = null, Duration = 116, PosterUrl ="uncharted.jpg", ReleaseYear=2022, Synopsis="Uncharted est un film américain réalisé par Ruben Fleischer et dont la sortie est prévue en 2022. Il s'agit d'une adaptation cinématographique de la série de jeux vidéo Uncharted développés par Naughty Dog et édités par Sony Interactive Entertainment."},
            new Movie{ Id_Movie = 4, Title ="Spider-Man", SubTitle = "No way home", Duration = 148, PosterUrl ="spiderman.jpg", ReleaseYear=2021, Synopsis="Pour la première fois dans son histoire cinématographique, Spider-Man, le héros sympa du quartier est démasqué et ne peut désormais plus séparer sa vie normale de ses lourdes responsabilités de super-héros. Quand il demande de l'aide à Doctor Strange, les enjeux deviennent encore plus dangereux, le forçant à découvrir ce qu'être Spider-Man signifie véritablement."},
            new Movie{ Id_Movie = 5, Title ="Tous en scène 2", SubTitle = null, Duration = 112, PosterUrl ="scene.jpg", ReleaseYear=2021, Synopsis="Tous en scène 2 ou Chantez ! 2 au Québec ( Sing 2) est un film d'animation réalisé par Garth Jennings et sorti en 2021. C'est la suite de Tous en scène sorti en 2016 . Buster Moon et ses amis essaient de convaincre la star du rock recluse Clay Calloway de rejoindre leur show d'ouverture ."}
        };
        private IEnumerable<CinemaPlace> _places = new CinemaPlace[] { 
            new CinemaPlace{ Id_CinemaPlace = 1, Name="Roosevelt", City="Charleroi", Street="Rue Jean Mermoz", Number = "3Bis", ZipCode =6000 },
            new CinemaPlace{ Id_CinemaPlace = 2, Name="Le Spectaculaire", City="Liège", Street="Avenue des cerisiers", Number = "24", ZipCode =4000 },
            new CinemaPlace{ Id_CinemaPlace = 3, Name="Le Parc", City="Namur", Street="Place des Lumières", ZipCode =5000 }
        };
        private IEnumerable<CinemaRoom> _rooms = new CinemaRoom[] { 
            new CinemaRoom{ Id_CinemaRoom = 1, Number = 1, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 1},
            new CinemaRoom{ Id_CinemaRoom = 2, Number = 2, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 1},
            new CinemaRoom{ Id_CinemaRoom = 3, Number = 1, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 2},
            new CinemaRoom{ Id_CinemaRoom = 4, Number = 2, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 2},
            new CinemaRoom{ Id_CinemaRoom = 5, Number = 3, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 2},
            new CinemaRoom{ Id_CinemaRoom = 6, Number = 1, SitsCount = 206, ScreenWidth = 1362 , ScreenHeight = 580, Can3D = true, Can4DX = false, Id_CinemaPlace = 3},
            new CinemaRoom{ Id_CinemaRoom = 7, Number = 1, SitsCount = 327, ScreenWidth = 1932 , ScreenHeight = 835, Can3D = true, Can4DX = true, Id_CinemaPlace = 1},
            new CinemaRoom{ Id_CinemaRoom = 8, Number = 4, SitsCount = 629, ScreenWidth = 2400 , ScreenHeight = 1021, Can3D = false, Can4DX = false, Id_CinemaPlace = 1},
            new CinemaRoom{ Id_CinemaRoom = 9, Number = 2, SitsCount = 629, ScreenWidth = 2400 , ScreenHeight = 1021, Can3D = false, Can4DX = false, Id_CinemaPlace = 3},
            new CinemaRoom{ Id_CinemaRoom = 10, Number = 3, SitsCount = 629, ScreenWidth = 2400 , ScreenHeight = 1021, Can3D = false, Can4DX = false, Id_CinemaPlace = 3}
        };
        private IEnumerable<Diffusion> _diffusions = new Diffusion[] { 
            new Diffusion { Id_Diffusion = 1, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,45,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 1 },
            new Diffusion { Id_Diffusion = 2, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,30,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 7 },
            new Diffusion { Id_Diffusion = 3, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(15,50,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 1 },
            new Diffusion { Id_Diffusion = 4, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(16,5,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 7 },
            new Diffusion { Id_Diffusion = 5, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(17,30,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 6, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,15,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 6 },
            new Diffusion { Id_Diffusion = 7, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(15,50,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 6 },
            new Diffusion { Id_Diffusion = 8, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(17,30,0),Id_Movie = 4, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 9 },
            new Diffusion { Id_Diffusion = 9, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,30,0),Id_Movie = 1, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 10, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(17,0,0),Id_Movie = 1, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 11, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(20,0,0),Id_Movie = 1, AudLang=Languages.Original, SubTitleLang=Languages.French, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 12, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,30,0),Id_Movie = 1, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 3 },
            new Diffusion { Id_Diffusion = 13, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(17,0,0),Id_Movie = 1, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 3 },
            new Diffusion { Id_Diffusion = 14, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(20,0,0),Id_Movie = 1, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 3 },
            new Diffusion { Id_Diffusion = 15, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(18,15,0),Id_Movie = 2, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 2 },
            new Diffusion { Id_Diffusion = 16, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(21,15,0),Id_Movie = 2, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 2 },
            new Diffusion { Id_Diffusion = 17, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(14,0,0),Id_Movie = 2, AudLang=Languages.Original, SubTitleLang=Languages.French, Id_CinemaRoom = 9 },
            new Diffusion { Id_Diffusion = 18, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(16,0,0),Id_Movie = 2, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 6 },
            new Diffusion { Id_Diffusion = 19, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(20,0,0),Id_Movie = 2, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 9 },
            new Diffusion { Id_Diffusion = 30, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,15,0),Id_Movie = 3, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 4 },
            new Diffusion { Id_Diffusion = 20, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(15,30,0),Id_Movie = 3, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 4 },
            new Diffusion { Id_Diffusion = 21, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(18,0,0),Id_Movie = 3, AudLang=Languages.Original, SubTitleLang=Languages.French, Id_CinemaRoom = 4 },
            new Diffusion { Id_Diffusion = 22, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(13,15,0),Id_Movie = 3, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 6 },
            new Diffusion { Id_Diffusion = 23, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(16,30,0),Id_Movie = 3, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 10 },
            new Diffusion { Id_Diffusion = 24, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(18,15,0),Id_Movie = 3, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 10 },
            new Diffusion { Id_Diffusion = 25, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(14,15,0),Id_Movie = 5, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 26, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(16,45,0),Id_Movie = 5, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 8 },
            new Diffusion { Id_Diffusion = 27, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(14,15,0),Id_Movie = 5, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 5 },
            new Diffusion { Id_Diffusion = 28, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(16,45,0),Id_Movie = 5, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 5 },
            new Diffusion { Id_Diffusion = 29, DiffusionDate = new DateTime(2022,2,16), DiffusionTime = new TimeSpan(18,15,0),Id_Movie = 5, AudLang=Languages.French, SubTitleLang=null, Id_CinemaRoom = 5 }
        };

        public CinemaContext()
        {

        }

        public CinemaContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaPlace> CinemaPlaces { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Diffusion> Diffusions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(_movies);
            modelBuilder.Entity<CinemaPlace>().HasData(_places);
            modelBuilder.Entity<CinemaRoom>().HasData(_rooms);
            modelBuilder.Entity<Diffusion>().HasData(_diffusions);
        }

    }
}
