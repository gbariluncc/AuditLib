using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Audits.Infastructure
{
    public sealed class ProgressReporter
    {
        private readonly TaskScheduler _scheduler;
        private Action _reportAction;

        public ProgressReporter()
        {
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
        public Action ReportAction
        {
            get { return _reportAction; }
            set { _reportAction = value; }
        }
        public TaskScheduler Scheduler
        {
            get { return _scheduler; }
        }
        public Task ReportProgressAsync(Action action)
        {
            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, this.Scheduler);
        }

        public void ReportProgress(Action action)
        {
            this.ReportProgressAsync(action).Wait();
        }
        public Task RegisterContinuation(Task task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.None, _scheduler);
        }
        public Task RegisterContinuation<TResult>(Task<TResult> task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.None, _scheduler);
        }
        public Task RegisterSucceededHandler(Task task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, _scheduler);
        }
        public Task RegisterSucceededHandler<TResult>(Task<TResult> task, Action<TResult> action)
        {
            return task.ContinueWith(t => action(t.Result), CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, _scheduler);
        }
        public Task RegisterFaultedHandler(Task task, Action<Exception> action)
        {
            return task.ContinueWith(t => action(t.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, _scheduler);
        }
        public Task RegisterFaultedHandler<TResult>(Task<TResult> task, Action<Exception> action)
        {
            return task.ContinueWith(t => action(t.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, _scheduler);
        }
        public Task RegisterCancelledHandler(Task task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, _scheduler);
        }
        public Task RegisterCancelledHandler<TResult>(Task<TResult> task, Action action)
        {
            return task.ContinueWith(_ => action(), CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, _scheduler);
        }
    }
}
