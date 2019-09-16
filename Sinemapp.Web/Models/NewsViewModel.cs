using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinemapp.Web.Models
{
    public class NewsViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Başlık")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Tarih")]
        [Required]
        public DateTime? NewsDate { get; set; }
        [Display(Name = "Haber Kaynağı")]
        [Required]
        public string ByWhom { get; set; }
        [Display(Name = "Açıklama")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
    }
}