use `await Task.WhenAll()` rather than `await` one by one
ex using `async/await` one by one, take 1.5s:
```c#
var stopwatch = new Stopwatch();
stopwatch.Start();

var first = await firstMethod();
Console.WriteLine("finish first: " + stopwatch.Elapsed);
var second = await secondMethod();
Console.WriteLine("finish second: " + stopwatch.Elapsed);

async Task<int> firstMethod()
{
    await Task.Delay(500);
    return 1;
}

async Task<int> secondMethod()
{
    await Task.Delay(1000);
    return 1;
}
```

ex using `Task.WhenAll`, take 1s:
```c#
var stopwatch = new Stopwatch();
stopwatch.Start();

// take 0.5s
var first = firstMethod();
Console.WriteLine("finish first: " + stopwatch.Elapsed);

// take 1s
var second = secondMethod();
Console.WriteLine("finish second: " + stopwatch.Elapsed);

// take 1s for all
await Task.WhenAll(first, second);
Console.WriteLine("When All: " + stopwatch.Elapsed);

// take 1s
int firstInt = await first;
Console.WriteLine("first int: " + stopwatch.Elapsed);
// take 1s
int secondInt = await second;
Console.WriteLine("second int: " + stopwatch.Elapsed);
```