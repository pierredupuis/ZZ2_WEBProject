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
    public class HouseController : Controller
    {

        // #################################################################################################
        // Méthodes _****() : Renvoient uniquement les données. Les méthodes créant des vues appellent ces méthodes => Economie de code, moins de recopie
        public static async Task<List<HouseModel>> _GetHouses()
        {
            List<HouseModel> Houses = new List<HouseModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<List<HouseModel>>(temp);
                }
            }
            return Houses;
        }
        public static async Task<HouseModel> _GetHouse(int ID)
        {
            HouseModel House = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    House = JsonConvert.DeserializeObject<HouseModel>(temp);
                }
            }
            return House;
        }

        // #################################################################################################
        // Méthodes de vue

        public async Task<ActionResult> Index()
        {
            return View(await _GetHouses());
        }

        // GET: House/Details/5
         public async Task<ActionResult> Details(int id)
         {
             return View(await _GetHouse(id));
         }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        [HttpPost]
        public async Task<ActionResult> Create(HouseModel hm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PostAsJsonAsync("api/House/Add/", hm);
                    if(!res.IsSuccessStatusCode)
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

        // GET: House/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _GetHouse(id));
        }

        // POST: House/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, HouseModel hm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PutAsJsonAsync("api/House/" + id + "/", hm);
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

        // GET: House/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _GetHouse(id));
        }

        // POST: House/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage res = await client.DeleteAsync("api/House/" + id);

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
