using HiTechStore.Common;
using HiTechStore.Data.Models.DatabaseModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HiTechStore.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public AuthenticationController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(AppConstants.BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: UserController/Register
        public ActionResult Register()
        {
            return View();
        }


        // GET: UserController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", registerModel.Username));
            keyValues.Add(new KeyValuePair<string, string>("email", registerModel.Email));
            keyValues.Add(new KeyValuePair<string, string>("password", registerModel.Password));

            //request.Content = new FormUrlEncodedContent(keyValues);

            string jsonString = JsonConvert.SerializeObject(keyValues);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient()) {
                using (var response = await httpClient.PostAsync(AppConstants.USER_REGISTRATION_ENDPOINT, stringContent)) {
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("Login");
                    else
                        return RedirectToAction("Register");
                }
            }


            //HttpResponseMessage resNews =
            //await client.PostAsync(AppConstants.USER_REGISTRATION_ENDPOINT, new StringContent(JsonConvert.SerializeObject(keyValues),
            //Encoding.UTF8, "application/json"));

            ////StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //if (resNews.IsSuccessStatusCode)
            //    return RedirectToAction("Login");
            //else
            //    return RedirectToAction("Register");


            //if (ModelState.IsValid)
            //{
            //    //var response = await client.PostAsync(AppConstants.USER_REGISTRATION_ENDPOINT, httpContent);
            //    var t = await client.PostAsJsonAsync(AppConstants.USER_REGISTRATION_ENDPOINT, json);

            //    //Response R = JsonConvert.DeserializeObject<Response>((JsonConvert.DeserializeObject(t.Content.ReadAsStringAsync().Result.ToString())).ToString());

            //    //if (t.IsSuccessStatusCode)
            //    //    return RedirectToAction("Login");
            //    //else
            //    //    return RedirectToAction("Register");

            //    var response_api = await t.Content.ReadAsStringAsync();

            //    if (t.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Login");
            //    }
            //    else
            //    {
            //        //ModelState.AddModelError(string.Empty, response_api.ToString());
            //        return RedirectToAction("Register");
            //    }
            //}

            //return RedirectToAction("Register");
        }


    }
}