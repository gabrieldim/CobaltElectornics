using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CobaltElectronics.Models
{
    public class Proizvod
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Слика")]
        public string ImgURL { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string Ime { get; set; }
        [Required]
        [Display(Name = "Производител")]
        public string Proizvoditel { get; set; }
        [Required]
        [Display(Name = "Цена (ден.)")]    
        public float Cena { get; set; }
        [Display(Name = "Залиха")]
        public bool DaliNaZaliha { get; set; }
        [Display(Name = "Опис")]
        public string Opis { get; set; }
        public virtual List<Prodavnica> prodavnici {get;set;}
        public virtual List<Category> categories { get; set; }

        public Proizvod()
        {
            prodavnici = new List<Prodavnica>();
            categories = new List<Category>();
        }


    }
}