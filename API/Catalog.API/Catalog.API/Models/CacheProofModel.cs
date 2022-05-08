using Catalog.DataTransferObjects.Responses;

namespace Catalog.API.Models
{
    public class CacheProofModel
    {
        public IEnumerable<ProductDisplayResponse> Products { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
