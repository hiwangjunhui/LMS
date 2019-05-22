using System;
using System.Linq;
using System.Web.Mvc;

namespace LibMgmtSys.Web.Controllers
{
    public class HomeController : Controller
    {
        private IService.IService<Models.User> _userService;
        private IService.IService<Models.Book> _bookService;

        public HomeController(IService.IService<Models.User> userService, IService.IService<Models.Book> bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var books = _bookService.Select(b => true);
            return View(books);
        }

        #region CRU
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Book book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookService.Insert(book);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(book);
        }

        public ActionResult Edit(Guid id)
        {
            var book = _bookService.QuerySingle(b => b.Id == id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Models.Book book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookService.Update(book);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(book);
        }

        public ActionResult Delete(Guid id)
        {
            var book = _bookService.Remove(b => b.Id == id);
            return RedirectToAction("Index");
        }
        #endregion

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var password = Utils.Utils.GetMd5(user.Password);
                var model = _userService.QuerySingle(u => u.UserName == user.UserName && u.Password == password);
                if (null != model)
                {
                    Session["CurrentUser"] = model;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误！");
                }
            }

            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return Content("Error");
        }
    }
}