using System;
using System.Collections.Generic;
using Xunit;
using HedinsToolKit.TaskControl;
using System.Linq;
using System.Threading.Tasks;

namespace HedinsToolKit.Tests
{
    public class EventWaiterUnitTests
    {
        [Fact]
        public void EventWaiterTest()
        {
            // Delay event invocation
            const int eventDelay = 1000;

            var raiseEventTask = Task.Run(async ()=>{
                // Wait delay
                await Task.Delay(eventDelay);
                // Raise event
                OnTestEvent(new EventArgs());
            });
            // Get awaiter for event
            var waitEventTask = EventWaiter.WaitAsync<EventArgs>((h)=> TestEvent += h,(h)=> TestEvent -= h);
            // Wait (await waitEventTask)
            var waitResult = waitEventTask.Wait(eventDelay + 100);

            Assert.True(waitResult);
        }

        private event EventHandler<EventArgs> TestEvent;  
        
        private void OnTestEvent(EventArgs e)
        {
            EventHandler<EventArgs> handler = TestEvent;
            if (handler != null) {
                handler(this, e);
            }
        }

    }
}
