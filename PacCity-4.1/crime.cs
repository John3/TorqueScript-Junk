package pacCityCrime
{
    function gameConnection::onDeath(%client, %killerPlayer, %killer, %damageType, %unknownA)
    {
        if(%killer != %client)
	    {
            if($PacCity::Pref::Crime == 1)
            {
			    commandToClient(%killer, 'centerPrint', "\c4You Murderer! You now got another 2 hits!", 1);
			    %killer.hits = %killer.hits + 2;
            }
	    }
	    parent::onDeath(%client, %player, %killer, %damageType, %unknownA);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////SP0
	function player::damage(%this, %obj, %pos, %damage, %damageType)
	{
        %hitter = %obj.client;
        %victim = %this.client;
        if(%hitter != %victim)
		{
            if($PacCity::Pref::Crime == 1)
			{
				commandToClient(%hitter, 'centerPrint', "\c4You hurt someone! You now got 1 more hit!", 1);
                %hitter.hits = %hitter.hits + 1;
            }

        }
		parent::damage(%this, %obj, %pos, %damage, %damageType);
	}
};
activatePackage(pacCityCrime);
	