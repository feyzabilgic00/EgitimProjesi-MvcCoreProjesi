using System.Collections.Generic;

namespace CoreApp102.Api.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
