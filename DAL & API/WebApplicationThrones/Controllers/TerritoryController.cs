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
    public class TerritoryController : Controller
    {

        // GET: Territory
        public async Task<ActionResult> Index()
        {
            List<TerritoryModel> Territories = new List<TerritoryModel>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:11526/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Territory");

                if(response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Territories = JsonConvert.DeserializeObject<List<TerritoryModel>>(temp);
                    /*foreach(Territory h in listTMP)
                    {
                        Territorys.Add(new TerritoryModel(h));
                    }*/
                }
            }
            return View(Territories);
        }
      
        // GET: Territory/Details/5
       /* public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: Territory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territory/Create
        [HttpPost]
        public async Task<ActionResult> Create(TerritoryModel tm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:11526/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PostAsJsonAsync("api/Territory/Add", tm);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Territory/Edit/5
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

        // GET: Territory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Territory/Delete/5
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
