
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace NESHTO.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        
        [AllowNull]
        public string Name { get; set; }

        public ICollection<ToDoTask> ToDoTasks { get; set; }
    }
}
