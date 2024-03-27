namespace NESHTO.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? Period { get; set; }

        public bool IsCompleted { get; set; }
    }
}
