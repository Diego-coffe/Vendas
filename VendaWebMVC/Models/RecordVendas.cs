using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMVC.Models.Enums;

namespace VendaWebMVC.Models
{
    public class RecordVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RecordVendas() { }

        public RecordVendas(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Total = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
