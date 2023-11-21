using System.Collections.Generic;

namespace Task2
{
    public class Storage
    {
        private int capacity;
        private List<Order> pizzas = new List<Order>();

        public Storage(int capacity)
        {
            this.capacity = capacity;
        }

        public bool TryPutPizza(Order order)
        {
            if (pizzas.Count >= capacity)
            {
                return false;
            }

            pizzas.Add(order);
            return true;
        }

        public bool TryGetPizza(Order order)
        {
            Order pizza = pizzas.Find(p => p.Id == order.Id);
            if (pizza == null)
            {
                return false;
            }

            pizzas.Remove(pizza);
            return true;
        }
    }
}