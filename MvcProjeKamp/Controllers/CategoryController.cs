using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);


        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            // categoryManager.CategoryAdd(category);
            CategoryValidator categoryValidator = new CategoryValidator();

            ValidationResult results = categoryValidator.Validate(category);

            if(results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);


                }

            }

            return View();
            

            
        }
    }
}