namespace NESHTO.Models
{
    public class RepeatingTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //Date for the next time 
        public DateTime DueDate{ get; set; }
        //Period between repetition
        public DateTime PeriodBetween { get; set; }
        public bool IsCompleted { get; set; }

    }
}
