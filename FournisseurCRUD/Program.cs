using FournisseurCRUD.BLL.Dtos;
using FournisseurCRUD.BLL.Services;
using FournisseurCRUD.Models;

SupplierService supplierService = new SupplierService();


SupplierForm newSupplier = new SupplierForm()
{
    Name = "Ce ne sont pas des livres",
    Tva = "BE3000456780"
};

supplierService.Delete(1);


List<Supplier> suppliers = supplierService.GetAll();

foreach (Supplier s in suppliers)
{
    Console.WriteLine(s);
    Console.WriteLine("_______________________________");
}