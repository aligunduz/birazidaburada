using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.ActionsFilters
{
    public class Erişebilirlik : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            Users usr = (Users)filterContext.RequestContext.HttpContext.Session["UserLogin"];
            if (usr == null || usr.UserType != 1)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("http://localhost:59835");
            }
            
            base.OnResultExecuted(filterContext);
        }
        
    }
}