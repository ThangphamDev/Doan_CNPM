namespace Order;

public partial class Form1 : Form
{

    private TextBox txtCustomerId;
    private TextBox txtItemName;
    private TextBox txtQuantity;
    private TextBox txtPrice;
    private TextBox txtNote;
    private Button btnAddItem;
    private ListBox listBoxItems;
    private Button btnPlaceOrder;
    private AppDbContext _context;
    private List<OrderDetail> orderDetails;
    public Form1()
    {
        InitializeComponent();
        InitializeCustomComponents();
        _context = new AppDbContext();
        orderDetails = new List<OrderDetail>();
        InitializeComponent();
    }
    private void InitializeCustomComponents()
    {
        txtCustomerId = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 200, PlaceholderText = "Customer ID" };
        txtItemName = new TextBox { Location = new System.Drawing.Point(20, 50), Width = 200, PlaceholderText = "Tên món" };
        txtQuantity = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 200, PlaceholderText = "Số lượng" };
        txtPrice = new TextBox { Location = new System.Drawing.Point(20, 110), Width = 200, PlaceholderText = "Giá" };
        txtNote = new TextBox { Location = new System.Drawing.Point(20, 140), Width = 200, PlaceholderText = "Ghi chú" };
        btnAddItem = new Button { Text = "Thêm món", Location = new System.Drawing.Point(20, 170), Width = 200 };
        listBoxItems = new ListBox { Location = new System.Drawing.Point(20, 200), Width = 200, Height = 100 };
        btnPlaceOrder = new Button { Text = "Gửi đơn hàng", Location = new System.Drawing.Point(20, 310), Width = 200 };

        btnAddItem.Click += BtnAddItem_Click;
        btnPlaceOrder.Click += BtnPlaceOrder_Click;

        this.Controls.Add(txtCustomerId);
        this.Controls.Add(txtItemName);
        this.Controls.Add(txtQuantity);
        this.Controls.Add(txtPrice);
        this.Controls.Add(txtNote);
        this.Controls.Add(btnAddItem);
        this.Controls.Add(listBoxItems);
        this.Controls.Add(btnPlaceOrder);
    }

    private void BtnAddItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtItemName.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtPrice.Text))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin món");
            return;
        }

        if (!int.TryParse(txtQuantity.Text, out int quantity) || !decimal.TryParse(txtPrice.Text, out decimal price))
        {
            MessageBox.Show("Số lượng và giá phải là số hợp lệ");
            return;
        }

        var orderDetail = new OrderDetail
        {
            ItemName = txtItemName.Text,
            Quantity = quantity,
            Price = price,
            Note = txtNote.Text
        };

        orderDetails.Add(orderDetail);
        listBoxItems.Items.Add($"{orderDetail.ItemName} - Số lượng: {orderDetail.Quantity} - Giá: {orderDetail.Price}");
    }

    
    }
}
