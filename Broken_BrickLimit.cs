//==========================================
//               PACNET2012                //
//==========================================

package bricklimit
{
    RTB_registerPref("Brick Limit For Non-Admins", "BRICKLIMIT", "$Pref::Server::ClientBrickLimit", "int", "Server_BrickLimit", false, false, false, "");
    function fxDTSbrick::onPlant(%client, %brick)
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
                %brick.delete();
                messageClient(%client, '', "\c4You have exceeded your brick limit! Ask a \c3Super Admin \c4 for more allowance!");
            }
        }
    }   
}
