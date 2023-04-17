using DC1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DC1.Controllers
{
    public class StadeController : Controller
    {
        private readonly DcContext _context;

        public StadeController(DcContext DCContext)
        {
            _context = DCContext;
        }

        // GET: StadeController
        public ActionResult Index()
        {
            List<Stade> stades = _context.Stades.ToList();
            return View(stades);
        }

        // GET: StadeController/Details/5
        public ActionResult Details(int id)
        {
            Stade stade = _context.Stades.Find(id);
            return View(stade);
        }

        // GET: StadeController/Create
        public ActionResult Create()
        {
            Stade stade = new Stade();
            return View(stade);
        }

        // POST: StadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("NomStade,CapaciteStade")] Stade StadeData)
        {

            Stade stade = new Stade();
            if (ModelState.IsValid)
            {
                try
                {
                    stade.NomStade = StadeData.NomStade;
                    stade.CapaciteStade = StadeData.CapaciteStade;
                    _context.Stades.Add(stade);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: StadeController/Edit/5
        public ActionResult Edit(int id)
        {
            Stade stade = _context.Stades.Find(id);
            return View(stade);
        }

        // POST: StadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("NomStade,CapaciteStade")] Stade StadeData)
        {
            Stade stade = _context.Stades.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    stade.NomStade = StadeData.NomStade;
                    stade.CapaciteStade = StadeData.CapaciteStade;
                    _context.Stades.Update(stade);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: StadeController/Delete/5
        public ActionResult Delete(int id)
        {
            Stade stade = _context.Stades.Find(id);
            return View(stade);
        }

        // POST: StadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Stade stade = _context.Stades.Find(id);
            try
            {
                _context.Stades.Remove(stade);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
