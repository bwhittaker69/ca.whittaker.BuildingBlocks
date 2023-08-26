namespace ca.whittaker.blocks.Helpers
{

    using AutoMapper;
    using ca.whittaker.blocks.Entities;
    using ca.whittaker.blocks.Models.Blocks;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequest, Block>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, Block>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Type" && src.Type == null) return false;

                        return true;
                    }
                ));
        }
    }
}
