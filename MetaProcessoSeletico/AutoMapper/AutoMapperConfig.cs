using AutoMapper;

namespace MetaProcessoSeletivo.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegistraMapeamento()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
