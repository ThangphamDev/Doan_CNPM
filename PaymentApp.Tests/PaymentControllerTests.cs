using System;

public class Class1
{
	public Class1()
	{
        [TestMethod]
        public void ProcessPayment_CompletedOrder_ReturnsSuccess()
        {
            var context = new AppDbContext();
            context.Orders.Add(new Order { Id = 1, Status = "completed", TotalAmount = 50000 });
            context.SaveChanges();
            var paymentGateway = new MockPaymentGateway();
            var controller = new PaymentController(context, paymentGateway);
            var result = controller.ProcessPayment(1, "Momo");
            Assert.AreEqual("Thanh toán thành công", result);
        }

        [TestMethod]
        public void ProcessPayment_NotCompletedOrder_ReturnsError()
        {
            var context = new AppDbContext();
            context.Orders.Add(new Order { Id = 1, Status = "pending", TotalAmount = 50000 });
            context.SaveChanges();
            var paymentGateway = new MockPaymentGateway();
            var controller = new PaymentController(context, paymentGateway);
            var result = controller.ProcessPayment(1, "Momo");
            Assert.AreEqual("Đơn hàng chưa sẵn sàng để thanh toán", result);
        }
    }
}
