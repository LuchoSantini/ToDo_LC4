namespace To_Do_List_LC4.Data.Dtos
{
    public class ToDoItemDto
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
