﻿using BlogProject.Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BusinessLayer.Abstract
{
    public interface IBlogManager
    {
        IList<Blog> ListBlog();

        void CreateBlog(Blog bg);

    }
}
