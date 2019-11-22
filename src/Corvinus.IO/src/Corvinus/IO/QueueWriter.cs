// <copyright file="QueueWriter.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The QueueWriter Class.
    /// This class gives the ability to use a TextWriter with an embedded Queue to store
    /// written items. QueueWriter includes an eventhandler to monitor changes to the Queue.
    /// Assignable to <see cref="TextWriter"/>.
    /// </summary>
    public class QueueWriter : TextWriter
    {
        private static volatile UnicodeEncoding s_encoding = null;
        private EventHandler _queued;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueWriter"/> class.
        /// </summary>
        public QueueWriter() 
            : base()
        {
            ItemQueue = new Queue<string>();
        }

        /// <summary>
        /// A write has occured and the relevant string has been
        /// enqueued.
        /// </summary>
        public event EventHandler Queued
        {
            add { _queued += value; }
            remove { _queued -= value; }
        }

        /// <summary>
        /// Gets ItemQueue as a buffer for text that is written to
        /// the object.
        /// </summary>
        public Queue<string> ItemQueue
        {
            get;
        }

        /// <inheritdoc/>
        public override Encoding Encoding
        {
            get
            {
                if (s_encoding == null)
                {
                    s_encoding = new UnicodeEncoding(false, false);
                }

                return s_encoding;
            }
        }

        /// <summary>
        /// Clears the ItemQueue.
        /// </summary>
        public override void Flush()
        {
            ItemQueue.Clear();
        }

        /// <inheritdoc/>
        public override void Write(bool value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(char value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(char[] buffer)
        {
            WriteToQueue(buffer.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(char[] buffer, int index, int count)
        {
            WriteIndexBufferToQueue(buffer, index, count, false);
        }

        /// <inheritdoc/>
        public override void Write(decimal value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(double value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(float value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(int value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(long value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(object value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(string format, object arg0)
        {
            WriteToQueue(string.Format(format, arg0), false);
        }

        /// <inheritdoc/>
        public override void Write(string format, object arg0, object arg1)
        {
            WriteToQueue(string.Format(format, new object[] { arg0, arg1 }), false);
        }

        /// <inheritdoc/>
        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            WriteToQueue(string.Format(format, new object[] { arg0, arg1, arg2 }), false);
        }

        /// <inheritdoc/>
        public override void Write(string format, params object[] arg)
        {
            WriteToQueue(string.Format(format, arg), false);
        }

        /// <inheritdoc/>
        public override void Write(string value)
        {
            WriteToQueue(value, false);
        }

        /// <inheritdoc/>
        public override void Write(uint value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void Write(ulong value)
        {
            WriteToQueue(value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void WriteLine()
        {
            WriteToQueue(string.Empty, true);
        }

        /// <inheritdoc/>
        public override void WriteLine(bool value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(char value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(char[] buffer)
        {
            WriteToQueue(buffer.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(char[] buffer, int index, int count)
        {
            WriteIndexBufferToQueue(buffer, index, count, true);
        }

        /// <inheritdoc/>
        public override void WriteLine(decimal value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(double value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(float value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(int value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(long value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(object value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(string format, object arg0)
        {
            WriteToQueue(string.Format(format, arg0), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(string format, object arg0, object arg1)
        {
            WriteToQueue(string.Format(format, new object[] { arg0, arg1 }), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            WriteToQueue(string.Format(format, new object[] { arg0, arg1, arg2 }), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(string format, params object[] arg)
        {
            WriteToQueue(string.Format(format, arg), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(string value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(uint value)
        {
            WriteToQueue(value.ToString(), true);
        }

        /// <inheritdoc/>
        public override void WriteLine(ulong value)
        {
            WriteToQueue(value.ToString(), true);
        }

        private void WriteToQueue(string value, bool isNewLine)
        {
            if (value != null)
            {
                if (isNewLine)
                {
                    value = value + NewLine;
                }

                ItemQueue.Enqueue(value);
                _queued?.Invoke(this, EventArgs.Empty);
            }
        }

        private void WriteIndexBufferToQueue(char[] buffer, int index, int count, bool isNewLine)
        {
            if (!(buffer == null || index < 0 || count < 0 || buffer.Length - index < count))
            {
                char[] newBuffer = new char[count];

                for (int i = 0; i < count; i++)
                {
                    newBuffer[i] = buffer[index + i];
                }

                WriteToQueue(newBuffer.ToString(), isNewLine);
            }
        }
    }
}
