```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2033)
12th Gen Intel Core i7-1265U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]                 : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  Version 3.5.0          : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  Version 4.0.0          : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  Version 4.0.0-preview5 : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method               | Job                    | NuGetReferences                            | Mean      | Error    | StdDev    | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
|--------------------- |----------------------- |------------------------------------------- |----------:|---------:|----------:|------:|--------:|--------:|----------:|------------:|
| BooleanFlagManyTimes | Version 3.5.0          | Microsoft.FeatureManagement 3.5.0          | 150.24 μs | 8.023 μs | 23.656 μs |  1.03 |    0.23 | 32.9590 | 203.13 KB |        1.00 |
| BooleanFlagManyTimes | Version 4.0.0          | Microsoft.FeatureManagement 4.9999.9999    | 120.67 μs | 2.357 μs |  2.315 μs |  0.82 |    0.13 | 22.9492 | 140.63 KB |        0.69 |
| BooleanFlagManyTimes | Version 4.0.0-preview5 | Microsoft.FeatureManagement 4.0.0-preview5 | 165.07 μs | 2.976 μs |  4.172 μs |  1.13 |    0.19 | 49.5605 | 304.69 KB |        1.50 |
|                      |                        |                                            |           |          |           |       |         |         |           |             |
| MissingFlagManyTimes | Version 3.5.0          | Microsoft.FeatureManagement 3.5.0          | 151.37 μs | 7.910 μs | 23.322 μs |  1.03 |    0.25 | 41.9922 | 257.81 KB |        1.00 |
| MissingFlagManyTimes | Version 4.0.0          | Microsoft.FeatureManagement 4.9999.9999    |  69.05 μs | 1.327 μs |  2.771 μs |  0.47 |    0.09 | 11.4746 |  70.31 KB |        0.27 |
| MissingFlagManyTimes | Version 4.0.0-preview5 | Microsoft.FeatureManagement 4.0.0-preview5 | 137.17 μs | 2.221 μs |  3.832 μs |  0.93 |    0.18 | 58.5938 | 359.38 KB |        1.39 |
