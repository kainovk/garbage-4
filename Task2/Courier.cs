using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2
{
    public class Courier
    {
        public int Id { get; }
        public bool IsBusy { get; set; }

        public Courier(int id)
        {
            Id = id;
        }

        public async Task ProcessOrder(List<Order> orders, Storage storage)
        {
            Order order = orders.Find(o => o.ReadyToPickup && !o.Delivered);

            if (order == null)
            {
                return;
            }

            
            IsBusy = true;
            if (order.DeliveryInProgress) return;
            order.DeliveryInProgress = true;
            Console.WriteLine($"{order.Id}, заказ в пути (курьер {Id})");
            await Task.Delay(order.Time * 1000);

            if (storage.TryGetPizza(order))
            {
                order.Delivered = true;
                Console.WriteLine($"{order.Id}, заказ доставлен курьером {Id}");
            }
            IsBusy = false;
        }
    }
}