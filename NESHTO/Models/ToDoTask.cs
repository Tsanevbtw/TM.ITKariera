
using Microsoft.EntityFrameworkCore;
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

    }
}
