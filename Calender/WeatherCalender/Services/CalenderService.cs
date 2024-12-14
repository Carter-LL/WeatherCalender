using Microsoft.JSInterop;
using WeatherCalender.Models.SQL.Tables;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherCalender.Services
{
    public class CalenderService
    {
        private IJSRuntime _jsRuntime { get; set; }
        private ConcurrentQueue<PlannedEventModel> _eventQueue;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _backgroundTask;

        public CalenderService(IJSRuntime jSRuntime)
        {
            this._jsRuntime = jSRuntime;
            _eventQueue = new ConcurrentQueue<PlannedEventModel>();
            _cancellationTokenSource = new CancellationTokenSource();

            StartBackgroundTask();
        }

        // This method will be called to add a new event to the queue
        public async Task AddCalenderEvent(PlannedEventModel model)
        {
            _eventQueue.Enqueue(model);
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
                    // Process the events in the queue
                    if (_eventQueue.TryDequeue(out var plannedEvent))
                    {
                        // Invoke JS runtime from the UI thread using InvokeAsync
                        try
                        {
                            await _jsRuntime.InvokeVoidAsync("addNoteToDate", plannedEvent.Date, plannedEvent.Description);
                            Console.WriteLine($"+ Event processed and added: Date:{plannedEvent.Date}, Description:{plannedEvent.Description}");
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
