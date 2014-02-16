package pacCityEnterGame
{
    function GameConnection::OnClientEnterGame(%this,%obj,%a,%b,%c,%d,%e) 
    {
        commandToClient(%client, 'IRunPac');
	        commandToClient(%this, 'centerPrint' , "\c6PacCity :\c4If it's your first time on this server either type /registerAccount user pass or /loginAccount user pass.", 3);
            PacCity_ClientTime(%this);
        schedule(10000, "PacCity_CheckClient", %this);
        parent::OnClientEnterGame(%this,%obj,%a,%b,%c,%d,%e);
    }
};
activatePackage(pacCityEnterGame);
function serverCmdregisterAccount(%client, %user, %pass)
{  	
	$PacCity::Save::ProfileSetup = "";
	export("$PacCity::Save::ProfileSetup", "config/server/PacCity/data/" @ %client.bl_id @ ".dat");
	commandToClient(%client, 'centerPrint' , "Account Registered. Setting up profile. You can recover your data if you forgot pass with /recoverAccount", 3);
	%client.bank = $PacCity::Pref::StartingCash; //copy
	%client.hand = 5; //copy
    %client.food = 100; //copy
    %client.hits = 0; //copy
    %client.food = 100; //copy
    %client.job = "Hobo"; //copy
    %client.training = 0;
    %client.pay = 0;
    %client.lastpay = 5;
    %client.age = 21;
    %client.birthday = $PacCity::Calendar::Day;
    %client.birthmonth = $PacCity::Calendar::Month;
    %client.lawyer = "";
    %client.jailed = 0;
    %client.lawyercl = "";
    %client.sleepy = 0;
    %client.job2 = "";
    %client.job3 = "";
    %client.lastpay2 = 5;
    %client.lastpay3 = 5;
    %client.pay2 = 0;
    %client.pay3 = 0;
    %client.illness = "Healthy";
    %client.vehiSpawn = "";
    %client.noVehi = 1;
    %client.username = %user;
    %client.password = %pass;
    %client.material = 0;
	messageClient(%client,'','\c4Created profile. enjoy! ');
}
function serverCmdloginAccount(%client, %user, %pass)
{
	%fileread = new FileObject();
	%fileread.openforread("config/server/PacCity/data/" @ %client.bl_id @ ".dat");
	while(!%fileread.isEOF()) //EOF means end of file
	{
		%line = %fileread.readLine();
		if(getWord(%line, 0) $= %client.bl_id)
		{
			if(getWord(%line, 25) $= %user)
			{
				if(getWord(%line, 26) $= %pass)
				{
					commandToClient(%client, 'centerPrint' , "Your data should be loading if you had any...", 3);
					%loader = %client;
					PacCity_LoadData(%loader); //Load his or her data with DataBot	
				}
                else
                {
                    commandToClient(%client, 'centerPrint' , "that Password doesn't match with your data file.", 3);
                }
			}
            else
            {
                commandToClient(%client, 'centerPrint' , "that Username doesn't match with your data file.", 3);
            }
		}
	}
}
function serverCmdrecoverAccount(%client)
{
    commandToClient(%client, 'centerPrint' , "\c4Login and register is to make it cooler but here I go loading your data ...", 3);	
    %loader = %client;
    PacCity_LoadData(%loader);
}

