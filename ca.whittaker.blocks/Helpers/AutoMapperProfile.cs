using AutoMapper;
using ca.whittaker.blocks.Entities;
using ca.whittaker.blocks.Models.Blocks;

namespace ca.whittaker.blocks.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> Block
            CreateMap<CreateRequest, Block>();

            // UpdateRequest -> Block
            CreateMap<UpdateRequest, Block>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop, context) =>
                    {
                        // Ignore both null and empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // Ignore null BlockTypeId
                        if (x.DestinationMember.Name == "BlockTypeId" && src.BlockTypeId == null) return false;

                        return true;
                    }
                ));
        }
    }
}
