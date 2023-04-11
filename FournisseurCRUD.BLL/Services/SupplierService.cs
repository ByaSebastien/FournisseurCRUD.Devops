using FournisseurCRUD.BLL.Dtos;
using FournisseurCRUD.BLL.Mappers;
using FournisseurCRUD.Models;
using FournisseurCRUD.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FournisseurCRUD.Models.Exceptions;

namespace FournisseurCRUD.BLL.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository supplierRepository = new SupplierRepository();

        public List<Supplier> GetAll()
        {
            return supplierRepository.GetMany();
        }

        public Supplier GetById(int id)
        {
            return supplierRepository.GetOne(s => s.Id == id);
        }

        public List<Supplier> GetByName(string name)
        {
            return supplierRepository.GetMany(s => s.Name.Contains(name));
        }

        public Supplier GetByTva(string tva)
        {
            return supplierRepository.GetOne(s => s.Tva == tva);
        }

        public List<Supplier> GetManyByTva(string tva)
        {
            return supplierRepository.GetMany(s => s.Tva.StartsWith(tva));
        }

        public Supplier Add(SupplierForm form)
        {
            ValidSupplierForm(form);
            return supplierRepository.Add(form.ToModels());
        }

        public bool Update(int id, SupplierForm form)
        {
            IsExistantSupplier(id);
            ValidSupplierForm(form);
            return supplierRepository.Update(id, new Supplier(id, form.Name, form.Tva));
        }

        public bool Delete(int id)
        {
            IsExistantSupplier(id);
            return supplierRepository.Delete(id);
        }

        private void IsExistantSupplier(int id)
        {
            if (!supplierRepository.Exists(s => s.Id == id))
            {
                throw new KeyNotFoundException();
            }
        }

        private void ValidSupplierForm(SupplierForm form)
        {
            if (form.Name is null || form.Tva is null)
            {
                throw new ArgumentNullException();
            }
            if (supplierRepository.Exists(s => s.Tva == form.Tva))
            {
                throw new TvaUniqueSupplierException();
            }
            if (form.Name.Trim() == "")
            {
                throw new RequiredNameSupplierException();
            }
            if (!char.IsLetter(form.Name.First()))
            {
                throw new FormatException();
            }
        }
    }
}
