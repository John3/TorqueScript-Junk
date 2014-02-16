//no jets at all
datablock PlayerData(PlayerSpeedsCO : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 0;
	maxBackwardSpeed = 0;
	maxSideSpeed = 0;

	maxForwardCrouchSpeed = 3.5;
	maxBackwardCrouchSpeed = 2;
	maxSideCrouchSpeed = 3;


	uiName = "Speeds_CrouchOnly";
	showEnergyBar = false;
};