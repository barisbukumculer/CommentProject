﻿using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.Concrete;
using CommentProject.DataAccessLayer.Repositories;
using CommentProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentByTitle(int id)
        {
            var context=new Context();
            return context.Comments.Where(x=>x.TitleID==id).ToList();
        }

        public List<Comment> GetCommentByTitleWithUser(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.TitleID == id).Include(y=>y.AppUser).Include(z=>z.Title.Category).ToList();
        }

        public List<Comment> GetCommentByUserWithTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.AppUserID == id).Include(y => y.Title).ToList();
        }
    }
}
