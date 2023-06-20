using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Interfaces
{
    public class ItemsWithFilterForCountSpecifications : BaseSpecifications<Item>
    {
        public ItemsWithFilterForCountSpecifications(ItemSpecParams itemParams)
             : base(x => /*(string.IsNullOrEmpty(itemParams.Search) || x.Name.ToLower().Contains(itemParams.Search)) &&*/
             (!itemParams.CategoryId.HasValue || x.CategoryId == itemParams.CategoryId))
        {

        }
    }
}
