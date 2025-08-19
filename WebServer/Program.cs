
using System.Collections;
// web server clients will send request
// monitor queue
// request processor queue

// 3 threads true parallelism

Queue<string?> requestQueue = new Queue<string?>();

// start the requests queue monitoring thread

Thread monitoringThread = new Thread(MonitorQueue);
monitoringThread.Start();

// main thread enqueing the tasks
Console.WriteLine("Server is up-running. press X to exit ");
while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "x")
    {
        Console.WriteLine("Server is exited ");

        break;
    }
    requestQueue.Enqueue(input);
}

// working thread; monoitoring the request .
// if has request to monitor then 

void MonitorQueue()
{
    while (true)
    {
        if (requestQueue.Count > 0)
        {
            string? input = requestQueue.Dequeue();
            // ProcessInput(input);
            Thread processingThread = new Thread(() => ProcessInput(input));
            processingThread.Start();
        }

        Thread.Sleep(100);
    }
}


//3. processing the request

static void ProcessInput(string? input)
{
    // simulate process time
    Thread.Sleep(4000);
    Console.WriteLine($" Processed input : {input} ");
}


// PLINQ
// var items = Enumerable.Range(1, 200);
// var evenNumbers = items.AsParallel().Where(
//     x =>
//     {
//         Console.WriteLine($" Process1 num {x} ; ThreadId : {Thread.CurrentThread.ManagedThreadId} ");
//         return (x % 2 == 0);
//     }
// );

// Console.WriteLine();
// // ForAll() calls for run all in threads to gain parallelism
// // so no ordering and synchronization maintained
// evenNumbers.ForAll(item =>
// {
//     Console.WriteLine($" Process2 num {item} ; ThreadId : {Thread.CurrentThread.ManagedThreadId}");
// });
