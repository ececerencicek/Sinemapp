using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinemapp.Model
{
    public enum Genre
    {
        [Display(Name="Aksiyon")]
        Action = 0,
        [Display(Name = "Macera")]
        Adventure = 1,
        [Display(Name = "Animasyon")]
        Animation = 2,
        [Display(Name = "Biyografi")]
        Biography = 3,
        [Display(Name = "Komedi")]
        Comedy = 4,
        [Display(Name = "Suç")]
        Crime = 5,
        [Display(Name = "Belgesel")]
        Documentary = 6,
        [Display(Name = "Dram")]
        Drama = 7,
        [Display(Name = "Aile")]
        Family = 8,
        [Display(Name = "Fantastik")]
        Fantasy = 9,
        [Display(Name = "Tarih")]
        History = 10,
        [Display(Name = "Korku")]
        Horror = 11,
        [Display(Name = "Müzikal")]
        Musical = 12,
        [Display(Name = "Gizem")]
        Mystery = 13,
        [Display(Name = "Romantik")]
        Romance = 14,
        [Display(Name = "Bilim Kurgu")]
        SciFi = 15,
        [Display(Name = "Kısa Film")]
        ShortFilm = 16,
        [Display(Name = "Spor")]
        Sport = 17,
        [Display(Name = "Gerilim")]
        Thriller = 18,
        [Display(Name = "Savaş")]
        War = 19

    }
}
