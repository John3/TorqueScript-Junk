//PacCity 6
//do i really need to explain this
//it's just a file crammed with as many serverCmds as i could think of


function serverCmdihavepaccity(%client) // don't bypass this please
{
    %client.hasPacCity = true; 
}


function serverCmdSaveData(%client)
{
    if(%client.saveDataCooldown $= "" ||  %client.saveDataCooldown $= "N")
    {    
        PacCity_SaveData(%client);
        %client.centerPrint("<color:00ff00><font:impact:30>Your data has been saved.", 2);
    }
    else
    {
        %client.centerPrint("<color:00ff00><font:impact:30>You can not use this feature that often.", 3);
    }
    %client.saveDataCooldown = "Y";
    schedule(300000, 0, "PacCity_EraseCoolDown", %client, "saveData");
}

function serverCmdDetectSpawns(%client)
{
    if(%client.isSuperAdmin)
    {
        %spawnCount = 0;
        messageAll('','\c6PacCity is searching for spawns...');
        
        %groupCount = MainBrickGroup.getCount();
        for(%i = 0; %i < %groupCount; %i++)
        {
	        %group = MainBrickGroup.getObject(%i);
	        %count = %group.getCount();
	        for(%j = 0; %j < %count; %j++)
	        {
	            %brick = %group.getObject(%j);
                if(%brick.uiName == "Jail Spawn" && %brick.category == "PacCity")
                {
	                $PacCityJailSpawn = %brick;
                    messageAll('', '\c6PacCity found the jail spawn brick');
                    %spawnCount++;
                }
                if(%brick.uiName == "Hospital Spawn" && %brick.category == "PacCity");
                {
                    $PacCityHospitalSpawn = %brick;
                    messageAll('', '\c6PacCity found the hospital spawn brick');
                    %spawnCount++;
                    
                }

	        }
        }
        messageAll('', '\c6PacCity found %1/2 spawns.', %spawnCount);
        messageAll('', '\c6If you do not have 2 spawns, make sure that you have a Jail Spawn brick and a Hospital Spawn brick (find it in the PacCity bricks section)');
    }
}