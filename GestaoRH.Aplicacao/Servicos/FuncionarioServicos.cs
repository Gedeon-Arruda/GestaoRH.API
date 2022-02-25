using GestaoRH.Aplicacao.Interfaces;
using GestaoRH.Aplicacao.ViewModel;
using GestaoRH.Infraestrutura;
using GestaoRH.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoRH.Aplicacao.Servicos
{
    public class FuncionarioServicos : IFuncionarioServico
    {
        private readonly DbFuncionarioContexto _funcionario;

        public FuncionarioServicos(DbFuncionarioContexto funcionario)
        {
            _funcionario = funcionario;
        }

        public FuncionarioViewModel Criar(FuncionarioViewModel funcionarioVw)
        {
            var duplicado = _funcionario.Funcionarios.Any(p => p.Nome == funcionarioVw.Nome);

            if (duplicado)
            {
                return null;
            }

            var funcionario = new Funcionario(funcionarioVw.Nome, DateTime.Parse(funcionarioVw.DataDeNascimento), DateTime.Parse(funcionarioVw.InicioNaEmpresa));

            _funcionario.Funcionarios.Add(funcionario);
            _funcionario.SaveChanges();

            return new FuncionarioViewModel(funcionario);
        }

        public FuncionarioViewModel Editar(FuncionarioViewModel funcionarioVw)
        {
            var funcionario = _funcionario.Funcionarios.SingleOrDefault(f => f.Id == funcionarioVw.Id);

            if (funcionario == null)
            {
                return null;
            }

            var duplicado = _funcionario.Funcionarios.Any(p => p.Nome == funcionarioVw.Nome);

            if (duplicado)
            {
                return null;
            }

            funcionario.Nome = funcionarioVw.Nome;
            funcionario.InicioNaEmpresa = DateTime.Parse(funcionarioVw.InicioNaEmpresa);
            funcionario.DataDeNascimento = DateTime.Parse(funcionarioVw.DataDeNascimento);
            funcionario.Id = funcionarioVw.Id;

            //_funcionario.Funcionarios.Update(funcionario);
            _funcionario.SaveChanges();

            return new FuncionarioViewModel(funcionario);
        }

        public void Excluir(Guid id)
        {
            var funcionario = _funcionario.Funcionarios.SingleOrDefault(f => f.Id == id);
            
            if (funcionario != null)
            {
                _funcionario.Funcionarios.Remove(funcionario);
                _funcionario.SaveChanges();
            }                        
        }

        public List<FuncionarioViewModel> Obter()
        {
            var funcionarios = _funcionario.Funcionarios.ToList();

            /*var funcionariosViewModel = new List<FuncionarioViewModel>();

            foreach (var funcionario in funcionarios)
            {
                var obj = new FuncionarioViewModel(funcionario);
                funcionariosViewModel.Add(obj);
            }

            return funcionariosViewModel;*/

            return funcionarios.Select(x => new FuncionarioViewModel(x)).ToList();
        }
    }
}