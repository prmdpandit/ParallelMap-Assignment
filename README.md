# ParallelMap-Assignment

Explanation:

Structure of Solution: N-Tier (All Project in .Net 6 Framwork)

Program.cs: Contains the Main method and Consume the ParallelMap Class and instructiion code for TakFunctions(Disk I/O, Network, CPU(Image Processing)). Deendency ParallelMap-Assignment.ParallelMapLib need to take refrence.
ParallelMap-Assignment.ParallelMapLib: .Net Library which have TaskFunctions and ParallelMap with some utnity for Sop (Sepration of consorn), TaskFunctions Contains the list of functions used in the ParallelMap method. 
ParallelMapTests.cs: Contains unit tests for the ParallelMap method using NUnit. Refrence of ParallelMap-Assignment.ParallelMapLib.

Summary:

1. A CancellationTokenSource is created to manage the timeout. The CancelAfter method sets the cancellation token to trigger after the specified timeoutMs.
2. Semaphore: A SemaphoreSlim to control the number of concurrent tasks, limiting it to maxConcurrency.
3. The ParallelMapFunc method allows you to execute a list of asynchronous functions in parallel with a limit on the maximum number of concurrent tasks (maxConcurrency) and an overall timeout (timeoutMs).
4. It uses a semaphore to control concurrency, a cancellation token to manage the timeout, and handles exceptions to ensure that the operation is robust and provides meaningful error messages.
5. The method returns a list of results, preserving the order of the input functions.
