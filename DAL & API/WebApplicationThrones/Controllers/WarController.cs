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
        // #################################################################################################
        // Méthodes _****() : Renvoient uniquement les données. Les méthodes créant des vues appellent ces méthodes => Economie de code, moins de recopie
        public static async Task<List<WarModel>> _GetWars()
        {
            List<WarModel> Wars = new List<WarModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/War");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Wars = JsonConvert.DeserializeObject<List<WarModel>>(temp);
                }
            }
            return Wars;
        }
        public static async Task<WarModel> _GetWar(int ID)
        {
            WarModel War = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/War/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    War = JsonConvert.DeserializeObject<WarModel>(temp);
                }
            }
            return War;
        }
        public static async void _PostWar(WarModel cm)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await client.PostAsJsonAsync("api/War/Add", cm);

            }
        }

        // #################################################################################################
        // Méthodes de vue

        // GET: War
        public async Task<ActionResult> Index()
        {
            return View(await _GetWars());
        }



        // GET: War/Details/5
         public async Task<ActionResult> Details(int id)
         {
             return View(await _GetWar(id));
         }

        // GET: War/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<HouseModel> HouseList = await HouseController._GetHouses();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (HouseModel hm in HouseList)
            {
                list.Add(new SelectListItem() { Text = hm.Name, Value = hm.ID.ToString() });
            }
            ViewBag.HouseList = list;

            return View();
        }

        // POST: War/Create
        [HttpPost]
        public ActionResult Create(WarModel wm)
        {
            try
            {
                _PostWar(wm);
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


                    await client.PostAsJsonAsync("api/War/Delete/" + id + "/", (string)null);

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
