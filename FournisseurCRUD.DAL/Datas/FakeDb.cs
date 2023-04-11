using FournisseurCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FournisseurCRUD.DAL.Datas
{
    public static class FakeDb
    {
        public static List<Supplier> Suppliers = new List<Supplier>()
        {
            new Supplier()
            {
                Name = "Brico",
                Tva = "BE3456789652"
            },
            new Supplier()
            {
                Name = "Gamma",
                Tva = "BE3458789252"
            },
            new Supplier()
            {
                Name = "Le rois Merlin",
                Tva = "BE6486780652"
            },
        };
    }
}
