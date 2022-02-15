using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreApp102.Api.DTOs;
using CoreApp102.Api.Filters;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp102.Api.Controllers
{
    //[ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _proService;
        private IMapper _mapper;

        public ProductsController(IProductService proService, IMapper mapper)
        {
            _proService = proService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pro = await _proService.GetAllAsync();

            //return Ok(categories);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(pro));
        }

        //[ValidationFilter]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pro = await _proService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(pro));
        }

        //[ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto proDto)
        {
            var newPro = await _proService.AddAsync(_mapper.Map<Product>(proDto));

            //return Created(null, _mapper.Map<CategoryDto>(newCat));
            return Created(string.Empty, _mapper.Map<ProductDto>(newPro));
        }

        [HttpPut]
        public IActionResult Update(ProductDto proDto)
        {
            if (string.IsNullOrEmpty(proDto.Id.ToString()) || proDto.Id==0)
            {
                throw new Exception("Id alani zorunludur.");
            }
            var pro = _proService.Update(_mapper.Map<Product>(proDto));
            return NoContent();
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var pro = _proService.GetByIdAsync(id).Result;//asenkron metod yazmadanda asenkron yapilari kullanmak icin sonuna Result ekliyerek asenkron bir metoddan bilgi cekebiliriz.
            _proService.Remove(pro);
            return NoContent();
        }

        
        [HttpGet("{id:int}/category")]
        public async Task<IActionResult> GetWithCategoryByIdAsync(int id)
        {
            var pro = await _proService.GetWithByIdAsync(id);
            //bu yapi category nesnesi donecek ancak benim sorgum ayni zamanda product da donmeli o yuzden dto ya nesne tanimliyorum

            return Ok(_mapper.Map<ProductWithCategoryDto>(pro));
        }
    }
}


//Person class olusturun
//id,name,surname
//migration yaparak db de olusturun
//sonrasinda controller da PersonsControlerini olusturun.