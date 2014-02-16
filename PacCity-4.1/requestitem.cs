function serverCmdrequest(%client, %item)
{
	if(%item $= "baton")
	{
		if(%client.job $= "Cop")
		{
			%player = %client.player;
			%player.updateArm(PacCityBatonImage);
			%player.mountImage(PacCityBatonimage, 0);
		}
		else if(%client.job $= "Mayor")
		{
			%player = %client.player;
			%player.updateArm(PacCityBatonImage);
			%player.mountImage(PacCityBatonImage, 0);
		}
		else if(%client.job $= "Admin")
		{
			%player = %client.player;
			%player.updateArm(PacCityBatonImage);
			%player.mountImage(PacCityBatonImage, 0);
		}
		else
		{
			messageClient(%client,'','\c4Your are not a person of authority to use a baton.');
		}
	}
	else if(%item $= "gun") //ModernPistolImage     Force required addon : Weapon_Skins_Pistol Weapon_Skins_Smg 
	{
		if(%client.job $= "Cop")
		{
			%player = %client.player;
			%player.updateArm(ModernPistolImage);
			%player.mountImage(ModernPistolImage, 0);
		}
		else if(%client.job $= "Criminal")
		{
			%player = %client.player;
			%player.updateArm(ModernPistolImage);
			%player.mountImage(ModernPistolImage, 0);
		}
		else if(%client.job $= "CriminalLeader")
		{
			%player = %client.player;
			%player.updateArm(unSilencedSMGImage);
			%player.mountImage(unSilencedSMGImage, 0);
		}
		else if(%client.job $= "Mayor")
		{
			%player = %client.player;
			%player.updateArm(unSilencedSMGImage);
			%player.mountImage(unSilencedSMGImage, 0);
		}
		else if(%client.job $= "Admin")
		{
			%player = %client.player;
			%player.updateArm(unSilencedSMGImage);
			%player.mountImage(unSilencedSMGImage, 0);
		}
		else
		{
			messageClient(%client,'','\c4Your job does not let you use a gun.');
		}
		
	}
}