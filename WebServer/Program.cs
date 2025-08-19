var items = Enumerable.Range(1, 200);
var evenNumbers = items.AsParallel().Where(
    x =>
    {
        Console.WriteLine($" Process1 num {x} ; ThreadId : {Thread.CurrentThread.ManagedThreadId} ");
        return (x % 2 == 0);
    }
);

Console.WriteLine();
// ForAll() calls for run all in threads to gain parallelism
// so no ordering and synchronization maintained
evenNumbers.ForAll(item =>
{
    Console.WriteLine($" Process2 num {item} ; ThreadId : {Thread.CurrentThread.ManagedThreadId}");
});
