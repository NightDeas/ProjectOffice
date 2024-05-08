using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Buffers.Text;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        Entities.DbContextProjectOffice _context;
        public AttachmentController()
        {
            _context = new Entities.DbContextProjectOffice();
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var attachment = await _context.Attachments.FirstOrDefaultAsync(x => x.Id == id);
            if (attachment == null)
                return NotFound();
            return Ok(attachment);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AttachmentModel model)
        {
            Entities.Attachment attachment = new()
            {
                Photo = model.Photo,
                Link = model.Link,
                NamePhoto = model.NamePhoto,
                SizeFile = model.SizeFile,
            };
            _context.Attachments.Add(attachment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при сохранении в БД");
            }
            return Ok(attachment.Id);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var attachment = await _context.Attachments.FirstOrDefaultAsync(x => x.Id == id);
            if (attachment == null)
                return NotFound();
            _context.Attachments.Remove(attachment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при сохранении в БД");
            }
            return Ok();
        }
    }
    public class AttachmentModel
    {
        public string? Link { get; set; }
        public byte[] Photo { get; set; }
        public string? NamePhoto { get; set; }
        public float? SizeFile { get; set; }
    }
}
