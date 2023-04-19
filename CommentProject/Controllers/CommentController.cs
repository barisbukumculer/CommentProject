using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITitleService _titleService;
        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, ITitleService titleService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _titleService = titleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> value = (from x in _titleService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.TitleName,
                                              Value = x.TitleID.ToString()
                                          }).ToList();
            ViewBag.v = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var commentuserID = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.AppUserID = commentuserID.Id;
            _commentService.TInsert(comment);
            return RedirectToAction("Index","Default");
        }
        public async Task<IActionResult>MyComments(int id)
        {
            var commentuserID = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TGetCommentByUserWithTitle(commentuserID.Id);
            return View(values);
        }
    }
}
