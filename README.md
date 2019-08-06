# Civ6_Map_Utility_Advanced

## About Project
Civ6_Map_Utility_Advanced was created to explore possibility of creating map templates in game Civilization 6 that differ from the standard sizes. Using this tool it is possible to set up extemely small and extremely large maps, with custom number of settings. Not all settings work correctly for all sizes, but this tool allows users to explore those possibilities that are not available in game by default.

## Release Information
For Executable Release and more info about the program to go:
https://github.com/iluzek/Civ6_Map_Utility_Advanced/releases

Initial release of exe was available on https://forums.civfanatics.com/resources/civ6_map_utility.25602/

## Direct links to the downloads :
https://github.com/iluzek/Civ6_Map_Utility_Advanced/releases/download/1.5.0/Civ6_Map_Utility.exe
https://github.com/iluzek/Civ6_Map_Utility_Advanced/archive/1.5.0.zip
https://github.com/iluzek/Civ6_Map_Utility_Advanced/archive/1.5.0.tar.gz


## How to open Project in Visual Studio/C#
Project written in C# with use of Visual Studio 2015. Still working with Visual Studio 2019.

- Clone or download the repository.

- Using Visual Studio open "Civ6_Map_Utility_Advanced.sln"

## What Civ6_Map_Utility does:

### Civ6_Map_Utility has two sections:
- **Map Sizes - Adds custom map sizes to the game**
- **Map Scripts - Adds external map scripts to the game (does not generate scripts)**<br />
#### Map Sizes section allows to add custom map sizes to the game.

- Create Map Sizes like 20x20, 100x200, 160x160 tiles.
- Select number of players.
- Select number of city states.
- Select number of natural wonders.
- Select number of continents.
- Select number of Prophets.

- Create Map Sizes like 20x20, 100x200, 160x160 tiles.
- Select number of players.
- Select number of city states.
- Select number of natural wonders.
- Select number of continents.
- Select number of Prophets.
<br />![alt text](http://i.imgur.com/BtOyDyv.png)<br />
**Easy to modify preset values from original game.**
<br />![alt text](http://i.imgur.com/jByOQUh.png)<br />
**Unlock settings by checking "Experimental settings" checkbox. **
<br />![alt text](http://i.imgur.com/PsoICsA.png)<br />
- It will allow you to go outside of normal settings to facilitate mods that increase number of civilizations, city states, beliefs etc.
- It will also allow you to unlock map sizes greater than defaults. They might or might not work, depending on how high you set it up.
Once in game you can find your new map size in selection screen.
<br />![alt text](http://i.imgur.com/4qqQtqZ.png)<br />
When new game starts.
<br />![alt text](http://i.imgur.com/47OMJil.jpg)<br />

**Other fun small custom maps:**
<br />![alt text](http://i.imgur.com/q0WLlge.jpg)<br />
<br />![alt text](http://i.imgur.com/geeHLQD.jpg)<br />

#### Map Scripts section allows to add custom map scripts to the game.
  
Adding map scripts with Civ6_Map_Utility is easy.

<br />![alt text](http://i.imgur.com/scar8Ee.png)<br />

Select path to the script you want to add.  
Set new name for that script.  
Set description for that script.  
In "Script functionality and default values", depending on what functionality the script is using select wanted values and default selection.  
Those correspond to the game options like seen here.
<br />![alt text](http://i.imgur.com/RxiYhXa.png)<br />

Select Game path to the root of the game.  
Press "Add to the game".  
  
In game you will see your new custom script.
<br />![alt text](http://i.imgur.com/lOwFu51.png)<br />


> **Use:**  

1. Unpack archive using 7zip ([http://www.7-zip.org/](http://www.7-zip.org/)).
2. Run Civ6_Map_Utility.exe.
3. For Map Sizes - Modify default game settings or create your own settings for map sizes.
4. For Map Scripts - Select map script to be added. Select functionality this script supports.
5. Click "Browse" button to select root/main directory of "Sid Meiers Civilization VI" game. - In case of steam it usually is: "C:\Program Files\Steam (x86)\SteamApps\Common\Sid Meiers Civilization VI"
6. Once happy with settings for new map size press "Add to Game" button.
7. Load Sid Meiers Civilization VI game and enjoy new functionality.
  
> **Removal map sizes:**  
To completely remove all custom map sizes:  
Go to "Sid Meiers Civilization VI" directory and remove following directories.  
"/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Sizes/"  
"/Base/Assets/Gameplay/Data/Civ6_Map_Utility/Map_Sizes/"  
  
To remove single map size go to the same directories and remove files:  

- MAP_SIZE_NAME_MapSizes.xml
- MAP_SIZE_NAME_Maps.xml
  
**Removal map scripts:**  
To completely remove all custom map scripts:  
Go to "Sid Meiers Civilization VI" directory and remove following directory.  
"/Base/Assets/Configuration/Data/Civ6_Map_Utility/Map_Scripts/"  
  
To remove single map script go to the same directory and remove files:  

- SCRIPT_NAME.lua,
- SCRIPT_NAME_MapSettings.xml  

- SCRIPT_NAME_StandardMaps.xml
**Troubleshooting:  
**  
> **Settings Problems:**  
Minimum, Maximum and Default values are described within TOOLTIPS- they can be read by hovering mouse over text.  
Experimental settings need to be tested by community and can be enhanced with use of other mods.  
If your game crashes, try different settings. I am unable to test all of them.  
  
I ask you guys to help figure out what works and what does not.  
  
Example:  
1. My game crashes to desktop for maps that are 170x170, however this might not be the case for everyone. Map size of 165 x 170 loaded for me just fine so it might be memory allocation limit or something else. (It does take long time to load on bigger maps - Recommend to disable barbarians on big maps.)  
  
2. Map sizes are not the same as map scripts - map scripts determine spawning of the world and as such, there is no guarantee that the map size selected will work well with your script map and player number.  
You might load the game and see no players or starting position as game was unable to find a suitable place for you to spawn. Reloading the map/script usually works, however this again I cannot predict.  
