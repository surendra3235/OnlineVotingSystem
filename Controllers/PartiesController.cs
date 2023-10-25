using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    [Authorize]
    public class PartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
              return _context.Party != null ? 
                          View(await _context.Party.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Party'  is null.");
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Party == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            ViewBag.PartyOptions = new List<SelectListItem>
    {
        new SelectListItem { Text = "", Value = "" },
        new SelectListItem { Text = "YCP", Value = "YCP" },
        new SelectListItem { Text = "TDP", Value = "TDP" },
        new SelectListItem { Text = "JSN", Value = "JSN" },
        new SelectListItem { Text = "BJP", Value = "BJP" },
        new SelectListItem { Text = "CONGRESS", Value = "CONGRESS" },
        new SelectListItem { Text = "COMMUNIST", Value = "COMMUNIST" }
    };

            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoterName,MobileNumber,Address,City,State,DateOfBirth,Age,SelectParty")] Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(party);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Party == null)
            {
                return NotFound();
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoterName,MobileNumber,Address,City,State,DateOfBirth,Age,SelectParty")] Party party)
        {
            if (id != party.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.Id))
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
            return View(party);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Party == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Party == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Party'  is null.");
            }
            var party = await _context.Party.FindAsync(id);
            if (party != null)
            {
                _context.Party.Remove(party);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyExists(int id)
        {
          return (_context.Party?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
