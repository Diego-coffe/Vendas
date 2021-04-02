using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaWebMVC.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
