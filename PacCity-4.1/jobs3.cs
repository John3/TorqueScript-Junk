function PacCity_JobTestThree(%applier, %job)
{
    if(%applier.training >= 10)
    {
        if(%job $= "Cop")
        {
            if(%applier.training >= 3)
            {
                messageClient(%client,'','\c4You are now a cop.Type /request baton to request an arrest baton and /request gun for a gun.');
                %applier.job3 = "Cop";
                %applier.pay3 = 60;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 3.');
            }
        }
        else if(%job $= "Criminal")
        {
            if(%applier.training >= 2)
            {
                messageClient(%client,'','\c4You are now a criminal.Type /request gun to request a gun.');
                %applier.job3 = "Criminal";
                %applier.pay3 = 45;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 2.');
            }
        }
        else if(%job $= "CriminalLeader")
        {
            if(%applier.training >= 3)
            {
                messageClient(%client,'','\c4You are now a criminal leader.Type /request gun to request a gun.');
                %applier.job3 = "CriminalLeader";
                %applier.pay3 = 75;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 3.');
            }
        }
        else if(%job $= "Mayor")
        {
            if(%applier.training >= 5)
            {
                messageClient(%client,'','\c4You are now a mayor.Type /request gun to request a gun and /request baton to request an arrest baton. To raise taxes type /setTax amount.');
                %applier.job3 = "Mayor";
                %applier.pay3 = 115;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 5.');
            }
        }
        else if(%job $= "MiddleClassPerson")
        {
            if(%applier.training >= 2)
            {
                messageClient(%client,'','\c4You are now a middle class person.');
                %applier.job3 = "MiddleClassPerson";
                %applier.pay3 = 30;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 2.');
            }
        }
        else if(%job $= "RichGuy")
        {
            if(%applier.training >= 6)
            {
                messageClient(%client,'','\c4You are now a rich guy. Enjoy your stream of cash!');
                %applier.job3 = "RichGuy";
                %applier.pay3 = 1000;
            }
            else
            {
                messageClient(%client,'','\c4You need to be trained to level 6.');
            }
        }
        else if(%job $= "Admin")
        {
            if(%applier.isAdmin || %applier.isSuperAdmin)
            {
                messageClient(%client,'','\c4You are now an admin. For admin commands type /help Admin. For a gun type /request gun. Baton ? /request baton.');
                %applier.job3 = "Admin";
                %applier.pay3 = 600000;
            }
            else
            {
                messageClient(%client,'','\c4You are not a server admin.');
            }
        }
        else if(%job $= "Judge")
        {
            if(%applier.training >= 7)
            {
                messageClient(%client,'','\c4You are now a judge.');
                %applier.job3 = "Judge";
                %applier.pay3 = 60000;
            }
            else
            {
                messageClient(%client,'','\c4You need to atleast be trained to level 7');
            }
        }
        else if(%job $= "Lawyer")
        {
            if(%applier.training >= 6)
            {
                messageClient(%client,'','\c4You are now a lawyer.');
                %applier.job3 = "Lawyer";
                %applier.pay3 = 6000;
            }
            else
            {
                messageClient(%client,'','\c4You need to atleast be trained to level 6');
            }
        }
        else
        {   
             messageClient(%client,'','\c4That job does not exist. Too bad.However, you can contact the host and ask him to add more if he has scripting knowledge or wait for PacCity Service Packs to be released..');
        }
    }
}     

      
        
function serverCmdJobs3(%client, %job)
{
    if(%job $= "")
    {
        messageClient(%client,'','\c4--PacCity Jobs--');
        messageClient(%client,'','\c4Type /getPayThree to get your paycheck every 5 days.');
        messageClient(%client,'','\c4Hobo - Default Job. Training Required : 0 Perks : None');
        messageClient(%client,'','\c4Cop - Training Required : 3 | Perks : Can Arrest People | Pay : $60');
        messageClient(%client,'','\c4Criminal - Training Required : 2 | Perks : Get A Gun | Pay : $45');
        messageClient(%client,'','\c4CriminalLeader - Training Required : 3 | Perks : Get A Gun | Pay : $75');
        messageClient(%client,'','\c4Mayor - Training Required : 5 | Perks : Arrest And Get a Gun | Pay : $115');
        messageClient(%client,'','\c4MiddleClassPerson - Training Required : 2 | Perks : Get a pay unlike hobos. | Pay : $30');
        messageClient(%client,'','\c4RichGuy - Training Required : 6 | Perks :  Huge Pay | Pay : $1,000');
        messageClient(%client,'','\c4Admin - Training Required : Admin Rights | Perks : Control Over The Server | Pay : $600,000');
        messageClient(%client,'','\c4Judge - Training Required : 7 | Perks : Decide if criminals go to jail | Pay : $60,000');
        messageClient(%client,'','\c4Lawyer - Training Required : 6 | Perks : Make it less likely for people to go to jail | Pay : $6,000');
    }
    else
    {
        PacCity_JobTestThree(%client, %job);
    }
}