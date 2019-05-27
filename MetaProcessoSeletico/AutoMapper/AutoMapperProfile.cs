using AutoMapper;
using Modelo;

namespace MetaProcessoSeletivo.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SolicitacaoViewModel, Solicitacao>();
            CreateMap<Solicitacao, SolicitacaoViewModel>();
        }
    }
}
