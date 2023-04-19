﻿using CommentProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.ViewComponents.Title
{
    public class _CommentListByTitle:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByTitle(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
           var values= _commentService.TGetCommentByTitle(2);
            return View(values);
        }
    }
}