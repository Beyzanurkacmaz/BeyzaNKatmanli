using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Concrete
{
    public class BlogManager:IBlogManager
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public IList<Blog> ListBlog()
        {
            return _blogRepository.GetAll();
        }

        public void CreateBlog(Blog bg)
        {
            _blogRepository.Add(bg);
            _blogRepository.Save();
        }


    }
}
