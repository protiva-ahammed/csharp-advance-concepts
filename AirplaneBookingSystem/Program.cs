
using System.Collections;
// web server clients will send request
// monitor queue
// request processor queue

// 3 threads true parallelism

Queue<string?> requestQueue = new Queue<string?>();
object ticketlock = new object();

int availableTickets = 11; 
// start the requests queue monitoring thread

Thread monitoringThread = new Thread(MonitorQueue);
monitoringThread.Start();

// main thread enqueing the tasks
Console.WriteLine("Server is up-running. \r\n Press B to book the ticket . \r\n Press C to cancel the ticket.\r\n X to exit \r\n ");
while (true)
{
    string? input = Console.ReadLine();

if (input?.ToLower() == "x")
    {
        Console.WriteLine("Server is exited ");
        break;
    }
    lock (ticketlock)
    {
         if (input?.ToLower() == "b")
    {
            if (availableTickets > 0)
            {
                availableTickets--;
                Console.WriteLine();
                Console.WriteLine($"Your seat had been booked. Number of available seats are {availableTickets} \n");

            }
            else
            {
                Console.WriteLine($"No available seats. Number of available seats are {availableTickets} \n");

        }

    }
    else if (input?.ToLower() == "c")
    {
        if (availableTickets < 0)
        {
            availableTickets++;
            Console.WriteLine();
            Console.WriteLine($"Your boking had been cancelled. Number of available seats are {availableTickets} \n");
        }else
            {
                Console.WriteLine($"No cancel available . Number of available seats are {availableTickets} \n");

        }
    }

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
            Thread processingThread = new Thread(() => ProcessBooking(input));
            processingThread.Start();
        }

        Thread.Sleep(100);
    }
}


//3. processing the request

static void ProcessBooking(string? input)
{
    // simulate process time
    Thread.Sleep(4000);
    Console.WriteLine($" Processed input : {input} ");
}




