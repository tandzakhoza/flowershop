using NUnit.Framework;
using Nsubstitute;
using Flowershop;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            

        }

        [Test]
        public void Test1()
        {
            // arrrange
            IClient c = Substitute.For<IClient>();
            IOrderDAO o = Substitute.For<IOrderDAO>();
            Order order01 = new Order(c,o,false);
            //act
            var order = order01.deliver();
            var iOrder = o.SetDelivered(order01).Return(order);
            //assert
           
            Assert.AreEqual(iOrder, order);

           // Assert.Pass();
        }
    }
}