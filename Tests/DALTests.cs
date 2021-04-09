using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void EFStoreRepository()
        {
            DAL.Repository.EFDataContext cntxt = new DAL.Repository.EFDataContext();
            DAL.Entities.EFCore.StoreRepository repo = new DAL.Entities.EFCore.StoreRepository(cntxt);
            System.Collections.Generic.IEnumerable<DAL.Entities.Store> alls = repo.GetAll();
        }
    }
}
