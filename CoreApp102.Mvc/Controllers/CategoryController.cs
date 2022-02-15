using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using CoreApp102.Mvc.DTOs;
using CoreApp102.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp102.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            //IEnumerable<Category> cat = await _categoryService.GetAllAsync();
            //var cat1 = (from s in cat select new { id = s.Id, name = s.Name }).ToList();
            //return View(cat1);
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            return View(_mapper.Map<CategoryDto>(category));
        }

        //[ServiceFilter(typeof(NotFoundFilter))]
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
