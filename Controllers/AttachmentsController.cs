using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeorgianCollege.Data;
using GeorgianCollege.Models;

namespace GeorgianCollege.Controllers
{
    public class AttachmentsController : Controller
    {
        private readonly GeorgianCollegeDbContext _context;

        public AttachmentsController(GeorgianCollegeDbContext context)
        {
            _context = context;
        }

 
        public async Task<IActionResult> Index()
        {
            var georgianCollegeDbContext = _context.Attachments.Include(a => a.Ticket);
            return View(await georgianCollegeDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

       
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "TicketId", "TicketId");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentId,TicketId,FileType,FileData,UploadedAt")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "TicketId", "TicketId", attachment.TicketId);
            return View(attachment);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "TicketId", "TicketId", attachment.TicketId);
            return View(attachment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttachmentId,TicketId,FileType,FileData,UploadedAt")] Attachment attachment)
        {
            if (id != attachment.AttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentExists(attachment.AttachmentId))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "TicketId", "TicketId", attachment.TicketId);
            return View(attachment);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment != null)
            {
                _context.Attachments.Remove(attachment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttachmentExists(int id)
        {
            return _context.Attachments.Any(e => e.AttachmentId == id);
        }
    }
}
