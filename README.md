# Source Generator Demo: AutoNotify + SignalR

A complete working example of a .NET Source Generator that automatically implements INotifyPropertyChanged and integrates with SignalR for real-time updates.

## 🚀 Quick Start

```bash
git clone <your-repo-url>
cd SourceGeneratorDemo
dotnet build
cd WebApi
dotnet run
```

###### Open http://localhost:5000/index.html

## ✨ What This Demo Shows

* Source Generator (introduced in .NET 5/C# 9)

* Automatic INotifyPropertyChanged implementation

* SignalR real-time communication

* Zero reflection - all code at compile time

## 📝 The Magic

#### Write this:

```cs
public partial class UserProfile {
    [AutoNotify] private string _name;
    [AutoNotify] private int _age;
}
```

#### Generator creates:

* Public properties (Name, Age)

* INotifyPropertyChanged implementation

* Change notification in setters

## 🎯 When to Use Source Generators


| Use ✅ | Don't Use ❌ |
| -------- | -------- |
| Repetitive boilerplate   | Complex business logic   |
| Serialization   | One-off calculations   |
| DTO mapping   | Dynamic scenarios   |
| Cross-cutting concerns   | Unique code per use   |

## 🏗️ Tech Stack

* .NET 8 Web API

* SignalR for real-time updates

* Source Generators (netstandard2.0)

## 📖 Learn More

[Source Generators in .NET](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview)

## 📄 License

MIT
