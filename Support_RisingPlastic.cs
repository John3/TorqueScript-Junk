//by Pacnet2013 and MARBLE MAN
//Rising Lava + Survival
//30 plastic max
//Planter puts a ghost brick where people look
//Remover uses the hammer model
//bricks they remove are the bricks they get
//players cannot build above 90 torque units up
//
//Do not package fxDTSBrick::onPlant
//Package servercmdplantbrick
//and to get torque units do
//
//getWord(%client.player.tempbrick.getPosition(), 2);
//
//%client.player.tempbrick.setDatablock()
//%client.player.tempbrick.getDatablock()

//-----------------------------------------
// REMOVER TOOL
//-----------------------------------------
datablock ProjectileData(PlasticRemoverProjectile : HammerProjectile)
{
   directDamage        = 0;
   directDamageType  = $DamageType::Hammer;
   radiusDamageType  = $DamageType::Hammer;
   explosion           = HammerExplosion;

   muzzleVelocity      = 200;
   velInheritFactor    = 1;

   armingDelay         = 0;
   lifetime            = 100;
   fadeDelay           = 70;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";
};

datablock ItemData(PlasticRemoverItem : HammerItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "Base/Data/Shapes/Hammer.dts";
	mass = 2;
	density = 1;
	elasticity = 0.1;
	friction = 0.9;
	emap = true;

	uiName = "Plastic Remover";
	iconName = "Base/Client/UI/ItemIcons/Hammer";
	doColorShift = true;
	colorShiftColor = "0.84 0.83 0.87 1";

	image = PlasticRemoverImage;
	canDrop = true;
};

datablock ShapeBaseImageData(PlasticRemoverImage : HammerImage)
{
   shapeFile = "Base/Data/Shapes/Hammer.dts";
   emap = true;
   mountPoint = 0;
   offset = "0 0 0";

   correctMuzzleVector = false;

   eyeOffset = "0.7 1.2 -0.25";
   className = "WeaponImage";
   ammo = " ";
   projectile = PlasticRemoverProjectile;
   projectileType = Projectile;
   showBricks = true;

   melee = true;
   doRetraction = false;
   armReady = true;

   doColorShift = true;
   colorShiftColor = PlasticRemoverItem.ColorShiftColor;
};

function PlasticRemoverProjectile::onCollision(%this, %object, %brick, %fade, %pos, %normal)
{
	if(%brick.getClassName() $= "fxDTSBrick" && %object.bricks < 30)
	{
		%client = %object.client;
		%brick.progress++;
		commandToClient(%client, 'centerPrint', "<color:ffffff><font:impact:30>Harvested <color:00ff00>" @ %brick.progress @ "/5 <color:FFFF00>Plastic<color:FFFFFF>.", 3);
		if(%brick.progress == 5)
		{
			%client.player.bricks++;
			for(%i = 1; %i < %client.player.bricks + 1; %i++)
			{
				if(%client.player.brick[%i] $= "")
				{
					%client.player.brick[%i] = %brick.getDatablock();
					break;
				}
			}
			%brick.delete();
		}
	}
	else
	{
		commandToClient(%object.client, 'centerPrint', "<color:FFFFFF>You cannot have more than 30 bricks in your inventory at a time!", 3);
	}
}
//-------------------------------------------------
//       PLANTER 
//------------------------------------------------
datablock ProjectileData(PlasticPlanterProjectile)
{
   directDamage        = 0;
   directDamageType  = $DamageType::Hammer;
   radiusDamageType  = $DamageType::Hammer;
   explosion           = HammerExplosion;

   muzzleVelocity      = 200;
   velInheritFactor    = 1;

   armingDelay         = 0;
   lifetime            = 100;
   fadeDelay           = 70;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = false;
   gravityMod = 0.0;

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";
};
datablock itemData(PlasticPlanterItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Plastic Planter";
	doColorShift = true;
	colorShiftColor = "0.12 0.15 0.13 1";
	
	image = PlasticPlanterImage;
	canDrop = true;
};

datablock ShapeBaseImageData(PlasticPlanterImage)
{
	projectile = PlasticPlanterProjectile;
	shapeFile = "base/data/shapes/brickweapon.dts";
	emap = true;
	mountPoint = 0;
	offset = "0 0 0";
	correctMuzzleVector = false;
	className = "WeaponImage";
	item = PlasticPlanterItem;
	ammo = " ";
	melee = true;
	doRetraction = false;
	armReady = true;
	doColorShift = true;
	colorShiftColor = "0.475 0.555 0.475 1.000";

	stateName[0]                   = "Activate";
	stateTimeoutValue[0]           = 0.5;
	stateTransitionOnTimeout[0]    = "Ready";
	stateSound[0]                  = weaponSwitchSound;

	stateName[1]                   = "Ready";
	stateTransitionOnTriggerDown[1]= "PreFire";
	stateAllowImageChange[1]       = true;

	stateName[2]                   = "PreFire";
	stateScript[2]                 = "onPreFire";
	stateAllowImageChange[2]       = false;
	stateTimeoutValue[2]           = 0.1;
	stateTransitionOnTimeout[2]    = "Fire";

	stateName[3]                   = "Fire";
	stateTransitionOnTimeout[3]    = "CheckFire";
	stateTimeoutValue[3]           = 0.3;
	stateFire[3]                   = true;
	stateAllowImageChange[3]       = false;
	stateScript[3]                 = "onFire";
	stateWaitForTimeout[3]         = true;

	stateName[4]                   = "CheckFire";
	stateTransitionOnTriggerUp[4]  = "StopFire";
	stateTransitionOnTriggerDown[4]= "PreFire";

	stateName[5]                   = "StopFire";
	stateTransitionOnTimeout[5]    = "Ready";
	stateTimeoutValue[5]           = 0.2;
	stateAllowImageChange[5]       = false;
	stateWaitForTimeout[5]         = true;
};

function makeTempBrick(%player, %pos)
{
	%player.tempbrick = new fxDTSBrick() {
	   position = %pos;
	   rotation = "0 0 1 180";
	   scale = "1 1 1";
	   dataBlock = "brick2x4Data";
	   angleID = "2";
	   colorID = "0";
	   printID = "0";
	   colorFxID = "0";
	   shapeFxID = "0";
	   isBasePlate = "0";
	   isPlanted = "0";
	   client = "-1";
	   stackBL_ID = "-1";
	};
}

function PlasticPlanterImage::onPreFire(%this, %obj, %slot)
{
	%obj.playthread(2, armattack);
	%obj.schedule(200, playthread, 2, root);
}
function PlasticPlanterProjectile::onCollision(%this,%obj,%col,%fade,%pos,%normal)
{
	if(%obj.bricks !$= "" && %obj.bricks > 0)
	{
		if(%obj.cbi $= "")
		{
			%obj.cbi = %obj.brick[1];
		}
		if(!isObject(%obj.tempbrick)
			makeTempBrick(%pos);
		%bN = %obj.cbi.uiName;
		%obj.tempbrick.setPosition(%pos);
		%obj.tempbrick.setDatablock(%obj.cbi);
		commandToClient(%obj.client, 'bottomPrint', "<color:FFFFFF>Brick Selected : <color:FFFF00>" @ %bN @ "<color:FFFFFF>. Right Click to switch.");
}

package nplantPkg
{
	function servercmdplantbrick(%client)
	{
		%p = %client.player;		
		if(%p.bricks $= "" && %p.bricks > 0)
		{
			for(%i = 1; %i < %p.bricks + 1; %i++)
			{
				%b = %p.brick[%i];
				if(%b == %p.tempbrick.getDatablock())
				{
					%p.brick[%i] = "";
					break;
				}
			}
			%p.bricks--;
			parent::servercmdplantbrick(%client);
		}
		else 
		{
			commandToClient(%client, 'centerPrint', "<color:FFFFFF>You have no plastic to build.", 3);
			return;
		}
	}
};
activatePackage(nplantPkg);

function serverCmdPlasticTrade(%client, %target, %plastic, %item, %way)
{
	if(isObject(findclientbyname(%target)) && %plastic > 0 && %item !$= "" && %client.bricks > 0 && !isObject(%client.trade) && !isObject(findclientbyname(%target).trade) && %item.uiName !$= "")
	{
		if(%way $= "pfi") //if the trade way is plastic for item
		{
			%t = findclientbyname(%target);
			%client.trade = new ScriptObject();
			%client.trade.with = %target;
			%client.trade.way = "pfi";
			%client.trade.plastic = %plastic;
			%client.trade.item = %item;
			%t.trade = new ScriptObject();
			%t.trade.with = %client;
			%t.trade.way = "ifp";
			%t.trade.plastic = %plastic;
			%t.trade.item = %item;
			%client.chatMessage("<color:FFFFFF>Your trade request has been sent.");
			%t.chatMessage("<color:FFFF00>" @ %client.name @ "<color:ffffff> wants to trade <color:FFFF00>" @ %plastic @ "<color:FFFFFF> plastic for a(n) <color:FFFF00>" @ %item.uiName @ "<color:FFFFFF>. Type /accepttrade to accept it.");
		}
		else if(%way $= "ifp")
		{
			%t = findclientbyname(%target);
			%client.trade = new ScriptObject();
			%client.trade.with = %target;
			%client.trade.way = "ifp";
			%client.trade.plastic = %plastic;
			%client.trade.item = %item;
			%t.trade = new ScriptObject();
			%t.trade.with = %client;
			%t.trade.way = "pfi";
			%t.trade.plastic = %plastic;
			%t.trade.item = %item;
			%client.chatMessage("<color:FFFFFF>Your trade request has been sent.");
			%t.chatMessage("<color:FFFF00>" @ %client.name @ "<color:ffffff> wants to trade a(n) <color:FFFF00>" @ %item.uiName @ "<color:FFFFFF> for <color:FFFF00>" @ %plastic @ "<color:FFFFFF> plastic. Type /accepttrade to accept it.");
		}
	}
}

function serverCmdAcceptTrade(%client)
{
	if(isObject(%client.trade))
	{
		if(%client.trade.way $= "pfi")
		{	
			%client.plastic = %client.plastic - %client.trade.plastic;
			%t = %client.trade.with;
			for(%i=0;%i<%t.player.getDatablock().maxTools+1;%i++)
			{
				if(%t.player.tool[%i] !$= "")
				{
					if(%t.player.tool[%i] == %client.trade.item)
					{
						%t.player.tool[%i] = "";
						break;
					}	
				}
			}
			for(%i=0;%i<%client.player.getDatablock().maxTools+1;%i++)
			{
				if(%client.player.tool[%i] $= "")
				{
					%client.player.tool[%i] = nameToId(%t.trade.item);
					messageClient(%client,'MsgItemPickup','',%i,nameToId(%t.trade.item));
					break;
				}
			}
			%client.trade.delete(); %t.trade.delete();
		}
	}
}
				
		
