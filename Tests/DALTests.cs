using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void EFStoreRepository()
        {
            var cntxt = new DAL.Repository.EFDataContext();
            var repo = new DAL.Entities.EFCore.StoreRepository(cntxt);
            var alls = repo.GetAll();
        }
    }
}
