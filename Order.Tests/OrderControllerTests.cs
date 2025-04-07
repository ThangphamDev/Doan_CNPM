using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Order.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return new AppDbContext(options);
        }

        [TestMethod]
        public void PlaceOrder_ValidOrder_ReturnsSuccess()
        {
            var context = GetInMemoryDbContext();
            var controller = new OrderController(context);
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { ItemName = "Phở", Quantity = 2, Price = 50000 }
            };
            var result = controller.PlaceOrder(1, orderDetails);
            Assert.AreEqual("Đơn hàng đã được gửi thành công", result);
        }

        [TestMethod]
        public void PlaceOrder_EmptyOrderDetails_ReturnsError()
        {
            var context = GetInMemoryDbContext();
            var controller = new OrderController(context);
            var result = controller.PlaceOrder(1, new List<OrderDetail>());
            Assert.AreEqual("Vui lòng chọn ít nhất một món", result);
        }

        [TestMethod]
        public void PlaceOrder_InvalidQuantity_ReturnsError()
        {
            var context = GetInMemoryDbContext();
            var controller = new OrderController(context);
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { ItemName = "Phở", Quantity = 0, Price = 50000 }
            };
            var result = controller.PlaceOrder(1, orderDetails);
            Assert.AreEqual("Số lượng mỗi món phải lớn hơn 0", result);
        }
    }
}