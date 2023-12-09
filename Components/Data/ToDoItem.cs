using System.ComponentModel.DataAnnotations;

namespace BlazorWhyUseDbContextFactory.Components.Data
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public int Priority { get; set; }  // 1=highest priority 3=lowest priority
        public string TaskDesc { get; set; }
    }
}
