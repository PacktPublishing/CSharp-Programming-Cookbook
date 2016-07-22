using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    public class AsyncDemo
    {
        #region Recipe 1 - Return Types of Asynchronous Functions
        /// <summary>
        /// Description:    This is the code for the Return Types of Asynchronous Functions Recipe found in Chapter 6
        /// Recipe:         Recipe 1 - Return Types of Asynchronous Functions
        /// Chapter:        6
        /// </summary>
        public async Task LongTask()
        {
            bool isLeapYear = await TaskOfTResultReturning_AsyncMethod();
            Console.WriteLine($"{DateTime.Now.Year} {(isLeapYear ? " is " : "  is not  ")} a leap year");
            await TaskReturning_AsyncMethod();


            //Task<bool> blnIsLeapYear = TaskOfTResultReturning_AsyncMethod();

            //for (int i = 0; i <= 10000; i++)
            //{
            //    // Do other work that does not rely on blnIsLeapYear before awaiting
            //}

            //bool isLeapYear = await TaskOfTResultReturning_AsyncMethod();

            //Console.WriteLine($"{DateTime.Now.Year} {(isLeapYear ? " is " : "  is not  ")} a leap year");

            //Task taskReturnMethhod = TaskReturning_AsyncMethod();

            //for (int i = 0; i <= 10000; i++)
            //{
            //    // Do other work that does not rely on taskReturnMethhod before awaiting
            //}

            //await taskReturnMethhod;

        }

        async Task TaskReturning_AsyncMethod()
        {
            // The body of an async method is expected to contain an awaited 
            // asynchronous call.
            // Task.Delay is a placeholder for actual work.
            await Task.Delay(5000);
            // Task.Delay delays the following line by 5 seconds.
            Console.WriteLine("5 second delay");
            // This method has no return statement, so its return type is Task.
        }

        async Task<bool> TaskOfTResultReturning_AsyncMethod()
        {
            // The body of the method is expected to contain an awaited asynchronous
            // call.
            // Task.FromResult is a placeholder for actual work that returns a string.
            return await Task.FromResult<bool>(DateTime.IsLeapYear(DateTime.Now.Year));
        }
        #endregion
        
        #region Recipe 2 - Handling tasks in Asynchronous programming
        public Task<int> ReadBigFile()
        {
            var bigFile = File.OpenRead(@"C:\temp\taskFile.txt");
            var bigFileBuffer = new byte[bigFile.Length];
            var readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            readBytes.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.Running)
                    Console.WriteLine("Running");
                else if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("RanToCompletion");
                else if (task.Status == TaskStatus.Faulted)
                    Console.WriteLine("Faulted");

                bigFile.Dispose();
            });
            return readBytes;
        }
        #endregion
        
        #region Recipe 3 - Exception Handling in Asynchronous Programming
        public async Task<int> ReadLogFile()
        {
            int returnBytes = -1;
            try
            {
                Task<int> intBytesRead = ReadMainLog();
                returnBytes = await ReadMainLog();
            }
            catch (Exception ex)
            {
                try
                {
                    returnBytes = await ReadBackupLog();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return returnBytes;
        }

        private async Task<int> ReadMainLog()
        {
            var bigFile = File.OpenRead(@"C:\temp\Log\MainLog\taskFile.txt");
            var bigFileBuffer = new byte[bigFile.Length];
            var readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            await readBytes.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Main Log RanToCompletion");
                else if (task.Status == TaskStatus.Faulted)
                    Console.WriteLine("Main Log Faulted");

                bigFile.Dispose();
            });
            return await readBytes;
        }

        private async Task<int> ReadBackupLog()
        {
            var bigFile = File.OpenRead(@"C:\temp\Log\BackupLog\taskFile.txt");
            var bigFileBuffer = new byte[bigFile.Length];
            var readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            await readBytes.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Backup Log RanToCompletion");
                else if (task.Status == TaskStatus.Faulted)
                    Console.WriteLine("Backup Log Faulted");

                bigFile.Dispose();
            });
            return await readBytes;
        } 
        #endregion

    }
}
