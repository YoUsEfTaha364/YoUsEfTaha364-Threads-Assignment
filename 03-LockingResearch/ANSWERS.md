# Assignment 03 — Answers

Student name:  
Group / ID:

1. Monitor is the same as lock but additionally make

allows threads to communicate with each other using wait and signal methods (Wait, Pulse, and PulseAll), making it useful for producer-consumer patterns.



2. it compiled to 

  bool lockTaken = false;
    try
    {
        Monitor.Enter(temp, ref lockTaken);
        // Critical section
    }
    finally
    {
        if (lockTaken)
        {
            Monitor.Exit(temp);
        }
    }

    uses Monitor

3. Timeout Support (Monitor.TryEnter) 
   Inter-Thread Signaling (Wait, Pulse, PulseAll)

4.  1. Monitor.TryEnter (Avoiding Deadlocks & Indefinite Blocking)
A plain lock statement blocks execution indefinitely until the lock is available

    2. Monitor.Wait and Monitor.Pulse / PulseAll (Inter-Thread Signaling & Coordination)
A plain lock only enforces isolation—it ensures one thread runs at a time, but cannot coordinate when a thread should run relative to state changes made by another thread.

Monitor.Wait and Monitor.Pulse allow threads to pause execution, temporarily release the lock, and wait until another thread notifies them that a condition has been met.


5.

 private static readonly object _gate = new object();
private static int _counter = 0;

public void IncrementCounter()
{
    lock (_gate)
    {
        _counter++;
    }
}

private static readonly object _gate = new object();
private static int _counter = 0;

public void IncrementCounter()
{
    object temp = _gate;
    bool lockTaken = false;

    try
    {
        Monitor.Enter(temp, ref lockTaken);
        _counter++;
    }
    finally
    {
        if (lockTaken)
        {
            Monitor.Exit(temp);
        }
    }
}

Links:

- https://learn.microsoft.com/en-us/dotnet/api/system.threading.monitor?view=net-10.0
- https://www.c-sharpcorner.com/article/monitor-and-lock-in-C-Sharp?srsltid=AYCX9vLrvrZjotmqTMcv4FhuIGcSm4sfGqoVt_ZzbANJNCn6N_YpOEpw
