using HiTechStore.Common;
using HiTechStore.Data.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HiTechStore.Web.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(AppConstants.BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: products/types
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(AppConstants.PRODUCTS_TYPES_ENDPOINT);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                foreach (KeyValuePair<string, object> keyValuePair in values)
                {
                    if (keyValuePair.Key.Equals("product_types"))
                    {
                        List<ProductTypeResponse> productTypes = JsonConvert.DeserializeObject<List<ProductTypeResponse>>(keyValuePair.Value.ToString());
                        return View(productTypes);
                    }
                }
            }
            return null;
            //return View("Error");
        }

        //}

        // GET: products
        //public ActionResult Index()
        //{
        //    IEnumerable<ProductType> students = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(AppConstants.BASE_URL);
        //        //HTTP GET
        //        var responseTask = client.GetAsync("student");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<ProductType>>();
        //            readTask.Wait();

        //            students = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            students = Enumerable.Empty<ProductType>();

        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return View(students);
        //}
    }
}
