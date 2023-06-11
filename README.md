# No Auto Pause
A mod for Super Monkey Ball Banana Mania that disables the automatic pausing when the game window loses focus. 

## Installation
Firstly, install the [Banana Mod Manager](https://github.com/MorsGames/BananaModManager) into the game's installation folder.

Download the latest version of the mod from the [Releases](https://github.com/piggeywig2000/BMNoAutoPause/releases) page, and extract the zip into the "mods" folder inside the game's installation folder. Then run the game through the Banana Mod Manager.

## Opening the project
If you'd like to open this project yourself to view or modify the source code, you'll need to define the location of a couple of directories.

In the BMNoAutoPause directory (which also contains the `BMNoAutoPause.csproj` file), create a file called `BMNoAutoPause.csproj.user` with the following contents:
```xml
<Project>
  <PropertyGroup>
    <OutputPath>C:\Program Files (x86)\Steam\steamapps\common\smbbm\mods\piggeywig2000.noautopause</OutputPath>
	<ReferenceFolder>C:\Program Files (x86)\Steam\steamapps\common\smbbm\managed</ReferenceFolder>
  </PropertyGroup>
</Project>
```
`OutputPath` refers to the directory to build the project into. `ReferenceFolder` refers to the directory that contains the game's DLLs. You should modify these paths if they're different on your computer.