using Modelo.Enumerador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Solicitacao
    {
        public Int64 Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataConclusao { get; set; }
        public string Responsavel { get; set; }
        public EStatusSolicitacao Status { get; set; }
    }
}
