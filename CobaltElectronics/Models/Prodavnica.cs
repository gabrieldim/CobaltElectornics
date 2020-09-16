using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CobaltElectronics.Models
{
    public class Prodavnica
    {
        [Required]
        public int Id { get; set; }
        public string adresa { get; set; }
        public string slika_url { get; set; }

        public string rabotno_vreme { get; set; }


    }
}