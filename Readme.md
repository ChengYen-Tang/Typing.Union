# Type.Union
[![NuGet](https://img.shields.io/nuget/v/Type.Union)](https://www.nuget.org/packages/Type.Union/)<br/>
Union typing is only needed when you have a statically typed language, as you need to declare that an object can return one of multiple types (in your case an int or string , or in the other example string or null)

## Example
```
using Type;

namespace Example;
public class Program
{
    public static void Main(string[] args)
    {
        Print((Union<int, string, string[]>)5);
        Print((Union<int, string, string[]>)"Hello");
        Print((Union<int, string, string[]>)new[] { "Hello", "World" });
        //Output:
        //5
        //Hello
        //Hello, World

        Console.WriteLine(GetStringLength((Union<int, string, string[]>)100));
        Console.WriteLine(GetStringLength((Union<int, string, string[]>)"Hello"));
        Console.WriteLine(GetStringLength((Union<int, string, string[]>)new[] { "Hello", "World" }));
        //Output:
        //3
        //5
        //12
    }

    public static void Print(Union<int, string, string[]> printValue)
        => printValue.MatchAction(
            i => Console.WriteLine(i),
            s => Console.WriteLine(s),
            sa => Console.WriteLine(string.Join(", ", sa)));

    public static int GetStringLength(Union<int, string, string[]> value)
        => value.MatchFunc(
                i => i.ToString().Length,
                s => s.Length,
                sa => string.Join(", ", sa).Length);
}
```
