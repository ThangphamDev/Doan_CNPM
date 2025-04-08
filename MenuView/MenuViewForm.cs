using System;
using System.Windows.Forms;
using MenuView

namespace MenuView
{
    public partial class MenuViewForm : Form
    {
        private Button btnViewMenu;
        private ListBox listBoxMenuItems;
        private AppDbContext _context;

        public MenuViewForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            _context = new AppDbContext();
        }

        private void InitializeCustomComponents()
        {
            btnViewMenu = new Button
            {
                Text = "Xem menu",
                Location = new System.Drawing.Point(20, 20),
                Width = 200
            };
            btnViewMenu.Click += BtnViewMenu_Click;

            listBoxMenuItems = new ListBox
            {
                Location = new System.Drawing.Point(20, 50),
                Width = 200,
                Height = 200
            };

            this.Controls.Add(btnViewMenu);
            this.Controls.Add(listBoxMenuItems);
        }

        private void BtnViewMenu_Click(object sender, EventArgs e)
        {
            var controller = new MenuController(_context);
            var menuItems = controller.GetMenuItems();

            listBoxMenuItems.Items.Clear();
            if (menuItems == null || !menuItems.Any())
            {
                MessageBox.Show("Không có món nào trong menu");
                return;
            }

            foreach (var item in menuItems)
            {
                listBoxMenuItems.Items.Add($"{item.Name} - {item.Price} VNĐ");
            }
        }
    }
}