# JsonSerializationIssue

## Issue
Newtonsoft.Json throws an exception (Unable to cast object of type 'System.Linq.EmptyPartition`1[System.String]' to type 'System.Collections.IList') upon deserialization involving constructor that uses **Enumerable.Empty<T>()** for Properties with **private** setters.

After some investigations, the cause of the issue can/may be attributed to the combination of :
1. Enumerable.Empty<T>() returns EmptyPartition<T>.Instance from .NET Core 3 onwards (https://github.com/dotnet/runtime/issues/27552)
2. This is a breaking change (in a way) for Newtonsoft.Json, which causes IEnumerable<T> properties with private setters to throw an exception (https://issues.hibernatingrhinos.com/issue/RavenDB-14394) 

## Workarounds
There are various workarounds to prevent this issue :
1. Use Enumerable.Empty<T>().ToArray()/ToList() instead of Enumerable.Empty<T>() (to force a type different from EmptyPartition)
2. Use Enumerable.Empty<T>() + public setters instead of private setters
3. Put another abstraction layer (a class whose properties are nullable) on it in such ways that this class does not get deserialized directly, but rather created by the abstraction layer

The ideal solution would be option 3 although it may not be possible depending on the place, etc.
