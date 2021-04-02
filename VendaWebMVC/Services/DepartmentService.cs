using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Data;
using VendaWebMVC.Models;

namespace VendaWebMVC.Views.Departments
{
    public class DepartmentService
    {
        private readonly SellerWebMVCContext _context;

        public DepartmentService(SellerWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Nome).ToList();
        }
    }
}
