// <copyright file="StackEventArgs.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Collections
{
    using System;

    /// <summary>
    /// StackEventArgs class.
    /// </summary>
    public class StackEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        public StackEventArgs(int count)
            : this(count, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        /// <param name="isValid">A valid Push or Pop transaction has occurred.</param>
        public StackEventArgs(int count, bool isValid) 
            : this(count, isValid, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        /// <param name="isValid">A valid Push or Pop transaction has occurred.</param>
        /// <param name="value">If this is a Push or Pop transaction, this is the object added or removed from the stack, otherwise null.</param>
        public StackEventArgs(int count, bool isValid, object value)
        {
            Count = count;
            IsValid = isValid;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the new Count of objects in the sender.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a valid item has been Pushed or Popped.
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item pushed or popped.
        /// </summary>
        public object Value
        {
            get;
            set;
        }
    }
}
