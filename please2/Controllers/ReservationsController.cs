using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using please2.Data;
using please2.Models;

using Microsoft.AspNetCore.Identity;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Claims;
using MailKit.Security;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf;

namespace please2.Controllers
{
	[Authorize]
	public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
		
		public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
              return _context.Reservation != null ? 
                          View(await _context.Reservation.ToListAsync()) :
                          Problem("Entity set 'please2Context.Reservation'  is null.");
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public async Task<IActionResult> CreateAsync(int id)
        {
            var Book = await _context.Livre.FindAsync(id);
            Reservation reservation = new Reservation();
            reservation.Book = Book.title;
            reservation.Bookid = id;
            return View(reservation);
        }
        public void SendEmail(string email, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ELibrary", "anouar7moussaoui@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = messageBody };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("anouar7moussaoui@gmail.com", "syod iyco hxtm hsrx");
                client.Send(message);
                client.Disconnect(true);
            }
        }
        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Id)
        {
            Reservation reservation = new Reservation();
            var Book = await _context.Livre.FindAsync(Id);
            
                reservation.Book =Book.title;
                reservation.Bookid = Book.Id;

                var userEmail = User.Identity.Name;

                // Obtenez l'ID de l'utilisateur connecté
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                reservation.Adherent = userEmail;
                reservation.Adherentid = userId;

                _context.Add(reservation);
                await _context.SaveChangesAsync();
            //email
            SendEmail(reservation.Adherent, "Bon de Réservation.", "Votre Réservation est bien confirmé.....");

            return View(reservation);
        }

        

       

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Book,BookId,Adherent,AdherentId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'please2Context.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservation?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
        

       
       
    }
}
