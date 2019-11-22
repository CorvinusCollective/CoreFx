// <copyright file="ExtendedStackDebugView.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Collections.Generic
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Extended Stack Debug View Class.
    /// </summary>
    /// <typeparam name="T">Type of Extended Stack.</typeparam>
    internal sealed class ExtendedStackDebugView<T>
    {
        private readonly ExtendedStack<T> _stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedStackDebugView{T}"/> class.
        /// </summary>
        /// <param name="stack">A <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedStackDebugView(ExtendedStack<T> stack)
        {
            _stack = stack ?? throw new ArgumentNullException(nameof(stack));
        }

        /// <summary>
        /// Gets the debugger browsable array of Items.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                return _stack.ToArray();
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
                return _stack.Count;
            }
        }
    }
}
