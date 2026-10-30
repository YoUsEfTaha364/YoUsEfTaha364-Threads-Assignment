namespace MenuViews;

public sealed class MenuViewCounter
{
    public int Views;

    public void RegisterView()
    {
        // Views++;

        Interlocked.Increment(ref Views);
    }
}
