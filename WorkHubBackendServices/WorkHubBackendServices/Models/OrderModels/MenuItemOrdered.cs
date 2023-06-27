using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Models.OrderModels
{
    public class MenuItemOrdered
    {
        public MenuItemOrdered()
        {
        }

        public MenuItemOrdered(int menuItemId, string itemName, string category)
        {
            MenuItemId = menuItemId;
            ItemName = itemName;
            CategoryType = category;
        }
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryType { get; set; }
    }
}

