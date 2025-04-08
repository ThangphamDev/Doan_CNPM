using MenuView; // Để sử dụng AppDbContext

namespace MenuView
{
    public class MenuviewController
    {
        private readonly AppDbContext _context;

        public MenuviewController(AppDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _context.MenuItems.ToList();
        }
    }
}