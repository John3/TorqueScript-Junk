$PacCity::Law::WantedList = "";
datablock fxDTSBrickData(PacCityLawTerminalData : brick2x4FData)
{
	category = "PacCity";
	subCategory = "Terminals";
	
	uiName = "Law (Police) Terminal";
	
	PacCityAdminOnly = true;
	
	triggerDatablock = PacCityTerminalTriggerData;
	triggerSize = "2 4 3";
	trigger = 0;
};
function PacCityLawTerminal::Data(%client, %triggerStatus)
{
    if(%triggerStatus == true)
	{
        if(%client.lawpoint $= "")
        {
		    messageClient(%client,'','\c6PacCity : \c4Law (Police) Terminal Loaded.You have %1 hits.', %client.hits);    	
            messageClient(%client,'','\c4Type /law payhits amount as long as they are under 5. Paying 1 hit costs 150 and after than costs 100 more for each one.');
            messageClient(%client,'','\c4Type /law remote info for information about mobile access to the police terminal.');
		    %client.lawpoint = 1;
	    }
	    if(%triggerStatus == false)
	    {
            if(%client.lawpoint !$= "")
            { 
		        messageClient(%client, '', '\c4Bye.');
		        %client.lawpoint = "";
            }
        }
    }		
}
//////////////////////////////////////////////////////////////////////////////////////////
function serverCmdlaw(%client, %type, %target)
{
    if(%type $= "payhits")
    {
        if(%client.hits >= 1)
        {
            if(%target == 1)
            {
                if(%client.hand >= 150)
                {
                    %client.hits = %client.hits - 1;
                    %client.hand = %client.hand - 150;
                    messageClient(%client, '', '\c4Payed one hit.');
                }
            }
            if(%target == 2)
            {
                if(%client.hand >= 250)
                {
                    %client.hits = %client.hits - 2;
                    %client.hand = %client.hand - 250;
                    messageClient(%client, '', '\c4Payed two hits.');
                }
            }
            if(%target == 3)
            {
                if(%client.hand >= 350)
                {
                    %client.hits = %client.hits - 3;
                    %client.hand = %client.hand - 350;
                    messageClient(%client, '', '\c4Payed three hits.');
                }
            }
            if(%target == 4)
            {
                if(%client.hand >= 450)
                {
                    %client.hits = %client.hits - 4;
                    %client.hand = %client.hand - 450;
                    messageClient(%client, '', '\c4Payed four hits.');
                }
            }
            if(%target == 5)
            {
                if(%client.hand >= 550)
                {
                    %client.hits = %client.hits - 5;
                    %client.hand = %client.hand - 550;
                    messageClient(%client, '', '\c4Payed five hits.That is the max.');
                }
            }
        }
    }
    else if(%type $= "remote")
    {
        messageClient(%client, '', '\c4You do not have to come to a bank terminal if you use remote access.');
        messageClient(%client, '', '\c4What happens is if you type /bank deposit amount or /bank withdraw amount the same thing happens.');
        messageClient(%client, '', '\c4For techies, this is possible due to me using a serverCmd statement unlike CityRPG.');
        messageClient(%client, '', '\c4The remote service is free.');     
    }
}