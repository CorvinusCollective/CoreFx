// <copyright file="ExtendedStack.cs" company="Corvinus Collective">
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
    /// Extends a <see cref="Stack{T}"/> that has events to watch Pushed, Popped, and Cleared.
    /// </summary>
    /// <typeparam name="T">Any object that can be added to a collection.</typeparam>
    [DebuggerTypeProxy(typeof(ExtendedStackDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public class ExtendedStack<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private readonly Stack<T> stack;
        private EventHandler<StackEventArgs> pushed;
        private EventHandler<StackEventArgs> popped;
        private EventHandler<StackEventArgs> cleared;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack{T}"/> class.
        /// </summary>
        public ExtendedStack() => this.stack = new Stack<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack{T}"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedStack{T}"/>.</param>
        public ExtendedStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Argument Out of Range. Need Non-Negative Number");
            }

            this.stack = new Stack<T>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack{T}"/> class.
        /// </summary>
        /// <param name="collection">An <see cref="IEnumerable{T}"/> collection of object to add to the <see cref="ExtendedStack{T}"/>.</param>
        public ExtendedStack(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            this.stack = new Stack<T>(collection);
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack{T}"/>.Clear().
        /// </summary>
        public event EventHandler<StackEventArgs> Cleared
        {
            add { this.cleared += value; }
            remove { this.cleared -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack{T}"/>.Pop().
        /// </summary>
        public event EventHandler<StackEventArgs> Popped
        {
            add { this.popped += value; }
            remove { this.popped -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack{T}"/>.Push().
        /// </summary>
        public event EventHandler<StackEventArgs> Pushed
        {
            add { this.pushed += value; }
            remove { this.pushed -= value; }
        }

        /// <summary>
        /// Gets the current count of items in the <see cref="ExtendedStack{T}"/>.
        /// </summary>
        public int Count
        {
            get { return this.stack.Count; }
        }

        /// <summary>
        /// Copies contents of the <see cref="ExtendedStack{T}"/> to provided array.
        /// </summary>
        /// <param name="array">The array of type T, to copy items into.</param>
        /// <param name="arrayIndex">Starting index of the copy.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.stack.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedStack{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.stack.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedStack{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.stack.GetEnumerator();
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ExtendedStack{T}"/>.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Pop()
        {
            T value = default;
            if (this.stack.Count > 0)
            {
                value = this.stack.Pop();
                this.popped?.Invoke(this, new StackEventArgs(stack.Count, true, value));
            }
            else
            {
                this.popped?.Invoke(this, new StackEventArgs(stack.Count, false));
            }

            return value;
        }

        /// <summary>
        /// Adds an object to the beginning of the <see cref="ExtendedStack{T}"/>.
        /// </summary>
        /// <param name="item">Object to be added to the <see cref="ExtendedStack{T}"/>.</param>
        public void Push(T item)
        {
            if (item != null)
            {
                this.stack.Push(item);
                this.pushed?.Invoke(this, new StackEventArgs(stack.Count, true, item));
            }
            else
            {
                this.pushed?.Invoke(this, new StackEventArgs(stack.Count, false));
            }
        }

        /// <summary>
        /// Removes all objects from the <see cref="ExtendedStack{T}"/>.
        /// </summary>
        public void Clear()
        {
            this.stack.Clear();
            this.cleared?.Invoke(this, new StackEventArgs(stack.Count, true));
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="ExtendedStack{T}"/> without removing it.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Peek()
        {
            return this.stack.Peek();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ExtendedStack{T}"/>.
        /// </summary>
        /// <param name="item">Item to check for.</param>
        /// <returns>A boolean indicating if the <see cref="ExtendedStack{T}"/> contains the item.</returns>
        public bool Contains(T item)
        {
            return this.stack.Contains(item);
        }

        /// <summary>
        /// Copies the <see cref="ExtendedStack{T}"/> elements into an array.
        /// </summary>
        /// <returns>An array of type T.</returns>
        public T[] ToArray()
        {
            return this.stack.ToArray();
        }

        /// <summary>
        /// Returns a string that represents the current stack.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            return this.stack.ToString();
        }
    }
}
