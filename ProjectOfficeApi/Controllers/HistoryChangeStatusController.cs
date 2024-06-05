using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOffice.DataBase.Entities;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryChangeStatusController : ControllerBase
    {
        private readonly Context _context;

        public HistoryChangeStatusController()
        {
            _context = new Context();
        }

        // GET: api/HistoryChangeStatus
        [HttpGet]
        public async Task<IActionResult> GetHistoryChangeStatuses()
        {
          if (_context.HistoryChangeStatuses == null)
          {
              return NotFound();
          }
            return Ok(await _context.HistoryChangeStatuses.ToListAsync());
        }

        [HttpGet("today/{projectId:Guid}")]
        public async Task<IActionResult> GetHistoryChangeStatuseEndOnDay(Guid projectId)
        {
            DateTime now = DateTime.Today;
            if (_context.HistoryChangeStatuses == null)
            {
                return NotFound();
            }
            return Ok(await _context.HistoryChangeStatuses
                .Include(x=> x.Task)
                .Where(x => x.ChangeTime.Month == now.Month &&
                x.ChangeTime.Year == now.Year &&
                x.ChangeTime.Day == now.Day &&
                x.StatusId == 5 &&
                x.Task.ProjectId == projectId)
                .CountAsync());
        }

        // GET: api/HistoryChangeStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryChangeStatus>> GetHistoryChangeStatus(int id)
        {
          if (_context.HistoryChangeStatuses == null)
          {
              return NotFound();
          }
            var historyChangeStatus = await _context.HistoryChangeStatuses.FindAsync(id);

            if (historyChangeStatus == null)
            {
                return NotFound();
            }

            return historyChangeStatus;
        }

        // PUT: api/HistoryChangeStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryChangeStatus(int id, HistoryChangeStatus historyChangeStatus)
        {
            if (id != historyChangeStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(historyChangeStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryChangeStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HistoryChangeStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostHistoryChangeStatus(HistoryChangeStatusRequest historyChangeStatus)
        {
          if (_context.HistoryChangeStatuses == null)
          {
              return Problem("Entity set 'DbContextProjectOffice.HistoryChangeStatuses'  is null.");
          }
            HistoryChangeStatus historyChangeStatus1 = new()
            {
                StatusId = historyChangeStatus.StatusId,
                TaskId = historyChangeStatus.TaskId
            };
            _context.HistoryChangeStatuses.Add(historyChangeStatus1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryChangeStatus", new { id = historyChangeStatus.StatusId }, historyChangeStatus);
        }

        // DELETE: api/HistoryChangeStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryChangeStatus(int id)
        {
            if (_context.HistoryChangeStatuses == null)
            {
                return NotFound();
            }
            var historyChangeStatus = await _context.HistoryChangeStatuses.FindAsync(id);
            if (historyChangeStatus == null)
            {
                return NotFound();
            }

            _context.HistoryChangeStatuses.Remove(historyChangeStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryChangeStatusExists(int id)
        {
            return (_context.HistoryChangeStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public class HistoryChangeStatusRequest
        {
            public Guid TaskId { get; set; }
            public int StatusId { get; set; }
        }
    }
}
