using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
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

        public bool IsArchieve(long noteId, long userId)
        {
            try
            {
                return noteRL.IsArchieve(noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                return noteRL.IsPinned(noteId, userId);
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
    }

}
