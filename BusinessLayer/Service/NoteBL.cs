using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NoteBL : INoteBL
    {
        private readonly INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public bool ChangeColour(long noteId, long userId, ChangeColour notesModel)
        {
            try
            {
                return noteRL.ChangeColour(noteId, userId, notesModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity CreateNote(NotesModel Notes, long userId)
        {
            try
            {
                return noteRL.CreateNote(Notes, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteNote(long noteId)
        {
            try
            {
                return noteRL.DeleteNote(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity getNote(long noteId)
        {
            try
            {
                return noteRL.getNote(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<NoteEntity> GetAllNotes()
        {
            try
            {
                return noteRL.GetAllNotes();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool IsArchieve(long noteId)
        {
            try
            {
                return noteRL.IsArchieve(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPinned(long noteId)
        {
            try
            {
                return noteRL.IsPinned(noteId);
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
                return noteRL.IsTrash(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity UpdateNote(UpdateNote updateNote, long noteId)
        {
            try
            {
                return noteRL.UpdateNote(updateNote, noteId);
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
                return noteRL.UploadImage(noteId,userId,image);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
