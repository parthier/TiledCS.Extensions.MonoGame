# TiledCS.Extensions.MonoGame
The officially supported MonoGame port for the TiledCS library.

## Overview
This [TiledCS](https://github.com/TheBoneJarmer/TiledCS) extension makes integrating the library easier for MonoGame projects.
It comes with the following features by default.

- A custom Content Pipeline extension;
- Basic rendering functionality;
- An example implementation of the rendering functionality.

Keep in mind that for advanced tile rendering, you would still need to write your own rendering code outside the library.
The reason for this is that it's difficult to write good rendering code that matches everyone's needs.

## Development
If you want to compile the library on your own or contribute to it, you'll have to get started by cloning the project.
```sh
git clone https://github.com/delightedcat/TiledCS.Extensions.MonoGame.git
cd TiledCS.Extensions.MonoGame/
```

You can then build the project using `dotnet build`. The first time though you might run into some errors.
This is because the content compilation process requires the pipeline to be compiled first. You can fix this by removing the builder tasks line from the `.csproj` of the example project and adding it back after compiling the package successfully for the first time.

You can also use the content pipeline without using the library by copying the content readers from the core project to your own codebase.
