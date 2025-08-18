
// internal class Program
// {
//     private static void Main(string[] args)
//     {
//if we use the main method then to run the code main method have to perform first as it is the entry point.therefore priority does not worked
// therefore to observe the performance of ThreadPriority we have to work without main function

using Microsoft.VisualBasic;

int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9 , 55];

int sum1 = 0, sum2=0, sum3=0, sum4=0;

var startTime = DateTime.Now;

int noOfThread = 4;

int segmentLength = arr.Length / noOfThread;


//thread's array
Thread[] thread = new Thread[noOfThread];



int getSum(int start , int end)
{
    int sum = 0;
    for (int i = start; i < end; i++)
    {
        sum += arr[i];
        Thread.Sleep(100);
    }
    Console.WriteLine( " accessed by " + Thread.CurrentThread.ManagedThreadId);

    return sum;
}

thread[0] = new Thread(() => { sum1 = getSum( 0, segmentLength); });

thread[1] = new Thread(() => { sum2 = getSum( segmentLength, 2 * segmentLength); });

thread[2] = new Thread(() => { sum3 = getSum(2 * segmentLength, 3 * segmentLength); });

thread[3] = new Thread(() => { sum4 = getSum( 3 * segmentLength, arr.Length); });

// starting the threads
foreach(var th in thread){
    th.Start();
}

//
foreach(var th in thread){
    th.Join();
}

int res = sum1 + sum2 + sum3 + sum4;
var endTime = DateTime.Now;
Console.WriteLine(" the sum is : " + res + " by " + Thread.CurrentThread.ManagedThreadId+ " Duration : " + (endTime - startTime).TotalMilliseconds);
Console.ReadLine();
