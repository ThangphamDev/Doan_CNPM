using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payment
{
    public partial class Form1 : Form
    {
        private TextBox txtOrderId;
        private ComboBox comboBoxPaymentMethod;
        private Button btnPay;
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }
        private void InitializeCustomComponents()
        {
            txtOrderId = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 200 };
            comboBoxPaymentMethod = new ComboBox { Location = new System.Drawing.Point(20, 50), Width = 200 };
            comboBoxPaymentMethod.Items.AddRange(new string[] { "Momo", "ZaloPay" });
            btnPay = new Button { Text = "Thanh toán", Location = new System.Drawing.Point(20, 80), Width = 200 };
            btnPay.Click += BtnPay_Click;

            this.Controls.Add(txtOrderId);
            this.Controls.Add(comboBoxPaymentMethod);
            this.Controls.Add(btnPay);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOrderId.Text, out int orderId))
            {
                MessageBox.Show("Vui lòng nhập orderId hợp lệ");
                return;
            }
            string paymentMethod = comboBoxPaymentMethod.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(paymentMethod))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán");
                return;
            }



            //thêm 


            var controller = new PaymentController(new AppDbContext(), new MockPaymentGateway());
            string result = controller.ProcessPayment(orderId, paymentMethod);
            MessageBox.Show(result);
        }
    }
}
