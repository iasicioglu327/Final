using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using BlogPage.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace BlogPage.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly BlogAPIService _blogService;
        private readonly CategoryAPIService _categoryService;
        private readonly TagAPIService _tagService;
        private readonly IFileProvider _fileProvider;

        public BlogController(BlogAPIService blogService, CategoryAPIService categoryService, IFileProvider fileProvider, TagAPIService tagService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _fileProvider = fileProvider;
            _tagService = tagService;
        }

        public IActionResult Admin()
        {
            ViewBag.categ = _categoryService.GetListAsync();
            return View(_blogService.GetBlogwithCategoryAsync());
        }

        public IActionResult AddBlog()
        {
             ViewBag.categ = _categoryService.GetListAsync();
             return View();
        }

        [HttpPost]
        public IActionResult SaveBlog(BlogDTO blogDto, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");
                var path = Path.Combine(picturesDirectory.PhysicalPath, image.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                image.CopyToAsync(stream);
                blogDto.ImagePath = image.FileName;
            }
            _blogService.AddAsync(blogDto);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult UpdateBlog(int id)
        {
            var newBlog = _blogService.GetbyIdAsync(id);
            ViewBag.categ = _categoryService.GetListAsync();
            return View(newBlog);
        }

        [HttpPost]
        public IActionResult SaveUpdate(BlogDTO blogDto, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");
                var path = Path.Combine(picturesDirectory.PhysicalPath, image.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                image.CopyToAsync(stream);
                blogDto.ImagePath = image.FileName;
            }
            _blogService.UpdateAsync(blogDto);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult DeleteBlog(int id)
        {
            _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCategory(CategoryDTO categoryDto)
        {
            _categoryService.AddAsync(categoryDto);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult UpdateCategoryPage(int id)
        {
            var newCategory = _categoryService.GetbyIdAsync(id);
            return View(newCategory);
        }

        [HttpPost]
        public IActionResult SaveUpdateCategory(CategoryDTO categDto)
        {
            _categoryService.UpdateAsync(categDto);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Admin));
        }

        public IActionResult Tags(int id)
        {
            ViewBag.blog =id;
            return View();
        }

        [HttpPost]
        public IActionResult SaveTag(BlogTagDTO tagDto)
        {
            _tagService.AddAsync(tagDto);
            return RedirectToAction(nameof(Admin));
        }
    }
}
