function PacCityTerminalTriggerData::onEnterTrigger(%this, %trigger, %obj)
{	
	%obj.client.PacCityTerminalTrigger = %trigger;
	%triggerStatus = true;
	%trigger.parent.getDatablock().Data(%obj.client, %triggerStatus);
}

function PacCityTerminalTriggerData::onLeaveTrigger(%this, %trigger, %obj, %a)
{	
    %triggerStatus = false;
	%trigger.parent.getDatablock().Data(%obj.client, %triggerStatus);
	%obj.client.PacCityTerminalTrigger = "";
}
datablock fxDTSBrickData(PacCityTrainingTerminalData : brick2x4FData)
{
	category = "PacCity";
	subCategory = "Terminals";
	
	uiName = "Training Terminal";
	
	PacCityAdminOnly = true;
	
	triggerDatablock = PacCityTerminalTriggerData;
	triggerSize = "2 4 3";
	trigger = 0;
};
function PacCityTrainingTerminal::Data(%client, %triggerStatus)
{
    if(%triggerStatus == true)
	{
        if(%client.trainpoint $= "")
        {
		    messageClient(%client,'','\c6PacCity : \c4Training Terminal Loaded. You have a %1 level training.', %client.training);    	
            messageClient(%client,'','\c4Type /train prices info to see how much each level of training costs.');
            messageClient(%client,'','\c4Type /train start level to start being trainined.');
            messageClient(%client,'','\c4Type /bank remote info to see about remote access.');
		    %client.trainpoint = 1;
	    }
	    if(%triggerStatus == false)
	    {
            if(%client.trainpoint !$= "")
            { 
		        messageClient(%client, '', '\c4Bye.');
		        %client.trainpoint = "";
            }
        }
    }		
}
function serverCmdtrain(%client, %type, %level)
{
    if(%type $= "prices")
    {
        messageClient(%client,'','\c6Note that this will SET your training to the level specified, not ADD. If you are dumb enough, you may downgrade your training.');
        messageClient(%client,'','\c6Level 1 Training : \c4$100');
        messageClient(%client,'','\c6Level 2 Training : \c4$200');
        messageClient(%client,'','\c6Level 3 Training : \c4$400');
        messageClient(%client,'','\c6Level 4 Training : \c4$600');
        messageClient(%client,'','\c6Level 5 Training : \c4$800  - If you get here, you can get a second additional job by typing /jobs jobName AND /jobs2 jobName');
        messageClient(%client,'','\c6Level 6 Training : \c4$1000');
        messageClient(%client,'','\c6Level 7 Training : \c4$1200');
        messageClient(%client,'','\c6Level 8 Training : \c4$1400');
        messageClient(%client,'','\c6Level 9 Training : \c4$1600');
        messageClient(%client,'','\c6Level 10 Training : \c4$1800   - If you get here, you can get three job slots in total by typing /jobs jobName, /jobs2 jobName AND /jobs3 jobName');
        messageClient(%client,'','\c6Level 11 Training : \c4$2150');
    }
    if(%type $= "start")
    {
        if(%level == 1)
        {
            if(%client.hand >= 100)
            {
                %client.hand = %client.hand - 100;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 2)
        {
            if(%client.hand >= 200)
            {
                %client.hand = %client.hand - 200;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 3)
        {
            if(%client.hand >= 400)
            {
                %client.hand = %client.hand - 400;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 4)
        {
            if(%client.hand >= 600)
            {
                %client.hand = %client.hand - 600;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 5)
        {
            if(%client.hand >= 800)
            {
                %client.hand = %client.hand - 800;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1. Second job slot opened. To use, type /jobs2 jobName', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 6)
        {
            if(%client.hand >= 1000)
            {
                %client.hand = %client.hand - 1000;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 7)
        {
            if(%client.hand >= 1200)
            {
                %client.hand = %client.hand - 1200;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 8)
        {
            if(%client.hand >= 1400)
            {
                %client.hand = %client.hand - 1400;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 9)
        {
            if(%client.hand >= 1600)
            {
                %client.hand = %client.hand - 1600;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 10)
        {
            if(%client.hand >= 1800)
            {
                %client.hand = %client.hand - 1800;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1. Third job slot opened. To use, type /jobs3 jobName and to use the second slot type /jobs2 jobName.', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else if(%level == 11)
        {
            if(%client.hand >= 2150)
            {
                %client.hand = %client.hand - 2150;
                %client.training = %level; 
                messageClient(%client,'','\c4Trained to level %1. You are now at the max training level.', %level);
            }
            else
            {
                messageClient(%client,'','\c4You need more cash on hand.');
            }
        }
        else
        {
            messageClient(%client,'','\c6You are either at the max level of training or that level does not exist in v2.8 !');
        }
    }
}