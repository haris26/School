using System.Data;
using System.Linq;
using System.Web.Mvc;
using Database;
using ReservationSystem.Models;


namespace ReservationSystem.Controllers
{
    public class CharacteristicNamesController : BaseController
    {
        

        public ActionResult Index()
        {
            return View(new CharacteristicNameUnit(Context).Get().ToList().Select(x => Factory.Create(x)));
        }

        
        public ActionResult Details(int id)
        {

            return View(Factory.Create(new CharacteristicNameUnit(Context).Get(id)));
        }

    
        public ActionResult Create()
        {
            FillBag();
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacteristicNameModel model)
        {

            if (ModelState.IsValid)
            {

                new CharacteristicNameUnit(Context).Insert(Parser.Create(model));
                return RedirectToAction("Index");
            }
            FillBag();
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            FillBag();
            return View(Factory.Create(new CharacteristicNameUnit(Context).Get(id)));
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacteristicNameModel model)
        {
            if (ModelState.IsValid)
            {

                new CharacteristicNameUnit(Context).Update(Parser.Create(model), model.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }

     
        public ActionResult Delete(int id)
        {
            CharacteristicName characteristicName = new CharacteristicNameUnit(Context).Get(id);
            return View(Factory.Create(characteristicName));
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CharacteristicNameUnit(Context).Delete(id);
            return RedirectToAction("Index");
        }

        void FillBag()
        {
            ViewBag.ResourceCategoryList = new SelectList(new Repository<ResourceCategory>(Context).Get().ToList(), "Id", "CategoryName");

        }
    }
}
