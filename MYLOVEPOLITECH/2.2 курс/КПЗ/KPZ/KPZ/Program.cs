using System;
using System.Collections.Generic;

namespace KPZ
{
    
        class Program
        {
            static void Main(string[] args)
            {
               
                Driver driver = new Driver();
                
                Auto auto = new Auto();
                
                driver.Travel(auto);
                
                Scooter scooter = new KPZ.Scooter();
                
                ITransport camelTransport = new ScooterToTransportAdapter(scooter);
             
                driver.Travel(camelTransport);
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "1 type of vehicle";
            a[1] = "2 type of vehicle";
            a[2] = "3 type of vehicle";
            a[3] = "4 type of vehicle";
            // Create Iterator and provide aggregate
            Iterator i = a.CreateIterator();
            Console.WriteLine("Iterating vehicles:");
            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            // Wait for user
            Console.ReadKey();

            Console.Read();

            }
        }
        interface ITransport
        {
            void Drive();
        }
        
        class Auto : ITransport
        {
            public void Drive()
            {
                Console.WriteLine("Їде до парку на автівці");
            }
        }
        class Driver
        {
            public void Travel(ITransport transport)
            {
                transport.Drive();
            }
        }
        // интерфейс животного
        interface scooter
        {
            void Move();
        }
        // класс верблюда
        class Scooter : scooter
        {
            public void Move()
            {
                Console.WriteLine("Їде по парку на самокаті");
            }
        }
        // Адаптер от Camel к ITransport
        class ScooterToTransportAdapter : ITransport
        {
            Scooter scooter;
            public ScooterToTransportAdapter(Scooter c)
            {
                scooter = c;
            }

            public void Drive()
            {
                scooter.Move();
            }
        }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
   
    public class ConcreteAggregate : Aggregate
    {
        List<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        // Get item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }
    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        ConcreteAggregate aggregate;
        int current = 0;
        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        // Gets first iteration item
        public override object First()
        {
            return aggregate[0];
        }
        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }
            return ret;
        }
        // Gets current iteration item
        public override object CurrentItem()
        {
            return aggregate[current];
        }
        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }

}
