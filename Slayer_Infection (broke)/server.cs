// +-------------------------------------------+
// |  ___   _     _____   __  __  ____   ____  |
// | | __| | |   | /_\ |  \ \/ / | ___| | /\ | |
// | |__ | | |_  |  _  |   \  /  | __|  | \/ / |
// | |___| |___| |_| |_|   |__|  |____| |_| \\ |
// |  Pacnet2012            Blockland ID 22696 |
// +-----------------------------+-------------+
// | DO NOT EDIT BELOW THIS LINE |
// +-----------------------------+

%error = forceRequiredAddon("Gamemode_Slayer");
if(%error == $Error::Addon_NotFound)
	error("ERROR: Server_Slayer_Infection - Required add-on Gamemode_Slayer not found!");
else
	exec("./IF.cs");