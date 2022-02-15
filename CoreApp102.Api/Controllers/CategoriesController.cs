using AutoMapper;
using CoreApp102.Api.DTOs;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp102.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _catService;
        private IMapper _mapper;

        public CategoriesController(ICategoryService catService, IMapper mapper)
        {
            _catService = catService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cat = await _catService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(cat));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _catService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(cat));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto catDto)
        {
            var newCat = await _catService.AddAsync(_mapper.Map<Category>(catDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(newCat));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto catDto)
        {
            var cat = _catService.Update(_mapper.Map<Category>(catDto));

            return NoContent();
            //return Ok(_mapper.Map<CategoryDto>(cat));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var cat = _catService.GetByIdAsync(id).Result;
            _catService.Remove(cat);
            return NoContent();
        }




        //public IActionResult deneme()
        //{
        //    return Ok();
        //    //200 Ok         -Olumlu mesajlar
        //    //204 NoContext

        //    //400 Client Hata Kodlari

        //    //500 Server hatalari
        //}
    }
}
