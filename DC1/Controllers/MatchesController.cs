using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DC1.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Immutable;

namespace DC1.Controllers
{
    public class MatchesController : Controller
    {
        private readonly DcContext _context;

        public MatchesController(DcContext context)
        {
            _context = context;
        }

        // GET: Matches

        public async Task<IActionResult> Index()
        {
            var dcContext = _context.Matches.Include(m => m.IdArbitreNavigation).Include(m => m.IdEquipeANavigation).Include(m => m.IdEquipeBNavigation).Include(m => m.IdStadeNavigation);
            return View(await dcContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.IdArbitreNavigation)
                .Include(m => m.IdEquipeANavigation)
                .Include(m => m.IdEquipeBNavigation)
                .Include(m => m.IdStadeNavigation)
                .FirstOrDefaultAsync(m => m.IdMatch == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {

              
          
            ViewData["IdArbitre"] = new SelectList(_context.Arbitres, "IdArbitre", "NomArbitre");
            ViewData["IdEquipeA"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe");
            ViewData["IdEquipeB"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe");
            ViewData["IdStade"] = new SelectList(_context.Stades, "IdStade", "NomStade");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatch,ScoreA,ScoreB,IdEquipeA,IdEquipeB,IdStade,IdArbitre")] Match match)
        {
            bool valid = !match.IdEquipeA.Equals(match.IdEquipeB) && _context.Equipes.Find(match.IdEquipeA).Groupe.Equals(_context.Equipes.Find(match.IdEquipeB).Groupe);
            if (ModelState.IsValid && valid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArbitre"] = new SelectList(_context.Arbitres, "IdArbitre", "NomArbitre", match.IdArbitre);
            ViewData["IdEquipeA"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe", match.IdEquipeA);
            ViewData["IdEquipeB"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe", match.IdEquipeB); //Where(eq => _context.Equipes.Find(eq).Equals(_context.Equipes.Find(match.IdEquipeA)));
            ViewData["IdStade"] = new SelectList(_context.Stades, "IdStade", "NomStade", match.IdStade);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["IdArbitre"] = new SelectList(_context.Arbitres, "IdArbitre", "NomArbitre", match.IdArbitre);
            ViewData["IdEquipeA"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe", match.IdEquipeA);
            ViewData["IdEquipeB"] = new SelectList(_context.Equipes, "IdEquipe", "NomEquipe", match.IdEquipeB);
            ViewData["IdStade"] = new SelectList(_context.Stades, "IdStade", "NomStade", match.IdStade);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatch,ScoreA,ScoreB,IdEquipeA,IdEquipeB,IdStade,IdArbitre")] Match match)
        {
            if (id != match.IdMatch)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.IdMatch))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArbitre"] = new SelectList(_context.Arbitres, "IdArbitre", "IdArbitre", match.IdArbitre);
            ViewData["IdEquipeA"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", match.IdEquipeA);
            ViewData["IdEquipeB"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", match.IdEquipeB);
            ViewData["IdStade"] = new SelectList(_context.Stades, "IdStade", "IdStade", match.IdStade);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.IdArbitreNavigation)
                .Include(m => m.IdEquipeANavigation)
                .Include(m => m.IdEquipeBNavigation)
                .Include(m => m.IdStadeNavigation)
                .FirstOrDefaultAsync(m => m.IdMatch == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matches == null)
            {
                return Problem("Entity set 'DcContext.Matches'  is null.");
            }
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> les_matche()
        {
            var dcContext = _context.Matches.Include(m => m.IdArbitreNavigation).Include(m => m.IdEquipeANavigation).Include(m => m.IdEquipeBNavigation).Include(m => m.IdStadeNavigation);
            return View(await dcContext.ToListAsync());
        }





        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.IdMatch == id);
        }
        //----------------------------------------------------------------------------------------------------------------------
        //hethi mazelit loutaniya affichage list de num group


        [Route("Matches/affcher0")]
        public IActionResult affcher0()
        {

            ViewBag["IdEquipeA"] = _context.Equipes.ToList().Select(c=>new  { Groupe= c.Groupe});
            return View();
        }


        // hethi loutaniya imrigla chwaya afficher les match ili  3andhim num id  ili da5altou fi methode
        

        [Route("Matches/affcher/{id?}")]
        public IActionResult affcher(int id)
        {
            // _context.Equipes.Where(gr => gr.Groupe == id.ToString()).Select(x=>new {  x.IdEquipe});
            //_context.Matches.Where(eqA => eqA.IdEquipeA == id ).ToList();

            /*IList<Match> MatchList = new List<Match>();

            MatchList=_context.Matches.Include(m => m.IdArbitreNavigation).
                Include(m => m.IdEquipeANavigation).Include(m => m.IdEquipeBNavigation).
                Include(m => m.IdStadeNavigation).Where(eq => eq.IdEquipeA == id).ToList();
            

            ViewData["Matchs"] = MatchList;

             return View();
            */
            IList<Equipe> EquipeList = new List<Equipe>();

            EquipeList = _context.Equipes.
                Include(m => m.IdEquipe).Include(m => m.Groupe).
                Where(eq => eq.Groupe.Equals( id)).ToList();


            ViewData["Matchs"] = EquipeList;

            return View();
        }


    }
}
