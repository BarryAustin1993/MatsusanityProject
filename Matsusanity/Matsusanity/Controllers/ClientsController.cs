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
using System.Configuration;
using Stripe;

namespace Matsusanity.Controllers
{
    [Authorize(Roles = "Client, Administrator")]
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult GetEvents()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _context.Clients.Where(c => c.UserId == userId).FirstOrDefault();
            var plan = client.WorkoutPlanId;
            var events = _context.CalendarPlanWorkouts.Where(c => c.WorkoutPlanId == plan).ToList();
            return new JsonResult(events);
        }


        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clients.Include(c => c.IdentityUser).FirstOrDefaultAsync();
            return View(await applicationDbContext);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            Client client = new Client();
            return View(client);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FirstName,LastName,Gender")] Client client)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                client.UserId = userId;
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("ChooseAPlan", new { id = client.Id });
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
            return View(client);
        }

        // GET: ClientsPlan
        public async Task<IActionResult> ChooseAPlan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
            return View(client);
        }

        // POST: ClientsPlan
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseAPlan(int id, Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var clientDb = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
                    clientDb.WorkoutPlanId = client.WorkoutPlanId;
                    _context.Update(clientDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,LastName")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", client.UserId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }


        public IActionResult PickAPersonalTrainer()
        {
            var PersonalTrainers = _context.PersonalTrainers.ToList();
            return View(PersonalTrainers);
        }


        // GET: Trainer
        public async Task<IActionResult> AddTrainer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PersonalTrainer = await _context.PersonalTrainers.FindAsync(id);
            if (PersonalTrainer == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", PersonalTrainer.UserId);

            this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            PersonalTrainersClients PTC = new PersonalTrainersClients();
            PTC.PersonalTrainerId = PersonalTrainer.Id;
            PTC.ClientId = _context.Clients.Where(x => x.IdentityUser.Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault().Id;
            _context.PersonalTrainersClients.Add(PTC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       


        public IActionResult Payment()
        {
            var StripePublishKey = ConfigurationManager.AppSettings["pk_test_ASAFc9Sb2Ftho2oSMSj36U9Y005Rm6N28g"];
            ViewBag.StripePublishKey = StripePublishKey;
            return View();
        }
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 5000,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            // further application specific code goes here

            return View();
        }

        public async Task<IActionResult> Workout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts.Where(c => c.Id == id).FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        public IActionResult RequestInPersonSession()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestInPersonSession(int id, InSessionRequest model )
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _context.Clients.Where(c => c.UserId == userId).FirstOrDefault();
            var clientId = client.Id;

            if (ModelState.IsValid)
            {
                InSessionRequest inSessionRequest = new InSessionRequest()
                {
                    PersonalTrainerId = id,
                    ClientId = clientId,
                    Approved = null,
                    Start = model.Start,
                    End = model.End,
                    Title = client.FirstName + " " + client.LastName + " In Person Session",
                    Description = model.Start + " - " + model.End,
                    AllDay = false,
                    Url = null
                };
                _context.Add(inSessionRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
    }
}
