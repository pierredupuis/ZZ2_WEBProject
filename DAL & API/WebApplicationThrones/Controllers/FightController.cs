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
    public class FightController : Controller
    {

        // #################################################################################################
        // Méthodes _****() : Renvoient uniquement les données. Les méthodes créant des vues appellent ces méthodes => Economie de code, moins de recopie
        public static async Task<List<FightModel>> _GetFights()
        {
            List<FightModel> Fights = new List<FightModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Fight");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fights = JsonConvert.DeserializeObject<List<FightModel>>(temp);

                    foreach (FightModel fm in Fights)
                    {
                        fm.AttArmy_obj = await HouseController._GetHouse(fm.AttArmy);
                        if (fm.DefArmy > 0)
                            fm.DefArmy_obj = await HouseController._GetHouse(fm.DefArmy);
                        else if(fm.DefArmy < 0)
                            fm.DefArmy_obj = await WhiteWalkerController._GetWhiteWalker(fm.DefArmy);

                        if(fm.WinningArmy > 0)
                            fm.WinningArmy_obj = await HouseController._GetHouse(fm.WinningArmy);
                        else if(fm.WinningArmy < 0)
                            fm.WinningArmy_obj = await WhiteWalkerController._GetWhiteWalker(fm.WinningArmy);
                    }
                }
            }
            return Fights;
        }
        public static async Task<FightModel> _GetFight(int ID)
        {
            FightModel Fight = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Fight/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fight = JsonConvert.DeserializeObject<FightModel>(temp);

                    Fight.AttArmy_obj = await HouseController._GetHouse(Fight.AttArmy);
                    if (Fight.DefArmy > 0)
                        Fight.DefArmy_obj = await HouseController._GetHouse(Fight.DefArmy);
                    else
                        Fight.DefArmy_obj = await WhiteWalkerController._GetWhiteWalker(Fight.DefArmy);
                   
                    if (Fight.WinningArmy > 0)
                        Fight.WinningArmy_obj = await HouseController._GetHouse(Fight.WinningArmy);
                    else
                        Fight.WinningArmy_obj = await WhiteWalkerController._GetWhiteWalker(Fight.WinningArmy);
                }
            }
            return Fight;
        }

        // #################################################################################################
        // Méthodes de vue

        // GET: Fight
        public async Task<ActionResult> Index()
        {
            return View(await _GetFights());
        }


        // GET: Fight/Details/5
         public async Task<ActionResult> Details(int id)
         {
             return View(await _GetFight(id));
         }

        // GET: Fight/Create
        public async Task<ActionResult> Create()
        {

            List<HouseModel> HouseList = await HouseController._GetHouses();
            List<WhiteWalkerModel> WhiteWalkerList = await WhiteWalkerController._GetWhiteWalkers();

            if (HouseList.Count + WhiteWalkerList.Count > 0)
            {

                SelectListGroup HGroup = new SelectListGroup() { Name = "Houses" };
                SelectListGroup WWGroup = new SelectListGroup() { Name = "White Walkers" };
                List<SelectListItem> ArmyItemList = new List<SelectListItem>();
                List<SelectListItem> HouseItemList = new List<SelectListItem>();

                foreach (HouseModel hm in HouseList)
                {
                    ArmyItemList.Add(new SelectListItem() { Text = hm.Name, Value = hm.ID.ToString(), Group = HGroup });
                    HouseItemList.Add(new SelectListItem() { Text = hm.Name, Value = hm.ID.ToString() });
                }

                foreach (WhiteWalkerModel wwm in WhiteWalkerList)
                {
                    ArmyItemList.Add(new SelectListItem() { Text = wwm.NumberOfUnits.ToString(), Value = wwm.Id.ToString(), Group = WWGroup });
                }

                ViewBag.AttArmy = HouseItemList;
                ViewBag.DefArmy = ArmyItemList;

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        // POST: Fight/Create
        [HttpPost]
        public async Task<ActionResult> Create(FightModel fm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    await client.PostAsJsonAsync("api/Fight/Add", fm);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Start(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Fight/Start/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Boolean>(temp);
                }
            }
            return RedirectToAction("Index");
        }
        // GET: Fight/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _GetFight(id));
        }

        // PUT: Fight/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, HouseModel fm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PutAsJsonAsync("api/Fight/" + id + "/", fm);
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

        // GET: Fight/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _GetFight(id));
        }

        // POST: Fight/Delete/5
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


                    await client.DeleteAsync("api/Fight/" + id);

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
