using MangoCrudWebApi.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MangoCrudWebApi.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
        private CategoryService _CategoryService;

        [TestInitialize]
        public void setup()
        {
            IMongoDbSettings settings = new MongoDbSettings
            {
                Database = "DbDemoCategory",
                ConnectionString = "mongodb://localhost:27017",
                Collection = "Category"
            };
            this._CategoryService = new CategoryService(settings);
        }

        [TestMethod]
        public void GetAll_Should_Return_Category()
        {
            List<Category> categories = _CategoryService.GetAll();
            Assert.AreNotEqual(0, categories.Count);
        }
        [TestMethod]
        public void GetSingle_Should_Return_Any_CategoryByObjectId()
        {
            string objectId = "1";
            var Entity = _CategoryService.SelectById(objectId);
            Assert.AreNotEqual(null, Entity); // null olursa test basarısız
            Assert.AreEqual("Category1", Entity.Name); // dönen nesnenin adı category1 olmazsa test başarısız.



        }
    }
}
