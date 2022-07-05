using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGroundV2.Shared.Tasks
{
    public class TaskManager
    {

        private readonly PlayGroundContext _playGroundContext;


        public TaskManager(PlayGroundContext playGroundContext)
        {
            _playGroundContext = playGroundContext;
        }


        public Task? FindById(int id) 
        {
            return _playGroundContext.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public Task Create(
            string name,
            string description,
            DateTime? dueDate,
            bool isActive)
        {
            var task = new Task();
            task.Name = name;
            task.Description = description;
            task.DueDate = dueDate;
            task.IsActive = isActive;

        
            _playGroundContext.Tasks.Add(task);
            
            _playGroundContext.SaveChanges();
            
            return task;
        }

        public Task? Update(
            int id,
            string name,
            string description,
            DateTime? dueDate,
            bool isActive)
        {
            Task task = FindById(id);
            if (task == null)
            {
                return null;
            }

            task.Name = name;
            task.Description= description;
            task.DueDate= dueDate;
            task.IsActive= isActive;

            _playGroundContext.Tasks.Update(task);

            _playGroundContext.SaveChanges();

            return task;
        }
    }
}
