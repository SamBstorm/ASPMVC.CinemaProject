using CinemaProject.Common.Enums;
using System;

namespace CinemaProject.BLL.Entities
{
    public class DiffusionHour
    {
        public int Id_Diffusion { get; set; }
        public DiffusionMovie Diffusion { get; set; }
        public TimeSpan DiffusionTime { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Languages AudLang { get; set; }
        public Languages? SubTitleLang { get; set; }
        public DiffusionType DiffType { get {
                if (this.CinemaRoom.Can4DX) return DiffusionType.Is4DX;
                else if (this.CinemaRoom.Can3D) return DiffusionType.Is3D;
                return DiffusionType.Normal;
            } }
        public DiffusionLanguage DiffLanguage { get {
                if (this.AudLang == Languages.French) return DiffusionLanguage.VF;
                else if (this.AudLang == Languages.Original && this.SubTitleLang == Languages.French) return DiffusionLanguage.VOSTFR;
                else return DiffusionLanguage.VO;
            } }
    }
}