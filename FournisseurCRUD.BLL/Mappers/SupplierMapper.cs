using FournisseurCRUD.BLL.Dtos;
using FournisseurCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FournisseurCRUD.BLL.Mappers
{
    public static class SupplierMapper
    {
        public static Supplier ToModels(this SupplierForm form)
        {
            return new Supplier()
            {
                Name = form.Name,
                Tva = form.Tva,
            };
        }
    }
}
