using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;


namespace Tengella.Survey.WebApp.Controllers
{
    public class SurveyObjectsController : Controller
    {
        private readonly SurveyDbContext _context;

        public SurveyObjectsController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: SurveyObjects
        public async Task<IActionResult> Index()
        {
            var surveyDbContext = _context.SurveyObjects
                .Include(s => s.User)
                .Include(s => s.Questions);
            return View(await surveyDbContext.ToListAsync());
        }

        // GET: SurveyObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _context.SurveyObjects
                .Include(s => s.User)
                .Include(s => s.Questions).ThenInclude(s => s.Answers)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == id);
            if (surveyObject == null)
            {
                return NotFound();
            }
            var surveyViewModel = new SurveyViewModel
            {
                SurveyId = surveyObject.SurveyObjectId,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionName,
                    QuestionPosition = q.QuestionPosition,
                    QuestionAnswers = q.Answers.Select(a => new AnswerViewModel
                    {
                        AnswerId = a.AnswerId,
                        AnswerName = a.AnswerName
                    }).ToList()
                }).ToList()
            };
            return View(surveyViewModel);
        }

        // GET: SurveyObjects/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: SurveyObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurveyObjectId,SurveyTitle,SurveyDescription,SurveyType,UserId")] SurveyObject surveyObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surveyObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", surveyObject.UserId);
            return View(surveyObject);
        }

        // GET: SurveyObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _context.SurveyObjects.FindAsync(id);
            if (surveyObject == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", surveyObject.UserId);
            return View(surveyObject);
        }

        // POST: SurveyObjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurveyObjectId,SurveyTitle,SurveyDescription,SurveyType,UserId")] SurveyObject surveyObject)
        {
            if (id != surveyObject.SurveyObjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyObjectExists(surveyObject.SurveyObjectId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", surveyObject.UserId);
            return View(surveyObject);
        }

        // GET: SurveyObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _context.SurveyObjects
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == id);
            if (surveyObject == null)
            {
                return NotFound();
            }

            return View(surveyObject);
        }

        // POST: SurveyObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surveyObject = await _context.SurveyObjects.FindAsync(id);
            if (surveyObject != null)
            {
                _context.SurveyObjects.Remove(surveyObject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyObjectExists(int id)
        {
            return _context.SurveyObjects.Any(e => e.SurveyObjectId == id);
        }
    }
}
