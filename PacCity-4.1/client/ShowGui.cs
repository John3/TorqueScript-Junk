function clientCmdPacCityError()
{
    canvas.pushDialog(PACCITY_Error);
}
function clientCmdOpenGui()
{
    canvas.pushDialog(PACCITY_Bank);
}
function PACCITY::showBank(%gui)
{
    commandToServer("OpenBank");
}
function PACCITY::showPD(%gui)
{
    commandToServer("OpenPd");
}
function PACCITY::showError(%gui)
{
    canvas.pushDialog(PACCITY_Error);
}
function PACCITY::showStatus(%gui)
{
    commandToServer("OpenStats");
}
function clientCmdOpenGuiTwo(%type) //Server's response
{
    if(%type $= "bank")
    {
        canvas.pushDialog(PACCITY_Bank);
    }
    else if(%type $= "pd")
    {
        canvas.pushDialog(PACCITY_Pd);
    }
    else if(%type $= "status")
    {
        canvas.pushDialog(PACCITY_Status);
    }
}