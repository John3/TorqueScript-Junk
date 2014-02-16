//PacCity 6
//Packages that don't overwrite stuff
//jumbopackagealert0x00053

package PacCity_Jumbo
{
    function GameConnection::onClientEnterGame(%this)
    {
	    if(isFile($pacdp @ %this.bl_id))
        {
            %this.centerPrint("<color:00ff00><font:impact:30>Welcome back, " @ %this.name @ "!", 2);
            PacCity_LoadData(%this);
        }
        else
        {
            %this.centerPrint("<color:00ff00><font:impact:30>Welcome to PacCity 6.", 3);
            echo("PacCity CREATE " %this.bl_id);
            %this.energy = 10;
            %this.handmoney = 0;
            %this.bankmoney = $PacCity_Pref_StartingMoney; //also known as the gerber life grow up plan after college payment
            %this.demerits = 0;
            %this.tax = 0;
            %this.nextSalary = 0;
            %this.age = 18; //this variable has no purpose right now, but I might do something with it later i guess
            %this.foodSellPermit = false;
            %this.gunSellPermit = false;
            %this.drivePermit = false;
            %this.gunUsePermit = false;
            %this.medicalPermit = false;
            %this.skillMine = 0;
            %this.skillLumber = 0;
            %this.skillPolicing = 0;
            %this.skillManufacturing = 0;
            %this.skillPolitics = 0;
            %this.skillComputer = 0;
            %this.criminalRecord = false; 
            %this.inJail = false;
            %this.debt = 0;
            %this.jailTime = 0;
            %this.inHospital = 0;
            %this.hospitalTime = 0;
            
        }
        if(isObject(PacCityMini))
        {
            PacCityMini.addMember(%this);
        }  
        else
        {
            PacCity_BuildMinigame();
        }
        if(!$PacCitySchedule)
        {
            PacCity_NewDay();
        }
        if(%this.demerits >= 100)
        {
            %client.jailable = true;
        }
	    return parent::onClientEnterGame(%this);
    }

	function GameConnection::autoAdminCheck(%this)
	{
	    schedule(5000, 0, "PacCity_ClientCheck", %this);
		return parent::autoAdminCheck(%this);
	}

    function PacCity_ClientCheck(%client) //too lazy to put this function in a seperate file anyway
    {
        if(!%client.hasPacCity && $PacCity_Pref_RequireClient)
        {
            %client.delete("You need the PacCity Client to play on this server."); //come on please don't bypass this okay? don't complain that you have no idea how to play afterwards
        }
    }

    function GameConnection::onClientLeaveGame(%this)
    {
	    PacCity_SaveData(%this); //because they'll come back later and say I LOST MY DATA HGFDG
	    parent::onClientLeaveGame(%this,%name,%a,%b,%c,%d,%e);
    }

};
activatePackage(PacCity_Jumbo);