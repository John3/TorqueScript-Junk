//no jets at all
datablock PlayerData(PlayerSpeedsS : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 3.5;
	maxBackwardSpeed = 2;
	maxSideSpeed = 3;

	maxForwardCrouchSpeed = 1.75;
	maxBackwardCrouchSpeed = 1.5;
	maxSideCrouchSpeed = 1;


	uiName = "Speeds_Slow";
	showEnergyBar = false;
};