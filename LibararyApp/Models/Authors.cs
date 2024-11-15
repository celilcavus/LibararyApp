namespace LibararyApp.Models
{
    public class Authors:BaseEntity
    {
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public string MAIL { get; set; }
        public DateTime BIRTHDATE { get; set; }

        public Authors()
        {
            BIRTHDATE.ToString("yyy-MM-dd");
        }
    }
}
