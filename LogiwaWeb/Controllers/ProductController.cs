using LogiwaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LogiwaWeb.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<ProductModel> prodcutList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("product/GetAllProducts").Result;
            prodcutList = response.Content.ReadAsAsync<List<ProductModel>>().Result;
            return View(prodcutList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            var model = new ProductModel();
            if (id == 0)
            {
                model.Categories = GetCategories();
                return View(model);
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/GetProduct/" + id.ToString()).Result;
                var editingProduct = response.Content.ReadAsAsync<ProductModel>().Result;
                editingProduct.Categories = GetCategories();
                return View(editingProduct);

            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductModel model)
        {

            model.Categories = GetCategories();
            if (model.ProductId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product/AddProduct", model).Result;
                TempData["SuccessMessage"] = "New product added succesfully!";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product/EditProduct/" + model.ProductId,
                    model).Result;
                TempData["SuccessMessage"] = "The product updated succesfully!";
            }


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product/DeleteProduct/" + id.ToString(), new { }).Result;
            TempData["SuccessMessage"] = "The product deleted successfully!";
            return RedirectToAction("Index");
        }

        private List<CategoryModel> GetCategories()
        {
            var categoryList = new List<CategoryModel>();
            HttpResponseMessage categories = GlobalVariables.WebApiClient.GetAsync("Category/GetAllCategories").Result;
            categoryList = categories.Content.ReadAsAsync<List<CategoryModel>>().Result;



            return categoryList;
        }
    }
}