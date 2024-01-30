namespace TestProject.DTO.Book
{
    public class BookInfoDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PublishDateUtc { get; set; }
    }
}
