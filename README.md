# ParallelMap-Assignment

Explanation
Structure of Solution: N-Tier (All Projects in .NET 6 Framework)

1 .Program.cs:

Contains the Main method.
Consumes the ParallelMap class and includes instruction code for TaskFunctions (Disk I/O, Network, CPU (Image Processing)).
Takes a dependency reference of ParallelMap-Assignment.ParallelMapLib.

2. ParallelMap-Assignment.ParallelMapLib:

A .NET Library that includes TaskFunctions and ParallelMap.
Promotes Separation of Concerns (SoC).
TaskFunctions contains the list of functions used in the ParallelMap method.

3. ParallelMapTests.cs:

Contains unit tests for the ParallelMap method using NUnit.
References ParallelMap-Assignment.ParallelMapLib.

4. Summary
   
a) The solution is structured in an N-Tier architecture using .NET 6 Framework. The Program.cs file serves as the entry point and utilizes the ParallelMap class, which is defined in the ParallelMap-Assignment.

b) ParallelMapLib library. This library also includes the TaskFunctions class, which encapsulates various tasks for Disk I/O, Network, and CPU-bound operations such as image processing. The solution emphasizes Separation of Concerns (SoC) by organizing functionalities into distinct classes and libraries.

c) Additionally, unit tests for the ParallelMap method are implemented in ParallelMapTests.cs using the NUnit testing framework, ensuring the reliability and correctness of the implementation.
