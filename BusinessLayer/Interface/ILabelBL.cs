using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        public LabelEntity AddLabelName(string LabelName, long notesId, long userId);
        public LabelEntity UpdateLabel(string LabelName, long noteId, long userId);
        public List<LabelEntity> RetrieveByLabelId(long noteId);
        public bool RemoveLabel(long labelId, long userId);

        public List<LabelEntity> GetAllLabel();
    }
}
