//==========================================
//               Brick Limit              //
//==========================================

if(isFile("Add-Ons/System_ReturnToBlockland/server.cs"))
{
    if(!$BrickLimitPrefsLoaded)
    {
        if(!$RTB::Hooks::ServerControl)
            exec("Add-Ons/System_ReturnToBlockland/hooks/serverControl.cs")
            
        RTB_registerPref("Brick Limit For Non-Admins", "BRICKLIMIT", "$Pref::Server::ClientBrickLimit", "int", "Server_BrickLimit", false, false, false, "");
        $BrickLimitPrefsLoaded = true;
    }
}

package bricklimit
{
    function serverCmdPlantBrick(%client)
    {
        if(%client.isAdmin || %client.isSuperAdmin)
        {
            return;
        }
        else
        {
            if(%client.brickLimitCount = "")
            {
                %client.brickLimitCount = 0;
            }   
            %client.brickLimitCount++;
            if(%client.brickLimitCount > $Pref::Server::ClientBrickLimit)
            {
                messageClient(%client, '', "\c4You have exceeded your brick limit! Ask a \c3Super Admin \c4 for more allowance!");
                %client.brickLimitCount--;
                return;
            }
        }
        parent::serverCmdPlantBrick(%client);
    }   
}
