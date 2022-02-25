using GestaoRH.Servicos;
using System;

namespace GestaoRH.Infraestrutura.ViewModel
{
    public class FuncionarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }
        public string InicioNaEmpresa { get; set; }

        public FuncionarioViewModel()
        {
        }

        public FuncionarioViewModel(Funcionario funcionario)
        {
            Nome = funcionario.Nome;
            DataDeNascimento = funcionario.DataDeNascimento.ToShortDateString();
            InicioNaEmpresa = funcionario.InicioNaEmpresa.ToShortDateString();
            Id = funcionario.Id;
        }        
    }
}
