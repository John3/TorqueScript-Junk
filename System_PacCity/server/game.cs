//PacCity 6
//Game.cs ...? 
//Spawns        Minigame                Blah
//
//OH AND YEAH HEY YOU
//REMEMBER TO EXEC ALL THESE FUNCTIONS IF NEEDED AFTER YOU DECLARE EACH ONE OR YOU'RE SCREWED
//HELLO?

//WINDOWS REALLY GOOD EDITION (Windows RGE) is now available! Go to rge.windows.com to download it for free!
//
//Requirements
//
//-You must be running Windows 8 or Windows 8.1 in order to install Windows Really Good Edition
//
//-------------------------------------------------------------------------------------------------------------
//
//WINDOWS PHONE HATE (Windows Phone H.1) is now available! Go to os9.windowsphone.com to download it for free!
//
//Requirements
//
//-You must be running Windows Phone 8
//
//--------------------------------------------------------------------------------------------------------------
$PacCitySchedule = false;

if(!isFile("config/server/PacCity/prefs.cs"))
{
    exec("./prefs");
}

else
{
    exec("config/server/PacCity/prefs.cs"); //custom prefs and saved data that i crammed in there anyway
}


function PacCity_EraseCoolDown(%client, %type)
{
    switch$(%type)
    {
        case "saveData":
            %client.saveDataCooldown = "N";
    }
}

function PacCity_BuildMinigame()  // this is partially ripped off from iban's code ..........
{
	echo("PacCity CREATE Minigame");
	for(%j = 0; %j < ClientGroup.getCount(); %j++)
	{
		%c = ClientGroup.getObject(%j);
		%c.minigame = NULL;
	}

	if(isObject(PacCityMini)) //clean up any existing PacCity minigame
	{
		PacCityMini.delete();
	}
	

	new scriptObject(PacCityMini) //the actual minigame
	{
		class = miniGameSO;
		
		brickDamage = true;
        fallingDamage = false; //remember to break their legs instead
        
		brickRespawnTime = 10000;
		colorIdx = -1;
		
		enableBuilding = true;
		enablePainting = true;
		enableWand = true;
		fallingDamage = true;
		inviteOnly = true;
		
		points_plantBrick = 0;
		points_breakBrick = 0;
		points_die = -1;
		points_killPlayer = 1;
		points_killSelf = -1;
		
		playerDatablock = playerNoJet;
		respawnTime = 3000;
		selfDamage = true;
		
		playersUseOwnBricks = false;
		useAllPlayersBricks = true;
		useSpawnBricks = false;
		VehicleDamage = true;            //so people can have fun running over others x_x
		vehicleRespawnTime = 5000;
		weaponDamage = true;
		
		numMembers = 0;
	};
	
	
	for(%i = 0; %i < ClientGroup.getCount(); %i++) //fill it up with the existing players
	{
		%CSGO = ClientGroup.getObject(%i);
		CityRPMini.addMember(%CSGO);
	}
}

function PacCity_NewDay() //this function will take a while to process and I can't do much about it, but atleast the same thing happens in iban's cityRPG
{
    cancel($PacCityDaySchedule);
    $PacCitySchedule = true;
    export("$PacCity_Pref_*","config/server/PacCity/prefs.cs"); //save the stuff and whatnot
    if($PacCity_Pref_CalDay == 30) //i know that every month doesn't have 30 days but that's not the point ok
    {
        $PacCity_Pref_CalDay = 1;
        if($PacCity_Pref_CalMonth == 12)
        {
            $PacCity_Pref_CalMonth = 1;
            $PacCity_Pref_CalYear++;
            messageAll('', '\c6Welcome to \c3%1\c6. This is a new year.', $PacCity_Pref_CalYear);
        }
        else
	    {
            $PacCity_Pref_CalMonth++;
	    }
    }
    messageAll('', '\c6Today is \c3%1\c6/\c3%2\c6/\c3%2.', $PacCity_Pref_CalMonth, $PacCity_Pref_CalDay, $PacCity_Pref_CalYear);

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //               BIG    -          GAS                    LOOP         THAT        DOES        A       LOT     OF      STUFF
    //------------------------------------------------------------------------------------------------------------------------------------------------

    for(%j = 0; %j < ClientGroup.getCount(); %j++) //big gas loop
    {
        %css = ClientGroup.getObject(%j);    //why do i keep making up counter strike game variables like CSGO and css for these clientgroup loops?
        PacCity_SaveData(%css); //slow!
        if(%css.nextSalary <= 0) //this isn't a you-get-a-free-salary game
        {
            %css.chatMessage("<color:FFFFFF><font:impact:26>You did not receive any money this time because you didn't work.");
        }
        else
        {
            %css.bankmoney += %css.nextSalary;
            %css.chatMessage("<color:FFFFFF>You received <color:00ff00>$" @ %css.nextSalary @ " <color:FFFFFF>from working.", 3);
        }
        %css.nextSalary = 0; //reset the next payout
        %css.energy--; //subtract from their energy
        if(%css.energy == 0)   //looks like someone recovers you
        {
            %css.player.kill();
            %css.chatMessage("<color:FFFFFF>You have almost starved yourself to death.");
            %css.chatMesage("<color:FFFFFF>You will recover in the hospital.");
            %css.inHospital = true;
            %css.energy = 10;
            %css.hospitalTime = 1;
        }
        if(%css.inHospital)
        {
            %css.hospitalTime--;
            if(%css.hospitalTime == 0)
            {
                %css.inHospital = false;
                %css.chatMessage("<color:FFFFFF>You have been discharged from the hospital.");
                %css.instantRespawn();
            }
            else
            {
                %css.chatMessage("<color:FFFFFF>You will be discharged in <color:00ff00>" @ %css.hospitalTime @ " <color:FFFFFF>days.");
            }
        }
        if(%css.inJail)
        {
            %css.jailTime--;
            if(%css.jailTime == 0)
            {
                %css.inJail = false;
                %css.chatMessage("<color:FFFFFF>You have served your jail sentence.");
                %css.instantRespawn();
            }
            else
            {
                %css.chatMessage("<color:FFFFFF>You have <color:00ff00>" @ %css.jailTime @ " <color:FFFFFF>days left on your sentence.");
            }
        }
        if($PacCity_Pref_CalDay == 1) //new month? more interest for you
        {
            %cssInterest = mFloatLength(%css.bankmoney * $PacCity_Pref_InterestMultiplier, 0); //times the set interest 
            %css.bankmoney += %cssInterest; //add the interest
            %css.chatMessage("<color:FFFFFF>You received <color:00ff00>$" @ %cssInterest @ " <color:FFFFFF>extra because the bank gave you interest.");
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------
    //               BIG                GAS                    LOOP                 END
    //------------------------------------------------------------------------------------------------------------------------------------------------

    $PacCityDaySchedule = schedule(60000 * $PacCity_Pref_DayTime, 0, "PacCity_NewDay");
}

function PacCity_RegisterCrime(%client, %amnt, %reason)
{
    %demDisplay = PacCity_CalculateDemDisplay(%client, %amnt);

    if(%demDisplay !$= "")
    {    
        %client.centerPrint("<color:FFFFFF>You committed <color:FF0000>" @ %reason @ "<color:FFFFFF>(" @ %demDisplay @ "<color:FFFFFF)";  //You committed Murder (*****^*)
        %client.jailable = true;
    }
    else
    {
        %client.centerPrint("<color:FFFFFF>You committed <color:FF0000>" @ %reason @ "<color:FFFFFF>.";   
    }
}

function PacCity_CalculateDemDisplay(%client, %amnt)
{
    %dems = %client.demerits + %amnt;
    
    if(%dems >= 100 && %dems < 200)
    {
        %demDisplay = "<color:7A7A7A>*****<color:FFFF00>*";
    }
    else if(%dems <= 99)
    {
        %demDisplay = "";
    }
    else if(%dems >= 200 && %dems < 300)
    {
        %demDisplay = "<color:7A7A7A>****<color:FFFF00>**";
    }    
    else if(%dems >= 300 && %dems < 400)
    {
        %demDisplay = "<color:7A7A7A>***<color:FFFF00>***";
    }   
    else if(%dems >= 400 && %dems < 500)
    {
        %demDisplay = "<color:7A7A7A>**<color:FFFF00>****";
    }   
    else if(%dems >= 500 && %dems < 600)
    {
        %demDisplay = "<color:7A7A7A>*<color:FFFF00>*****";
    }   
    else if(%dems >= 600 && %dems < 700)
    {
        %demDisplay = "<color:FFFF00>******";
    }   
    else
    {
        %demDisplay = "<color:FFFF00>*";
        %stars = mFloatLength(%dems/100, 0);
        for(%i = 1; %i < %stars; %i++)
        {
            %demDisplay += "*";
        }
    }
    return %demDisplay;
}

