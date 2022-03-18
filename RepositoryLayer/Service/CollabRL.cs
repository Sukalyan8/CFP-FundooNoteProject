using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CollabRL : ICollabRL
    {
        private readonly FundooContext fundoContext;

        public CollabRL(FundooContext fundoContext)
        {
            this.fundoContext = fundoContext;
        }
        public CollaboratorEntity AddCollaborator(CollaberationModel collabModel)
        {
            try
            {
                CollaboratorEntity collaboration = new CollaboratorEntity();
                var user = fundoContext.User.Where(e => e.Email == collabModel.CollabEmail).FirstOrDefault();

                var notes = fundoContext.Notes.Where(e => e.NotesId == collabModel.NotesId && e.id == collabModel.Id).FirstOrDefault();
                if (notes != null && user != null)
                {
                    collaboration.NotesId = collabModel.NotesId;
                    collaboration.CollabEmail = collabModel.CollabEmail;
                    collaboration.Id = collabModel.Id;
                    fundoContext.CollabTable.Add(collaboration);
                    var result = fundoContext.SaveChanges();
                    return collaboration;
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
        public CollaboratorEntity RemoveCollab(long userId, long collabId)
        {
            try
            {
                var data = this.fundoContext.CollabTable.FirstOrDefault(d => d.Id == userId && d.CollabId == collabId);
                if (data != null)
                {
                    this.fundoContext.CollabTable.Remove(data);
                    this.fundoContext.SaveChanges();
                    return data;
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
        public List<CollaboratorEntity> GetByNoteId(long noteId, long userId)
        {
            try
            {
                var data = this.fundoContext.CollabTable.Where(c => c.NotesId == noteId && c.Id == userId).ToList();
                if (data != null)
                {
                    return data;
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
    }
}