using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FournisseurCRUD.Models.Exceptions
{
    public class SupplierException : Exception
    {
        public SupplierException(string? message) : base(message) { }
    }
    public class TvaLengthSupplierException : SupplierException
    {
        public TvaLengthSupplierException() : base("Taille innégale a 12") { }
    }
    public class TvaUniqueSupplierException : SupplierException
    {
        public TvaUniqueSupplierException() : base("Tva doit etre unique"){}
    }
    public class RequiredNameSupplierException : SupplierException
    {
        public RequiredNameSupplierException() : base("Nom requis") { }
    }
}
