using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueueTests
{
    public class UnorderedArrayPriorityQueueTest
    {

        private PriorityQueue<string> queue;

        [SetUp]
        public void Setup()
        {
            queue = new UnorderedArrayPriorityQueue<string>(10);
        }

        [Test]
        public void Test1()
        {
            queue.Add("A", 3);
            queue.Add("B", 12);
            queue.Add("C", 8);

            Assert.AreEqual("B", queue.Head());
        }
    }
}