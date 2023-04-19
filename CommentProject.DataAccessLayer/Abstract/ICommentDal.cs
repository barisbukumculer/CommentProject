using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        List<Comment> GetCommentByTitle(int id);
        List<Comment> GetCommentByTitleWithUser(int id);
        List<Comment> GetCommentByUserWithTitle(int id);
    }
}
