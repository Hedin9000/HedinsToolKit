using System;
using System.Collections.Generic;
using Xunit;
using HedinsToolKit.TaskControl;
using System.Linq;
using System.Threading.Tasks;

namespace HedinsToolKit.Tests
{
    public class TaskControlUnitTest
    {
        [Fact]
        public void EventWaiterTest()
        {
            const int eventDelay = 1000;
            var raiseEventTask = Task.Run(async ()=>{
                await Task.Delay(eventDelay);
                OnTestEvent(new EventArgs());
            });
            var waitEventTask = EventWaiter.WaitAsync<EventArgs>((h)=> TestEvent += h,(h)=> TestEvent -= h);   
            var waitResult = waitEventTask.Wait(eventDelay + 100);
            Assert.True(waitResult);
        }

        private event EventHandler<EventArgs> TestEvent;        
        private void OnTestEvent(EventArgs e) {
            EventHandler<EventArgs> handler = TestEvent;
            if (handler != null) {
                handler(this, e);
            }
        }

    }
}
