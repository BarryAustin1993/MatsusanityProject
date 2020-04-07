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
        public async Task<IActionResult> AddWorkoutToPlan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var workoutPlan = await _context.WorkoutPlans.FindAsync(id);
            if (workoutPlan == null)
            {
                return NotFound();
            }
            return View();
        }


        // POST: Workout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkoutToPlan (int id, Workout workout)
        {
            if (ModelState.IsValid)
            {
                Workout dbWorkout = new Workout();
                dbWorkout = workout;
                dbWorkout.WorkoutPlanId = id;
                _context.Workouts.Add(dbWorkout);
                
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowWorkoutPlans");
            }
            return RedirectToAction("ShowWorkoutPlans");
        }

    }
}
