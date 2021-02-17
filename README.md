# Assault-Teams-Onfoot-Cops-mod
Adds assault teams/onfoot cops that spawn during wanted levels, essentially making it look like an assault.

1-2 stars spawns a scripted police car (POLICE2) with 2 patrol officers (DISABLED FEATURE)

3-5 stars spawn variety of enemies like The FIB, NOOSE, Merryweather Black Ops Soldiers (with Combat MG)
each enemy carry different arsenals, from snipers to carbines.

Spawned Units will be removed by the game itself, so you wont get any piles of dead corpses everywhere.


Installation:
Drop WantedLevel.cs into Grand Theft Auto V > scripts folder, if you do not have "scripts" folder, install Scripthook and either run the game once or create the folder manually.
It also comes with script that disables DT_PoliceAutomobile and DT_SwatAutomobile when player is onfoot and enables it when in a vehicle pursuit, drop the contents of DisableDispatch folder in your scripts folder.


Not Compatible with RDE as RDE uses script based spawning which this mod cant disable it by ENABLE_DISPATCH_SERVICE native, however the WantedLevel.cs will work as its a seperate script for spawning the enemies (which the best way is, lower the amount of cops responding in RDE if you want to use this with RDE)
