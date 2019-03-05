using System;
using System.Collections.Generic;
using System.Text;
using System.NSubstitute;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;

        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                List<Flower> totalflowers = Substitute.For <List<Flower>>();
                
                return 0;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int n)
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {   // i tried adding a reference for the NSubstitute package but i couldnt find it yet it was installed 
            // arrrange
            IOrderDAO o = Substitute.For<IOrderDAO>();
            Order order01 = Substitute.For<Order>();
            //act
            o.SetDelivered(order01).Return(o);
            //assert
            Assert.AreEqual(o.SetDelivered(order01), o);

            throw new NotImplementedException();
        }
    }
}
