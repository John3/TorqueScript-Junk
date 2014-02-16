//no jets at all
datablock PlayerData(PlayerSpeeds : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 7;
	maxBackwardSpeed = 4;
	maxSideSpeed = 6;

	maxForwardCrouchSpeed = 3.5;
	maxBackwardCrouchSpeed = 2;
	maxSideCrouchSpeed = 3;


	uiName = "Speeds_Standard";
	showEnergyBar = false;
};