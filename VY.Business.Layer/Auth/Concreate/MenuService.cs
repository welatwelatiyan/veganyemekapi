using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Menu;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.Product;

namespace VY.Business.Layer.Auth.Concreate
{
    public class MenuService : IMenuService
    {
        private IMenuManager menuManager;
        private IMapper mapper;

        public MenuService(IMenuManager menuManager,
                           IMapper mapper)
        {
            this.menuManager = menuManager;
            this.mapper = mapper;
        }

        public IDataResult<List<MenuGetDTO>> get(Guid storeid)
        {
            try
            {
                List<VyMenuTable> vyMenu = menuManager.
                getByFilterOrAll(x => x.StoreId == storeid).ToList();

                if (vyMenu.Count == 0)
                    return new ErrorDataResult<List<MenuGetDTO>>(new List<MenuGetDTO>(), "0",
                        ExceptionMessage.menuIsNotFounded[(int)language.Turkish]);
                return new SuccessDataResult<List<MenuGetDTO>>(
                    mapper.Map<List<VyMenuTable>, List<MenuGetDTO>>(vyMenu));
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<MenuGetDTO>>(new List<MenuGetDTO>(), "0",
                                ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }

        public IDataResult<MenuGetDTO> setMenu(MenuDTO menu, Guid storeid)
        {
            try
            {
                VyMenuTable vymenu = new VyMenuTable
                {
                    Description = menu.Description,
                    StoreId = storeid,
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    Name = menu.Name,
                    Price = menu.Price,
                    UpdateTime = DateTime.UtcNow
                };

                bool isAdded = menuManager.add(vymenu);

                return isAdded ?
                    new SuccessDataResult<MenuGetDTO>(mapper.Map<VyMenuTable, MenuGetDTO>(vymenu)) :
                    new ErrorDataResult<MenuGetDTO>(new MenuGetDTO(),
                    "0", ExceptionMessage.menuIsNotAdded[(int)language.Turkish]);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<MenuGetDTO>(new MenuGetDTO(), "0",
                     ExceptionMessage.systemException[(int)language.Turkish]);
            } 
        }

        public IDataResult<MenuGetDTO> updateMenu(MenuDTO menu, Guid menuid, Guid storeid)
        {
            try
            {
                List<VyMenuTable> vyMenu = menuManager.
                getByFilterOrAll(x => x.Id == menuid && x.StoreId == storeid).ToList();
                if (vyMenu.Count == 0)
                    return new ErrorDataResult<MenuGetDTO>(new MenuGetDTO(), "0",
                        ExceptionMessage.menuIsNotFounded[(int)language.Turkish]);
                vyMenu[0].Description = menu.Description;
                vyMenu[0].Name = menu.Name;
                vyMenu[0].Price = menu.Price;
                vyMenu[0].UpdateTime = DateTime.UtcNow;


                bool isUpdated = menuManager.update(vyMenu[0]);

                return isUpdated ?
                    new SuccessDataResult<MenuGetDTO>(mapper.Map<VyMenuTable, MenuGetDTO>(vyMenu[0])) :
                    new ErrorDataResult<MenuGetDTO>(new MenuGetDTO(), "0",
                    ExceptionMessage.menuIsNotAdded[(int)language.Turkish]);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<MenuGetDTO>(new MenuGetDTO(), "0",
                    ExceptionMessage.systemException[(int)language.Turkish]);
            }

        }
    }
}
