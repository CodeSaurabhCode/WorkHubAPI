using System.Linq.Expressions;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Interfaces
{
    public class ItemsWithCategorySpecification : BaseSpecifications<Item>
    {
        public ItemsWithCategorySpecification()
        {
            AddInclude(x => x.Category);
        }

        public ItemsWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}
