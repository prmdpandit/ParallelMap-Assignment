using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParallelMap_Assignment.ParallelMapLib;

namespace ParallelMap_Assignment.Test
{
    [TestFixture]
    public class ParallelMapTests
    {
        private ParallelMap parallelMap;
        private List<Func<Task<string>>> taskFunctions;

        private string testTextFilePath;
        private string testXmlFilePath;

        [SetUp]
        public void Setup()
        {
           parallelMap = new ParallelMap();
           taskFunctions = TaskFunctions.GetTaskFunctions();

           
            // Construct the full path to the test files
            testTextFilePath = "TestFiles/TestTextFile.txt";
            testXmlFilePath = "TestFiles/TestXmlFile.xml";

            // Ensure the files exist (optional sanity check)
            Assert.IsTrue(File.Exists(testTextFilePath), $"Test file not found: {testTextFilePath}");
            Assert.IsTrue(File.Exists(testXmlFilePath), $"Test file not found: {testXmlFilePath}");
        }

        [Test]
        public async Task ParallelMap_ShouldExecuteAllFunctions()
        {
            // Arrange
            

            // Act
            List<string> results = null;
            try
            {
                results = await parallelMap.ParallelMapFunc<string>(2, taskFunctions, 2000);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Execution failed: {ex.Message}");
            }

            // Assert
            Assert.NotNull(results);
            Assert.AreEqual(taskFunctions.Count, results.Count);
        }

        [Test]
        public async Task ParallelMap_ShouldRespectConcurrencyLimit()
        {
            // Arrange
            
            var maxConcurrency = 2;
            var timeoutMs = 5000; // Increase timeout to handle network calls and file I/O

            // Act
            List<string> results = null;
            var start = DateTime.Now;
            try
            {
                results = await parallelMap.ParallelMapFunc<string>(maxConcurrency, taskFunctions, timeoutMs);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Execution failed: {ex.Message}");
            }
            var duration = DateTime.Now - start;

            // Assert
            Assert.NotNull(results);
            Assert.AreEqual(taskFunctions.Count, results.Count);
            Assert.GreaterOrEqual(duration.TotalMilliseconds, 1000); // Ensure that some delay due to concurrency limit
        }   

    
    }
}