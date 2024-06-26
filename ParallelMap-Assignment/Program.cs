using ParallelMap_Assignment.ParallelMapLib;

namespace ParallelMap_Assignment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var taskFunctions = TaskFunctions.GetTaskFunctions();

            var parallelMap = new ParallelMap();
            try
            {
                var results = await parallelMap.ParallelMapFunc<string>(2, taskFunctions, 2000); // 2 concurrent tasks, 5000ms timeout             

                results.ForEach(Console.WriteLine);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }
}
