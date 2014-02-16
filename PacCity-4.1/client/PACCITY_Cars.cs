exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Cars.gui");
function clientCmdBuyCar(%car, %cost, %bank)
{
    PACCITY_CAR_COST.setValue(%cost);
    PACCITY_CAR_BANK.setValue(%bank);
    PACCITY_CAR_NAME.setValue(%car);
}
function PACCITY::buyCar()
{
    %budget = PACCITY_CAR_BANK.getValue();
    %cost = PACCITY_CAR_COST.getValue();
    if(%budget < %cost)
    {
        canvas.pushDialog(PACCITY_Error);
    }
    else
    {
        commandToServer("buyCar");
    }
}
function PACCITY::declineCar()
{
    commandToServer("dontBuyCar");
}    