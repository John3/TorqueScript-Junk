function PacCity_noVehi(%client)
{
    if(%client.vehiSpawn !$= "")
    {
        if(%client.noVehi == 1)
        {
            %client.vehiSpawn.getDatablock().vehicle = "";
        }
    }
}
    