using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.MenuKategori;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.Product;

namespace VY.Business.Layer.Auth.Concreate
{
    public class MenuKategoriService : IMenuKategoriService
    {
        private IMenuKategoriManager menuKategoriManager;
        private IMapper mapper;
        public MenuKategoriService(IMenuKategoriManager menuKategoriManager,
                                   IMapper mapper)
        {
            this.menuKategoriManager = menuKategoriManager;
            this.mapper = mapper;
        }
        public IDataResult<List<MenuKategoriGetDTO>> get(Guid storeid)
        {
            try
            {
                List<VyMenuKategori> vyMenus = menuKategoriManager
                .getByFilterOrAll(x => x.StoreId == storeid).ToList();
                if (vyMenus.Count == 0)
                    return new ErrorDataResult<List<MenuKategoriGetDTO>>(
                        new List<MenuKategoriGetDTO>(),
                        "0", ExceptionMessage.dataIsNotFounded[(int)language.Turkish]);

                return new SuccessDataResult<List<MenuKategoriGetDTO>>(mapper.
                    Map<List<VyMenuKategori>, List<MenuKategoriGetDTO>>(vyMenus));
                    
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<MenuKategoriGetDTO>>(
                        new List<MenuKategoriGetDTO>(),
                        "0", ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public IDataResult<MenuKategoriGetDTO> set(MenuKategoriDTO menuKategori, Guid storeid)
        {
            VyMenuKategori vyMenuKategori = new VyMenuKategori
            {
                StoreId = storeid,
                CreateDate = DateTime.UtcNow,
                IsActive = true,
                IsRequireChoice = true,
                Name = menuKategori.Name,
                UpdateTime = DateTime.UtcNow
            };
            bool isadded = menuKategoriManager.add(vyMenuKategori);

            return isadded ? new SuccessDataResult<MenuKategoriGetDTO>(mapper.
                Map<VyMenuKategori, MenuKategoriGetDTO>(vyMenuKategori)) :
                new ErrorDataResult<MenuKategoriGetDTO>(new MenuKategoriGetDTO(), "0",
                ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);
        }

        public IDataResult<MenuKategoriGetDTO> update(MenuKategoriDTO menuKategori, 
                                                   Guid kategoriid, Guid storeid)
        {
            List<VyMenuKategori> vyMenuKategori = menuKategoriManager.
                getByFilterOrAll(x => x.StoreId == storeid && x.Id == kategoriid).ToList();
            if (vyMenuKategori.Count == 0)
                return new ErrorDataResult<MenuKategoriGetDTO>(new MenuKategoriGetDTO(), "0",
                ExceptionMessage.dataIsNotFounded[(int)language.Turkish]);
            vyMenuKategori[0].IsRequireChoice = menuKategori.IsRequireChoice;
            vyMenuKategori[0].Name= menuKategori.Name;

            bool isupdated = menuKategoriManager.update(vyMenuKategori[0]);

            return isupdated ? new SuccessDataResult<MenuKategoriGetDTO>(mapper.
                Map<VyMenuKategori, MenuKategoriGetDTO>(vyMenuKategori[0])) :
                new ErrorDataResult<MenuKategoriGetDTO>(new MenuKategoriGetDTO(), "0",
                ExceptionMessage.dataIsNotSaved[(int)language.Turkish]);
        }
    }
}
