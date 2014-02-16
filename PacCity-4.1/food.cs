registerOutputEvent("fxDTSBrick", "foodSale", "string 45 100" TAB "int 1 5 1" TAB "int 1 300 1");

function fxDTSBrick::foodSale(%brick, %name, %size, %cost, %client)
{
	if(%client.player.saleBrick $= "")
	{
		%client.player.saleName = %name;
		%client.player.saleSize = %size;
		%client.player.saleCost = %cost;
		%client.player.saleBrick = %brick;
		messageClient(%client,'','\c4You can buy some %1 %2 for %3. Type /buyFood to accept it otherwise /dontBuyFood if you do not.', %client.player.saleSize, %client.player.saleName, %client.player.saleCost);
	}
	else
    {
        messageClient(%client,'','\c4You have to decline the previous offer.');
		//Error gui code here
    }
}
function serverCmdbuyFood(%client)
{
    %name = %client.player.saleName;
    %size = %client.player.saleSize;
    %cost = %client.player.saleCost;
    %brick = %client.player.saleBrick;
    if(%name !$= "")
    {
        if(%size == 1)
        {
            if(%client.hand >= %cost)
            {
                messageClient(%client,'','\c4You ate the %1.', %name);
                %client.hunger = %client.hunger + 2;
                %client.hand = %client.hand - %cost;
                %sellerid = %client.player.saleBrick.getGroup().bl_id;
                %seller = findClientByBL_ID(%sellerid);
                %seller.bank = %seller.bank + %cost;
                messageClient(%seller,'','\c4You sold some food to %1', %client.name);
                ///////////////////////////////
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
            }
            else
            {
                messageClient(%client,'','\c4You need more cash.');
                //Error gui code
            }
        }
        else if(%size == 2)
        {
            if(%client.hand >= %cost)
            {
                messageClient(%client,'','\c4You ate the %1.', %name);
                %client.hunger = %client.hunger + 4;
                %client.hand = %client.hand - %cost;
                %sellerid = %client.player.saleBrick.getGroup().bl_id;
                %seller = findClientByBL_ID(%sellerid);
                %seller.bank = %seller.bank + %cost;
                messageClient(%seller,'','\c4You sold some food to %1', %client.name);
                ///////////////////////////////
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
            }
            else
            {
                messageClient(%client,'','\c4You need more cash.');
                //Error gui code
            }
        }
        else if(%size == 3)
        {
            if(%client.hand >= %cost)
            {
                messageClient(%client,'','\c4You ate the %1.', %name);
                %client.hunger = %client.hunger + 6;
                %client.hand = %client.hand - %cost;
                %sellerid = %client.player.saleBrick.getGroup().bl_id;
                %seller = findClientByBL_ID(%sellerid);
                %seller.bank = %seller.bank + %cost;
                messageClient(%seller,'','\c4You sold some food to %1', %client.name);
                ///////////////////////////////
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
            }
            else
            {
                messageClient(%client,'','\c4You need more cash.');
                //Error gui code
            }
        }
        else if(%size == 4)
        {
            if(%client.hand >= %cost)
            {
                messageClient(%client,'','\c4You ate the %1.', %name);
                %client.hunger = %client.hunger + 8;
                %client.hand = %client.hand - %cost;
                %sellerid = %client.player.saleBrick.getGroup().bl_id;
                %seller = findClientByBL_ID(%sellerid);
                %seller.bank = %seller.bank + %cost;
                messageClient(%seller,'','\c4You sold some food to %1', %client.name);
                ///////////////////////////////
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
            }
            else
            {
                messageClient(%client,'','\c4You need more cash.');
                //Error gui code
            }
        }
        else if(%size == 5)
        {
            if(%client.hand >= %cost)
            {
                messageClient(%client,'','\c4You ate the %1.', %name);
                %client.hunger = %client.hunger + 10;
                %client.hand = %client.hand - %cost;
                %sellerid = %client.player.saleBrick.getGroup().bl_id;
                %seller = findClientByBL_ID(%sellerid);
                %seller.bank = %seller.bank + %cost;
                messageClient(%seller,'','\c4You sold some food to %1', %client.name);
                ///////////////////////////////
		        %client.player.saleName = "";
		        %client.player.saleSize = "";
		        %client.player.saleCost = "";
		        %client.player.saleBrick = "";
            }
            else
            {
                messageClient(%client,'','\c4You need more cash.');
                //Error gui code
            }
        }
    }
    else
    {
        messageClient(%client,'','\c4You do not have an open sale request.');
    }
}
function serverCmddontBuyFood(%client)
{
    messageClient(%client,'','\c4You chose not to buy that.');
    %client.player.saleName = "";
    %client.player.saleSize = "";
    %client.player.saleCost = "";
    %client.player.saleBrick = "";
}