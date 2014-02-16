function serverCmdPlugin(%client, %plugin)
{
    talk("If nothing happens, you misspelled something. /plugin [plugin file name]");
    echo("Load PacCity Plugin : " @ %plugin @ ".");
    exec("Add-Ons/Gamemode_PacCity/plugin/" @ %plugin @ ".cs");
}