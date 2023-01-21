using Microsoft.AspNetCore.Mvc;
using Milk_and_Cookies.Models;
using Milk_and_Cookies.Models.Extensions;
using System.Collections.Generic;

namespace Milk_and_Cookies.Controllers
{
    [Route("api/shoppingcart/")]
    public class ShoppingcartController : Controller
    {
        [HttpGet]
        public IEnumerable<ProductModel> GetProduct()   
        {
            var products = HttpContext.Session.GetObjectFromJson<List<ProductModel>>("Shoppingcart");

            return products;
        }
    

        [HttpPost("addProducts")]
        public void AddProduct(string productName, double productPrice)
        {
            CreateSession();
            var products = HttpContext.Session.GetObjectFromJson<List<ProductModel>>("Shoppingcart");

            var product = CreateProduct(productName, productPrice);

            products.Add(product);

            HttpContext.Session.SetObjectAsJson("Shoppingcart", products);
        }

        [HttpDelete("removeProduct")]
        public void RemoveProduct(string productName)
        {   
            var products = HttpContext.Session.GetObjectFromJson<List<ProductModel>>("Shoppingcart");

            var product = products.FirstOrDefault(x => x?.Name == productName);

            if (product != null)
            {
                products.Remove(product);
            }

            HttpContext.Session.SetObjectAsJson("Shoppingcart", products);
        }

        private void CreateSession()
        {
            var products = new List<ProductModel>();
            var session = HttpContext.Session.GetObjectFromJson<List<ProductModel>>("Shoppingcart");

            if (session is null)
            {
                HttpContext.Session.SetObjectAsJson("Shoppingcart", products);
            }
        }
        private static ProductModel CreateProduct(string productName, double productPrice)
        {
            return new ProductModel(productName, productPrice);
        }
    }
}
