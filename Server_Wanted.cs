//----------------------------------------
// Server - Furdle Script
//
// Revision: Private Rev-1
//
// Created by TomTom BL_ID:3694
//----------------------------------------
//Pacnet2012 Revision Notes :
//Level 1 = 15 Coins
//Level 2 = 25 Coins
//Level 3 = 40 Coins
//Level 4 = 55 Coins
//Level 5 = 80 Coins
//Level 6 = 100 Coins +

if(isfile("config/Server/WantedPrefs.cs"))
{
	exec("config/Server/WantedPrefs.cs");
}
else
{
	//if not make one
	new scriptobject(WantedMod);
	WantedMod.Save("config/Server/WantedPrefs.cs");
}

//Check if blockland wants to be retarded and fuck up the saving

if(!isobject(WantedMod))
{
	new scriptobject(WantedMod);
	WantedMod.Save("config/Server/WantedPrefs.cs");
}

//Int packages
	
package wantedMod
{
	//%sourceClient.Killstreak++; 
	function GameConnection::onDeath(%this, %sourceObject, %sourceClient, %damageType, %damLoc)
	{
		Parent::onDeath(%this, %sourceObject, %sourceClient, %damageType, %damLoc);
		if(%this $= %sourceClient)
		{
			return;
		}		
		%OPWantLevel = WantedMod.WantedLevel[%this.BL_ID];
		if(%OPWantLevel > 0)
		{	
			%cl = %sourceClient; //Cuz ime lazy
			WantedMod.WantedLevel[%this.BL_ID] =0;
			%coins = (%OPWantLevel) *10;
			%cl.Chatmessage("\c6You got " @ %coins @ " coins for killing " @ %this.name);
			announce("\c3" @%cl.name @ "\c6 claimed the bounty on \c0" @ %this.name @ "\c6!");
			announce("Calling " @ %coins);
			%cl.player.VCE_modVariable(Money, 1, %coins, %cl);
            //Level :
            %total = %cl.brickgroup.vargroup.getVariable("Player","Money",%client);
            if(%total > 0)
            {
                //Level 1 = 15 Coins
                //Level 2 = 25 Coins
                //Level 3 = 40 Coins
                //Level 4 = 55 Coins
                //Level 5 = 80 Coins
                //Level 6 = 100 Coins +
                if(%total >= 15)
                {
                    %cl.levels = 1;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 1.");
                }
                if(%total >= 25)
                {
                    %cl.levels = 2;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 2.");
                }
                if(%total >= 40)
                {
                    %cl.levels = 3;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 3.");
                }
                if(%total >= 55)
                {
                    %cl.levels = 4;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 4.");
                }
                if(%total >= 80)
                {
                    %cl.levels = 5;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 5.");
                }
                if(%total >= 100)
                {
                    %cl.levels = 6;
                    %cl.updateLevel();
                    %cl.chatmessage("\c6You're now Level 6. You have reached the highest level currently possible.");
                }
            }
                
		}
		else
		{
			WantedMod.WantedLevel[%sourceClient.BL_ID]++;
			%Level = WantedMod.WantedLevel[%sourceClient.BL_ID];
			if(%level == 1)
			{
				announce("\c3" @%sourceClient.name @ "\c6 is now \c0Wanted!");
			}
			%sourceClient.player.setShapeNameColor("1 0 0");
		}
		WantedMod.Save("config/Server/WantedPrefs.cs");
	}
    
    function GameConnection::updateLevel(%client)
    {
        %level = %client.levels;
	    commandToClient(%client, 'bottomPrint', "<color:FFFFFF>You are currently Level " @ %level @ " !");
    }    

	function serverCmdMessageSent(%client,%msg)
	{
		%oldPrefix = %client.clanPrefix;
		if(%client.levels > 0)
		{
			%client.clanPrefix = "\c6[" @ %client.levels @ "]" @ %oldPrefix;
		}
		Parent::serverCmdMessageSent(%client,%msg);
		%client.clanPrefix = %oldPrefix;
	}
    //PACNET2012 : Saving / LOADING system
    function GameConnection::OnClientLeaveGame(%this,%obj,%a,%b,%c,%d,%e)
	{
        %SD = new FileObject();
        %SD.openforwrite("config/server/WantedUser/" @ %this.bl_id @ ".txt");
        %total = %cl.brickgroup.vargroup.getVariable("Player","Money",%this);
        %SD.writeLine(%this.bl_id, %this.levels, %total);
        %SD.close();
        %SD.delete();
		Parent::OnClientLeaveGame(%this,%a,%b,%c,%d,%e);
	}
    function GameConnection::OnClientEnterGame(%this,%obj,%a,%b,%c,%d,%e)
	{
        if(isFile("config/server/WantedUser/" @ %this.bl_id @ ".txt")
        {
            %SD = new FileObject();
            %SD.openforread("config/server/WantedUser/" @ %this.bl_id @ ".txt");
            %line = %SD.readLine();
            if(getWord(%line, 0) $= %this.bl_id)
            {
                %this.levels = getWord(%line, 1);
                %coins = getWord(%line, 2);
                %this.player.VCE_modVariable(Money, 1, %coins, %this);
            }
        }
        %SD.close();
        %SD.delete();
		Parent::OnClientEnterGame(%this,%a,%b,%c,%d,%e);
	}
	function GameConnection::SpawnPlayer(%client)
	{
		parent::SpawnPlayer(%client);
		%player = %client.player;
		if(WantedMod.WantedLevel[%client.BL_ID] >0)
		{
			%player.setShapeNameColor("1 0 0");
		}
		else
		{
			%player.setShapeNameColor("0 1 0");
		}
	}
};
activatepackage(wantedMod);

//End packages

//Int commands

function servercmdWanted(%cl)
{
	%obj = %cl.player;
	if(!isobject(%obj))
		return;
	
	initContainerRadiusSearch(%obj.getPosition(),60, $TypeMasks::PlayerObjectType);
	while(isObject(%searchObj = containerSearchNext()))
	{
		if(%searchObj != %obj)
		{
			%level = WantedMod.WantedLevel[%searchObj.client.BL_ID];
			if(%level > 0)
			{
 	 			%WantedList = %WantedList @ "\c0 | \c6" @ %searchObj.client.name @ " \c4Bounty: \c5" @ %Level @ "\c0 | ";
 	 		}
 	 	}
	}
	if(%WantedList !$= "")
	{
		%cl.chatmessage("\c6The following wanted are nearby");
		%cl.chatmessage("\c2-------------------------------");
		%cl.chatmessage("\c3" @ %WantedList);
		%cl.chatmessage("\c2-------------------------------");
	}
	else
	{
		%cl.chatmessage("\c6Nobody nearby is wanted!");
	}
}
//end commands
			