using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltElectronics.Models
{
    public class AddToCategory
    {
        public List<Proizvod> proizvods { get; set; }
        public int selectedProizvod { get; set; }
        public int selectedCategory { get; set; }
        public AddToCategory()

        {
            proizvods = new List<Proizvod>();
        }
    }
}