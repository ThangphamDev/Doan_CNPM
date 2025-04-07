using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    internal class PaymentController
    {
        private readonly AppDbContext _context;
        private readonly IPaymentGateway _paymentGateway;

        public PaymentController(AppDbContext context, IPaymentGateway paymentGateway)
        {
            _context = context;
            _paymentGateway = paymentGateway;
        }

        public string ProcessPayment(int orderId, string paymentMethod)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return "Đơn hàng không tồn tại";
            if (order.Status != "completed") return "Đơn hàng chưa sẵn sàng để thanh toán";

            bool paymentSuccess = _paymentGateway.ProcessPayment(order.TotalAmount, paymentMethod);
            if (!paymentSuccess) return "Thanh toán thất bại: Không đủ tiền";

            order.Status = "paid";
            _context.SaveChanges();
            return "Thanh toán thành công";
        }
    }
}
