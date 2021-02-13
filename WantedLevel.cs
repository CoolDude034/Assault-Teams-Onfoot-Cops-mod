using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;

namespace CustomWantedLevel
{
    public class WantedLevel : Script
    {
        int interval = 2500; // 2.5 seconds, you can increase or decrease it, just remember lower value = intense amount of cops which might affect performance
        int spawnrange = 30; // Assault Team spawn distance, by default its 30 to make them spawn close as possible, but feel free to increase
        int assaultUnits;
        public static Random rnd = new Random();
        public WantedLevel()
        {
            Tick += update;
            Interval = interval;
        }

        void update(object sender, EventArgs e)
        {

            if (Game.Player.Character.IsOnFoot == true)
            {
                if (Game.Player.WantedLevel == 1 || Game.Player.WantedLevel == 2)
                {
                    //CreatePoliceVehicle(); // spawn first responders, disabled as it spawns a shit ton of cop cars with the current interval 2.5 seconds
                }
                else if (Game.Player.WantedLevel >= 3)
                {
                    assaultUnits = rnd.Next(0, 50); // case 0 to 50, if adding a case, make sure to add its number in here
                    switch (assaultUnits)
                    {
                        case 0:
                            SpawnAssaultTeam(); // You can add or remove these, and or replace them with some another unit type!
                            break;
                        case 10:
                            SpawnHeavyUnits();
                            break;
                        case 20:
                            SpawnAggressiveSquad();
                            break;
                        case 30: // Spawn FIB Units and some noose (who will take cover mostly)
                            SpawnFBIHrt();
                            SpawnSnipers();
                            break;
                        case 40:
                            JuggernautAssaultShotgun();
                            break;
                        case 50:
                            JuggernautCombatMG();
                            break;
                    }
                }   
            }   
        }
        // Below here can be customized, from model to weapon. If you know what you're doing, you can add new functions and add them to the spawn group.
        void CreatePoliceVehicle()
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Police2, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * 100));
            Ped cop1 = World.CreatePed(PedHash.Cop01SMY, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.Cop01SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.MarkAsNoLongerNeeded();
            cop1.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop2.Task.Wait(1000);
        }

        void SpawnAssaultTeam() // Squad with carbines and SMGs
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop3 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop4 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            cop3.SetIntoVehicle(policeCar, VehicleSeat.LeftRear);
            cop4.SetIntoVehicle(policeCar, VehicleSeat.RightRear);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            cop3.Weapons.Give(WeaponHash.SMG, 9999, true, true);
            cop4.Weapons.Give(WeaponHash.SMG, 9999, true, true);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop3.Task.FightAgainst(Game.Player.Character);
            cop4.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop3.MarkAsNoLongerNeeded();
            cop4.MarkAsNoLongerNeeded();
        }


        void SpawnHeavyUnits() // heavier units with Pump Shotguns, Carbines and Special Carbines
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop3 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop4 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            cop3.SetIntoVehicle(policeCar, VehicleSeat.LeftRear);
            cop4.SetIntoVehicle(policeCar, VehicleSeat.RightRear);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            cop3.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
            cop4.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
            cop1.Armor = 300;
            cop2.Armor = 300;
            cop3.Armor = 300;
            cop4.Armor = 300;
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop3.Task.FightAgainst(Game.Player.Character);
            cop4.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop3.MarkAsNoLongerNeeded();
            cop4.MarkAsNoLongerNeeded();
        }

        void SpawnAggressiveSquad() // regular squad with shotguns and carbines, with more aggressive behavior
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop3 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop4 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            cop3.SetIntoVehicle(policeCar, VehicleSeat.LeftRear);
            cop4.SetIntoVehicle(policeCar, VehicleSeat.RightRear);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
            cop3.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            cop4.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop1, 3); // supposed to give them suicidal offensive or smth, idk i never noticed anything :P
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop2, 3);
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop3, 3);
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop4, 3);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop3.Task.FightAgainst(Game.Player.Character);
            cop4.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop3.MarkAsNoLongerNeeded();
            cop4.MarkAsNoLongerNeeded();
        }

        void SpawnFBIHrt() // FBI Team with SMGs, Carbines and Pistols
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.FBI2, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.FibSec01SMM, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.FibSec01SMM, policeCar.Position);
            Ped cop3 = World.CreatePed(PedHash.FibSec01SMM, policeCar.Position);
            Ped cop4 = World.CreatePed(PedHash.FibSec01SMM, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            cop3.SetIntoVehicle(policeCar, VehicleSeat.LeftRear);
            cop4.SetIntoVehicle(policeCar, VehicleSeat.RightRear);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.SMG, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.SMG, 9999, true, true);
            cop3.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            cop4.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop3.Task.FightAgainst(Game.Player.Character);
            cop4.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop3.MarkAsNoLongerNeeded();
            cop4.MarkAsNoLongerNeeded();
        }

        void JuggernautCombatMG() // Juggernaut Unit for as a special unit, spawns 1 only unit, this one carries a Combat MG
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Blackops02SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.CombatMG, 9999, true, true);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop1.Armor = 4000;
            cop1.Health = 2000;
            cop1.SetConfigFlag(281, true); // no writhing
            cop1.SetConfigFlag(314, true); // player cant melee, but npc may melee
            Function.Call(Hash.SET_PED_AS_COP, cop1, true);
            cop1.MarkAsNoLongerNeeded();
        }

        void JuggernautAssaultShotgun() // Juggernaut Unit with Assault Shotgun
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Blackops02SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.AssaultShotgun, 9999, true, true);
            cop1.Task.FightAgainst(Game.Player.Character);
            cop1.Armor = 4000;
            cop1.Health = 2000;
            cop1.SetConfigFlag(281, true); // no writhing
            cop1.SetConfigFlag(314, true); // player cant melee, but npc may melee
            Function.Call(Hash.SET_PED_AS_COP, cop1, true);
            cop1.MarkAsNoLongerNeeded();
        }

        void SpawnSnipers() // sniper teams
        {
            Vehicle policeCar = World.CreateVehicle(VehicleHash.Riot, Game.Player.Character.Position + (Game.Player.Character.ForwardVector * spawnrange));
            Ped cop1 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop2 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop3 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            Ped cop4 = World.CreatePed(PedHash.Swat01SMY, policeCar.Position);
            cop1.SetIntoVehicle(policeCar, VehicleSeat.Driver);
            cop2.SetIntoVehicle(policeCar, VehicleSeat.Passenger);
            cop3.SetIntoVehicle(policeCar, VehicleSeat.LeftRear);
            cop4.SetIntoVehicle(policeCar, VehicleSeat.RightRear);
            policeCar.PlaceOnGround();
            policeCar.PlaceOnNextStreet();
            policeCar.Delete(); // delete the police car, so we have the units onfoot
            cop1.Weapons.Give(WeaponHash.SniperRifle, 9999, true, true);
            cop2.Weapons.Give(WeaponHash.SniperRifle, 9999, true, true);
            cop3.Weapons.Give(WeaponHash.SniperRifle, 9999, true, true);
            cop4.Weapons.Give(WeaponHash.HeavySniper, 9999, true, true); // cop4 uses Heavy Sniper to add a bit variety
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop1, 1); // squad uses Defensive Combat Movement
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop2, 1);
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop3, 1);
            Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, cop4, 0); // cop4 uses stationary movement instead
            cop1.Task.FightAgainst(Game.Player.Character);
            cop2.Task.FightAgainst(Game.Player.Character);
            cop3.Task.FightAgainst(Game.Player.Character);
            cop4.Task.FightAgainst(Game.Player.Character);
            cop1.MarkAsNoLongerNeeded();
            cop2.MarkAsNoLongerNeeded();
            cop3.MarkAsNoLongerNeeded();
            cop4.MarkAsNoLongerNeeded();
        }
    }
}
