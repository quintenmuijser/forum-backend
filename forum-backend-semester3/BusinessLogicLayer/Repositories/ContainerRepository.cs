using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        private IContainerContext _context;

        public ContainerRepository(IContainerContext context)
        {
            _context = context;
        }

        public Container ContainerFromContainerDTO(ContainerDTO containerDTO)
        {
            Container containerFromDTO = new Container();
            containerFromDTO.ContainerId = containerDTO.ContainerId;
            containerFromDTO.Priority = containerDTO.Priority;
            containerFromDTO.Title = containerDTO.Title;
            return containerFromDTO;
        }

        public Container ContainerDTOFromMySqlDataReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Container Create()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Container> GetAll()
        {
            IReadOnlyList<ContainerDTO> containerDTOs = _context.GetAll();
            List<Container> containers = new List<Container>();
            foreach (ContainerDTO containerDTO in containerDTOs)
            {
                containers.Add(ContainerFromContainerDTO(containerDTO));
            }
            return containers.AsReadOnly();
        }

        public Container GetById(int containerId)
        {
            throw new NotImplementedException();
        }

    }
}
