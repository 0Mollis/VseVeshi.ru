namespace VseVeshi.ru.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Addres { get; set; }
        public string Status { get; set; }
        public int TotalPrice { get; set; }
        public string TypeOfOrder { get; set; }
        public string TimeOfOrder { get; set; }
    }
}
