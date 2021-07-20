// <copyright file="ExtendedStack.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Collections
{
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Extends a <see cref="Stack"/> that has events to watch Pushed, Popped, and Cleared.
    /// </summary>
    public class ExtendedStack : Stack
    {
        private EventHandler<StackEventArgs> _popped;
        private EventHandler<StackEventArgs> _pushed;
        private EventHandler<StackEventArgs> _cleared;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack"/> class.
        /// </summary>
        public ExtendedStack() 
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedStack"/>.</param>
        public ExtendedStack(int capacity) 
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStack"/> class.
        /// </summary>
        /// <param name="col">An <see cref="ICollection"/> to generate the new Stack from.</param>
        public ExtendedStack(ICollection col) 
            : base(col)
        {
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack"/>.Clear().
        /// </summary>
        public event EventHandler<StackEventArgs> Cleared
        {
            add { _cleared += value; }
            remove { _cleared -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack"/>.Pop().
        /// </summary>
        public event EventHandler<StackEventArgs> Popped
        {
            add { _popped += value; }
            remove { _popped -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedStack"/>.Push().
        /// </summary>
        public event EventHandler<StackEventArgs> Pushed
        {
            add { _pushed += value; }
            remove { _pushed -= value; }
        }

        /// <summary>
        /// Removes all objects from the <see cref="ExtendedStack"/>.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            _cleared?.Invoke(this, new StackEventArgs(Count, true));
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ExtendedStack"/>.
        /// </summary>
        /// <returns>The first object from the stack.</returns>
        public override object Pop()
        {
            object value = null;
            if (Count > 0)
            {
                value = base.Pop();
                _popped?.Invoke(this, new StackEventArgs(Count, true, value));
            }
            else
            {
                _popped?.Invoke(this, new StackEventArgs(Count, false));
            }
                
            return value;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ExtendedStack"/>
        /// </summary>
        /// <param name="obj">Object to add to the Stack.</param>
        public override void Push(object obj)
        {
            if (obj != null)
            {
                base.Push(obj);
                _pushed?.Invoke(this, new StackEventArgs(Count, true, obj));
            }
            else
            {
                _pushed?.Invoke(this, new StackEventArgs(Count, false));
            }
        }
    }
}
