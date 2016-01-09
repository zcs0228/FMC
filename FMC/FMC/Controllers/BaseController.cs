using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMC.Controllers
{
    public class BaseController : Controller
    {
        //public User UserInfo { get; set; }

        /// <summary>
        /// 重写基类在Action之前执行的方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //UserInfo = Session["UserInfo"] as User;

            ////检验用户是否已经登录，如果登录则不执行，否则则执行下面的跳转代码
            //if (UserInfo == null)
            //{
            //    Response.Redirect("/Login/Index");
            //}
        }
    }
}