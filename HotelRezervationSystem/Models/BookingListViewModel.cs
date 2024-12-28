namespace HotelRezervationSystem.Models
{
    public class BookingListViewModel
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string City { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
