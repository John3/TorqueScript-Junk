exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Pd.gui");
exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Main.gui");
exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Error.gui");
function clientCmdgetPdData(%hits, %jailed)
{
    PACCITY_PD_HITS.setValue(%hits);
    if(%jailed == 0)
    {
        PACCITY_PD_JAILED.setValue("No");
    }
    else
    {
        PACCITY_PD_JAILED.setValue("Yes");
    }
}
function PACCITY::payhits(%gui)
{
    %hits = PACCITY_PD_PAYHITS_AMOUNT.getValue();
    %realhits = PACCITY_PD_HITS.getValue();
    if(%hits <= %realhits)
    {
        commandToServer("law", "payhits", %hits);
    }
}
function PACCITY::listcriminals(%gui)
{
    commandToServer("law", "viewWanted", "info");
}
function PACCITY::addcriminal(%gui)
{
    %criminal = PACCITY_PD_ADD_CRIMINAL.getValue();
    commandToServer("wanted", %criminal);
}


    