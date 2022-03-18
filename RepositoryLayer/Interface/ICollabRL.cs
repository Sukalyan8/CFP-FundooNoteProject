﻿using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollabRL
    {
        public CollaboratorEntity AddCollaborator(CollaberationModel collabModel);
        public CollaboratorEntity RemoveCollab(long userId, long collabId);
        public List<CollaboratorEntity> GetByNoteId(long noteId, long userId);
    }
}