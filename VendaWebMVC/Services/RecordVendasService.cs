using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaWebMVC.Data;
using VendaWebMVC.Models;

namespace VendaWebMVC.Services
{
    public class RecordVendasService
    {

        private readonly SellerWebMVCContext _context;

        public RecordVendasService(SellerWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<RecordVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RecordVendas select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result.Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, RecordVendas>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RecordVendas select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result.Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Department)
                .ToListAsync();
        }


    }
}
