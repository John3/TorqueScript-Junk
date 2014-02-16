//Pacnet2012
//Kick on death
//Ban on death + time control

$Server::KickDie::Enabled = false;
$Server::KickDie::Option = false;
$Server::KickDie::BanTime = 10;

if(isFile("Add-Ons/System_ReturnToBlockland/server.cs"))
{
    if(!$RTB::RTBR_ServerControl_Hook)
    {
        exec("Add-Ons/System_ReturnToBlockland/hooks/serverControl.cs");
    }
    RTB_registerPref("Enabled","Kick/Ban on Death","Server::KickDie::Enabled","bool","Server_KickBanDie",0,0,1);
    RTB_registerPref("Kick:1 Ban:2","Kick/Ban on Death","Server::KickDie::Option","int 1 2","Server_KickBanDie",1,0,1);
    RTB_registerPref("Ban Time","Kick/Ban on Death","Server::KickDie::BanTime","int 1 60","Server_KickBanDie",10,0,1);
}

package kickDie
{	
    function gameConnection::onDeath(%client,%source,%killer,%type,%pos)
	{
		parent::onDeath(%client,%source,%killer,%type,%pos);
        if($Server::KickDie::Option == 1)
        {
            if($Server::KickDie::Enabled)
            {
                %client.delete("You have died in the server.");
                messageAll('','\c6%1 has been kicked because he/she has died in-game.', %client.name);
            }
        }
        else if($Server::KickDie::Option == 2)
        {
            if($Server::KickDie::Enabled)
            {
                messageAll('','\c6%1 has been banned because he/she has died in-game.', %client.name);
                banBLID(%client.bl_id, $Server::KickDie::BanTime, "You have died in-game.");
            }
        }
	}
};
activatePackage(kickDie);
