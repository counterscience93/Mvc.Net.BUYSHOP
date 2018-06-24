using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSEM3.Dao;
using ProjectSEM3.DAO;
using ProjectSEM3.EF;

namespace ProjectSEM3.Controllers
{
    public class UserController : Controller
    {
        UserDAO _userDao = new UserDAO();
        // GET: User
        public ActionResult Detail(int id)
        {
            var temp = _userDao.ViewDetail(id);
            return View(temp);
        }



        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDAO();
            var model = dao.Update(user);
            if (model)
            {
                TempData["Result"] = "Cập nhập tài khoản thành công";
                return RedirectToAction("Detail", new { id = user.ID });
            }
            else
            {
                TempData["Result"] = "Cập nhập tài khoản thất bại";
                return RedirectToAction("Detail", new { id = user.ID });
            }
        }
        public void setViewBag(long? selectedID = null)
        {
            var dao = new GroupUserDao();
            ViewBag.GroupUserID = new SelectList(dao.GetAllGroupUsers(""), "ID", "Name", selectedID);

        }

    }

}