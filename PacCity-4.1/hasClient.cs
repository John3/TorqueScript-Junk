function PacCity_CheckClient(%client)
{
    if(!%this.hasClient)
    {
        %this.delete("You need Gamemode_PacCity! Get it off rtb or here : [LINK]");
    }
}
function serverCmdhasclient(%client, %slash) // %slash checks if you send the valid code, not just type /hasclient
{
    if(%slash $= $PacCity::Slash)
    {
        %client.hasClient = true;
    }   
}
