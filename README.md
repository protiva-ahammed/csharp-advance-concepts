# C# Advanced Concurrency Concepts

Practical implementations of advanced C# threading 
and concurrency patterns. Concepts applied to build an 
embedded IoT system enabling multiple staff to 
concurrently process picking, sorting, and packing 
of multiple customer orders simultaneously.


## References
- [Threading in C# — Albahari](http://albahari.com/threading/)
- [Task Parallel Library — Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl)
- [TPL in ASP.NET Web API — Stack Overflow](https://stackoverflow.com/questions/64567968/is-task-parallel-library-plinq-or-concurrent-collections-used-in-web-applicatio)

## Implementations

### Threading Fundamentals
- How threads run within the OS
- Starting multiple threads
- Thread synchronisation techniques
- Thread safety
- Thread affinity
- Thread pool

### Task Parallel Library
- Task vs Thread
- Running tasks
- Waiting for tasks
- Task continuations
- Exception and cancellation handling

### Async & Await
- async/await basics
- How async/await works under the hood

### Parallel Programming
- Parallel loops — stop, break, throw exceptions
- States of running results
- Performance considerations
- PLINQ (Parallel LINQ)

### Concurrent Collections
- Concurrent collections usage
- Event handling and delegates
