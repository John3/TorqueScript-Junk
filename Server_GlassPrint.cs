//______________
//|GLASS MODS  |
//|Pacnet2012  |
//|__12/4/2012_|
//%client.trenchDirt
//%client.score
//%health = 100 - %client.player.getDamageLevel();
package pacnetglassmods
{
    function gameconnection::OnClientEnterGame(%this,%obj,%a,%b,%c,%d,%e)
    {
		loopallstats();
		%fw = new FileObject();
		%fw.openForRead("config/server/scores/" @ %client.bl_id @ ".txt");
		%client.score = %fw.readLine();
		%fw.close();
		%fw.delete();
		Parent::OnClientEnterGame(%this,%a,%b,%c,%d,%e);
	}
};
activatePackage(pacnetglassmods);

$TrenchWars::StatTicker = 2000;

if(isFile("Add-Ons/System_ReturnToBlockland/server.cs"))
{
    if(!$RTB::RTBR_ServerControl_Hook)
    {
        exec("Add-Ons/System_ReturnToBlockland/RTBR_ServerControl_Hook.cs");
    }
    RTB_registerPref("Stat Tick","GlassMod","TrenchWars::StatTicker","int 0 60","Gamemode_TrenchDigging","2000",0,0,0);
}


function loopallstatsticker()
{
    loopallstats();
    schedule($TrenchWars::StatTicker, 0, "loopallstatsticker");   
}

loopallstatsticker();

function loopallstats()
{
    %c = ClientGroup.getCount();
    for(%i=0;%i<%c;%i++) 
    {
        %client = ClientGroup.getObject(%i);
        %dirt = %client.trenchDirt;
        %score = %client.score;
        if(!%client.player.getDatablock().isInvincible)
        {
            %client.player.addHealth(1);
        }
        %health = 100 - %client.player.getDamageLevel();
        commandToClient(%client, 'bottomPrint', "<font:impact:22><color:FF0000>Health : <color:FFFFFF>" @ %health @ " / 100 <color:FFFF00> || <color:AC5900> Dirt : <color:FFFFFF>" @ %dirt @ "<color:FFFF00> || <color:00FF00> Score : <color:FFFFFF> " @ %score @ " !");
    }
}

//====================scoreSave
package glassmodssave
{
	function gameConnection::onClientLeaveGame(%client)
	{
		%fw = new FileObject();
		%fw.openForWrite("config/server/scores/" @ %client.bl_id @ ".txt");
		%fw.writeLine(%client.score);
		%fw.close();
		%fw.delete();
		Parent::onClientLeaveGame(%client);
	}
};
activatePackage(glassmodssave);