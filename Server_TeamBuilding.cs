package teamBuilding
{
    function getTrustLevel(%client, %brick)
    {
        %builder = %brick.getGroup().client;
        if(%client.getTeam() == %builder.getTeam())
        {
            return 1;
        }
        parent::getTrustLevel(%client, %brick);
    }
};
activatePackage(teamBuilding);
