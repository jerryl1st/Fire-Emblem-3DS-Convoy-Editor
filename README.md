# Fire Emblem 3DS Convoy Editor
A simple convoy editor for Fire Emblem Awakening and Fire Emblem Fates' save files.

# Requirements
* [.NET Framework 4](http://www.microsoft.com/en-US/download/details.aspx?id=17718)
* A way to extract a decrypted save file, like [homebrew](http://smealum.github.io/3ds/)
or custom firmware (CFW).

# Notes before using
* **ALWAYS BACKUP YOUR SAVE!!!**. I'm not responsible if you lost your save during editing
process.
* By using this software, you also have to accept the risk of being shadowbanned (by over
forging your weapons and use enemy-only / unreleased items). As long as your items is legal
(which means they can be obtained in legal ways), you should be fine.
* Some DLC items will not work if you don't have certain DLC installed. List of DLC items:
*Pebble*, *Hero's Brand*, *Exalt's Brand*, *Fell Brand*, *First Blood*, *Vanguard Brand*,
*Heavy Blade*, *Veteran Intuition*, *Aether*, *Warp*.
* You can edit any weapon's forge level in *Uses* column (Fire Emblem Fates only).
* There's **no need** to recompress your save file after editing.
* If you've found any bugs, just open the issue [here](https://github.com/RainThunder/Fire-Emblem-Fates-Convoy-Editor/issues). Pull requests are welcome!

# Download
https://github.com/RainThunder/Fire-Emblem-Fates-Convoy-Editor/releases

# How to use
For 3DS :
* Extract your save file using your favorite 3DS save tool.
* Copy that save from your 3DS to your PC.
* Run this software.
* Click **Load**, then choose a "Chapter*" file from the extracted save.
* Edit the items.
* Click **Save** button after editing. Your save file will be **automatically compressed**.
* Copy the compressed save to your 3DS.
* Import your save back into the game.

For Citra Emulator:
* Run this software
* Click **Load**, then choose a "Chapter*" file from citra's save location (Usually in %appdata%/Citra/sdmc/Nintendo 3DS)
* Edit the items.
* Click **Save** button after editing.

# Screenshots
![Main](https://i.imgur.com/NFkvlBy.png)

# License
* [Huffman](http://www.romhacking.net/utilities/826/) by CUE is licensed under GPL v3.
* Both [FEAST](https://github.com/SciresM/FEAST) (had some of the source code that this
software borrowed from) and Fire Emblem 3DS Convoy Editor are licensed under GPL v2.

# Credits
* [SciresM](https://github.com/SciresM) and CUE for [Fire Emblem Awakening Save Tool](https://github.com/SciresM/FEAST).
