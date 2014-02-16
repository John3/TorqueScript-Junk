//no jets at all
datablock PlayerData(PlayerSpeedsSF : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 140;
	maxBackwardSpeed = 80;
	maxSideSpeed = 120;

	maxForwardCrouchSpeed = 25;
	maxBackwardCrouchSpeed = 25;
	maxSideCrouchSpeed = 25;


	uiName = "Speeds_SuperFast";
	showEnergyBar = false;
};