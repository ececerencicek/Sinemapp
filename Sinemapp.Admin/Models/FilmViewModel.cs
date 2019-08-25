﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinemapp.Admin.Models
{
    public class FilmViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Film Adı")]
        [Required]
        public string FilmName { get; set; }
        [Display(Name = "Puan")]
        [Required]
        public string Rating { get; set; }
        [Display(Name = "Film Süresi")]
        [Required]
        public DateTime RunTime { get; set; }
        [Display(Name = "Çıkış Tarihi")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Yönetmen")]
        [Required]
        public string Director { get; set; }
        [Display(Name = "Senarist")]
        public string Writer { get; set; }
        [Display(Name = "Ülke")]
        public string Country { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Fotoğraf")]
        [Required]
        public string Photo { get; set; }
        [Display(Name = "İzleyici Sayısı")]
        public string NumOfViewer { get; set; }
        [Display(Name = "Hasılat")]
        public string Revenue { get; set; }

       
    }
}