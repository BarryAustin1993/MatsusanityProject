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
using Matsusanity.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Matsusanity.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministratorsController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Administrators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Administrators.Include(a => a.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Administrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // GET: Home Page Options
        public IActionResult Home()
        {
            return View();
        }
        // GET: Home Page Options
        public IActionResult CreatePersonalTrainerView()
        {
            CreatePersonalTrainerViewModel createPersonalTrainerViewModel = new CreatePersonalTrainerViewModel()
            {
                IdentityUser = new Microsoft.AspNetCore.Identity.IdentityUser(),
                PersonalTrainer = new PersonalTrainer(),
                IdentityUserRole = new IdentityUserRole<string>()
            };
            ViewData["IdentityUser"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePersonalTrainerView(CreatePersonalTrainerViewModel model, IdentityUser identityUser)
        {
            if (ModelState.IsValid)
            {
                Guid guid = Guid.NewGuid();
                var hasher = new PasswordHasher<IdentityUser>();
                var role = _context.Roles.Where(r => r.Name == "Personal Trainer").FirstOrDefault();

                identityUser = new Microsoft.AspNetCore.Identity.IdentityUser
                {
                    Id = guid.ToString(),
                    Email = model.IdentityUser.Email,
                    UserName = model.IdentityUser.Email,
                    NormalizedEmail = model.IdentityUser.Email.ToUpper(),
                    NormalizedUserName = model.IdentityUser.Email.ToUpper(),
                    PasswordHash = hasher.HashPassword(null, model.IdentityUser.PasswordHash)

                };

                PersonalTrainer personalTrainer = new PersonalTrainer
                {
                    UserId = guid.ToString(),
                    FirstName = model.PersonalTrainer.FirstName,
                    LastName = model.PersonalTrainer.LastName
                };

                IdentityUserRole<string> identityUserRole = new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
                {
                    UserId = guid.ToString(),
                    RoleId = role.Id
                };

                _context.Add(identityUserRole);
                _context.Add(identityUser);
                _context.Add(personalTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalTrainers");
            };

            ViewData["UserId"] = new SelectList(_context.PersonalTrainers, "Id", "Id", model.PersonalTrainer.UserId);
            return View();
        }

        // GET: Administrators/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FirstName,LastName")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", administrator.UserId);
            return View(administrator);
        }

        // GET: Administrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", administrator.UserId);
            return View(administrator);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,LastName")] Administrator administrator)
        {
            if (id != administrator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", administrator.UserId);
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrators
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            return _context.Administrators.Any(e => e.Id == id);
        }
        public IActionResult CreateWorkoutPlan()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorkoutPlan(WorkoutPlan model)
        {
            if (ModelState.IsValid)
            {
                WorkoutPlan workout = new WorkoutPlan()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _context.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Administrators");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", model.Id);
            return View();
        }
        public async Task<IActionResult> EditActivePlans()
        {
            var applicationDbContext = _context.WorkoutPlans;
            return View(await applicationDbContext.ToListAsync());
        }

    
    }
}

