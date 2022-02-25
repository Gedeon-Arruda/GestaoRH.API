using GestaoRH.Negocio.Entidades;
using System;

namespace GestaoRH.Servicos
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime InicioNaEmpresa { get;  set; }

        public Funcionario() : base()
        {
        }

        public Funcionario(string nome, DateTime dataDeNascimento, DateTime inicioNaEmpresa): this()
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            InicioNaEmpresa = inicioNaEmpresa;
        }

        //public void Criar(string nome, DateTime dataDeNascimento, DateTime inicioNaEmpresa)
        //{
        //    Id = new Guid();
        //    Nome = nome;
        //    DataDeNascimento = dataDeNascimento;
        //    InicioNaEmpresa = inicioNaEmpresa;
        //}

    }
}
