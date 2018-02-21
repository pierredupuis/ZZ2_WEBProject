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

        // #################################################################################################
        // Méthodes _****() : Renvoient uniquement les données. Les méthodes créant des vues appellent ces méthodes => Economie de code, moins de recopie
        public static async Task<List<TerritoryModel>> _GetTerritories()
        {
            List<TerritoryModel> Territories = new List<TerritoryModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Territory");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Territories = JsonConvert.DeserializeObject<List<TerritoryModel>>(temp);
                }
            }
            return Territories;
        }
        public static async Task<TerritoryModel> _GetTerritory(int ID)
        {
            TerritoryModel Territory = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Territory/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Territory = JsonConvert.DeserializeObject<TerritoryModel>(temp);
                }
            }
            return Territory;
        }
        public static async void _PostTerritory(TerritoryModel cm)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await client.PostAsJsonAsync("api/Territory/Add", cm);

            }
        }

        // #################################################################################################
        // Méthodes de vue


        // GET: Territory
        public async Task<ActionResult> Index()
        {
            return View(await _GetTerritories());
        }
        

        // GET: Territory/Details/5
         public async Task<ActionResult> Details(int id)
         {
             return View(await _GetTerritory(id));
         }

        // GET: Territory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territory/Create
        [HttpPost]
        public ActionResult Create(TerritoryModel tm)
        {
            try
            {
                _PostTerritory(tm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _GetTerritory(id));
        }

        // PUT: Territory/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, TerritoryModel tm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PutAsJsonAsync("api/TerritoryTest/" + id + "/", tm);
                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception("Error : " + res.StatusCode);
                    }

                }
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
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PostAsJsonAsync("api/Territory/Delete/" + id + "/", (string)null);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
