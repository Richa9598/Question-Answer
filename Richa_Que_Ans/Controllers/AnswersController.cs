using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Richa_Que_Ans.Data;
using Richa_Que_Ans.Models;

namespace Richa_Que_Ans.Controllers
{
    public class AnswersController : Controller
    {
        private readonly QuestionContext _context;

        public AnswersController(QuestionContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Answers.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers
                .FirstOrDefaultAsync(m => m.AnswerID == id);
            if (answers == null)
            {
                return NotFound();
            }

            return View(answers);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerID,QuestionID,AnswerText,AnswerDateAndTime")] Answer answers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(answers);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }
            return View(answers);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerID,QuestionID,AnswerText,AnswerDateAndTime")] Answer answers)
        {
            if (id != answers.AnswerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswersExists(answers.AnswerID))
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
            return View(answers);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers
                .FirstOrDefaultAsync(m => m.AnswerID == id);
            if (answers == null)
            {
                return NotFound();
            }

            return View(answers);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answers = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswersExists(int id)
        {
            return _context.Answers.Any(e => e.AnswerID == id);
        }
    }
}
