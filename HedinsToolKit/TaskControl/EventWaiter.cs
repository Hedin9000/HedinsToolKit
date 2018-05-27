using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HedinsToolKit.TaskControl
{
    public static class EventWaiter
    {
        /// <summary>
        /// Asynchronous wait one event.
        /// </summary>
        /// <typeparam name="TArgs">Type of EventArgs</typeparam>
        /// <param name="subscribeEventAction">Subscribe handler to event</param>
        /// <param name="unsubscribeEventAction">Unsubscribe handler from event</param>
        /// <returns></returns>
        public static async Task<TArgs> WaitAsync<TArgs>(Action<EventHandler<TArgs>> subscribeEventAction, Action<EventHandler<TArgs>> unsubscribeEventAction)
        {
            var taskCompletionSource = new TaskCompletionSource<TArgs>();

            void Handler(object sender, TArgs args) => taskCompletionSource.TrySetResult(args);

            subscribeEventAction(Handler);
            await taskCompletionSource.Task;
            unsubscribeEventAction(Handler);
            
            return taskCompletionSource.Task.Result;
        }
    }
}
