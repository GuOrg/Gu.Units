namespace Gu.Units.Generator
{
    using System;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    public static class ObservableExtensions
    {
#pragma warning disable VSTHRD200 // Use "Async" suffix for async methods
        public static IDisposable SubscribeAsync<T>(this IObservable<T> source, Func<Task> onNextAsync) =>
#pragma warning restore VSTHRD200 // Use "Async" suffix for async methods
            source
                .Select(_ => Observable.FromAsync(onNextAsync))
                .Concat()
                .Subscribe();
    }
}
