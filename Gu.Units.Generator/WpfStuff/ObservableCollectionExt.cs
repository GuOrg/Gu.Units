namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Threading;

    internal static class ObservableCollectionExt
    {
        internal static void InvokeAdd<T>(this ObservableCollection<T> collection, T newItem)
        {
            collection.Invoke(() => collection.Add(newItem));
        }

        internal static void InvokeAddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> newItems)
        {
            collection.Invoke(
                () =>
                {
                    foreach (var newItem in newItems)
                    {
                        collection.Add(newItem);
                    }
                });
        }

        internal static void InvokeRemove<T>(this ObservableCollection<T> collection, T oldItem)
        {
            collection.Invoke(() => collection.Remove(oldItem));
        }

        internal static void InvokeRemove<T>(this ObservableCollection<T> collection, Func<T, bool> criteria)
        {
            collection.InvokeRemove(collection.Where(criteria).ToArray());
        }

        internal static void InvokeRemove<T>(this ObservableCollection<T> collection, IEnumerable<T> oldItems)
        {
            collection.Invoke(
                () =>
                {
                    foreach (var oldItem in oldItems)
                    {
                        collection.Remove(oldItem);
                    }
                });
        }

        internal static void InvokeClear<T>(this ObservableCollection<T> collection)
        {
            collection.Invoke(() => collection.Clear());
        }

        internal static void Invoke<T>(this ObservableCollection<T> col, Action action)
        {
            Dispatcher dispatcher = Application.Current != null
                ? Application.Current.Dispatcher
                : Dispatcher.CurrentDispatcher;
            dispatcher.Invoke(action);
        }

        internal static DispatcherOperation AddAsync<T>(this ObservableCollection<T> collection, T newItem)
        {
            return collection.InvokeAsync(() => collection.Add(newItem));
        }

        internal static DispatcherOperation AddRangeAsync<T>(
            this ObservableCollection<T> collection,
            IEnumerable<T> newItems)
        {
            return collection.InvokeAsync(
                () =>
                {
                    foreach (var newItem in newItems)
                    {
                        collection.Add(newItem);
                    }
                });
        }

        internal static DispatcherOperation RemoveAsync<T>(this ObservableCollection<T> collection, T oldItem)
        {
            return collection.InvokeAsync(() => collection.Remove(oldItem));
        }

        internal static DispatcherOperation ClearAsync<T>(this ObservableCollection<T> collection)
        {
            return collection.InvokeAsync(() => collection.Clear());
        }

        internal static DispatcherOperation InvokeAsync<T>(this ObservableCollection<T> col, Action action)
        {
            Dispatcher dispatcher = Application.Current != null // For testst
                ? Application.Current.Dispatcher
                : Dispatcher.CurrentDispatcher;
            return dispatcher.InvokeAsync(action);
        }
    }
}
