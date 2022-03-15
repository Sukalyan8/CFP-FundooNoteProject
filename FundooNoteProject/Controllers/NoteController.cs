using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace FundooNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBL noteBL;
        public NoteController(INoteBL noteBL)
        {
            this.noteBL = noteBL;
        }
        [HttpPost("Create")]
        public IActionResult CreateNote(NotesModel Notes)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = noteBL.CreateNote(Notes, userId);
                if (result != null)
                    return this.Ok(new { success = true, message = "Create node Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Note not Created" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("Update")]
        public IActionResult UpdateNote(UpdateNote update, long noteId)
        {
            try
            {
                var result = noteBL.UpdateNote(update, noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Notes updated successful" });
                else
                    return this.BadRequest(new { Success = false, message = "Update failed" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}/Get")]
        public NoteEntity GetNote(long noteId)
        {
            try
            {
                var result = this.noteBL.getNote(noteId);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                var notes = this.noteBL.DeleteNote(noteId);
                if (!notes)
                {
                    return this.BadRequest(new { Success = false, message = "failed to Delete the note" });
                }
                else
                {
                    return this.Ok(new { Success = true, message = " Note is Deleted successfully ", data = notes });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("Pinned")]
        public IActionResult IsPinned(long noteId, long userID)
        {
            bool result = noteBL.IsPinned(noteId, userID);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("Archieve")]
        public IActionResult IsArchieve(long noteId, long userID)
        {
            bool result = noteBL.IsArchieve(noteId, userID);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("Trash")]
        public IActionResult IsTrash(long noteId)
        {
            bool result = noteBL.IsTrash(noteId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}