# AnimeCoverImage 👀
[![.NET Core Desktop](https://github.com/Ruffythemonkey/AnimeCoverImage/actions/workflows/dotnet-desktop.yml/badge.svg?branch=master)](https://github.com/Ruffythemonkey/AnimeCoverImage/actions/workflows/dotnet-desktop.yml)

###

<p align="left">Is a library for searching anime covers from various sources in .net8</p>

###

<h2 align="left">How to use it</h2>

###

### Lets Start

```c#
using AnimeCoverImage.Services;

IAnimeCoverImage myAnimeList = new MyAnimeListCom();

// x returns a Dictionary<string, string>
// Key = name of the Anime
// Value = url to the Image
var x = await myAnimeList.GetAnimeCoverAsync("Dragon ball");

```
> [!NOTE]
> The first result is always the best.



### All results in one overview

```csharp
Debug.WriteLine(string.Join("\n", x.ToArray()));
```

### Supported Services
```
MyAnimeList
AniList
```

###

<h2 align="left">coded in</h2>

###

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" height="40" alt="dotnetcore logo"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="40" alt="csharp logo"  />
</div>

###
