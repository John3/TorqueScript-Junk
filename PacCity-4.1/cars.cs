registerOutputEvent("fxDTSBrick", "carSale", "datablock WheeledVehicleData" TAB "int 1 5000 1");

function fxDTSBrick::carSale(%brick, %car, %cost, %client)
{
	if(%client.player.saleBrick $= "")
	{
		%car = %client.player.saleName;
		%cost = %client.player.saleCost;
		%brick = %client.player.saleBrick;
        %bank = %client.bank;
		commandToClient(%client, "BuyCar", %car, %cost, %bank);
	}
	else
    {
        messageClient(%client,'','\c4You have to decline the previous offer.');
		//Error gui code here
    }
}
function serverCmdbuyCar(%client)
{
    if(%client.player.saleName !$= "")
    {
        if(%client.hand >= %client.player.saleCost)
        {
            %sellerid = %client.player.saleBrick.getGroup().bl_id;
            %seller = findClientByBL_ID(%sellerid);
            %player = %client.player;
            %car = %client.player.saleName;
            %client.noVehi = 0;
            %client.vehiSpawn.getDatablock().vehicle = %car;
                messageClient(%seller,'','\c4You bought a vehicle!');
                 messageClient(%seller,'','\c4You sold a vehicle to %1.', %client.name);
                 %client.hand = %client.hand - %client.player.saleCost;
                 %seller.bank = %seller.bank + %client.player.saleCost;
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
        }
        else
        {
            messageClient(%client,'','\c4Get more cash.');
        }
    }
    else
    {
        messageClient(%client,'','\c4You do not have an open sale request.');
    }
}
function serverCmddontBuyCar(%client)
{
    messageClient(%client,'','\c4You chose not to buy that.');
    %client.player.saleName = "";
    %client.player.saleSize = "";
    %client.player.saleCost = "";
    %client.player.saleBrick = "";
}