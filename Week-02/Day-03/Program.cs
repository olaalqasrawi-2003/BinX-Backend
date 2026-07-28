using System.Diagnostics;

static async Task GetDatabaseDataAsync(CancellationToken token)
{
    Console.WriteLine("Loading Database...");
    await Task.Delay(5000, token);
    Console.WriteLine("Database Loaded");
}

static async Task GetApiDataAsync()
{
    Console.WriteLine("Loading API...");
    await Task.Delay(3000);
    Console.WriteLine("API Loaded");
}

static async Task GetFileDataAsync()
{
    Console.WriteLine("Loading File...");
    await Task.Delay(1000);
    Console.WriteLine("File Loaded");
}


var stopwatch = Stopwatch.StartNew();

await GetDatabaseDataAsync(CancellationToken.None);
await GetApiDataAsync();
await GetFileDataAsync();

stopwatch.Stop();

Console.WriteLine();
Console.WriteLine(
    $"Sequential Execution Time: {stopwatch.ElapsedMilliseconds} ms"
);


Console.WriteLine();

var stopwatch2 = Stopwatch.StartNew();

await Task.WhenAll(
    GetDatabaseDataAsync(CancellationToken.None),
    GetApiDataAsync(),
    GetFileDataAsync()
);

stopwatch2.Stop();

Console.WriteLine();
Console.WriteLine(
    $"Concurrent Execution Time: {stopwatch2.ElapsedMilliseconds} ms"
);


Console.WriteLine();

using CancellationTokenSource cancellationTokenSource = new();

Task databaseTask =
    GetDatabaseDataAsync(cancellationTokenSource.Token);

await Task.Delay(2000);

cancellationTokenSource.Cancel();

try
{
    await databaseTask;
}
catch (OperationCanceledException)
{
    Console.WriteLine("Database operation was cancelled.");
}