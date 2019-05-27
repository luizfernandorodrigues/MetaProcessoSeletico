using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modelo.Enumerador
{
    public enum EStatusSolicitacao
    {
        [Description("Aguardando Atendimento")]
        AguardandoAtendimento = 0,

        [Description("Atendendo")]
        Atendendo = 1,

        [Description("Testando")]
        Testando = 2,

        [Description("Encerrado")]
        Encerrado = 3
    }
}
