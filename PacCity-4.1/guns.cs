registerOutputEvent("fxDTSBrick", "gunSale", "datablock ItemData" TAB "int 1 5000 1");

function fxDTSBrick::gunSale(%brick, %img, %cost, %client)
{
	if(%client.player.saleBrick $= "")
	{
		%client.player.saleName = %img;
		%client.player.saleCost = %cost;
		%client.player.saleBrick = %brick;
		messageClient(%client,'','\c4You can buy a %1 for %2. Type /buyGun to accept it otherwise /dontBuyGun if you do not.', %client.player.saleName, %client.player.saleCost);
	}
	else
    {
        messageClient(%client,'','\c4You have to decline the previous offer.');
		//Error gui code here
    }
}
function serverCmdbuyGun(%client)
{
    if(%client.player.saleName !$= "")
    {
        if(%client.hand >= %client.player.saleCost)
        {
            %sellerid = %client.player.saleBrick.getGroup().bl_id;
            %seller = findClientByBL_ID(%sellerid);
            %player = %client.player;
            %img = %client.player.saleName;
            for(%j = 0; %j < %player.getDatablock().maxTools; %j++)
            {
              %tool = %player.tool[%j];
              if(%tool == 0)
              {
                 %player.tool[%j] = %img;
                 %player.weaponCount++;
                 messageClient(%client,'MsgItemPickup','', %j, %img);
                 messageClient(%seller,'','\c4You sold a gun to %1.', %client.name);
                 %client.hand = %client.hand - %client.player.saleCost;
                 %seller.bank = %seller.bank + %client.player.saleCost;
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
                 break;
              }
           }
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
function serverCmddontBuyGun(%client)
{
    messageClient(%client,'','\c4You chose not to buy that.');
    %client.player.saleName = "";
    %client.player.saleSize = "";
    %client.player.saleCost = "";
    %client.player.saleBrick = "";
}