using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollabBL : ICollabBL
    {
        private readonly ICollabRL collabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }

        public CollaboratorEntity AddCollaborator(CollaberationModel collabModel)
        {
            try
            {
                return this.collabRL.AddCollaborator(collabModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CollaboratorEntity> GetByNoteId(long noteId, long userId)
        {
            try
            {
                return this.collabRL.GetByNoteId(noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CollaboratorEntity RemoveCollab(long userId, long collabId)
        {
            try
            {
                return this.collabRL.RemoveCollab(userId, collabId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
