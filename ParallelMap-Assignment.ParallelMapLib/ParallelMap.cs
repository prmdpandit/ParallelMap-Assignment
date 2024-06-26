using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelMap_Assignment.ParallelMapLib
{
    public class ParallelMap
    {    

        public async Task<List<TResult>> ParallelMapFunc<TResult>(int maxConcurrency, List<Func<Task<TResult>>> functions, int timeoutMs)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeoutMs);

            var tasks = new List<Task<TResult>>();
            var results = new TResult[functions.Count];
            var semaphore = new SemaphoreSlim(maxConcurrency);

            for (int i = 0; i < functions.Count; i++)
            {
                int index = i;
                try
                {
                   // await semaphore.WaitAsync(cancellationTokenSource.Token);
                    await semaphore.WaitAsync(cancellationTokenSource.Token).ConfigureAwait(false);

                }
                catch (OperationCanceledException)
                {
                    throw new TimeoutException("The operation timed out.");
                }

                var task = Task.Run(async () =>
                {
                    try
                    {
                        results[index] = await functions[index]();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Function at index {index} failed: {ex.Message}");
                        throw;  // Ensure that the task represents a failed state if an exception occurs
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                    return results[index];
                }, cancellationTokenSource.Token);

                tasks.Add(task);
            }

            try
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("The operation timed out.");
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

            return results.ToList();
        }

    }
}
