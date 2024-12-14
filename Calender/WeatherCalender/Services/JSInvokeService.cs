using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherCalender.Services
{
    public class JSInvokeService
    {
        private IJSRuntime _jsRuntime { get; set; }
        private ConcurrentQueue<(string FunctionName, object[] Parameters)> _customQueue;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _backgroundTask;

        public JSInvokeService(IJSRuntime jSRuntime)
        {
            this._jsRuntime = jSRuntime;
            _customQueue = new ConcurrentQueue<(string, object[])>();
            _cancellationTokenSource = new CancellationTokenSource();

            StartBackgroundTask();
        }

        // This method will be called to add a new function call with parameters to the queue
        public async Task EnqueueJSInvocation(string functionName, params object[] parameters)
        {
            _customQueue.Enqueue((functionName, parameters));
        }

        // Starts the background task that checks the queue every second
        public void StartBackgroundTask()
        {
            // If the background task is already running, do nothing
            if (_backgroundTask != null && !_backgroundTask.IsCompleted)
                return;

            // Create and start a new background task
            _backgroundTask = Task.Run(async () =>
            {
                var token = _cancellationTokenSource.Token;

                while (!token.IsCancellationRequested)
                {
                    // Process the items in the queue
                    if (_customQueue.TryDequeue(out var item))
                    {
                        // Extract function name and parameters
                        var (functionName, parameters) = item;

                        // Invoke JS runtime from the UI thread using InvokeAsync with dynamic parameters
                        try
                        {
                            await _jsRuntime.InvokeVoidAsync(functionName, parameters);
                            Console.WriteLine($"+ Function '{functionName}' processed and sent to JS with parameters: {string.Join(", ", parameters)}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error invoking JSRuntime: {ex.Message}");
                        }
                    }

                    // Wait for 1 second before checking the queue again
                    await Task.Delay(100);
                }
            });
        }

        // Stops the background task
        public void StopBackgroundTask()
        {
            _cancellationTokenSource.Cancel();
            _backgroundTask?.Wait();  // Wait for the background task to complete gracefully
        }
    }
}
