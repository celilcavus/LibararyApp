using LibararyApp.Models;

namespace LibararyApps.Models
{
    public class BooksAndAuthors:BaseEntity
    {

        public string AUTHORSNAME { get; set; }
        public string LASTNAME { get; set; }
        public int AUTHORSID { get; set; }
        public String BOOKSNAME { get; set; }
        public int BOOKSID { get; set; }
        public Int16 PAGE { get; set; }

    }
}
