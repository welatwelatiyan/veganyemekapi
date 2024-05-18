using AutoMapper;
using VY.Business.Layer.Auth.DTO;
using VY.Business.Layer.Auth.DTO.Menu;
using VY.Business.Layer.Auth.DTO.MenuKategori;
using VY.Business.Layer.Auth.DTO.MenuProduct;
using VY.Business.Layer.Auth.DTO.Product;
using VY.Business.Layer.Auth.DTO.Store;
using VY.Entity.Layer.Table.AddressTables;
using VY.Entity.Layer.Table.Product;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VyStoreTable, StoreDTO>()
                .ForMember(d => d.TaxNumber, src => src.MapFrom(x => x.TaxNumber))
                .ForMember(d => d.TaxBranchName, src => src.MapFrom(x => x.TaxBranchName))
                .ForMember(d => d.StoreName, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.StoreDescription, src => src.MapFrom(x => x.Description))
                .ForMember(d => d.IsClosed, src => src.MapFrom(x => x.IsClosed))
                .ForMember(d => d.IsClosed, src => src.MapFrom(x => x.IsClosed));

            CreateMap<VyUserAdressTable, UserAdressGetDTO>()
                .ForMember(d => d.AddressUUID, src => src.MapFrom(x => x.Id))
                .ForMember(d => d.TelNumber, src => src.MapFrom(x => x.TelNumber))
                .ForMember(d => d.latitude, src => src.MapFrom(x => x.latitude))
                .ForMember(d => d.Name, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.Description, src => src.MapFrom(x => x.Description))
                .ForMember(d => d.longitude, src => src.MapFrom(x => x.longitude))
                .ForMember(d => d.Il, src => src.MapFrom(x => x.Il));

            CreateMap<VyStoreAdressTable, StoreAdressDTO>()
                .ForMember(d => d.TelNumber, src => src.MapFrom(x => x.TelNumber))
                .ForMember(d => d.latitude, src => src.MapFrom(x => x.latitude))
                .ForMember(d => d.Name, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.Description, src => src.MapFrom(x => x.Description))
                .ForMember(d => d.longitude, src => src.MapFrom(x => x.longitude))
                .ForMember(d => d.Il, src => src.MapFrom(x => x.Il))
                .ForMember(d => d.MaxOrderDistance, src => src.MapFrom(x => x.MaxOrderDistance));

            CreateMap<VyProductTable, ProductGetDTO>()
                .ForMember(d => d.Id, src => src.MapFrom(x => x.Id))
                .ForMember(d => d.Price, src => src.MapFrom(x => x.Price))
                .ForMember(d => d.Name, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.Description, src => src.MapFrom(x => x.Description));

            CreateMap<VyMenuTable, MenuGetDTO>()
                .ForMember(d => d.Id, src => src.MapFrom(x => x.Id))
                .ForMember(d => d.Price, src => src.MapFrom(x => x.Price))
                .ForMember(d => d.Name, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.Description, src => src.MapFrom(x => x.Description));

            CreateMap<VyMenuKategori, MenuKategoriGetDTO>()
                .ForMember(d => d.Id, src => src.MapFrom(x => x.Id))
                .ForMember(d => d.IsRequireChoice, src => src.MapFrom(x => x.IsRequireChoice))
                .ForMember(d => d.Name, src => src.MapFrom(x => x.Name))
                .ForMember(d => d.IsActive, src => src.MapFrom(x => x.IsActive));

            CreateMap<VyMenuProductTable, MenuProductGetDTO>()
                .ForMember(d => d.Id, src => src.MapFrom(x => x.Id))
                .ForMember(d => d.MenuId, src => src.MapFrom(x => x.MenuId))
                .ForMember(d => d.MenuKategoriId, src => src.MapFrom(x => x.MenuKategoriId))
                .ForMember(d => d.ProductId, src => src.MapFrom(x => x.ProductId))
                .ForMember(d => d.StoreId, src => src.MapFrom(x => x.StoreId))
                .ForMember(d => d.IsActive, src => src.MapFrom(x => x.IsActive))
                .ForMember(d => d.SortingNumber, src => src.MapFrom(x => x.SortingNumber))
                .ForMember(d => d.ExternalPrice, src => src.MapFrom(x => x.ExternalPrice));


        }
    }
}
