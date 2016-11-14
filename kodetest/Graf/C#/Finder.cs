using System.Collections;

namespace Graf
{
    public class Finder : IFinder
    {
        public string FromRight(Customers customers, int numberFromRight)
        {
            var customerQueue = new Queue();

            while (customers != null)
            {
                    customerQueue.Enqueue(customers.Person);

                    if (customerQueue.Count > numberFromRight)
                    {
                        customerQueue.Dequeue();
                    }

                customers = customers.Next;
            }

            return (string)customerQueue.Dequeue();
        }
    }
}
