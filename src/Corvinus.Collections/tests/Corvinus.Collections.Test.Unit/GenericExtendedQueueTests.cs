namespace Corvinus.Collections.Test.Unit
{
    using System;
    using Xunit;
    using FluentAssertions;
    using Corvinus.Collections.Generic;
    using System.Collections;
    using System.Collections.Generic;

    public class GenericExtendedQueueTests
    {
        [Fact]
        public void Can_initiate_typed_extendedqueue()
        {
            ExtendedQueue<int> queue = new ExtendedQueue<int>();

            Assert.True(queue != null);
        }

        [Fact]
        public void Can_initiate_typed_extendedqueue_with_capacity()
        {
            ExtendedQueue<int> queue = new ExtendedQueue<int>(14);

            Assert.True(queue != null);
        }




        [Fact]
        public void Can_initiate_typed_extendedqueue_with_IEnumerable()
        {
            List<int> enumerable = new List<int>();
            enumerable.Add(1);
            enumerable.Add(2);
            enumerable.Add(3);

            ExtendedQueue<int> queue = new ExtendedQueue<int>(enumerable);

            Assert.True(queue != null);
            Assert.True(queue.Peek() == 1);
            Assert.True(queue.Count == 3);
        }



        [Fact]
        public void Can_listen_for_extendedqueue_clear()
        {
            ExtendedQueue<int> queue = new ExtendedQueue<int>();

            queue.Cleared += Queue_Cleared;

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.True(queue.Count == 3);

            queue.Clear();

            Assert.True(queue.Count == 0);

            queue.Cleared -= Queue_Cleared;
        }

        [Fact]
        public void Can_listen_for_extendedqueue_enqueue_dequeue()
        {
            ExtendedQueue<object> queue = new ExtendedQueue<object>();

            queue.Enqueued += Queue_Enqueued;

            queue.Dequeued += Queue_Dequeued;

            queue.Enqueue(1);

            object result = queue.Dequeue();

            Assert.True((int)result == 1);

            queue.Enqueued -= Queue_Enqueued;

            queue.Dequeued -= Queue_Dequeued;

            queue.Enqueued += Queue_Enqueued_Invalid;

            queue.Dequeued += Queue_Dequeued_Invalid;

            queue.Dequeue();

            queue.Enqueue(null);
        }

        [Fact]
        public void Cannot_initiate_typed_extendedqueue_with_negative_capacity()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ExtendedQueue<int> queue = new ExtendedQueue<int>(-4);
            });
        }

        [Fact]
        public void Cannot_initiate_typed_extendedqueue_with_null_IEnumerable()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                ExtendedQueue<int> queue = new ExtendedQueue<int>(null);
            });
        }

        private void Queue_Cleared(object sender, QueueEventArgs e)
        {
            Assert.True(e != null);
            Assert.True(e.IsValid);
            Assert.True(e.Count == 0);
        }

        private void Queue_Dequeued(object sender, QueueEventArgs e)
        {
            Assert.True(e != null);
            Assert.True(e.IsValid);
            Assert.True(e.Count == 0);
            Assert.True((int)e.Value == 1);
        }

        private void Queue_Enqueued(object sender, QueueEventArgs e)
        {
            Assert.True(e != null);
            Assert.True(e.IsValid);
            Assert.True(e.Count > 0);
            Assert.True((int)e.Value == 1);
        }

        private void Queue_Dequeued_Invalid(object sender, QueueEventArgs e)
        {
            Assert.True(e != null);
            Assert.False(e.IsValid);
            Assert.True(e.Count == 0);
            Assert.True(e.Value == null);
        }

        private void Queue_Enqueued_Invalid(object sender, QueueEventArgs e)
        {
            Assert.True(e != null);
            Assert.True(!e.IsValid);
            Assert.True(e.Count == 0);
            Assert.True(e.Value == null);
        }
    }
}
