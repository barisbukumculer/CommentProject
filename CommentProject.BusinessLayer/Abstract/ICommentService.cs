using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetCommentByTitle(int id);
        List<Comment> TGetCommentByTitleWithUser(int id);
        List<Comment> TGetCommentByUserWithTitle(int id);
    }
}
