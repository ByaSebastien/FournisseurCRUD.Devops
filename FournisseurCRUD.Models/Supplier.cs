using FournisseurCRUD.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FournisseurCRUD.Models
{
    public class Supplier
    {
        private static int _currentId = 1;
        private string _tva;
        private string _name;
        public Supplier() 
        {
            Id = _currentId++;
        }
        public Supplier(int id, string name, string tva)
        {
            Id = id;
            Name = name;
            Tva = tva;
        }

        public int Id { get; set; }

        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value is null)
                    throw new ArgumentNullException();
                _name = value;
            } 
        }
        public string Tva 
        {
            get
            { 
                return _tva;
            }
            set
            {
                if (value.Length != 12)
                    throw new TvaLengthSupplierException();
                _tva = value;
            } 
        }

        public override string ToString()
        {
            return $"Id : {Id}\n" +
                   $"Name : {Name}\n" +
                   $"Tva : {Tva}";
        }
    }
}
