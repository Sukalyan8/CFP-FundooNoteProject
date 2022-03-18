using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        public NoteEntity CreateNote(NotesModel Notes, long userId);

        public NoteEntity UpdateNote(UpdateNote updateNote, long noteId);
        public NoteEntity getNote(long noteId);
        public bool DeleteNote(long noteId);
        public bool IsPinned(long noteId);
        public bool IsArchieve(long noteId);
        public bool IsTrash(long noteId);
        public NoteEntity UploadImage(long noteId, long userId, IFormFile image);
        public bool ChangeColour(long noteId, long userId, ChangeColour notesModel);
    }
}
