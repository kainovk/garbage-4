using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    public class Baker
    {
        public int Id { get; }
        public bool IsBusy { get; set; }

        public Baker(int id)
        {
            Id = id;
        }

        public async Task ProcessOrder(List<Order> orders, Storage storage)
        {
            Order order = orders.Find(o => !o.ReadyToPickup && !o.BakerId.HasValue);

            if (order == null)
            {
                return;
            }

            order.BakerId = Id;
            IsBusy = true;
            Console.WriteLine($"{order.Id}, заказ в обработке пекарем {Id}");
            await Task.Delay(order.Time * 1000);

            if (storage.TryPutPizza(order))
            {
                order.ReadyToPickup = true;
                Console.WriteLine($"{order.Id}, заказ выполнен пекарем {Id}");
            }
            IsBusy = false;
        }
    }
}