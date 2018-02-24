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
    public class WhiteWalkerController : Controller
    {

        // #################################################################################################
        // Méthodes _****() : Renvoient uniquement les données. Les méthodes créant des vues appellent ces méthodes => Economie de code, moins de recopie
        public static async Task<List<WhiteWalkerModel>> _GetWhiteWalkers()
        {
            List<WhiteWalkerModel> WhiteWalkers = new List<WhiteWalkerModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/WhiteWalker");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    WhiteWalkers = JsonConvert.DeserializeObject<List<WhiteWalkerModel>>(temp);
                }
            }
            return WhiteWalkers;
        }
        public static async Task<WhiteWalkerModel> _GetWhiteWalker(int ID)
        {
            WhiteWalkerModel WhiteWalker = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/WhiteWalker/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    WhiteWalker = JsonConvert.DeserializeObject<WhiteWalkerModel>(temp);
                }
            }
            return WhiteWalker;
        }

        // #################################################################################################
        // Méthodes de vue

        public async Task<ActionResult> Index()
        {
            return View(await _GetWhiteWalkers());
        }

        // GET: WhiteWalker/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _GetWhiteWalker(id));
        }

        // GET: WhiteWalker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhiteWalker/Create
        [HttpPost]
        public async Task<ActionResult> Create(WhiteWalkerModel wwm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PostAsJsonAsync("api/WhiteWalker/Add/", wwm);
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

        // GET: WhiteWalker/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _GetWhiteWalker(id));
        }

        // POST: WhiteWalker/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, WhiteWalkerModel wwm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PutAsJsonAsync("api/WhiteWalker/" + id + "/", wwm);
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

        // GET: WhiteWalker/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _GetWhiteWalker(id));
        }

        // POST: WhiteWalker/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage res = await client.DeleteAsync("api/WhiteWalker/" + id);

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
