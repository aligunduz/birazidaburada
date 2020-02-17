using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.ModelBinders
{
    public class CategoryModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            if (bindingContext.ModelType == typeof(Category))
            {
                Category category = new Category();
                var req = controllerContext.HttpContext.Request;
                category.Name = req.Form["Name"].ToString();
                category.CreateDate = DateTime.Now;

                if (req.Form["ParentCat"] != null && !String.IsNullOrWhiteSpace(req.Form["ParentCat"].ToString()))
                {
                    int parentId = int.Parse(req.Form["ParentCat"].ToString());
                    if (parentId != -1)
                    {
                        category.ParentCategory_Id = parentId;
                    }
                }

                return category;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}