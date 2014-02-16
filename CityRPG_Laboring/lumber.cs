// ============================================================
// Project            :  Platinum CityRPG
// Created on         :  Saturday, November 07, 2012 9:00 PM
// Description        :  For those guys who are going to lumberjack
// Author             :  Pacnet2012
// ============================================================

//=============================================================
// Table of Contents
// 1 Brick
// 2 Actual laboring
//=============================================================

//=============================================================
//1 : BRICK
//=============================================================
//Weak [1]
$CityRPG::Lumber::Weak = 2; //money given for selling
//Medium [2]
$CityRPG::Lumber::Medium = 7;
//Strong [3]
$CityRPG::Lumber::Strong = 12;

//(Assuming there is no brick file for this)

datablock fxDTSBrickData(CityRPGWeakTreeData : brickPineTreeData)
{
	category = "CityRPG";
	subCategory = "CityRPG Resources";
	uiName = "Weak Tree";
    type = 1;
};

datablock fxDTSBrickData(CityRPGMediumTreeData : brickPineTreeData)
{
	category = "CityRPG";
	subCategory = "CityRPG Resources";
	uiName = "Medium Tree";
    type = 2;
};

datablock fxDTSBrickData(CityRPGStrongTreeData : brickPineTreeData)
{
	category = "CityRPG";
	subCategory = "CityRPG Resources";
	uiName = "Strong Tree";
    type = 3;
};

//Remember to make the AXE TOOL FILES accordingly! A weak tree should be lumbered with any axe and a strong tree requires a more expensive axe to 

//=============================================================
//2 : ACTUAL LABOR
//=============================================================
//%client is the client
//%type is the type of tree (1 = weak, 2 = medium, 3 = strong)
//%amount is the amount of wood
//------Save to Inventory------ (Insert this function accordingly into axe files)
function addLumber(%client, %type, %amount)
{
    if(%type == 1)
    {
        %name = "Weak";
        CityRPGData.data[%client.BL_ID, "Wood"] += %amount;
    }
    else if(%type == 2)
    {
        %name = "Medium";
        CityRPGData.data[%client.BL_ID, "Wood2"] += %amount;
    }
    else if(%type == 3)
    {   
        %name = "Strong";
        CityRPGData.data[%client.BL_ID, "Wood3"] += %amount;
    }
    %client.chatMessage("<font:impact:30><color:00ff00>+" @ %amount @ " of " @ %name @ " type wood!");
}