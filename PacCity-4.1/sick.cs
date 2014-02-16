//$PacCity::Sick::Sickness1 = "Cold";
//$PacCity::Sick::Sickness2 = "Flu";
//$PacCity::Sick::Sickness3 = "Fever";
//$PacCity::Sick::Sickness4 = "Constipation";
//$PacCity::Sick::Sickness5 = "Diarrhea";
//$PacCity::Sick::Sickness6 = "Bladder Issues";
//$PacCity::Sick::Sickness7 = "Cancer";
//$PacCity::Sick::Sickness8 = "Healthy";
//$PacCity::Sick::Sickness9 = "Healthy";
function PacCity_AssignSickness(%client)
{
	%sickness = getRandom(1,9);
	if(%sickness == 1)
	{
		%client.illness = "Cold";
	}
	else if(%sickness == 2)
	{
		%client.illness = "Flu";
	}
	else if(%sickness == 3)
	{
		%client.illness = "Fever";
	}
	else if(%sickness == 4)
	{
		%client.illness = "Constipation"; //Yuck!
	}
	else if(%sickness == 5)
	{
		%client.illness = "Diarrhea"; //Nasty!
	}
	else if(%sickness == 6)
	{
		%client.illness = "Bladder Issues"; //Damn!
	}
	else if(%sickness == 7)
	{
		%client.illness = "Cancer";
		messageClient(%client, '', '\c4Sorry. You were diagnosed with cancer. You will die in 5 days.');
	}
	else if(%sickness == 8)
	{
		%client.illness = "Healthy";
	}
	else if(%sickness == 9)
	{
		%client.illness = "Healthy"; //Ahh....
	}
}
function PacCity_FadeSickness(%client)
{
	%sickness = "Healthy";
	messageClient(%client, '', '\c4You are now healthy.');
	if(%client.illness $= "Cancer")
	{
		%client.player.kill("suicide");
		%client.hand = 0;
		messageClient(%client, '', '\c4You died but of course you just get to respawn.');
	}
}
