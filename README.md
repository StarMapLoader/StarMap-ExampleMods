# StarMap-ExampleMods

Example mods for the StarMap mod loader for KSA

## How to create mods

-   Create a new class library targeting .NET 9
-   Add `https://nuget.pkg.github.com/StarMapLoader/index.json` as a nuget source ([For Visual Studio](https://nuget.pkg.github.com/StarMapLoader/index.json))
-   Import [StarMap.API](https://github.com/StarMapLoader/StarMap/pkgs/nuget/StarMap.API)
-   Create a new class that implements IStarMapMod
-   Implement the methods from the interface
    -   OnImmediatLoad is called immediatly when the mod is finished loading (before Mod.PrepareSystems)
    -   OnFullyLoaded is called when all Mods are loaded (After ModLibrary.LoadAll)
    -   ImmediateUnload boolean states if the unload method should be called immediatly after OnImmediatLoad
    -   Unload is called or immedialty, or when the game unloads

## How to publish and install mods

-   Provide a zip or folder that contains the the class library dll as well as any dependencies excluding:
    -   Any part of KSA
    -   Harmony
-   Provide a mod.toml in the folder that contains the name of the mod 'name = [mod name]` (known in KSA as mod id)
-   The mod id needs to match the name of the assembly that contains the IStarMapMod class
-   StarMap will search for mods that have a dll like this, and then loads the first class that implements IStarMapMod (if any)
-   StarMap mods still work as normal KSA mods (so any textures added to the same folder will work correctly)
-   Lastly the mod needs to be added to the manifest.toml in the content folder, the id needs to match the id set above

```
[[mods]]
id = "[mod name]"
enabled = true
```

-   When now loading the game via `StarMap.exe` or `StarMapLoader.exe`, the mod should be loaded and run
