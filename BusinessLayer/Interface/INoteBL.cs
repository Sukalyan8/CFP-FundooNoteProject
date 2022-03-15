using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        public NoteEntity CreateNote(NotesModel Notes, long userId);
        public NoteEntity UpdateNote(UpdateNote updateNote, long noteId);
        public NoteEntity getNote(long noteId);
        public bool DeleteNote(long noteId);
        public bool IsPinned(long noteId, long userId);

        public bool IsArchieve(long noteId, long userId);
        public bool IsTrash(long noteId);


    }
}
