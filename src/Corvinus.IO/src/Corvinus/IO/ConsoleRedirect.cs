// <copyright file="ConsoleRedirect.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.IO
{
    using System;

    /// <summary>
    /// ConsoleRedirect allows a user to redirect the console output to any
    /// source they want through the constructor parameter redirectDelegate.
    /// The delegate will perform actions on a single string as it is automatically
    /// read from the QueueWriter.
    /// </summary>
    public class ConsoleRedirect
    {
        private bool _sending = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleRedirect"/> class.
        /// </summary>
        /// <param name="redirectDelegate">Delegate to handle the message from console redirect.</param>
        public ConsoleRedirect(Action<string> redirectDelegate)
        {
            if (redirectDelegate != null)
            {
                RedirectDelegate = redirectDelegate;
            }
            else
            {
                RedirectDelegate = (s) => { };
            }
            
            Writer = new QueueWriter();
            Console.SetOut(Writer);
            Writer.Queued += Writer_Queued;
        }

        /// <summary>
        /// Gets a <see cref="QueueWriter"/> for the console to use for redirect.
        /// </summary>
        public QueueWriter Writer { get; }

        /// <summary>
        /// Gets a <see cref="Action{T}"/> with a parameter type of string.
        /// This action defines how to handle the message string.
        /// </summary>
        /// <example>
        /// string output = "";
        /// 
        /// ConsoleRedirect((message) => {
        ///     output += message;
        /// };
        /// 
        /// Will append the message to the output string.
        /// </example>
        public Action<string> RedirectDelegate { get; }

        private void SendMessages()
        {
            while (true)
            {
                if (Writer.ItemQueue.Count > 0)
                {
                    RedirectDelegate.Invoke(Writer.ItemQueue.Dequeue());
                }
                else
                {
                    _sending = false;
                    break;
                }
            }
        }

        private void Writer_Queued(object sender, EventArgs e)
        {
            if (!_sending)
            {
                _sending = true;
                SendMessages();
            }
        }
    }
}
