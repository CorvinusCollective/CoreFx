
namespace Corvinus.Collections
{
    using System;

    /// <summary>
    /// QueueEventArgs class.
    /// </summary>
    public class QueueEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        public QueueEventArgs(int count)
            : this(count, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        /// <param name="isValid">A valid transaction has occurred.</param>
        public QueueEventArgs(int count, bool isValid)
            : this(count, isValid, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEventArgs"/> class.
        /// </summary>
        /// <param name="count">A new count from the sender.</param>
        /// <param name="isValid">A valid transaction has occurred.</param>
        /// <param name="value">If this is an Enqueue or Dequeue transaction, this is the object added or removed from the que, otherwise null.</param>
        public QueueEventArgs(int count, bool isValid, object value)
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
        /// Gets or sets a value indicating whether a valid item has been enqueued or dequeued.
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item enqueued or dequeued.
        /// </summary>
        public object Value
        {
            get;
            set;
        }
    }
}
