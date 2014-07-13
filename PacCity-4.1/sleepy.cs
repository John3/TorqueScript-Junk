
function serverCmdgoToSleep(%client)
{
	%client.isAsleep = true;
	%client.player.kill("suicide");
	messageClient(%client, '', '\c4Resting.');
}
function PacCity_Rest(%client)
{
	if(%client.isAsleeep)
	{
		%client.sleepy = 100; //this is horrible
		messageClient(%client, '', '\c4Your fatigue level is at 100 percent.');
	}
	else
	{
		%client.sleepy = %client.sleepy - 5;
		if(%client.sleepy == 5)
		{
			messageClient(%client, '', '\c4Your fatigue level is five percent! You will automatically go to sleep in one more day if you do not type /goToSleep.');
		}
		else if(%client.sleepy == 0)
		{
			%client.isAsleep = true;
			%client.forceSleep = true;
			%client.player.kill("suicide");
			messageClient(%client, '', '\c4Resting.');
		}
	}
}
