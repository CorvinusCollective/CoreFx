// <copyright file="ExtendedQueue.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Corvinus.Collections;

    /// <summary>
    /// Extends a <see cref="Queue{T}"/> that has events to watch Enqueued, Dequeued, and Cleared.
    /// </summary>
    /// <typeparam name="T">Any object that can be added to a collection.</typeparam>
    [DebuggerTypeProxy(typeof(ExtendedQueueDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public class ExtendedQueue<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private readonly Queue<T> queue;
        private EventHandler<QueueEventArgs> enqueued;
        private EventHandler<QueueEventArgs> dequeued;
        private EventHandler<QueueEventArgs> cleared;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        public ExtendedQueue()
        {
            queue = new Queue<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Argument Out of Range. Need Non-Negative Number");
            }

            this.queue = new Queue<T>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        /// <param name="collection">An <see cref="IEnumerable{T}"/> collection of object to add to the <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            this.queue = new Queue<T>(collection);
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Clear().
        /// </summary>
        public event EventHandler<QueueEventArgs> Cleared
        {
            add { this.cleared += value; }
            remove { this.cleared -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Dequeue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Dequeued
        {
            add { this.dequeued += value; }
            remove { this.dequeued -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Enqueue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Enqueued
        {
            add { this.enqueued += value; }
            remove { this.enqueued -= value; }
        }

        /// <summary>
        /// Gets the current count of items in the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        public int Count
        {
            get { return this.queue.Count; }
        }

        /// <summary>
        /// Copies contents of the <see cref="ExtendedQueue{T}"/> to provided array.
        /// </summary>
        /// <param name="array">The array of type T, to copy items into.</param>
        /// <param name="arrayIndex">Starting index of the copy.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.queue.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Dequeue()
        {
            T value = default;
            if (this.queue.Count > 0)
            {
                value = this.queue.Dequeue();
                this.dequeued?.Invoke(this, new QueueEventArgs(queue.Count, true, value));
            }
            else
            {
                this.dequeued?.Invoke(this, new QueueEventArgs(queue.Count, false));
            }

            return value;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <param name="item">Object to be added to the <see cref="ExtendedQueue{T}"/>.</param>
        public void Enqueue(T item)
        {
            if (item != null)
            {
                this.queue.Enqueue(item);
                this.enqueued?.Invoke(this, new QueueEventArgs(queue.Count, true, item));
            }
            else
            {
                this.enqueued?.Invoke(this, new QueueEventArgs(queue.Count, false));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.queue.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.queue.GetEnumerator();
        }

        /// <summary>
        /// Removes all objects from the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        public void Clear()
        {
            this.queue.Clear();
            this.cleared?.Invoke(this, new QueueEventArgs(queue.Count, true));
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="ExtendedQueue{T}"/> without removing it.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Peek()
        {
            return this.queue.Peek();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <param name="item">Item to check for.</param>
        /// <returns>A boolean indicating if the <see cref="ExtendedQueue{T}"/> contains the item.</returns>
        public bool Contains(T item)
        {
            return this.queue.Contains(item);
        }

        /// <summary>
        /// Copies the <see cref="ExtendedQueue{T}"/> elements into an array.
        /// </summary>
        /// <returns>An array of type T.</returns>
        public T[] ToArray()
        {
            return this.queue.ToArray();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            return this.queue.ToString();
        }
    }
}
