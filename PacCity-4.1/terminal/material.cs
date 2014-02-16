datablock fxDTSBrickData(PacCityMaterialTerminalData : brick2x4FData)
{
	category = "PacCity";
	subCategory = "Terminals";
	
	uiName = "Material Terminal";
	
	PacCityAdminOnly = true;
	
	triggerDatablock = PacCityTerminalTriggerData;
	triggerSize = "2 4 3";
	trigger = 0;
};
function PacCityMaterialTerminal::Data(%client, %triggerStatus)
{
    if(%triggerStatus == true)
	{
        if(%client.materialpoint $= "")
        {
		    messageClient(%client,'','\c6PacCity : \c4Material Terminal Loaded. You have %1 material.', %client.material);    	
            messageClient(%client,'','\c4Type /material to sell your material.');
		    %client.materialpoint = 1;
	    }
	    if(%triggerStatus == false)
	    {
            if(%client.materialpoint !$= "")
            { 
		        messageClient(%client, '', '\c4Bye.');
		        %client.materialpoint = "";
            }
        }
    }		
}
function serverCmdmaterial(%client)
{
    if(%client.material > 0)
    {
        %gain = %client.material * 3;
        %client.bank = %client.bank + %gain;
        %client.material = 0;
        messageClient(%client,'','\c4I sent %1 to your bank account.', %gain);
    }
    else
    {
        messageClient(%client,'','\c4You do not have any material to sell! Please do not waste our time!');   
    }
}