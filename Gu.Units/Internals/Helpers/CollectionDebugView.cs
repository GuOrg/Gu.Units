namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// http://www.codeproject.com/Articles/28405/Make-the-debugger-show-the-contents-of-your-custom
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    internal class CollectionDebugView<T>
    {
        private readonly IEnumerable<T> collection;

        private static readonly T[] Empty = new T[0];

        public CollectionDebugView(IEnumerable<T> collection)
        {
            this.collection = collection;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                var array = this.collection as T[];
                if (array != null)
                {
                    return array;
                }

                return this.collection?.ToArray() ?? Empty;
            }
        }
    }
}
