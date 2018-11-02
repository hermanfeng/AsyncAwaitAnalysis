using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitAnalysisCommon
{
    public class TestCase
    {
        public static ILogger Logger = new DebugLogger();
        /// <summary>
        /// Precondition:
        /// 1. In winform, wpf, webapi or asp.net, SynchronizationContext in runtime
        /// 2. Block on call task method.
        /// </summary>
        /// <returns></returns>
        public static Task RunMockDeadLook()
        {
            Logger.Log($"0MockDeadLook : Start in Thread Id --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
            TaskCompletionSource<bool> source = new TaskCompletionSource<bool>();
            var task = RunTestTaskAsync();

            task.GetAwaiter().OnCompleted(
                () =>
                {
                    Console.WriteLine($"MockDeadLook : End in Thread Id --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
                    source.SetResult(true);
                });
            return source.Task;
        }


        public static async Task RunTestTaskAsync()
        {
            Logger.Log($"1Test : Start in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
            await RunTestTask1();
            Logger.Log($"4Test : After Test 1 in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
            await RunTestTask2();
            Logger.Log($"7Test : End in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
        }

        private static async Task RunTestTask1()
        {
            Logger.Log($"2Test 1 : Start in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
            await Task.Delay(1000);
            Logger.Log($"3Test 1 : End in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
        }

        private static async Task RunTestTask2()
        {
            Logger.Log($"5Test 2 : Start in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
            await Task.Delay(1000);
            Logger.Log($"6Test 2 : End in thread --{Thread.CurrentThread.ManagedThreadId}-- in context --{GetSyncContext()}--");
        }

        private static string GetSyncContext()
        {
            return SynchronizationContext.Current?.GetType().Name ?? "Null";
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
