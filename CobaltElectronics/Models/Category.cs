using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CobaltElectronics.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Proizvod> proizvodi { get; set; }
        public Category()
        {
            proizvodi = new List<Proizvod>();
        }
    }
}