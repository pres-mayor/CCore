namespace TestProject.Model
{
    public class Result
    {
        public int totalPage { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public IEnumerable<Book>? results { get; set; }

    }
}
