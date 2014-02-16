new scriptObject(PacCityMini)
{
	class = miniGameSO;
    brickDamage = true;
	brickRespawnTime = 7000;
	colorIdx = -1;
	enableBuilding = true;
	enablePainting = true;
	enableWand = true;
	fallingDamage = true;
	inviteOnly = false;
	points_plantBrick = 0;
	points_breakBrick = 0;
	points_die = 0;
	points_killPlayer = 0;
	points_killSelf = 0;
	playerDatablock = playerNoJet;
	respawnTime = 0;
	selfDamage = true;
	playersUseOwnBricks = false;
	useAllPlayersBricks = true;
	useSpawnBricks = false;
	VehicleDamage = true;
	vehicleRespawnTime = 7000;
	weaponDamage = true;
	numMembers = 0;
	vehicleRunOverDamage = true;
};
function serverCmdcreateMiniGame(%client)
{
	messageClient(%client, '', "PacCity : You cannot do that");
}	
function serverCmdleaveMiniGame(%client)
{
	messageClient(%client, '', "PacCity : You cannot do that");
}
	