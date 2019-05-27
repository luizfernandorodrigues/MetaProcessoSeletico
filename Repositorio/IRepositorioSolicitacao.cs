using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioSolicitacao
    {
        bool Inserir(Solicitacao solicitacao);
        Solicitacao ObterPorId(Int64 id);
        bool Alterar(Solicitacao solicitacao);
        IEnumerable<Solicitacao> ObterTodos();
        bool Excluir(Int64 id);

    }
}
