using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Data;
using VendaWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendaWebMVC.Services
{
    public class SellerService
    {
        private readonly SellerWebMVCContext _context;

        public SellerService(SellerWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj=> obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            //Estou fazendo uma busca no banco de dado com o id que informei, e estou guardando no obj 
            //Depois uso a função remove, que vai receber o id do vendedor e por fim chamo SaveChanges para salvar no banco de dados
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }


    }  
}
