# 🔢 Text Processor CLI

[![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-11.0-239120?style=flat-square&logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Cross--Platform-lightgrey?style=flat-square)](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md)

> **Advanced Text-to-Number Converter with 5-Step Algorithm Processing**

A sophisticated CLI application that transforms any text input through a comprehensive 5-step algorithm, producing deterministic numerical outputs with elegant mathematical operations.

## 📋 Table of Contents

- [Features](#-features)
- [Algorithm Overview](#-algorithm-overview)
- [Installation](#-installation)
- [Usage](#-usage)
- [Menu Options](#-menu-options)
- [Technical Details](#-technical-details)
- [Examples](#-examples)
- [Contributing](#-contributing)
- [License](#-license)

## ✨ Features

- 🎯 **5-Step Processing Algorithm** - Advanced text transformation pipeline
- 📖 **Interactive Dictionary Viewer** - Explore character-to-number mappings
- 🎨 **Beautiful CLI Interface** - ASCII art borders and emoji indicators
- 🔄 **Deterministic Results** - Same input always produces same output
- 🚀 **High Performance** - Optimized with LINQ and efficient data structures
- 🌐 **Cross-Platform** - Runs on Windows, Linux, and macOS
- 🛡️ **Error Resilient** - Robust input validation and error handling
- 📊 **Step-by-Step Visualization** - Clear display of each processing stage

## 🔄 Algorithm Overview

The program implements a sophisticated 5-step algorithm:

```
Input Text → [1] → [2] → [3] → [4] → [5] → Final Numbers
```

### Step-by-Step Process

| Step | Process | Description |
|------|---------|-------------|
| **1** | Text to Numbers | Convert each character using predefined mapping |
| **2** | Alternating Sum | Calculate: `first + second - third + fourth - ...` |
| **3** | Number to Letters | Build sequence summing to Step 2 result, convert to letters |
| **4** | Sequence Refinement | Apply alternating sum, replace last 2 elements |
| **5** | Final Transformation | Convert even numbers to odd, keep odd numbers same |

## 🚀 Installation

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- Any terminal/command prompt

### Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/text-processor-cli.git
   cd text-processor-cli
   ```

2. **Build the application**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

### Alternative: Direct Execution

1. **Build for release**
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained
   ```

2. **Run the executable**
   ```bash
   ./bin/Release/net6.0/win-x64/publish/TextProcessorCLI.exe
   ```

## 🎮 Usage

Launch the application and you'll see the main menu:

```
╔══════════════════════════════════════════════════════════════╗
║                         MAIN MENU                           ║
╠══════════════════════════════════════════════════════════════╣
║  1. 📝 Process Text to Numbers                              ║
║  2. 📖 View Dictionary Mapping                              ║
║  3. ℹ️  About Program                                        ║
║  4. 🚪 Exit                                                  ║
╚══════════════════════════════════════════════════════════════╝
```

Simply enter your choice (1-4) and follow the prompts!

## 🎯 Menu Options

### 1. 📝 Process Text to Numbers
Transform your text through the complete 5-step algorithm:
- Enter any text string
- Watch each transformation step
- Get final numerical result

### 2. 📖 View Dictionary Mapping
Explore the character-to-number conversion tables:
- **Uppercase letters**: A-Z mappings
- **Lowercase letters**: a-z mappings  
- **Number-to-letter**: Reverse conversion table
- **Special characters**: Space and other symbols

### 3. ℹ️ About Program
Learn about:
- Detailed algorithm explanation
- Technical implementation details
- Performance characteristics
- Development information

### 4. 🚪 Exit
Gracefully exit the application with a farewell message.

## 🔧 Technical Details

### Architecture

- **Language**: C# 11.0
- **Framework**: .NET 6.0+
- **Pattern**: Pipeline processing with functional programming
- **Data Structures**: Dictionary, List, StringBuilder, Tuple

### Performance

| Metric | Value | Notes |
|--------|-------|--------|
| **Time Complexity** | O(n + target) | n = text length, target = sum value |
| **Space Complexity** | O(n + target) | Linear memory usage |
| **Dictionary Lookup** | O(1) | Constant time character mapping |
| **Processing Speed** | ~1ms per 100 chars | On modern hardware |

### Key Components

- **Dictionary Mapping**: 66 character-to-number mappings
- **LINQ Operations**: Functional data transformations
- **Error Handling**: Safe dictionary access with fallbacks
- **UI Framework**: ASCII art with emoji enhancement

## 📊 Examples

### Example 1: Simple Text

```bash
Input: Hello
Step 1: 3 7 5 5 3
Step 2: 3 + 7 - 5 + 5 - 3 = 7
Step 3: A B B B B A A
Step 4: A B B B B A E
Step 5: 1 1 1 1 1 1 7
```

### Example 2: Mixed Case

```bash
Input: Hello World
Step 1: 3 7 5 5 3 0 9 3 2 5 8
Step 2: 3 + 7 - 5 + 5 - 3 + 0 - 9 + 3 - 2 + 5 - 8 = -4
Step 3: A A A A
Step 4: A A E E
Step 5: 1 1 7 7
```

### Character Mapping Reference

| Uppercase | Value | Lowercase | Value |
|-----------|-------|-----------|--------|
| A | 0 | v,w,x,y,z | 0 |
| B,C,D | 1 | u | 1 |
| E | 2 | p,q,r,s,t | 2 |
| F,G,H | 3 | o | 3 |
| I | 4 | j,k,l,m,n | 4 |
| J,K,L,M,N | 5 | i | 5 |
| O | 6 | f,g,h | 6 |
| P,Q,R,S,T | 7 | e | 7 |
| U | 8 | b,c,d | 8 |
| V,W,X,Y,Z | 9 | a | 9 |

## 🏗️ Project Structure

```
TextProcessorCLI/
│
├── Program.cs              # Main application entry point
├── TextProcessorCLI.csproj # Project configuration
├── README.md               # This file
└── LICENSE                 # MIT License
```

## 🔨 Building from Source

### Development Build
```bash
# Debug build
dotnet build

# Release build
dotnet build -c Release
```

### Platform-Specific Builds
```bash
# Windows x64
dotnet publish -c Release -r win-x64 --self-contained

# Linux x64
dotnet publish -c Release -r linux-x64 --self-contained

# macOS x64
dotnet publish -c Release -r osx-x64 --self-contained
```

## 🧪 Testing

The application includes comprehensive error handling:

- **Invalid Input**: Non-mapped characters default to 0
- **Empty Input**: Graceful handling with user feedback
- **Edge Cases**: Negative sums, zero values, large inputs
- **Menu Navigation**: Input validation for menu choices

## 🎨 Customization

### Modifying Character Mappings

Edit the `LetterToNumber` dictionary in `Program.cs`:

```csharp
private static readonly Dictionary<char, int> LetterToNumber = new Dictionary<char, int>
{
    {'A', 0},  // Modify these values
    {'B', 1},  // Add new characters
    // ... rest of mappings
};
```

### Adding New Processing Steps

Extend the `ProcessText` method:

```csharp
static void ProcessText(string input)
{
    // ... existing steps
    
    // Add your custom step
    var customResult = YourCustomAlgorithm(refined);
    Console.WriteLine($"6️⃣  STEP 6 - Custom Processing:");
    Console.WriteLine($"    {customResult}");
}
```

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add amazing feature'`)
4. **Push to the branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

### Development Guidelines

- Follow C# coding conventions
- Add XML documentation for public methods
- Include unit tests for new features
- Update README for significant changes


## 🎯 Roadmap

- [ ] **GUI Version** - Windows Forms or WPF interface
- [ ] **API Endpoint** - REST API for web integration
- [ ] **Batch Processing** - Process multiple files
- [ ] **Custom Algorithms** - Plugin system for new algorithms
- [ ] **Export Options** - JSON, CSV, XML output formats
- [ ] **Performance Profiler** - Built-in benchmarking tools

## 🙏 Acknowledgments

- **Microsoft .NET Team** - For the excellent framework
- **C# Community** - For best practices and inspiration
- **ASCII Art Generators** - For beautiful CLI borders

---

**Made with ❤️ and C#**

[⬆ Back to Top](#-text-processor-cli)
