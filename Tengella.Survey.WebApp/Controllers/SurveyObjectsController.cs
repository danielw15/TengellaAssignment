using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;


namespace Tengella.Survey.WebApp.Controllers
{
    public class SurveyObjectsController : Controller
    {
        private readonly SurveyDbContext _context;
        private readonly ISurveyService _surveyService;
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SurveyObjectsController(SurveyDbContext context, ISurveyService surveyService, ISubmissionService submissionService, IMapper mapper)
        {
            _context = context;
            _surveyService = surveyService;
            _submissionService = submissionService;
            _mapper = mapper;
        }

        // GET: SurveyObjects
        public async Task<IActionResult> Index()
        {
            return View(await _surveyService.GetAllSurveyAsync());
        }

        // GET: SurveyObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var surveyObject = await _surveyService.GetSurveyAsync(id);
            if (surveyObject == null)
            {
                return NotFound();
            }
            var surveyViewModel = new SurveyViewModel
            {
                SurveyObjectId = surveyObject.SurveyObjectId,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionName,
                    QuestionPosition = q.QuestionPosition,
                    QuestionChoices = q.Choices.Select(a => new ChoiceViewModel
                    {
                        ChoiceId = a.ChoiceId,
                        ChoicePosition = a.Position,
                        ChoiceText = a.Text
                    }).ToList()
                }).ToList()
            };
            
            return View(surveyViewModel);
        }

        // GET: SurveyObjects/DoSurvey/1
        [HttpGet]
        [Route("/{id:int}")]
        public async Task<IActionResult> DoSurvey(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyObject = await _surveyService.GetSurveyAsync(id);
            
            if (surveyObject == null)
            {
                return NotFound();
            }
            var surveyViewModel = new SurveyViewModel
            {
                SurveyObjectId = surveyObject.SurveyObjectId,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyType = surveyObject.SurveyType,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionName,
                    QuestionPosition = q.QuestionPosition,
                    QuestionChoices = q.Choices.Select(a => new ChoiceViewModel
                    {
                        ChoiceId = a.ChoiceId,
                        ChoicePosition = a.Position,
                        ChoiceText = a.Text
                    }).ToList()
                }).ToList()
            };
            return View(surveyViewModel);
        }
        // GET: SurveyObjects/DoSurvey/1
        [HttpPost]
        [Route("/{id:int}")]
        public async Task<IActionResult> DoSurvey(int? id, SurveyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var surveyObject = _surveyService.GetSurveyAsync(id);
                viewModel = _mapper.Map<SurveyViewModel>(surveyObject);
               
                return View(viewModel);
            }
            var submission = new Submission
            {
                SurveyObjectId = viewModel.SurveyObjectId,
                Answers = viewModel.SurveyAnswers.Select(a => new Answer
                {
                    AnswerId = a.AnswerId,
                    QuestionId = a.QuestionId,
                    SubmissionId = a.SubmissionId,
                    AnswerValue = a.AnswerValue
                }).ToList(),
                SubmissionDate = DateTime.Now
            };
            await _submissionService.SubmitSubmissionAsync(submission);
            await _submissionService.SaveSubmissionAsync();
            return View(viewModel);
        }

        // GET: SurveyObjects/Create
        public IActionResult Create()
        {
            SurveyObject survey = new SurveyObject();
            survey.UserId = 1;
            SurveyViewModel viewModel = new SurveyViewModel();
            viewModel = _mapper.Map<SurveyViewModel>(survey);
            return View(viewModel);
        }

        // POST: SurveyObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel model)
        {
            var survey = _mapper.Map<SurveyObject>(model);
            survey.UserId = 1;
            await _surveyService.SubmitSurveyAsync(survey);
            await _surveyService.SaveSurveyAsync();
            return RedirectToAction(nameof(Index));
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



        //ADD QUESTION
        // SurveyObjects/AddQuestion/8
        [HttpPost]
        public async Task<IActionResult> AddQuestion(SurveyViewModel model)
        {
            if (model != null)
            {
                var question = new Question();
                question.SurveyObjectId = model.SurveyObjectId;
                if (model!.SurveyQuestions == null)
                {
                    model!.SurveyQuestions = new List<QuestionViewModel>();
                }
                var questionModel = new QuestionViewModel();
                questionModel = _mapper.Map<QuestionViewModel>(question);
                model.SurveyQuestions.Add(questionModel);
                
                
                return PartialView("_QuestionRowPartial", questionModel);
            }
            else
            {
                model = new SurveyViewModel();
                var question = new QuestionViewModel();
                model!.SurveyQuestions!.Add(question);
                return PartialView("_QuestionRowPartial", model);
            }
            
        }
        //ADD QUESTION
        // SurveyObjects/AddChoice/8
        [HttpPost]
        public IActionResult AddChoice(int position, SurveyViewModel model)
        {
            if (model.SurveyQuestions != null)
            {
                var choice = new ChoiceViewModel();
                model!.SurveyQuestions[position]!.QuestionChoices!.Add(choice);
                return PartialView("_ChoiceRowPartial", model);
            }
            else
            {
                var question = new QuestionViewModel();
                var choice = new ChoiceViewModel();
                question.QuestionChoices!.Add(choice);
                model.SurveyQuestions!.Add(question);
                return PartialView("_ChoiceRowPartial", model);
            }
        }

        private bool SurveyObjectExists(int id)
        {
            return _context.SurveyObjects.Any(e => e.SurveyObjectId == id);
        }
    }
}
