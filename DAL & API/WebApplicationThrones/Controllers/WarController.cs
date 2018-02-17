using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApplicationThrones.Models;
using System.Collections.Specialized;

namespace WebApplicationThrones.Controllers
{
    public class WarController : Controller
    {

        // GET: War
        public async Task<ActionResult> Index()
        {
            List<WarModel> Wars = new List<WarModel>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:11526/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/War");

                if(response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Wars = JsonConvert.DeserializeObject<List<WarModel>>(temp);
                    /*foreach(War w in listTMP)
                    {
                        Wars.Add(new WarModel(w));
                    }*/
                }
            }
            return View(Wars);
        }
      
        // GET: War/Details/5
       /* public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: War/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: War/Create
        [HttpPost]
        public async Task<ActionResult> Create(WarModel hm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:11526/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PostAsJsonAsync("api/War/Add", hm);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: War/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: War/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: War/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: War/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
