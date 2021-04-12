using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VendaWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Salario base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
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
