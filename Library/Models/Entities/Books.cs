namespace Library.Models.Entities
{
    public class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }   
        public DateTime CreationDate { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool IsAvailable { get; set; }

    }
}
