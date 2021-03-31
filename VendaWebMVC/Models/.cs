using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace VendaWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Department Department { get; set; }
        public ICollection<RecordVendas> Vendas { get; set; } = new List<RecordVendas>();

        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Department = department;
        }

        public void AddVenda(RecordVendas rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVenda(RecordVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas (DateTime inicial, DateTime fim)
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= fim).Sum(rv => rv.Total);
        }
    }
}
