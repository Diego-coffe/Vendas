using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Data;
using VendaWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendaWebMVC.Services.Exceptions;

namespace VendaWebMVC.Services
{
    public class SellerService
    {
        private readonly SellerWebMVCContext _context;

        public SellerService(SellerWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj=> obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            //Estou fazendo uma busca no banco de dado com o id que informei, e estou guardando no obj 
            //Depois uso a função remove, que vai receber o id do vendedor e por fim chamo SaveChanges para salvar no banco de dados
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }  
}
