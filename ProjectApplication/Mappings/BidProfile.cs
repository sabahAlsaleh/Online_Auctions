using AutoMapper; 
using ProjectApplication.DataAccess;
using ProjectApplication.Core;

namespace ProjectApplication.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            //Default mapping when property names are same
            CreateMap<BidDB, Bid>().ReverseMap();
        }
    }
}
