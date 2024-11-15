namespace LibararyApp.Models
{
    public class Books:BaseEntity
    {
        public string NAME { get; set; }
        public Int16 PAGE { get; set; }
        public int AUTHORSID { get; set; }

    }
}
