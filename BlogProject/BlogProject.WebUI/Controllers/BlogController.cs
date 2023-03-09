using BlogProject.BusinessLayer.Abstract;
using BlogProject.BusinessLayer.Concrete;
using BlogProject.Entities.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogManager _blogManager;

        public BlogController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public ActionResult Index()
        {
            var blogDetails = _blogManager.ListBlog();

            return View(blogDetails);
        }
        public ActionResult UploadBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBlog(Blog bg)
        {
            _blogManager.CreateBlog(bg);
            ViewBag.message = "Blog basari ile eklendi.";
            return View();
        }
    }
}
