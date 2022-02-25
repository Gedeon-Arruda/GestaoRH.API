using GestaoRH.Aplicacao.ViewModel;
using System;
using System.Collections.Generic;

namespace GestaoRH.Aplicacao.Interfaces
{
    public interface IFuncionarioServico
    {
        List<FuncionarioViewModel> Obter();
        FuncionarioViewModel Criar(FuncionarioViewModel funcionarioVw);
        FuncionarioViewModel Editar(FuncionarioViewModel funcionarioVw);
        void Excluir(Guid id);
    }
}
