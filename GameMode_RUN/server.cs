//-----------------------------------------------
//                   RUN
//          That game where you run fast
//  by Pacnet2013 with content from Redoctober2009
//  One function made by Headcrab Zombie
//-----------------------------------------------

//-----------------------------------------------
//EXECUTE Redoctober2009's Speed Playertypes!
//------------------------------------------------
exec("./playertypes/Player_SpeedsCrouchOnly.cs");
exec("./playertypes/Player_SpeedsCrouchRacer.cs");
exec("./playertypes/Player_SpeedsFast.cs");
exec("./playertypes/Player_SpeedsNoMove.cs");
exec("./playertypes/Player_SpeedsRunOnly.cs");
exec("./playertypes/Player_SpeedsSlow.cs");
exec("./playertypes/Player_SpeedsStandard.cs");
exec("./playertypes/Player_SpeedsSuperFast.cs");
//------------------------------------------------

//-------------------------------------------------
//            LOAD GAMEMODE SCRIPTS
//-------------------------------------------------
package runGamemode
{
	function ShapeBase::isMovingForward(%this)
	{
		%movingVector = %this.getVelocity(); //The direction we're moving
		%movingX = getWord(%movingVector,0);
		%movingY = getWord(%movingVector,1);
		
		if(!%movingX && !%movingY) //We're not moving at all
			return 0;
			
		%forwardVector = %this.getForwardVector(); //The direction we're facing
		%forwardX = getWord(%forwardVector,0);
		%forwardY = getWord(%forwardVector,1);
	
		%q1 = %movingX/%forwardX;
		%q2 = %movingY/%forwardY;
		
		if(mAbs(%q1-%q2) <= 0.01) //If %q1 and %q2 are within 0.01 of each other, to compensate for rounding
			return 1;
		else
			return 0;
	
	}
	
	function scoreupdater(%client) //it's inneficient on purpose
	{
		if(%client.player.isMovingForward())
		{
			%client.totalscore = %client.totalscore + 5;
			commandToClient(%client, 'bottomPrint', "<color:FFFFFF>Score : " @ %client.totalscore @ " | Level : " @ %client.currentlevel @ "!");
		}
		schedule(2000, 0, "scoreupdater", %client);
	}
	
	function GameConnection::OnClientEnterGame(%client)
	{
		parent::OnClientEnterGame(%client);
		%client.totalscore = 0;
		%client.currentLevel = 1;
		scoreupdater(%client);
		messageclient(%client,'',"<color:00ff00>-The RUN Gamemode has now started your score counter");
		messageclient(%client,'',"<color:ffffff>-The score counter will be shown at the bottom of your screen");
	}
	
	function GameConnection::nextLevel(%client)
	{
 		%client.currentLevel++;
		commandToClient(%client, 'centerPrint', "<color:00ff00><font:impact:30>You have reached level " @ %client.currentLevel @ "!");
	}
	registerOutputEvent(GameConnection, "nextLevel");
};
activatePackage(runGamemode);
//------------------------------------------------------