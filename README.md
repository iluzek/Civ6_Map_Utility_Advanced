# Civ6_Map_Utility_Advanced
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
  
  
> **Support:**  
If you are able to provide additional information regarding values and ranges.  
If you have an idea how to improve the application - visually or functionally.  
Please share it with myself and other community members within Utility's Discussion page.  
  
> **Changelog from 2016-11-20:**  
1.Default settings for 'Huge' Map' have been set as 'default' values when loading the application.  
2.Minimum and maximum values set to facilitate more sensible map size creation.  
3.Minimum, Maximum and Default values are now limited by each other.  
4."Experimental settings" checkbox added to ignore sensible map settings.  
5."Reset Fields" button added to restore defaults from first load.  
6.Tooltips updated with more relevant information.  
7.Game path field set to read only to disable invalid path input.  
8.Miscellaneous Layout and Label Changes.  
9.Better Icon created and added to the executable file.  
  
> **Changelog 2 from 2016-11-20:**  
1.Rebuild the Civ6_Map_Utility.exe as for some reason previous version is getting flagged for malicious code. No real changes made, but this .exe seems to work fine.  
  
**Changelog from 2016-11-21:**  
1. Minor cosmetic layout changes to accommodate new functionality.  
2. Default game sizes were added in form of presets.  
3. Significant progress was made to the Map Scripts Section, however it stays hidden until fully functional.  
  
> **Changelog from 2016-11-22:**  
1. Map Scripts section added to facilitate easy installation of game scripts without modifying existing xml files.  
2. Confirm overwrite yes/no popup message when files already exist - implemented.
