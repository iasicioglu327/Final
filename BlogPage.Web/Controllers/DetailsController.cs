using AutoMapper;
using BlogPage.Core;
using BlogPage.Core.DTOs;
using BlogPage.Core.Services;
using BlogPage.Web.Services;
using Microsoft.AspNetCore.Mvc;
//using PagedList.Core;
using X.PagedList;


namespace BlogPage.Web.Controllers
{
    public class DetailsController : Controller
    {
        private readonly BlogAPIService _blogService;
        private readonly CommentAPIService _commentService;
        private readonly CategoryAPIService _categoryService;
        private readonly TagAPIService _tagService;

        public DetailsController(BlogAPIService blogService, CommentAPIService commentService, CategoryAPIService categoryService, TagAPIService tagService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.categ = _categoryService.GetListAsync().ToList();
            ViewBag.blog = _blogService.GetListAsync().ToList().OrderByDescending(s => s.ViewCount);
            ViewBag.tag= _tagService.GetBlogTagAsync().ToList();
            var blog = _blogService.GetBlogwithCategoryAsync().ToPagedList(page, 3);
            return View(blog);
        }

        public IActionResult ContinueReadingBlog(int id)
        {
            ViewBag.blog = _blogService.GetListAsync().Where(x => x.ID == id).ToList();
            ViewBag.id=id;
            var comment = _commentService.GetCommentwithBlogAsync().Where(x => x.BlogId == id).ToList();
            var newBlog = _blogService.GetbyIdAsync(id);
            newBlog.ViewCount=newBlog.ViewCount+1;
            _blogService.UpdateAsync(newBlog);
            return View(comment);
        }

        public IActionResult Categories(int id)
        {
            var categ = _categoryService.GetbyIdAsync(id);
            ViewBag.categ = categ.CategoryName;
            return View(_blogService.GetListAsync().Where(x => x.CategoryId == id).ToList());
        }

        public IActionResult Tags(int id)
        {
            var tag = _tagService.GetbyIdAsync(id);
            ViewBag.tag = tag;
            return View(_tagService.GetBlogTagAsync().Where(x=>x.ID==id).ToList());
        }

        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddComment(CommentwithBlogDTO commentDto)
        {
            _commentService.AddAsync(commentDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddTagBlog(BlogTagDTO tag,int id)
        {
           var blog= _blogService.GetbyIdAsync(id);
            tag.Blogs.Add(blog);
            return RedirectToAction(nameof(Index));
        }

    }
}
