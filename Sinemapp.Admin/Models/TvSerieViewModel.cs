using Sinemapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinemapp.Admin.Models
{
    public class TvSerieViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Dizi Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Ülke")]
        [Required]
        public Country Country { get; set; }
        [Display(Name = "Tür")]
        [Required]
        public Genre Genre { get; set; }
        [Display(Name = "Puan")]
        [Required]
        public string Rating { get; set; }
        [Display(Name = "Çıkış Tarihi")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Fotoğraf")]
        [Required]
        public string Photo { get; set; }
        [Display(Name = "Açıklama")]
        [Required]
        public string Description { get; set; }
    }
}