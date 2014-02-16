//no jets at all
datablock PlayerData(PlayerSpeedsCR : PlayerStandardArmor)
{
	minJetEnergy = 0;
	jetEnergyDrain = 0;
	canJet = 0;

	maxForwardSpeed = 7;
	maxBackwardSpeed = 4;
	maxSideSpeed = 6;

	maxForwardCrouchSpeed = 70;
	maxBackwardCrouchSpeed = 40;
	maxSideCrouchSpeed = 60;


	uiName = "Speeds_CrouchRacer";
	showEnergyBar = false;
};