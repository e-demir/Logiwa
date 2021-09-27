using LogiwaWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace LogiwaWeb.Controllers
{
    public class CategoryController : Controller
    {        
        public ActionResult Index()
        {
            List<CategoryModel> categoryList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category/GetAllCategories").Result;
            categoryList = response.Content.ReadAsAsync<List<CategoryModel>>().Result;
            return View(categoryList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new CategoryModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Category/GetCategory/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CategoryModel>().Result);

            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(CategoryModel model)
        {
            if (model.CategoryId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Category/AddCategory", model).Result;
                TempData["SuccessMessage"] = "New product added succesfully!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Category/EditCategory/" + model.CategoryId,
                    model).Result;
                TempData["SuccessMessage"] = "The product updated succesfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Category/DeleteCategory/" + id.ToString(), new { }).Result;
            TempData["SuccessMessage"] = "The category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}