// <copyright file="ExtendedQueueDebugView.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Collections.Generic
{
    using System;
    using System.Diagnostics;

    internal sealed class ExtendedQueueDebugView<T>
    {
        private readonly ExtendedQueue<T> _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueueDebugView{T}"/> class.
        /// </summary>
        /// <param name="queue">A <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedQueueDebugView(ExtendedQueue<T> queue)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
        }

        /// <summary>
        /// Gets the debugger browsable array of Items.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                return _queue.ToArray();
            }
        }

        /// <summary>
        /// Gets the debugger browsable count of Items.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }
    }
}
