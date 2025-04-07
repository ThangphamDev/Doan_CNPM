namespace Order
{
    public class OrderController
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public string PlaceOrder(int customerId, List<OrderDetail> orderDetails)
        {
            if (orderDetails == null || !orderDetails.Any())
                return "Vui lòng chọn ít nhất một món";

            if (orderDetails.Any(od => od.Quantity <= 0))
                return "Số lượng mỗi món phải lớn hơn 0";

            var order = new Order
            {
                CustomerId = customerId,
                TotalAmount = orderDetails.Sum(od => od.Quantity * od.Price),
                Status = "pending",
                OrderDetails = orderDetails
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            return "Đơn hàng đã được gửi thành công";
        }
    }
}