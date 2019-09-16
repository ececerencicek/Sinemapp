using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinemapp.Model
{
    public enum Country
    {
        [Display(Name = "Tüm Ülkeler")]
        All = 0,
        [Display(Name = "Amerika")]
        ABD = 1,
        [Display(Name = "Türkiye")]
        Turkey = 2,
        [Display(Name = "Almanya")]
        Germany = 3,
        [Display(Name = "İspanya")]
        IncomingCall = 4
    }
}
