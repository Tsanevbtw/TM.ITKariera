namespace NESHTO.Models
{
    public class TaskResp
    {
        private List<Model> tasks;

        public TaskResp()
        {
            tasks = new List<Model>();
        }

        public List<Model> GetAllTasks()
        {
            return tasks;
        }
        public Model GetTaskById(int taskId)
        {
            return tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public void AddTask(Model task)
        {
            
            task.Id = tasks.Count + 1;
            tasks.Add(task);
        }

        public void UpdateTask(Model updatedTask)
        {
            var existingTask = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.IsCompleted = updatedTask.IsCompleted;
            }
        }

        public void DeleteTask(int taskId)
        {
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
            }
        }
    }
}
