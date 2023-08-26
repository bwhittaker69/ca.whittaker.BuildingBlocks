using AutoMapper;
using ca.whittaker.blocks.Entities;
using ca.whittaker.blocks.Models;

namespace ca.whittaker.blocks.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> Block
            CreateMap<Models.Blocks.CreateBlockRequest, Block>();

            // UpdateRequest -> Block
            CreateMap<Models.Blocks.UpdateBlockRequest, Block>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop, context) =>
                    {
                        // Ignore both null and empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // Ignore null BlockTypeId
                        if (x.DestinationMember.Name == "BlockTypeId" && (src.BlockTypeId == null)) return false;

                        return true;
                    }
                ));

            // CreateRequest -> BlockType
            CreateMap<Models.BlockTypes.CreateBlockTypeRequest, BlockType>();

            // UpdateRequest -> BlockType
            CreateMap<Models.BlockTypes.UpdateBlockTypeRequest, BlockType>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop, context) =>
                    {
                        // Ignore both null and empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;


                        return true;
                    }
                ));
        }
    }
}
