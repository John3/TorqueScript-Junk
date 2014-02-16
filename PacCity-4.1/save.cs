//PacCity DataBot

//RE-DO's
//11-4-2011 : Made DataBot 
//1-1-2012 : Added extra job slots and illness
//2-21-2012 : Added vehiSpawn and noVehi client variables.
//2-22-2012 : Stored different BL_ID data in different files to avoid errors and make it easy for host to edit someone. ;)
function PacCity_SaveData(%savor)
{
    $pacCityDataBlank = "";
    export("$pacCityDataBlank", "config/server/PacCity/data/" @ %savor.bl_id @ ".dat"); //Does this create the file?
	%datfile = new FileObject();
	%datfile.openForWrite("config/server/PacCity/data/" @ %savor.bl_id @ ".dat"); //Or is it this?
	%datfile.writeline(%savor.bl_id SPC %savor.bank SPC %savor.hand SPC %savor.food SPC %savor.hits SPC %savor.job SPC %savor.training SPC %savor.pay SPC %savor.lastpay SPC %savor.age SPC %savor.birthday SPC %savor.birthmonth SPC %savor.lawyer SPC %savor.jailed SPC %savor.lawyercl SPC %savor.sleepy SPC %savor.job2 SPC %savor.job3 SPC %savor.lastpay2 SPC %savor.lastpay3 SPC %savor.pay2 SPC %savor.pay3 SPC %savor.illness SPC %savor.vehiSpawn SPC %savor.noVehi SPC %savor.username SPC %savor.password SPC %savor.material);
	%datfile.close();
}
function PacCity_LoadData(%loader)
{
    %file = new FileObject();
	%file.openForRead("config/server/PacCity/data/" @ %loader.bl_id @ ".dat");
    %line = %file.readLine();
	if(getWord(%line, 0) $= %loader.bl_id) //double check
	{
	    %loader.bank = getWord(%line, 1);
        %loader.hand = getWord(%line, 2); //getWord basically uses the number to count words. 
        %loader.food = getWord(%line, 3); //Basically if this line is in our .dat file..
        %loader.hits = getWord(%line, 4); //65 34 24
        %loader.job = getWord(%line, 5);  //getWord(%line, 0); would return as 65 (Yeah, it starts at 0)
        %loader.training = getWord(%line, 6); //getWord(%line, 1); would return as 34
        %loader.pay = getWord(%line, 7); //getWord(%line, 2); would return as 24
        %loader.lastpay = getWord(%line, 8); //and so on
        %loader.age = getWord(%line, 9);
        %loader.birthday = getWord(%line, 10);
        %loader.birthmonth = getWord(%line, 11);
        %loader.lawyer = getWord(%line, 12);
        %loader.jailed = getWord(%line, 13);
        %loader.lawyercl = getWord(%line, 14);
        %loader.sleepy = getWord(%line, 15);
        %loader.job2 = getWord(%line, 16);
        %loader.job3 = getWord(%line, 17);
        %loader.lastpay2 = getWord(%line, 18);
        %loader.lastpay3 = getWord(%line, 19);
        %loader.pay2 = getWord(%line, 20);
        %loader.pay3 = getWord(%line, 21);
        %loader.illness = getWord(%line, 22);
        %loader.vehiSpawn = getWord(%line, 23);
        %loader.noVehi = getWord(%line, 24);
        %loader.username = getWord(%line, 25);
        %loader.password = getWord(%line, 26);
        %loader.material = getWord(%line, 27);
        commandToClient(%client, 'centerPrint' , "\c4Alright, your data should have been loaded if you had any.", 1);
        //Delete line to be replaced.
        %line.deleteLine();
        %file.delete(); //Incase that won't work
        //I do think that export(); deletes all the data before replacing. 
        //I once deleted my config/server/prefs.cs while exporting a variable :P
        //Now I know you have to do $Pref::Server::* while exporting
        //But anyway.
	}
}
package pacCityLeaveGame
{
    function gameconnection::OnClientLeaveGame(%this,%obj,%a,%b,%c,%d,%e)
    {
        %savor = %this;
        PacCity_SaveData(%savor);
        parent::OnClientLeaveGame(%this,%obj,%a,%b,%c,%d,%e);
    }    
};
activatePackage(pacCityLeaveGame);
//Finally i'm done.