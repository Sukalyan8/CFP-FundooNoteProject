using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NoteRL : INoteRL
    {
        //instance of  FundooContext Class
        private readonly FundooContext fundooContext;
        private IConfiguration _config;

        //Constructor
        public NoteRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this._config = configuration;

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
                    note.Colour = updateNote.Colour;
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
        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId && e.id == userId);

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
        public bool IsArchieve(long noteId, long userId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId && e.id == userId);

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
    }
}