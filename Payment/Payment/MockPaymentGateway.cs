using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    internal class MockPaymentGateway
    {
        public bool ProcessPayment(decimal amount, string method)
        {
            // Giả lập: nếu tổng tiền < 1,000,000 thì thành công, ngược lại thất bại
            return amount < 1000000;
        }
    }
}
