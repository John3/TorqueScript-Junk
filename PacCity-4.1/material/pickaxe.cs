datablock ProjectileData(PacCityPickaxeProjectile)
{
   directDamage        = 500;
   directDamageType  = $DamageType::Hammer;
   radiusDamageType  = $DamageType::Hammer;

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

datablock ItemData(PacCityPickaxeItem)
{
	category = "Weapon";
	className = "Weapon";

	shapeFile = "Base/Data/Shapes/Hammer.dts";
	mass = 2;
	density = 1;
	elasticity = 0.1;
	friction = 0.9;
	emap = true;

	uiName = "PacCity Pickaxe";
	iconName = "Base/Client/UI/ItemIcons/Hammer";
	doColorShift = true;
	colorShiftColor = "1 0 0 1";

	image = PacCityPickaxeImage;
	canDrop = true;
};

datablock ShapeBaseImageData(PacCityPickaxeImage)
{
   shapeFile = "Base/Data/Shapes/Hammer.dts";
   emap = true;
   mountPoint = 0;
   offset = "0 0 0";

   correctMuzzleVector = false;

   eyeOffset = "0.7 1.2 -0.25";
   className = "WeaponImage";
   item = PacCityPickaxeItem;
   ammo = " ";
   projectile = PacCityPickaxeProjectile;
   projectileType = Projectile;
   showBricks = true;

   melee = true;
   doRetraction = false;
   armReady = true;

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.15;
	stateTransitionOnTimeout[0]      = "Ready";
	stateSound[0]                    = playerMountSound;

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "PreFire";
	stateAllowImageChange[1]         = true;

	stateName[2]					= "PreFire";
	stateScript[2]                  = "onPreFire";
	stateAllowImageChange[2]        = false;
	stateTimeoutValue[2]            = 0.1;
	stateTransitionOnTimeout[2]     = "Fire";

	stateName[3]                    = "Fire";
	stateTransitionOnTimeout[3]     = "CheckFire";
	stateTimeoutValue[3]            = 0.2;
	stateFire[3]                    = true;
	stateAllowImageChange[3]        = false;
	stateSequence[3]                = "Fire";
	stateScript[3]                  = "onFire";
	stateWaitForTimeout[3]			= true;

	stateName[4]					= "CheckFire";
	stateTransitionOnTriggerUp[4]	= "StopFire";
	stateTransitionOnTriggerDown[4]	= "Fire";

	
	stateName[5]                    = "StopFire";
	stateTransitionOnTimeout[5]     = "Ready";
	stateTimeoutValue[5]            = 0.2;
	stateAllowImageChange[5]        = false;
	stateWaitForTimeout[5]			= true;
	stateSequence[5]                = "StopFire";
	stateScript[5]                  = "onStopFire";
};

function PacCityPickaxeImage::onPreFire(%this, %obj, %slot)
{
	%obj.playthread(2, armattack);
}

function PacCityPickaxeImage::onStopFire(%this, %obj, %slot) 
{	
	%obj.playthread(2, root);
}
function PacCityPickaxeProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal) 
{
    if(%col.getClassName() $="fxDTSBrick") 
    {
        if(%col.getDatablock().typeOre || %col.getDatablock().typeSteel)
        {
            %gain = %col.getDatablock().material;
            %client = %obj.client;
            %client.material = %client.material + %gain;
            commandToClient(%client, 'centerPrint' , "<font:impact:38><color:00FF00>+" @ %gain @ "material.", 1);
        }
    }
}