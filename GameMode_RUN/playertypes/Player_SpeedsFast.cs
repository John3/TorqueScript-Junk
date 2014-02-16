//no jets at all
datablock PlayerData(PlayerSpeedsF : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 70;
	maxBackwardSpeed = 40;
	maxSideSpeed = 60;

	maxForwardCrouchSpeed = 10;
	maxBackwardCrouchSpeed = 10;
	maxSideCrouchSpeed = 10;


	uiName = "Speeds_Fast";
	showEnergyBar = false;
};