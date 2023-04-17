using DC1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;

namespace DC1.Controllers
{
    public class EquipeController : Controller
    {
        private readonly DcContext _context;

        public EquipeController(DcContext DCContext)
        {
            _context = DCContext;
        }

        // GET: EquipeController
        public ActionResult Index()
        {
            List<Equipe> equipes = _context.Equipes.ToList();
            return View(equipes);
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            Equipe equipe = _context.Equipes.Find(id);
            return View(equipe);
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            Equipe equipe = new Equipe();
            return View(equipe);
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("NomEquipe,Groupe")] Equipe EquipeData)
        {

            Equipe equipe = new Equipe();
            if (ModelState.IsValid)
            {
                try
                {
                    equipe.NomEquipe = EquipeData.NomEquipe;
                    equipe.Groupe = EquipeData.Groupe;
                    _context.Equipes.Add(equipe);
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

        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            Equipe equipe = _context.Equipes.Find(id);
            return View(equipe);
        }

        // POST: EquipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("NomEquipe,Groupe")] Equipe EquipeData)
        {
            Equipe equipe = _context.Equipes.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    equipe.NomEquipe = EquipeData.NomEquipe;
                    equipe.Groupe = EquipeData.Groupe;
                    _context.Equipes.Update(equipe);
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

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            Equipe equipe = _context.Equipes.Find(id);
            return View(equipe);
        }

        // POST: EquipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Equipe equipe = _context.Equipes.Find(id);
            try
            {
                _context.Equipes.Remove(equipe);
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
