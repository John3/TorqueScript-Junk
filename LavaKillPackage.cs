//Can be replaced using MiniGameSO::checkLastManStanding(%this)

if(!isObject(ServerClient))
{
	new AiConnection(ServerClient);
	ServerClient.isAdmin = 1;
	ServerClient.isSuperAdmin = 1;
}


package lavakill
{
   function GameConnection::OnDeath(%client, %killerPlayer, %killer, %damageType, %damageLoc)
   {
      parent::OnDeath(%client, %killerPlayer, %killer, %damageType, %damageLoc);
      if(isObject(%client.minigame))
      {
         %peopleAlive = 0;
         for(%i=0;%i<%client.minigame.numMembers;%i++)
         {
            %miniPlayer = %client.minigame.member[%i];
            if(isObject(%miniPlayer.player))
            {
	       %peopleAlive++;
            }
         }
         echo("There are " @ %peopleAlive @ " people alive.");
         if(%peopleAlive == 1)
         {
            if(isObject(WaterPlane))
	    {
		ServerCmdEnvGUI_SetVar(ServerClient, WaterHeight, 0);
            }
         }
      }
   }
};
activatePackage(lavaKill);
