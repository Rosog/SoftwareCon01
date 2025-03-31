using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueueTests
{
    public class UnorderedLinkedPriorityQueueTest
    {

        private PriorityQueue<string> queue;

        [SetUp]
        public void Setup()
        {
            queue = new UnorderedLinkedPriorityQueue<string>();
        }

        [Test]
        public void Add_FindHighest()
        {
            queue.Add("A", 3);
            queue.Add("B", 12);
            queue.Add("C", 8);

            Assert.AreEqual("B", queue.Head());
        }

        [Test]
        public void Remove_RemovesHighestPriorityItem()
        {
            queue.Add("A", 2);
            queue.Add("B", 4);
            queue.Remove();
            Assert.AreEqual("A", queue.Head());
        }

        [Test]
        public void Add_RemoveAll()
        {
            queue.Add("A", 3);
            queue.Add("B", 12);
            queue.Add("C", 8);
            queue.Remove();
            queue.Remove();
            queue.Remove();
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void CanAdd()
        {
            queue.Add("A", 3);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void StartsEmpty()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void ExceptionWhenEmpty()
        {
            Assert.Throws<QueueUnderflowException>(() => queue.Head());
        }

        [Test]
        public void ExceptionWhenEmptyRemove()
        {
            Assert.Throws<QueueUnderflowException>(() => queue.Remove());
        }

        [Test]
        public void OverflowCheck()
        {
            var test = new UnorderedArrayPriorityQueue<String>(2);
            test.Add("A", 3);
            test.Add("B", 4);
            Assert.Throws<QueueOverflowException>(() => test.Add("C", 3));

        }


    }
}