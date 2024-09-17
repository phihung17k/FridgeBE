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

----------------------------------------------------------
In Object:
`a.Equals(object? b)`: throw `NullReferenceException` when it is invoked on a `null` reference (a must be != null)
`ReferenceEquals(object? a, object? b)`: **not** throw `NullReferenceException`
`==`: same `ReferenceEquals`

object o1 = null;
object o2 = new object();

ReferenceEquals(o1, o1); //true
ReferenceEquals(o1, o2); //false
ReferenceEquals(o2, o1); //false
ReferenceEquals(o2, o2); //true

o1.Equals(o1); //NullReferenceException
o1.Equals(o2); //NullReferenceException
o2.Equals(o1); //false
o2.Equals(o2); //true