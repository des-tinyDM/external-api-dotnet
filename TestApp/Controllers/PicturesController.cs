using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TestApp.Controllers
{
    public class PicturesController : Controller
    {
        // GET: Pictures
        public async Task<ActionResult> Index()
        {
            Picture dogPic = new Picture();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dog.ceo/api/breeds/image/random");
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("https://dog.ceo/api/breeds/image/random");

                if (Res.IsSuccessStatusCode)
                {
                    var PicResponse = Res.Content.ReadAsStringAsync().Result;
                    dogPic = JsonConvert.DeserializeObject<Picture>(PicResponse);
                }
                return View(dogPic);
            }

        }
    }
}