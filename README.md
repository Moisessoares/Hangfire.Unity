Hangfire.Unity
================

[![Build status](https://ci.appveyor.com/api/projects/status/79opt6sesdam48yq)](https://ci.appveyor.com/project/odinserj/hangfire-unity)

[Hangfire](http://hangfire.io) background job activator based on 
[Unity](https://unity.codeplex.com/) IoC Container. It allows you to use instance
methods of classes that define parametrized constructors:

Installation
--------------

Hangfire.Unity is available as a NuGet Package. Type the following
command into NuGet Package Manager Console window to install it:

```
Install-Package Hangfire.Unity
```

Usage
------

The package provides an extension method for [OWIN bootstrapper](http://docs.hangfire.io/en/latest/users-guide/getting-started/owin-bootstrapper.html):

```csharp
app.UseHangfire(config =>
{
    var container = new UnityContainer();
    config.UseUnityActivator(container);
});
```

In order to use the library outside of web application, set the static `JobActivator.Current` property:

```csharp
var container = new UnityContainer();
JobActivator.Current = new UnityJobActivator(container);
```

