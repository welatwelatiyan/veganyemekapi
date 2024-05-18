using AutoMapper;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Store;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.authTable;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Concreate
{
    public class StoreService : IStoreService
    {
        private IStoreManager storeManager;
        private IAuthMAnager authMAnager;
        private IMapper mapper;
        public StoreService(IStoreManager storeManager, 
                            IAuthMAnager authMAnager,
                            IMapper mapper)
        {
            this.storeManager = storeManager;
            this.authMAnager = authMAnager; 
            this.mapper = mapper;
        }
        public IResult addStore(StoreDTO store,Guid userid)
        {
            try
            {
                List<VyStoreTable> vyStores = storeManager.
                                            getByFilterOrAll(x => x.userId == userid).ToList();
                if (vyStores.Count > 0)
                    return new ErrorResult("0", ExceptionMessage.
                                                StoreDublicated[(int)language.Turkish]);

                bool storeIsAdded = storeManager.add(new VyStoreTable
                {

                    Description = store.StoreDescription,
                    Name = store.StoreName,
                    TaxBranchName = store.TaxBranchName,
                    TaxNumber = store.TaxNumber,
                    userId = userid,
                    IsClosed =true
                });

                if (!storeIsAdded)
                    return new ErrorResult("0", ExceptionMessage.
                                                StoreInfoNotSaved[(int)language.Turkish]);

                List<VyUserTable> vyUsers = authMAnager.
                                            getByFilterOrAll(x => x.Id == userid).
                                            ToList();
                if (vyUsers.Count == 0)
                    return new ErrorResult("0", ExceptionMessage.
                                                AccountNotFoundException[(int)language.Turkish]);

                vyUsers[0].IsSeller = true;
                vyUsers[0].UpdateTime = DateTime.UtcNow;
                bool userIsUpdated = authMAnager.update(vyUsers[0]);

                return userIsUpdated ? new SuccesResult("1", ExceptionMessage.
                                                            StoreSaved[(int)language.Turkish]) :
                                      new ErrorResult("0", ExceptionMessage.
                                                            StoreSaved[(int)language.Turkish]);
            }
            catch (Exception e) 
            {

                return new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }

        }

        public IDataResult<StoreDTO> getStore(Guid userid)
        {
            try
            {
                List<VyStoreTable> vyStores = storeManager.getByFilterOrAll(x => x.userId == userid).ToList();
                if (vyStores.Count == 0)
                    return new ErrorDataResult<StoreDTO>(new StoreDTO(), "0", 
                        ExceptionMessage.StoreNotFound[(int)language.Turkish]);
                return new SuccessDataResult<StoreDTO>(mapper.Map<StoreDTO>(vyStores[0]), "1", "");
            }
            catch (Exception e)
            {

                return new ErrorDataResult<StoreDTO>(new StoreDTO(), "0",
                         ExceptionMessage.systemException[(int)language.Turkish]);
            }

        }

        public IResult updateStore(StoreUpdateDTO store,Guid userid)
        {
            try
            {
                List<VyStoreTable> vyStores = storeManager.
                                            getByFilterOrAll(x => x.userId == userid).ToList();
                if (vyStores.Count == 0)
                    return new ErrorResult("0", ExceptionMessage.
                                                StoreNotFound[(int)language.Turkish]);
                vyStores[0].Description = store.StoreDescription;
                vyStores[0].Name = store.StoreName;
                vyStores[0].UpdateTime= DateTime.UtcNow;
                //vyStores[0].UpdateTime = store.Closedtime;
                //vyStores[0].Closedtime = store.Closedtime;

                bool storeIsUpted = storeManager.update(vyStores[0]);

                return storeIsUpted ? new SuccesResult("1", ExceptionMessage.StoreUpdated[(int)language.Turkish]) :
                                      new ErrorResult("0", ExceptionMessage.StoreInfoNotUpdated[(int)language.Turkish]);
            }
            catch (Exception e)
            {

               return  new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            } 

        }
    }
}
