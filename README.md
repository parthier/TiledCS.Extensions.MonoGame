# TiledCS.Extensions.MonoGame

A MonoGame port of the [TiledCS](https://github.com/TheBoneJarmer/TiledCS) library that comes
with a complete content pipeline and minimal rendering code.

**DISCLAIMER:** During development of this library, it turned out to be really hard to write
rendering code that is useful for everyone's needs. This is why the project only comes with a very
basic rendering API. The rest is entirely up to the users.

## Overview

This extension for [TiledCS](https://github.com/TheBoneJarmer/TiledCS) is aimed at integrating the library
in MonoGame projects more easily. It comes with the following features by default:

- A custom Content Pipeline extension (`Pipeline`);
- Basic rendering functionality (`Core`);
- An example implementation of the rendering functionality (`Example.Rendering`);
- An example implementation using only the Content Pipeline extension (`Example.Vanilla`).

## Getting Started

**NOTE:** A NuGet package should be coming soon to ease up the process of installing the library!

There are two ways to go about getting started with this library; with or without the
build-in renderer. For very basic demonstrations, using the renderer is probably fine,
but for more advanced cases you're probably looking for a custom rendering solution.

First off, you will need to clone the library and include it into your project as you
normally would. Compile the project once in your editor/IDE of choice and
[reference the freshly built DLL in your MonoGame Content Pipeline project](https://www.monogameextended.net/docs/getting-started/installation#using-the-monogame-pipeline-gui).

The DLL that should be referenced is called `TiledCS.Extensions.MonoGame.Content.Pipeline.dll` and can usually be found somewhere in `bin\Debug` or `bin\Release`,
depending on your selected release type.

Once done, you should be able to load maps as follows:
```cs
var map = Content.Load<TiledMap>("TestMap");
```
This will load a TMX file that was added to your Content Pipeline project called `TestMap`. That's all that's needed to load up a single map!

Have a look at the [TiledCS](https://github.com/TheBoneJarmer/TiledCS) repository to
get an overview of all the available properties. Beyond this point map handling works
exactly the same as any project using the TiledCS library.

If you want to use the built-in renderer, have a look at the example project for
this in the `Example.Renderer` directory of this repository.

## Development

If you want to compile the library on your own or contribute to it, you'll have to get started by
cloning the project.

```sh
git clone https://github.com/delightedcat/TiledCS.Extensions.MonoGame.git
cd TiledCS.Extensions.MonoGame/
```

You can then build the project using `dotnet build`. The first time though you might run into some errors.
This is because the content compilation process requires the pipeline to be compiled first. You can fix this by removing the builder tasks line from the `.csproj` of the example project and adding it back after compiling the package successfully for the first time.

You can also use the content pipeline without using the library by copying the content readers from the core project to your own codebase.
