package pacCitySuicideHandler
{
	function serverCmdSuicide(%client)
	{
	    if(%client.jailed == 1)  
	    {
	        messageClient(%client, '', '\c4You cannot suicide in jail.');
	        return;
	    }
	    else
	    {
	        %client.instantRespawn();
	        if(%client.forceSleep == true)
	        {
		        %client.isAsleep = true;
		        %client.forceSleep = true;
		        %client.player.kill("suicide");
		        messageClient(%client, '', '\c4Resting.');
	        }
	    }
	}
};
activatePackage(pacCitySuicideHandler);
