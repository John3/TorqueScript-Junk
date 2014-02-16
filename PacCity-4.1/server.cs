messageAll('', '\c6Reloading PacCity 3.0 System : Gamemode_PacCity By Pacnet2011 - 2012');
messageAll('', '\c6By using PacCity you agree you will not claim credit for making this mod and that if anything goes wrong with your system or Blockland after using this, it is not my fault. If you do not agree, close the server and delete this mod from your folder. :c');
$PacCity::Path = "Add-Ons/Gamemode_PacCity/";
exec($PacCity::Path @ "arrestsystem.cs");
exec($PacCity::Path @ "cars.cs");
exec($PacCity::Path @ "crime.cs");
exec($PacCity::Path @ "food.cs");
exec($PacCity::Path @ "guns.cs");
exec($PacCity::Path @ "hasClient.cs");
exec($PacCity::Path @ "jobs.cs");
exec($PacCity::Path @ "jobs2.cs");
exec($PacCity::Path @ "jobs3.cs");
exec($PacCity::Path @ "land.cs");
exec($PacCity::Path @ "material.cs");
exec($PacCity::Path @ "minigameHandler.cs");
exec($PacCity::Path @ "noVehi.cs");
exec($PacCity::Path @ "OpenGui.cs");
exec($PacCity::Path @ "pay.cs");
exec($PacCity::Path @ "plugin.cs");
exec($PacCity::Path @ "prefs.cs");
exec($PacCity::Path @ "profiles.cs");
exec($PacCity::Path @ "requestItem.cs");
exec($PacCity::Path @ "save.cs");
exec($PacCity::Path @ "services.cs");
exec($PacCity::Path @ "sick.cs");
exec($PacCity::Path @ "sleepy.cs");
exec($PacCity::Path @ "suicideHandler.cs");
exec($PacCity::Path @ "time.cs");
exec($PacCity::Path @ "timecl.cs");
//Item
exec($PacCity::Path @ "item/baton/baton.cs");
exec($PacCity::Path @ "item/crowbar/crowbar.cs");
//Material Item
exec($PacCity::Path @ "material/axe.cs");
exec($PacCity::Path @ "material/pickaxe.cs");
//Terminal (PacCity 2.x)
exec($PacCity::Path @ "terminal/bank.cs");
exec($PacCity::Path @ "terminal/law.cs");
exec($PacCity::Path @ "terminal/material.cs");
exec($PacCity::Path @ "terminal/training.cs");

//---------RELOAD TO FIX UN-IDENTIFIED VARIABLES AND/OR FUNCTIONS---------\\
messageAll('', '\c6Reloading PacCity 3.0 System : Gamemode_PacCity By Pacnet2011 - 2012');
messageAll('', '\c6By using PacCity you agree you will not claim credit for making this mod and that if anything goes wrong with your system or Blockland after using this, it is not my fault. If you do not agree, close the server and delete this mod from your folder. :c');
$PacCity::Path = "Add-Ons/Gamemode_PacCity/";
exec($PacCity::Path @ "arrestsystem.cs");
exec($PacCity::Path @ "cars.cs");
exec($PacCity::Path @ "crime.cs");
exec($PacCity::Path @ "food.cs");
exec($PacCity::Path @ "guns.cs");
exec($PacCity::Path @ "hasClient.cs");
exec($PacCity::Path @ "jobs.cs");
exec($PacCity::Path @ "jobs2.cs");
exec($PacCity::Path @ "jobs3.cs");
exec($PacCity::Path @ "land.cs");
exec($PacCity::Path @ "material.cs");
exec($PacCity::Path @ "minigameHandler.cs");
exec($PacCity::Path @ "noVehi.cs");
exec($PacCity::Path @ "OpenGui.cs");
exec($PacCity::Path @ "pay.cs");
exec($PacCity::Path @ "plugin.cs");
exec($PacCity::Path @ "prefs.cs");
exec($PacCity::Path @ "profiles.cs");
exec($PacCity::Path @ "requestItem.cs");
exec($PacCity::Path @ "save.cs");
exec($PacCity::Path @ "services.cs");
exec($PacCity::Path @ "sick.cs");
exec($PacCity::Path @ "sleepy.cs");
exec($PacCity::Path @ "suicideHandler.cs");
exec($PacCity::Path @ "time.cs");
exec($PacCity::Path @ "timecl.cs");
//Item
exec($PacCity::Path @ "item/baton/baton.cs");
exec($PacCity::Path @ "item/crowbar/crowbar.cs");
//Material Item
exec($PacCity::Path @ "material/axe.cs");
exec($PacCity::Path @ "material/pickaxe.cs");
//Terminal (PacCity 2.x)
exec($PacCity::Path @ "terminal/bank.cs");
exec($PacCity::Path @ "terminal/law.cs");
exec($PacCity::Path @ "terminal/material.cs");
exec($PacCity::Path @ "terminal/training.cs");


/////////Manual LOAD//////////////////
function serverCmdreloadPacCity(%client)
{
    if(getnumkeyid() == %client.bl_id)
    {
        messageAll('', '\c6Reloading PacCity 3.0 System : Gamemode_PacCity By Pacnet2011 - 2012');
        messageAll('', '\c6By using PacCity you agree you will not claim credit for making this mod and that if anything goes wrong with your system or Blockland after using this, it is not my fault. If you do not agree, close the server and delete this mod from your folder. :c');
        $PacCity::Path = "Add-Ons/Gamemode_PacCity/";
        exec($PacCity::Path @ "arrestsystem.cs");
        exec($PacCity::Path @ "cars.cs");
        exec($PacCity::Path @ "crime.cs");
        exec($PacCity::Path @ "food.cs");
        exec($PacCity::Path @ "guns.cs");
        exec($PacCity::Path @ "hasClient.cs");
        exec($PacCity::Path @ "jobs.cs");
        exec($PacCity::Path @ "jobs2.cs");
        exec($PacCity::Path @ "jobs3.cs");
        exec($PacCity::Path @ "land.cs");
        exec($PacCity::Path @ "material.cs");
        exec($PacCity::Path @ "minigameHandler.cs");
        exec($PacCity::Path @ "noVehi.cs");
        exec($PacCity::Path @ "OpenGui.cs");
        exec($PacCity::Path @ "pay.cs");
        exec($PacCity::Path @ "plugin.cs");
        exec($PacCity::Path @ "prefs.cs");
        exec($PacCity::Path @ "profiles.cs");
        exec($PacCity::Path @ "requestItem.cs");
        exec($PacCity::Path @ "save.cs");
        exec($PacCity::Path @ "services.cs");
        exec($PacCity::Path @ "sick.cs");
        exec($PacCity::Path @ "sleepy.cs");
        exec($PacCity::Path @ "suicideHandler.cs");
        exec($PacCity::Path @ "time.cs");
        exec($PacCity::Path @ "timecl.cs");
        //Item
        exec($PacCity::Path @ "item/baton/baton.cs");
        exec($PacCity::Path @ "item/crowbar/crowbar.cs");
        //Material Item
        exec($PacCity::Path @ "material/axe.cs");
        exec($PacCity::Path @ "material/pickaxe.cs");
        //Terminal (PacCity 2.x)
        exec($PacCity::Path @ "terminal/bank.cs");
        exec($PacCity::Path @ "terminal/law.cs");
        exec($PacCity::Path @ "terminal/material.cs");
        exec($PacCity::Path @ "terminal/training.cs");
    }
}

