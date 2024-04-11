
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NESHTO.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [AllowNull]
        public DateTime DueDate { get; set; }
        [AllowNull]
        public DateTime Period { get; set; }

        public bool IsDone { get; set; } = false;

        [ForeignKey(nameof(TaskList.Id))]
        public int TaskListId { get; set; }

    }
}
