using System.Diagnostics;

namespace InvoiceExport;

public sealed class InvoiceExportService
{
    readonly OrderDatabase _db;
    readonly CustomerFileStore _customers;
    readonly InvoiceFileWriter _invoices;

    public InvoiceExportService(OrderDatabase db, CustomerFileStore customers, InvoiceFileWriter invoices)
    {
        _db = db;
        _customers = customers;
        _invoices = invoices;
    }

    private async Task ExportOrderAsync(Order order)
    {
        Order fresh = await _db.GetOrderById(order.Id)
            ?? throw new InvalidOperationException(
                $"Order {order.Id} missing");

        CustomerProfile customer =
            await _customers.ReadProfile(fresh.CustomerId);

        string path =
            await _invoices.WriteInvoice(fresh, customer);

        Console.WriteLine($"Wrote {path}");
    }

    public async Task ExportAllPending()
    {
        var watch = Stopwatch.StartNew();
        List<Order> orders = await _db.GetPendingOrders();

        // foreach (Order order in orders)
        // {
        //     Order fresh = await _db.GetOrderById(order.Id)
        //         ?? throw new InvalidOperationException($"Order {order.Id} missing");

        //     CustomerProfile customer = await _customers.ReadProfile(fresh.CustomerId);
        //     string path = await _invoices.WriteInvoice(fresh, customer);
        //     Console.WriteLine($"Wrote {path}");
        // }

          await Task.WhenAll(
          orders.Select(ExportOrderAsync));

        Console.WriteLine($"Export finished in {watch.Elapsed.TotalSeconds:F1} s");
    }
}
