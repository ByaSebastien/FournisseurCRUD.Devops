using FournisseurCRUD.Models;
using static FournisseurCRUD.DAL.Datas.FakeDb;

namespace FournisseurCRUD.DAL.Repositories
{
    public class SupplierRepository
    {
        public Supplier GetOne(Func<Supplier, bool> predicate)
        {
            Supplier? s = Suppliers.SingleOrDefault(predicate);
            if (s is null)
            {
                throw new KeyNotFoundException();
            }
            return s;
        }
        public List<Supplier> GetMany(Func<Supplier, bool> predicate = null)
        {
            if (predicate is null)
            {
                return Suppliers;
            }
            return Suppliers.Where(predicate).ToList();
        }
        public Supplier Add(Supplier supplier)
        {
            Suppliers.Add(supplier);
            return supplier;
        }
        public bool Update(int id, Supplier supplier)
        {
            Supplier? oldSupplier = Suppliers.SingleOrDefault(s => s.Id == id);
            if (oldSupplier is null)
            {
                return false;
            }
            oldSupplier.Name = supplier.Name;
            oldSupplier.Tva = supplier.Tva;
            return true;
        }
        public bool Delete(int id)
        {
            Supplier? s = Suppliers.SingleOrDefault(s => s.Id == id);
            if (s is null)
                return false;
            Suppliers.Remove(s);
            return true;
        }
        public bool Exists(Predicate<Supplier> predicate)
        {
            return Suppliers.Exists(predicate);
        }
    }
}
