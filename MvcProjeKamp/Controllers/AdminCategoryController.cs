using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetList();

            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if(result.IsValid)
            {
                categoryManager.CategoryAdd(category);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);

        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            categoryManager.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            return View(categoryvalue);

        }


        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");

        }
    }
}