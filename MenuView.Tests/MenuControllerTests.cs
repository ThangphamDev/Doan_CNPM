using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MenuView.tests
{
    [TestClass]
    public class MenuControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return new AppDbContext(options);
        }

        [TestMethod]
        public void GetMenuItems_ReturnsAllItems()
        {
            var context = GetInMemoryDbContext();
            var controller = new MenuController(context);
            var result = controller.GetMenuItems();
            Assert.AreEqual(3, result.Count); // 3 món từ SeedData
            Assert.IsTrue(result.Any(item => item.Name == "Phở" && item.Price == 50000));
        }

        [TestMethod]
        public void GetMenuItems_EmptyDatabase_ReturnsEmptyList()
        {
            var context = GetInMemoryDbContext();
            context.MenuItems.RemoveRange(context.MenuItems); // Xóa dữ liệu mẫu
            context.SaveChanges();
            var controller = new MenuController(context);
            var result = controller.GetMenuItems();
            Assert.AreEqual(0, result.Count);
        }
    }
}