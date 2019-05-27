using Modelo.Enumerador;
using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class SolicitacaoViewModel
    {
        [Display(Name ="Id")]
        public Int64 Id { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage ="A Descrição é Obrigatória!")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name ="Data de Conclusão")]
        [Required(ErrorMessage ="A Data de Clonclusão é Obrigatória")]
        [DataType(DataType.DateTime)]
        public DateTime DataConclusao { get; set; }

        [Display(Name ="Responsável")]
        [Required(ErrorMessage ="Responsável é Obrigátorio")]
        [DataType(DataType.Text)]
        [MaxLength(200, ErrorMessage ="Responsável Só Pode Conter 200 Caracteres")]
        public string Responsavel { get; set; }

        [Display(Name ="Status")]
        [Required(ErrorMessage ="Status é Obrigatório")]
        public EStatusSolicitacao Status { get; set; }
    }
}
