function serverCmdgetGlassStats(%client)
{
    %player = %client.player;
    //d
    %dirt = %client.trenchDirt;
    %health = 100 - %client.player.getDamageLevel();
    %score = %client.score;
    %team = %client.getTeam().name; //Slayer
    %slot1 =  %player.tool[0].uiName;
    %slot2 =  %player.tool[1].uiName;
    %slot3 =  %player.tool[2].uiName;
    %slot4 =  %player.tool[3].uiName;
    %slot5 =  %player.tool[4].uiName;
    %slot6 =  %player.tool[5].uiName;
    %slot7 =  %player.tool[6].uiName;
    %blid = %client.bl_id;
    %name = %client.name;
    commandToClient(%client, 'sendGlassStats', %dirt, %health, %score, %team, %slot1, %slot2, %slot3, %slot4, %slot5, %slot6, %slot7, %blid, %name);
}