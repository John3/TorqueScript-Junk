// +-------------------------------------------+
// |  ___   _     _____   __  __  ____   ____  |
// | | __| | |   | /_\ |  \ \/ / | ___| | /\ | |
// | |__ | | |_  |  _  |   \  /  | __|  | \/ / |
// | |___| |___| |_| |_|   |__|  |____| |_| \\ |
// |  Pacnet2012            Blockland ID 22696 |
// +-----------------------------+-------------+
// | DO NOT EDIT BELOW THIS LINE |
// +-----------------------------+
$Slayer::IF::Version = 1.0;
//Slayer Gamemode system stuff

if(!$Slayer::Server::Dependencies::Gamemodes)
	exec("Add-ons/Gamemode_Slayer/Dependencies/Gamemodes.cs");
Slayer.Gamemodes.addMode("Infection","IF",1,1);

//Slayer preference system stuff
if(!$Slayer::Server::Dependencies::Preferences)
	exec("Add-ons/Gamemode_Slayer/Dependencies/Preferences.cs");
Slayer.Prefs.addPref("IF","Start Timer","$Slayer::IF::Timer", "Rules IF Timer");

//the stuff starts here.

function Slayer_IF_onModeStart(%mini)
{
	Slayer_IF_setUpMini(%mini);
    messageAll('','\c6<font:impact:30>Slayer - "Infection" v%1 Running.', $Slayer::IF::Version);
}


function Slayer_IF_setUpMini(%mini)
{
	%oneTeam = %mini.Teams.getTeamFromName(%mini.OMA_bossName);
	if(!isObject(%oneTeam))
	{
		%oneTeam = %mini.Teams.addTeam();

		%oneTeam.setPref("Team","Name", "Team 1");
		%oneTeam.setPref("Team","AutoSort",1);
		%oneTeam.setPref("Team","Color",0);
		%oneTeam.setPref("Team","Max Players",-1);
		%oneTeam.setPref("Team","Uniform",2);
		for(%i=0; %i < 5; %i++)
			%oneTeam.setPref("Team","Start Equip" SPC %i,%mini.startEquip[%i]);
		%twoTeam.setPref("Team","Playertype",%mini.playerDatablock);
	}

	if(isObject(%twoTeam))
	{
		%twoTeam = %mini.Teams.addTeam();

		%twoTeam.setPref("Team","Name","Team 2");
		%twoTeam.setPref("Team","Color",1);
		%twoTeam.setPref("Team","Max Players",-1);
		%twoTeam.setPref("Team","Uniform",2);
		for(%i=0; %i < 5; %i++)
			%twoTeam.setPref("Team","Start Equip" SPC %i,%mini.startEquip[%i]);
		%twoTeam.setPref("Team","Playertype",%mini.playerDatablock);
	}
	Slayer.Prefs.setPref("Teams","Lock Teams",0,%mini);
}

function Slayer_IF_postDeath(%mini,%client,%obj,%killer,%type,%area)
{
	%clTeam = %client.getTeam();
	%killlerTeam = %killer.getTeam();
	%clTeam.joinTeam(%killerTeam.name);
	messageAll('', '\c6<font:impact:30>%1 was moved to team %2 by %3', %client.name, %killerTeam.name, %killer.name);
	messageClient(%client, '', '\c6<font:impact:30>You have been placed in team ' @ %killerTeam.name @ '!' );
}

