using DC1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DC1.Controllers
{
    public class ArbitreController : Controller
    {
        private readonly DcContext _context;

        public ArbitreController(DcContext DCContext)
        {
            _context = DCContext;
        }

        // GET: ArbitreController
        public ActionResult Index()
        {
            List<Arbitre> arbitres = _context.Arbitres.ToList();
            return View(arbitres);
        }

        // GET: ArbitreController/Details/5
        public ActionResult Details(int id)
        {
            Arbitre arbitre = _context.Arbitres.Find(id);
            return View(arbitre);
        }

        // GET: ArbitreController/Create
        public ActionResult Create()
        {
            Arbitre arbitre = new Arbitre();
            return View(arbitre);
        }

        // POST: ArbitreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("NomArbitre,NationaliteArbitre")] Arbitre ArbitreData)
        {

            Arbitre arbitre = new Arbitre();
            if (ModelState.IsValid)
            {
                try
                {
                    arbitre.NomArbitre = ArbitreData.NomArbitre;
                    arbitre.NationaliteArbitre = ArbitreData.NationaliteArbitre;
                    _context.Arbitres.Add(arbitre);
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

        // GET: ArbitreController/Edit/5
        public ActionResult Edit(int id)
        {
            Arbitre arbitre = _context.Arbitres.Find(id);
            return View(arbitre);
        }

        // POST: ArbitreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("NomArbitre,NationaliteArbitre")] Arbitre ArbitreData)
        {
            Arbitre arbitre = _context.Arbitres.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    arbitre.NomArbitre = ArbitreData.NomArbitre;
                    arbitre.NationaliteArbitre = ArbitreData.NationaliteArbitre;
                    _context.Arbitres.Update(arbitre);
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

        // GET: ArbitreController/Delete/5
        public ActionResult Delete(int id)
        {
            Arbitre arbitre = _context.Arbitres.Find(id);
            return View(arbitre);
        }

        // POST: ArbitreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Arbitre arbitre = _context.Arbitres.Find(id);
            try
            {
                _context.Arbitres.Remove(arbitre);
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
