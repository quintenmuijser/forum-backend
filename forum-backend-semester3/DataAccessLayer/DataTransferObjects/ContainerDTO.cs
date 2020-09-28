using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataTransferObjects
{
    public class ContainerDTO
    {
        public int ContainerId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }

        public ContainerDTO()
        {

        }

        public ContainerDTO(int containerId, int priority, string title)
        {
            this.ContainerId = containerId;
            this.Priority = priority;
            this.Title = title;
        }
    }
}
