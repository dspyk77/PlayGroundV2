namespace PlayGroundV2.Web.Models.Tasks
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsActive { get; set; }


    }
}
