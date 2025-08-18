
void WriteThreadId()
{
    for (int i = 0; i <= 100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.Name + " has count occuring of " + i);
        Thread.Sleep(50);
        //  keeping the thread in sleep will change the algorithms of thread synchronization
 
    }
}

// WriteThreadId();

Thread thread1 = new Thread(WriteThreadId);
Thread thread2 = new Thread(WriteThreadId);

thread1.Name = "Thread1";
thread2.Name = "Thread2";
Thread.CurrentThread.Name = "main thread ";

thread1.Priority = ThreadPriority.Highest;
thread2.Priority = ThreadPriority.Lowest;
Thread.CurrentThread.Priority = ThreadPriority.Normal;

thread1.Start();
WriteThreadId();
thread2.Start();



// to sttart the thread
Console.ReadLine();