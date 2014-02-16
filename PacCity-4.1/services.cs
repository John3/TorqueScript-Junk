registerOutputEvent("fxDTSBrick", "otherSale", "string 1 3000 1" TAB "int 1 3000 1");
registerInputEvent("fxDTSBrick", "onServiceAccepted", "Self fxDTSBrick" TAB "Player Player" TAB "Client GameConnection");
function fxDTSBrick::otherSale(%brick, %name, %cost, %client)
{
	if(%client.player.saleBrick $= "")
	{
		%client.player.saleName = %name;
		%client.player.saleCost = %cost;
		%client.player.saleBrick = %brick;
		messageClient(%client,'','\c4You can accept the service %1 for %2 bucks. Type /acceptService to accept or /declineService to decline it.', %client.player.saleName, %client.player.saleCost);
	}
	else
    {
        messageClient(%client,'','\c4You have to decline the previous offer.');
		//Error gui code here
    }
}
function serverCmdacceptService(%client)
{
    if(%client.player.saleName !$= "")
    {
        if(%client.hand >= %client.player.saleCost)
        {
            %sellerid = %client.player.saleBrick.getGroup().bl_id;
            %seller = findClientByBL_ID(%sellerid);
            %player = %client.player;
            messageClient(%seller,'','\c4You sold a service called %1 to %2.', %client.player.saleName, %client.player.saleCost);
            %client.hand = %client.hand - %client.player.saleCost;
            %seller.bank = %seller.bank + %client.player.saleCost;
            	$inputTarget_self = %client.player.saleBrick;
	            $inputTarget_player	= %client.player;
	            $inputTarget_client	= %client;
	            %client.player.saleBrick.processInputEvent("onServiceAccepted", %client);
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
function serverCmddeclineService(%client)
{
    messageClient(%client,'','\c4You chose not to buy that.');
    %client.player.saleName = "";
    %client.player.saleSize = "";
    %client.player.saleCost = "";
    %client.player.saleBrick = "";
}