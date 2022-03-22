using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        private readonly FundooContext fundooContext;

        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        public LabelEntity AddLabelName(string labelName, long noteId, long userId)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity
                {
                    LabelName = labelName,
                    Id = userId,
                    NoteId = noteId
                };
                this.fundooContext.Label.Add(labelEntity);
                int result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return labelEntity;
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
        public LabelEntity UpdateLabel(string LabelName, long noteId, long userId)
        {
            try
            {
                var label = this.fundooContext.Label.FirstOrDefault(a => a.NoteId == noteId && a.Id == userId);
                if (label != null)
                {
                    label.LabelName = LabelName;
                    this.fundooContext.Label.Update(label);
                    this.fundooContext.SaveChanges();
                    return label;

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
        public List<LabelEntity> RetrieveByLabelId(long noteId)
        {
            try
            {
                // Fetch All the details with the given noteid.
                var data = this.fundooContext.Label.Where(d => d.NoteId == noteId).ToList();
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
        public List<LabelEntity> GetAllLabel()
        {
            try
            {
                // Fetch All the details from Label Table
                var data = this.fundooContext.Label.ToList();
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
        public bool RemoveLabel(long labelId, long userId)
        {
            try
            {
                var labelDetails = this.fundooContext.Label.FirstOrDefault(l => l.LabelId == labelId && l.Id == userId);
                if (labelDetails != null)
                {
                    this.fundooContext.Label.Remove(labelDetails);

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
    }
}
