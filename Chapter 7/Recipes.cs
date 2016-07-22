using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Chapter7
{
    public class Recipes
    {
        private object threadLock = new object();

        #region Recipe 1 - Create and abort a low priority background thread
        /// <summary>
        /// Description:    This is the code for the Create and abort a low priority background thread Recipe found in Chapter 7
        /// Recipe:         Recipe 1 - Create and abort a low priority background thread
        /// Chapter:        7
        /// </summary>
        public void DoBackgroundTask()
        {
            WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has a threadstate of {Thread.CurrentThread.ThreadState} with {Thread.CurrentThread.Priority} priority");
            WriteLine($"Start thread sleep at {DateTime.Now.Second} seconds");
            Thread.CurrentThread.Abort();
            Thread.Sleep(3000);
            WriteLine($"End thread sleep at {DateTime.Now.Second} seconds");
        }
        #endregion

        #region Recipe 2 - Increasing maximum thread pool size
        /// <summary>
        /// Description:    This is the code for the Increasing maximum thread pool size Recipe found in Chapter 7
        /// Recipe:         Recipe 2 - Increasing maximum thread pool size
        /// Chapter:        7
        /// </summary>
        public void IncreaseThreadPoolSize()
        {
            int numberOfProcessors = Environment.ProcessorCount;
            WriteLine($"Processor Count = {numberOfProcessors}");

            int maxworkerThreads;
            int maxconcurrentActiveRequests;
            int minworkerThreads;
            int minconcurrentActiveRequests;
            ThreadPool.GetMinThreads(out minworkerThreads, out minconcurrentActiveRequests);
            WriteLine($"ThreadPool minimum Worker = {minworkerThreads} and minimum Requests = {minconcurrentActiveRequests}");

            ThreadPool.GetMaxThreads(out maxworkerThreads, out maxconcurrentActiveRequests);
            WriteLine($"ThreadPool maximum Worker = {maxworkerThreads} and maximum Requests = {maxconcurrentActiveRequests}");

            Random rndWorkers = new Random();
            int newMaxWorker = rndWorkers.Next(minworkerThreads, maxworkerThreads);
            WriteLine($"New Max Worker Thread generated = {newMaxWorker}");

            Random rndConRequests = new Random();
            int newMaxRequests = rndConRequests.Next(minconcurrentActiveRequests, maxconcurrentActiveRequests);
            WriteLine($"New Max Active Requests generated = {newMaxRequests}");

            bool changeSucceeded = ThreadPool.SetMaxThreads(newMaxWorker, newMaxRequests);
            if (changeSucceeded)
            {
                WriteLine("SetMaxThreads completed");
                int maxworkerThreadCount;
                int maxconcurrentActiveRequestCount;
                ThreadPool.GetMaxThreads(out maxworkerThreadCount, out maxconcurrentActiveRequestCount);
                WriteLine($"ThreadPool Max Worker = {maxworkerThreadCount} and Max Requests = {maxconcurrentActiveRequestCount}");
            }
            else
                WriteLine("SetMaxThreads failed");

        }
        #endregion

        #region Recipe 3 - Creating multiple threads
        /// <summary>
        /// Description:    This is the code for the Creating multiple threads Recipe found in Chapter 7
        /// Recipe:         Recipe 3 - Creating multiple threads
        /// Chapter:        7
        /// </summary>
        public void MultipleThreadWait()
        {
            Task thread1 = Task.Factory.StartNew(() => RunThread(3));
            Task thread2 = Task.Factory.StartNew(() => RunThread(5));
            Task thread3 = Task.Factory.StartNew(() => RunThread(2));

            Task.WaitAll(thread1, thread2, thread3);
            WriteLine("All tasks completed");
        }

        private void RunThread(int sleepSeconds)
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;

            WriteLine($"Sleep thread {threadID} for {sleepSeconds} seconds at {DateTime.Now.Second} seconds");
            Thread.Sleep(sleepSeconds * 1000);
            WriteLine($"Wake thread {threadID} at {DateTime.Now.Second} seconds");
        }

        #endregion

        #region Recipe 4 - Locking one thread until contended resources are available
        /// <summary>
        /// Description:    This is the code for the Locking one thread until contended resources are available Recipe found in Chapter 7
        /// Recipe:         Recipe 4 - Locking one thread until contended resources are available
        /// Chapter:        7
        /// </summary>
        public void LockThreadExample()
        {
            Task thread1 = Task.Factory.StartNew(() => ContendedResource(3));
            Task thread2 = Task.Factory.StartNew(() => ContendedResource(5));
            Task thread3 = Task.Factory.StartNew(() => ContendedResource(2));

            Task.WaitAll(thread1, thread2, thread3);
            WriteLine("All tasks completed");
        }

        private void ContendedResource(int sleepSeconds)
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            lock (threadLock)
            {
                WriteLine($"Locked for thread {threadID}");
                Thread.Sleep(sleepSeconds * 1000);
            }
            WriteLine($"Lock released for thread {threadID}");
        }
        #endregion

        #region Recipe 5 - Invoking parallel calls to methods using Parallel.Invoke
        /// <summary>
        /// Description:    This is the code for the Invoking parallel calls to methods using Parallel.Invoke Recipe found in Chapter 7
        /// Recipe:         Recipe 5 - Invoking parallel calls to methods using Parallel.Invoke
        /// Chapter:        7
        /// </summary>
        public void ParallelInvoke()
        {
            WriteLine($"Parallel.Invoke started at {DateTime.Now.Second} seconds");
            Parallel.Invoke(
                () => PerformSomeTask(3),
                () => PerformSomeTask(5),
                () => PerformSomeTask(2)
                );

            WriteLine($"Parallel.Invoke completed at {DateTime.Now.Second} seconds");
        }

        private void PerformSomeTask(int sleepSeconds)
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"Sleep thread {threadID} for {sleepSeconds} seconds");
            Thread.Sleep(sleepSeconds * 1000);
            WriteLine($"Thread {threadID} resumed");
        }
        #endregion

        #region Recipe 6 - Using a parallel foreach loop
        /// <summary>
        /// Description:    This is the code for the Using a parallel foreach loop Recipe found in Chapter 7
        /// Recipe:         Recipe 6 - Using a parallel foreach loop
        /// Chapter:        7
        /// </summary>
        public double ReadCollectionForEach(List<string> intCollection)
        {
            var timer = Stopwatch.StartNew();
            foreach (string integer in intCollection)
            {
                WriteLine(integer);
                Clear();
            }
            return timer.Elapsed.TotalSeconds;
        }

        public double ReadCollectionParallelForEach(List<string> intCollection)
        {
            var timer = Stopwatch.StartNew();
            Parallel.ForEach(intCollection, integer =>
            {
                WriteLine(integer);
                Clear();
            });
            return timer.Elapsed.TotalSeconds;
        }

        public void CreateWriteFilesForEach(List<string> intCollection)
        {
            WriteLine($"Start foreach File method");
            var timer = Stopwatch.StartNew();
            foreach (string integer in intCollection)
            {
                string filePath = $"C:\\temp\\output\\ForEach_Log{integer}.txt";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    {
                        sw.WriteLine($"{integer}. Log file start: {DateTime.Now.ToUniversalTime().ToString()}");
                    }
                }
            }
            WriteLine($"foreach File method executed in {timer.Elapsed.TotalSeconds} seconds");
        }

        public void CreateWriteFilesParallelForEach(List<string> intCollection)
        {
            WriteLine($"Start Parallel.ForEach File method");
            var timer = Stopwatch.StartNew();
            Parallel.ForEach(intCollection, integer =>
            {
                string filePath = $"C:\\temp\\output\\ParallelForEach_Log{integer}.txt";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    {
                        sw.WriteLine($"{integer}. Log file start: {DateTime.Now.ToUniversalTime().ToString()}");
                    }
                }
            });
            WriteLine($"Parallel.ForEach File method executed in {timer.Elapsed.TotalSeconds} seconds");
        }
        #endregion

        #region Recipe 7 - Cancelling a parellel foreach loop
        /// <summary>
        /// Description:    This is the code for the Cancelling a parallel foreach loop Recipe found in Chapter 7
        /// Recipe:         Recipe 7 - Cancelling a parallel foreach loop
        /// Chapter:        7
        /// </summary>
        public void CancelParallelForEach(List<string> intCollection, int timeOut)
        {
            var timer = Stopwatch.StartNew();
            Parallel.ForEach(intCollection, (integer, state) =>
            {
                Thread.Sleep(1000);
                if (timer.Elapsed.Seconds > timeOut)
                {
                    WriteLine($"Terminate thread {Thread.CurrentThread.ManagedThreadId}. Elapsed time {timer.Elapsed.Seconds} seconds");
                    state.Break();
                }
                WriteLine($"Processing item {integer} on thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }
        #endregion
        
        #region Recipe 8 - Catching errors in parallel foreach loops
        /// <summary>
        /// Description:    This is the code for the Catching errors in parallel foreach loops Recipe found in Chapter 7
        /// Recipe:         Recipe 8 - Catching errors in parallel foreach loops
        /// Chapter:        7
        /// </summary>
        public void CheckClientMachinesOnline(List<string> ipAddresses, int minimumLive)
        {
            try
            {
                int machineCount = ipAddresses.Count();
                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = machineCount;
                int deadMachines = 0;

                Parallel.ForEach(ipAddresses, options, ip =>
                {
                    if (MachineReturnedPing(ip))
                    {

                    }
                    else
                    {
                        if (machineCount - Interlocked.Increment(ref deadMachines) < minimumLive)
                        {
                            WriteLine($"Machines to check = {machineCount}");
                            WriteLine($"Dead machines = {deadMachines}");
                            WriteLine($"Minimum machines required = {minimumLive}");
                            WriteLine($"Live Machines = {machineCount - deadMachines}");

                            throw new Exception($"Minimum machines requirement of {minimumLive} not met");
                        }
                    }
                });

            }
            catch (AggregateException aex)
            {
                WriteLine("An AggregateException has occurred");
                throw;
            }
        }

        private bool MachineReturnedPing(string ip)
        {
            return false;
        }

        #endregion
        
        #region Recipe 9 - Debugging multithreaded applications
        /// <summary>
        /// Description:    This is the code for the Debugging multithreaded applications Recipe found in Chapter 7
        /// Recipe:         Recipe 9 - Debugging multithreaded applications
        /// Chapter:        7
        /// </summary>
        public void DebugMultipleThreads()
        {
            Task thread1 = Task.Factory.StartNew(() => RunProcess());
            Task thread2 = Task.Factory.StartNew(() => RunProcess());
            Task thread3 = Task.Factory.StartNew(() => RunProcess());

            Task.WaitAll(thread1, thread2, thread3);
            WriteLine("All tasks completed");
        }

        private void RunProcess()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            Thread.CurrentThread.Name = $"New Thread{threadID}";

            Random rnd = new Random();
            int sleepSeconds = rnd.Next(1, 10);

            WriteLine($"Sleep thread {threadID} for {sleepSeconds} seconds at {DateTime.Now.Second} seconds");
            Thread.Sleep(sleepSeconds * 1000);
            WriteLine($"Wake thread {threadID} at {DateTime.Now.Second} seconds");
        } 
        #endregion
    }
}
