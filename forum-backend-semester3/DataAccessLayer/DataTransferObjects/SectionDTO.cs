using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class SectionDTO
    {
        public int SectionId { get; set; }
        public int ContainerId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }

        public SectionDTO()
        {

        }

        public SectionDTO(int sectionId,int containerId,int priority, string title)
        {
            this.SectionId = sectionId;
            this.ContainerId = containerId;
            this.Priority = priority;
            this.Title = title;
        }
    }
}
