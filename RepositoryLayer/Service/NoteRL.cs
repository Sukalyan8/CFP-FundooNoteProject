using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Octokit;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Account = CloudinaryDotNet.Account;

namespace RepositoryLayer.Service
{
    public class NoteRL : INoteRL
    {
        //instance of  FundooContext Class
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _config;

        //Constructor
        public NoteRL(FundooContext fundooContext, IConfiguration _config)
        {
            this.fundooContext = fundooContext;
            this._config = _config;

        }
        //Method to Create Notes Details.
        public NoteEntity CreateNote(NotesModel Notes, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = Notes.Title;
                noteEntity.Description = Notes.Description;
                noteEntity.Colour = Notes.Colour;
                noteEntity.Image = Notes.Image;
                noteEntity.IsArchieve = Notes.IsArchieve;
                noteEntity.IsTrash = Notes.IsTrash;
                noteEntity.IsPin = Notes.IsPin;
                noteEntity.CreatedAt = Notes.CreatedAt;
                noteEntity.ModifierAt = Notes.ModifierAt;
                noteEntity.id = userId;
                fundooContext.Notes.Add(noteEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                    return noteEntity;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Method to UpdateNote Details.
        public NoteEntity UpdateNote(UpdateNote updateNote, long noteId)
        {
            try
            {
                var note = fundooContext.Notes.Where(update => update.NotesId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Title = updateNote.Title;
                    note.Description = updateNote.Description;
                    note.Image = updateNote.Image;
                    note.id = noteId;
                    fundooContext.Notes.Update(note);
                    int result = fundooContext.SaveChanges();
                    return note;
                }

                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Method to RetrieveAllNotes Details.
        public NoteEntity getNote(long noteId)
        {
            try
            {
                // Fetch details with the given noteId.
                var note = this.fundooContext.Notes.Where(n => n.NotesId == noteId).FirstOrDefault();
                if (note != null)
                {

                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                {
                    throw;
                }
            }


        }
        public bool DeleteNote(long noteId)
        {
            try
            {
                // Fetch details with the given noteId.
                var note = this.fundooContext.Notes.Where(n => n.NotesId == noteId).FirstOrDefault();
                if (note != null)
                {
                    // Remove Note details from database
                    this.fundooContext.Notes.Remove(note);

                    // Save Changes Made in the database
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Method to IsPinned Details.
        public bool IsPinned(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsPin == true)
                    {
                        notes.IsPin = false;
                    }
                    else if (notes.IsPin == false)
                    {
                        notes.IsPin = true;
                    }
                    notes.ModifierAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Method to IsArchieve Details.
        public bool IsArchieve(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsArchieve == true)
                    {
                        notes.IsArchieve = false;
                    }
                    else if (notes.IsArchieve == false)
                    {
                        notes.IsArchieve = true;
                    }
                    notes.ModifierAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsTrash(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsTrash == true)
                    {
                        notes.IsTrash = false;
                    }
                    else if (notes.IsTrash == false)
                    {
                        notes.IsTrash = true;
                    }
                    notes.ModifierAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public NoteEntity UploadImage(long noteId, long userId, IFormFile image)
        {
            try
            {
                // Fetch All the details with the given noteId and userId
                var note = this.fundooContext.Notes.FirstOrDefault(n => n.NotesId == noteId && n.id == userId);
                if (note != null)
                {
                    Account acc = new Account(_config["Cloudinary:CloudName"], _config["Cloudinary:ApiKey"], _config["Cloudinary:ApiSecret"]);
                    Cloudinary cloud = new Cloudinary(acc);
                    var imagePath = image.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, imagePath),
                    };
                    var uploadResult = cloud.Upload(uploadParams);
                    note.Image = image.FileName;
                    this.fundooContext.Notes.Update(note);
                    int upload = this.fundooContext.SaveChanges();
                    if (upload > 0)
                    {
                        return note;
                    }
                    else
                    {
                        return null;
                    }
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
        //Method to ChangeColor Details.
        public bool ChangeColour(long noteId, long userId, ChangeColour notesModel)
        {
            try
            {
                var result = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId && e.id == userId);

                if (result != null)
                {
                    result.Colour = notesModel.Colour;
                    result.ModifierAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Method to GetNoteId Details.
        public NoteEntity GetNoteId(long noteId, long userId)
        {
            var result = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId && e.id == userId);

            return result;
        }
    }
}