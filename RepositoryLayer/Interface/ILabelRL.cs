using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        public LabelEntity AddLabelName(string LabelName, long notesId, long userId);
        public LabelEntity UpdateLabel(string LabeName, long noteId, long userId);
        public List<LabelEntity> RetrieveByLabelId(long noteId);
        public bool RemoveLabel(long labelId, long userId);
        public List<LabelEntity> GetAllLabel();
    }
}
