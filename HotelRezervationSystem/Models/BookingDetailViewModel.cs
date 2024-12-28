namespace HotelRezervationSystem.Models
{
    public class BookingDetailViewModel
    {
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string City { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        public double? Rating { get; set; }
    }
}
