using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите начальные параметры: ");
            int n = int.Parse(Console.ReadLine()); // пекари
            int m = int.Parse(Console.ReadLine()); // курьеры
            int t = int.Parse(Console.ReadLine()); // размер склада

            List<Order> orders = new List<Order>();
            List<Baker> bakers = new List<Baker>();
            List<Courier> couriers = new List<Courier>();
            Storage storage = new Storage(t);

            for (int i = 0; i < n; i++)
            {
                bakers.Add(new Baker(i));
            }

            for (int i = 0; i < m; i++)
            {
                couriers.Add(new Courier(i));
            }

            Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(1000);
                    ProcessOrdersAsync(orders, bakers, couriers, storage);
                }
            });
            
            while (true)
            {
                Console.WriteLine("Введите номер заказа и время выполнения (в минутах) или 'exit' для завершения: ");
                string input = Console.ReadLine();
                if (input == "exit") break;

                string[] orderInfo = input.Split(' ');
                int orderId = int.Parse(orderInfo[0]);
                int orderTime = int.Parse(orderInfo[1]);
                orders.Add(new Order(orderId, orderTime));

                Console.WriteLine($"{orderId}, добавлен в очередь");
            }
        }

        static async Task ProcessOrdersAsync(List<Order> orders, List<Baker> bakers, List<Courier> couriers, Storage storage)
        {
            List<Task> tasks = new List<Task>();

            foreach (var baker in bakers)
            {
                if (!baker.IsBusy)
                {
                    tasks.Add(baker.ProcessOrder(orders, storage));
                }
            }
            
            foreach (var courier in couriers)
            {
                if (!courier.IsBusy)
                {
                    tasks.Add(courier.ProcessOrder(orders, storage));
                }
            }

            await Task.WhenAll(tasks);
        }
    }
}