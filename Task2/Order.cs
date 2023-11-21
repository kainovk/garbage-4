namespace Task2
{
    public class Order
    {
        public int Id { get; }
        public int Time { get; }
        public bool ReadyToPickup { get; set; }
        public bool DeliveryInProgress { get; set; }
        public bool Delivered { get; set; }
        public int? BakerId { get; set; }

        public Order(int id, int time)
        {
            Id = id;
            Time = time;
            ReadyToPickup = false;
            DeliveryInProgress = false;
            Delivered = false;
        }
    }
}