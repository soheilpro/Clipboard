# Clipboard
Cross-platform (Windows and OSX) clipboard library for .NET Core.

## Install

```
dotnet add package Clipboard
```

## Usage

```
using System;
using Clipboard;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Clipboard.Default.SetText("Hello World!");
        }
    }
}
```

## Version History
+ **1.0**
	+ Initial release.

## Author
**Soheil Rashidi**

+ http://soheilrashidi.com
+ http://twitter.com/soheilpro
+ http://github.com/soheilpro

## Credits
Windows support code borrowed from https://github.com/KolibriDev/clippy.

## Copyright and License
Copyright 2018 Soheil Rashidi.

Licensed under the The MIT License (the "License");
you may not use this work except in compliance with the License.
You may obtain a copy of the License in the LICENSE file, or at:

http://www.opensource.org/licenses/mit-license.php

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
