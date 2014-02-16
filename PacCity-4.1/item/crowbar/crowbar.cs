datablock ProjectileData(PacCityCrowbarProjectile)
{
   directDamage        = 500;
   directDamageType  = $DamageType::Hammer;
   radiusDamageType  = $DamageType::Hammer;
   muzzleVelocity      = 170;
   velInheritFactor    = 1;
   armingDelay         = 0;
   lifetime            = 110;
   fadeDelay           = 60;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = false;
   gravityMod = 0.0;
   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 0 0.5";
};
function PacCityCrowbarProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
   if(%col.getClassName() $="fxDTSBrick")
   {
      %client = %obj.client;
      %col.fakeKillBrick();
      %client.hits = %client.hits + 1;
      commandToClient(%client, 'centerPrint', "\c4For vandalising property you get 1 hit.", 1);
   }
}
datablock ItemData(PacCityCrowbarItem)
{
    category = "Weapon";
    className = "Weapon";
    shapeFile = "Add-Ons/Gamemode_PacCity/item/crowbar/crowbar.dts";
    mass = 2;
    density = 1;
    elasticity = 0.1;
    friction = 0.9;
    emap = true;
    uiName = "PacCity Crowbar";
    doColorShift = true;
    colorShiftColor = "1 0 0 1";
    image = PacCityBatonImage;
    canDrop = true;
};
datablock ShapeBaseImageData(PacCityCrowbarImage)
{
   shapeFile = "Add-Ons/Gamemode_PacCity/item/crowbar/crowbar.dts";
   emap = true;
   mountPoint = 0;
   offset = "0 0 0";

   correctMuzzleVector = false;

   eyeOffset = "0.7 1.2 -0.25";
   className = "WeaponImage";
   item = PacCityCrowbarItem;
   ammo = " ";
   projectile = PacCityCrowbarProjectile;
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
function PacCityCrowbarImage::onPreFire(%this, %obj, %slot)
{
	%obj.playthread(2, armattack);
}

function PacCityCrowbarImage::onStopFire(%this, %obj, %slot)
{	
	%obj.playthread(2, root);
}