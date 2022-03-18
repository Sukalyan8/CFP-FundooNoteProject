using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public LabelEntity AddLabelName(string LabelName, long noteId, long userId)
        {
            try
            {
                return this.labelRL.AddLabelName(LabelName, noteId, userId);
            }
            catch (Exception)
            {

                throw;
            }
            {

            }
        }
        public LabelEntity UpdateLabel(string LabelName, long noteId, long userId)
        {
            try
            {
                return this.labelRL.UpdateLabel(LabelName, noteId, userId);
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
                return this.labelRL.RetrieveByLabelId(noteId);
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
                return this.labelRL.RemoveLabel(labelId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}