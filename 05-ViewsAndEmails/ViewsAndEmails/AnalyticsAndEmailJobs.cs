using System.Collections.Concurrent;

namespace ViewsAndEmails;

public sealed class AnalyticsAndEmailJobs
{
    public readonly ConcurrentDictionary<string, int> Views = new();
    public readonly ConcurrentQueue<string> EmailJobs = new();
    public readonly List<string> SentEmails = new();

    readonly object _sentSync = new();
    public volatile bool ProducersDone;

    // public void RecordView(string product)
    // {
    //     if (!Views.ContainsKey(product))
    //         Views.Add(product, 0);

    //     Views[product] = Views[product] + 1;
    // }

    public void RecordView(string product)
    {
        Views.AddOrUpdate(
            key: product,
            addValue: 1, // If the key doesn't exist, set value to 1
            updateValueFactory: (key, currentValue) => currentValue + 1 // If it exists, increment
        );
    }

    public void PlaceOrder(int orderId)
    {
        EmailJobs.Enqueue($"Email: order {orderId}");
    }

    // public void EmailWorker()
    // {
    //     while (true)
    //     {
    //         try
    //         {
    //             string? job = null;
    //             if (EmailJobs.Count > 0)
    //                 job = EmailJobs.Dequeue();

    //             if (job is not null)
    //             {
    //                 lock (_sentSync)
    //                     SentEmails.Add(job);
    //                 continue;
    //             }

    //             if (ProducersDone && EmailJobs.Count == 0)
    //                 return;

    //             Thread.Sleep(1);
    //         }
    //         catch (InvalidOperationException)
    //         {
    //             Console.WriteLine("InvalidOperationException");
    //             if (ProducersDone)
    //                 return;
    //         }
    //     }
    // }

    public void EmailWorker()
{
    while (true)
    {
        if (EmailJobs.TryDequeue(out string? job))
        {
            lock (_sentSync)
            {
                SentEmails.Add(job);
            }

            continue;
        }

        if (ProducersDone && EmailJobs.IsEmpty)
            return;

        Thread.Sleep(1);
    }
}
}
