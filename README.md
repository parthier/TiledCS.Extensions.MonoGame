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
