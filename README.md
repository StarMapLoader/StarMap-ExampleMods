# StarMap example mods

Example mods for the [StarMap](https://github.com/StarMapLoader/StarMap) mod loader for Kitten Space Agency (KSA).

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A StarMap release compatible with `StarMap.API` 0.3.6
- KSA reference assemblies for local builds, and KSA itself for installation and testing

The repository uses the .NET 10 SDK and all assemblies target `net10.0`. This is a runtime requirement, not only a build-tool choice: the current StarMap loader and KSA reference assemblies also target .NET 10.

CI uses the official `RocketWerkz.KSA.Ref` package from StarMap's authenticated GitHub Packages feed and authenticates with the workflow's repository token. Local builds use assemblies from an `Import` directory by default because GitHub Packages requires authentication. Neither approach copies proprietary game binaries into build output or commits them to this repository.

## Build

Create an `Import` directory next to this repository and copy these files from the matching KSA installation into it:

- `KSA.dll`
- `Brutal.ImGui.dll`
- `Brutal.ImGui.Extensions.dll`
- `Brutal.Core.Numerics.dll`
- `Brutal.Glfw.dll`

Then restore and build the complete solution from the repository root:

```shell
dotnet restore StarMap-ExampleMods.sln
dotnet build StarMap-ExampleMods.sln --configuration Release --no-restore
```

To keep the assemblies elsewhere, pass `-p:KsaReferencePath=C:\path\to\assemblies` to restore and build. The build reports a direct error with the expected path when the references are missing.

Release output is written below each project's `bin/Release/net10.0` directory. CI performs the same Release build and verifies formatting.

## Create a mod

1. Create a .NET class library targeting `net10.0`.
2. Add the [`StarMap.API`](https://www.nuget.org/packages/StarMap.API) package.
3. Reference the matching KSA and Brutal assemblies for compilation when the mod uses their APIs, without copying them to output.
4. Add a class marked with `[StarMapMod]`.
5. Mark lifecycle methods with the relevant StarMap attributes, as demonstrated by `StarMap.SimpleMod` and `StarMap.SimpleMod2`.
6. Add a `mod.toml` whose `name` and `StarMap.EntryAssembly` match the mod assembly name.

The examples demonstrate these lifecycle hooks:

- `[StarMapImmediateLoad]`: runs as soon as the mod is loaded.
- `[StarMapBeforeMain]`: runs before the game enters its main flow.
- `[StarMapAllModsLoaded]`: runs after all mods are loaded.
- `[StarMapAfterGui]`: runs after the game's GUI update.
- `[StarMapUnload]`: releases patches or other resources when the mod unloads.

`StarMap.SimpleMod2` also demonstrates exporting a dependency, and `StarMap.SimpleMod` demonstrates importing that dependency from another mod.

## Package and install

Package the mod DLL, its `mod.toml`, and any mod-owned runtime dependencies. Do not redistribute KSA assemblies, Brutal assemblies, StarMap, or Harmony with a mod.

Install the folder in one of StarMap's supported mod locations:

- `Documents/My Games/Kitten Space Agency/mods/<ModName>/` (recommended)
- `<KSA installation>/Content/<ModName>/`

For a content-folder installation, add the mod to KSA's `manifest.toml`:

```toml
[[mods]]
id = "StarMap.SimpleMod"
enabled = true
```

Start the game through `StarMap.exe`. Compilation validates the public reference surface; final compatibility still needs an in-game smoke test with the matching KSA and StarMap versions.
