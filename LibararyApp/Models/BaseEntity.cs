namespace LibararyApp.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public DateTime UPDATEDDATE { get; set; }
        public bool ISACTIVE { get; set; }


        public BaseEntity()
        {
            CREATEDDATE = DateTime.Now;
            UPDATEDDATE = DateTime.Now;


            ISACTIVE = false;
        }
    }
}
