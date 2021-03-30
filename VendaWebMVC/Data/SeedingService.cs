using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Models;
using VendaWebMVC.Models.Enums;

namespace VendaWebMVC.Data
{
    public class SeedingService
    {
        private VendaWebMVCContext _context;

        public SeedingService(VendaWebMVCContext context)
        {
            _context = context;
        }

        //Operação para popular o banco de dados
        public void Seed()
        {
            //Estou testando se ja existe alguma coisa nas tabelas a baixo 'Department, Vendedor, RecordVendas'
            if (_context.Department.Any() || _context.Vendedor.Any() || _context.RecordVendas.Any())
            {
                return; // O DB já foi populado
            }

            Department d1 = new Department(1, "Computador");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Roupas");
            Department d4 = new Department(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Bob", "bob@gmail.com", new DateTime(1990 / 2 / 3), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Ana", "ana@gmail.com", new DateTime(1995 / 3 / 12), 1000.0, d2);
            Vendedor v3 = new Vendedor(3, "Maria", "Maria@gmail.com", new DateTime(2000 / 4 / 11), 1000.0, d3);
            Vendedor v4 = new Vendedor(4, "Joao", "Joao@gmail.com", new DateTime(1993 / 5 / 4), 1000.0, d4);
            Vendedor v5 = new Vendedor(5, "Carlos", "Carlos@gmail.com", new DateTime(2005 / 6 / 08), 1000.0, d3);
            Vendedor v6 = new Vendedor(6, "Bia", "Bia@gmail.com", new DateTime(1985 / 7 / 7), 1000.0, d2);

            RecordVendas vd1 = new RecordVendas(1, new DateTime(2020/ 3 / 03), 11000.0, StatusVenda.Faturado, v1);
            RecordVendas vd2 = new RecordVendas(2, new DateTime(2020 / 3 / 03), 2000.0, StatusVenda.Faturado, v2);
            RecordVendas vd3 = new RecordVendas(3, new DateTime(2020 / 3 / 04), 1000.0, StatusVenda.Cancelado, v3);
            RecordVendas vd4 = new RecordVendas(4, new DateTime(2020 / 3 / 05), 500.0, StatusVenda.Cancelado, v4);
            RecordVendas vd5 = new RecordVendas(5, new DateTime(2020 / 3 / 08), 200.0, StatusVenda.Faturado, v5);
            RecordVendas vd6 = new RecordVendas(6, new DateTime(2020 / 3 / 09), 100.0, StatusVenda.Pendente, v6);
            RecordVendas vd7 = new RecordVendas(7, new DateTime(2020 / 3 / 11), 300.0, StatusVenda.Faturado, v1);
            RecordVendas vd8 = new RecordVendas(8, new DateTime(2020 / 3 / 12), 9000.0, StatusVenda.Pendente, v4);


            //Adicionando os objs no banco de dados
            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.RecordVendas.AddRange(vd1, vd2, vd3, vd4, vd5, vd6, vd7, vd8);


            //Aqui estou salvando e confirmando as alterações no banco de dados _context.SaveChanges();
            _context.SaveChanges();
        }
    }
}
