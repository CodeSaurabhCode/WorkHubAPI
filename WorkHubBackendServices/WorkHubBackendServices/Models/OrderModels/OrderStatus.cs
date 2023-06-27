using System.Runtime.Serialization;

namespace WorkHubBackEndServices.Models.OrderModels
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Delivered")]
        Delivered,
    }
}
