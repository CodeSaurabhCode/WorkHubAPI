using System.Diagnostics;
using System.Linq.Expressions;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Interfaces
{
    public class ItemsWithCategorySpecification : BaseSpecifications<Item>
    {
        public ItemsWithCategorySpecification(ItemSpecParams itemParams)
            : base(x => /*(string.IsNullOrEmpty(itemParams.Search) || x.Name.ToLower().Contains(itemParams.Search)) &&*/
            (!itemParams.CategoryId.HasValue || x.CategoryId == itemParams.CategoryId))
        {
            AddInclude(x => x.Category);
            ApplyPaging(itemParams.PageSize * (itemParams.PageIndex- 1), itemParams.PageSize);

            if (!string.IsNullOrEmpty(itemParams.Sort))
            {
                switch(itemParams.Sort){

                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default: 
                        AddOrderBy(x => x.Name);
                        break;

                }
            }
        }

        public ItemsWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}
