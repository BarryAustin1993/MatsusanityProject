using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matsusanity.Data;
using Matsusanity.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Matsusanity.ViewModels;

namespace Matsusanity.Controllers
{
    [Authorize(Roles = "Personal Trainer, Administrator")]
    public class PersonalTrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalTrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalTrainers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonalTrainers.Include(c => c.IdentityUser).FirstOrDefaultAsync();
            return View(await applicationDbContext);
        } 

        // GET: PersonalTrainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            if (personalTrainer == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.UserId);
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonalTrainer personalTrainer)
        {
            if (id != personalTrainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalTrainerExists(personalTrainer.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.UserId);
            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            _context.PersonalTrainers.Remove(personalTrainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalTrainerExists(int id)
        {
            return _context.PersonalTrainers.Any(e => e.Id == id);
        }

        // GET: Show Clients
        public async Task<IActionResult> ShowClients()
        {
            var LoggedInPersonalTrainer = _context.PersonalTrainers.Where(x => x.IdentityUser.Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            var id = LoggedInPersonalTrainer.Id;
            var ListOfClientsIds = _context.PersonalTrainersClients.Where(m => m.PersonalTrainerId == id).Select(x => x.ClientId);
            var clients = _context.Clients.Where(c => ListOfClientsIds.Contains(c.Id));


            return View(clients);
        }

        // GET: WorkoutPlans
        public async Task<IActionResult> ShowWorkoutPlans()
        {
            return View(await _context.WorkoutPlans.ToListAsync());
        }

        // GET: Workout/Create
        public IActionResult AddWorkoutToPlan()
        {
            return View();
        }
        // POST: Workout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkoutToPlan (int id, Workout_Calendar_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                Workout workout = new Workout()
                {
                    WorkoutPlanId = id,
                    ExerciseOne = model.Workout.ExerciseOne,
                    RepsOne = model.Workout.RepsOne,
                    SetsOne = model.Workout.SetsOne,
                    WeightOne = model.Workout.WeightOne,
                    ExerciseTwo = model.Workout.ExerciseTwo,
                    RepsTwo = model.Workout.RepsTwo,
                    SetsTwo = model.Workout.SetsTwo,
                    WeightTwo = model.Workout.WeightTwo,
                    ExerciseThree = model.Workout.ExerciseThree,
                    RepsThree = model.Workout.RepsThree,
                    SetsThree = model.Workout.SetsThree,
                    WeightThree = model.Workout.WeightThree,
                    ExerciseFour = model.Workout.ExerciseFour,
                    RepsFour = model.Workout.RepsFour,
                    SetsFour = model.Workout.SetsFour,
                    WeightFour = model.Workout.WeightFour,
                    ExerciseFive = model.Workout.ExerciseFive,
                    RepsFive = model.Workout.RepsFive,
                    SetsFive = model.Workout.SetsFive,
                    WeightFive = model.Workout.WeightFive

                };
                _context.Add(workout);
                await _context.SaveChangesAsync();

                var dbWorkout = _context.Workouts.ToList().LastOrDefault();
                int dbWorkoutId = dbWorkout.Id;

                CalendarPlanWorkout calendarPlanWorkout = new CalendarPlanWorkout()
                {
                    Title = model.CalendarPlanWorkout.Title,
                    Description = model.CalendarPlanWorkout.Description,
                    Url = "https://localhost:44366/clients/Workout/" + dbWorkoutId,
                    WorkoutId = workout.Id,
                    WorkoutPlanId = id,
                    Start = model.CalendarPlanWorkout.Start,
                    End = null,
                    AllDay = true
                };
                _context.Add(calendarPlanWorkout);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index", "PersonalTrainers");
            }
            return View();
        }
        public IActionResult SetInPersonHours()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetInPersonHours(string id, TrainerWeeklyAvailability model )
        {
            if (ModelState.IsValid)
            {
                TrainerWeeklyAvailability weeklyAvailability = new TrainerWeeklyAvailability()
                {
                    PersonalTrainerId = id,
                    MondayStartTime = model.MondayStartTime,
                    MondayEndTime = model.MondayEndTime,
                    TuesdayStartTime = model.TuesdayStartTime,
                    TuesdayEndTime = model.TuesdayEndTime,
                    WednesdayStartTime = model.WednesdayStartTime,
                    WednesdayEndTime = model.WednesdayEndTime,
                    ThursdayStartTime = model.ThursdayStartTime,
                    ThursdayEndTime = model.ThursdayEndTime,
                    FridayStartTime = model.FridayStartTime,
                    FridayEndTime = model.FridayEndTime,
                    SaturdayStartTime = model.SaturdayStartTime,
                    SaturdayEndTime = model.SaturdayEndTime,
                    SundayStartTime = model.SundayStartTime,
                    SundayEndTime = model.SundayEndTime
                };
                _context.Add(weeklyAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalTrainers");
            }
            return View();
        }
    }
}
