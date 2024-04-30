﻿# AnimeCoverImage
[![.NET Core Desktop](https://github.com/Ruffythemonkey/AnimeCoverImage/actions/workflows/dotnet-desktop.yml/badge.svg?branch=master)](https://github.com/Ruffythemonkey/AnimeCoverImage/actions/workflows/dotnet-desktop.yml)

<h1 align="left">AnimeCoverImage 👀</h1>

###

<p align="left">Is a library for searching anime covers from various sources in .net8</p>

###

<h2 align="left">How to use it</h2>

###


<p align="left">The first result is always the best</p>

```csharp
IAnimeCoverImage myAnimeList = new MyAnimeListCom();
var x = await myAnimeList.GetAnimeCoverAsync("Dragon ball");
output.WriteLine(string.Join("\n", x.ToArray()));
```


###

<h2 align="left">I code with</h2>

###

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" height="40" alt="dotnetcore logo"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="40" alt="csharp logo"  />
</div>

###
