//External - brickBot Events
//by Pacnet2013 (22696)
//Allows you to use Bot Hole events from other bricks and without using [input] > Bot > [blah]

//registerOutputEvent("CLASS NAME", "FUNCTION", "argumenttype BOUNDS OR SETTINGS	argumenttype BOUNDS OR SETTINGS	...", APPENDCLIENT)


//BOT relation to BRICK : BRICK.hBOT
function fxDTSBrick::bLookAtPlayer(%object,%opt,%client) //done
{
	// Bot,"LookAtPlayer","list Clear 0 Activator 1 Closest 2 Reset 3", 1 
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.lookAtPlayer(%bot,%opt,%client);
	}
}

function fxDTSBrick::bLookAtBrick(%object, %target) //done
{
	//Bot,"LookAtBrick","string 20 100"
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.lookAtBrick(%bot,%target);
	}
}

function fxDTSBrick::bGoToBrick(%object, %target) //done
{
	//Bot,"GoToBrick","string 20 100"
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.GoToBrick(%bot,%target);
	}
}

function fxDTSBrick::bSetPowered(%object, %list) //done
{
	//Bot, "SetBotPowered", "list Off 0 On 1 Reset 2", 0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setBotPowered(%bot,%list);
	}
}

function fxDTSBrick::bSetRunSpeed(%object, %speed) //done
{
	//Bot, "SetRunSpeed", "float 0.2 1.0 0.05 1.0", 0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setRunSpeed(%bot,%speed);
	}
}
//----------------------------------------------------
function fxDTSBrick::bPlayGesture(%object, %list)
{
	//AlreadyRegistered
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.playGesture(%bot,%list);
	}
}

function createExtGestureList()
{
	%count = -1;
	$hBotGest = "";
	$holeBotGestures = "";
	%list[%count++] = "Ani_activate2 2";
	%list[%count++] = "Ani_rotccw 3";
	%list[%count++] = "Ani_undo 4";
	%list[%count++] = "Ani_wrench 5";
	%list[%count++] = "Ani_talk 6";
	%list[%count++] = "Ani_head 7";
	%list[%count++] = "Ani_headReset 8";

	%list[%count++] = "Mov_activate 1";
	%list[%count++] = "Mov_attack 9";
	%list[%count++] = "Mov_sit 10";
	%list[%count++] = "Mov_crouch 11";
	%list[%count++] = "Mov_jump 12";
	%list[%count++] = "Mov_jet 13";

	%list[%count++] = "Emo_alarm 14";
	%list[%count++] = "Emo_love 15";
	%list[%count++] = "Emo_hate 16";
	%list[%count++] = "Emo_confusion 17";
	%list[%count++] = "Emo_bricks 18";

	%list[%count++] = "Arm_ArmUp 19";
	%list[%count++] = "Arm_BothArmsUp 20";
	%list[%count++] = "Arm_ArmsDown 21";

	%total = 0;
	// %count = $hBotGest;
	%catList = "";
	for(%a = 0; %a <= %count; %a++)
	{
		// %gesture = $holeBotGestures[%a];
		%gesture = %list[ %a ];
		
		%nGest = getWord( %gesture, 1 );
		
		%preGest = strreplace(%gesture,"_"," ");
		%preGest = getWord(%preGest,1);
	
		// add to our working list
		$hBotGest++;
		$holeBotGestures[ %nGest ] = %preGest;
		
		%catList = %catList SPC %gesture;// SPC %total++;
	}

	%fList = "Root 0" @ %catList;
	//registerOutputEvent(Bot, "SetBotDataBlock", list SPC %fList, 0);
	
	if( $pref::server::isDebugCrap )
		echo(%fList);
		
	registerOutputEvent(fxDTSBrick, "bPlayGesture", list SPC %fList, 0);
}
//---------------------------------------------------------------
function fxDTSBrick::bSetDatablock(%object, %list) //done
{
	//Bot, "setBotDataBlock", "datablock PlayerData", 0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setBotDataBlock(%bot,%list);
	}
}

function fxDTSBrick::bSetActivateDirection(%object, %dir) //done
{
	//Bot,"SetActivateDirection","list Both 0 Front 1 Back 2"
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setActivateDirection(%bot,%dir);
	}
}
//----------------------------------------------------------------
function hCreateExtSearchList()
{
	$HBSE = -1;
	$hBotSearchEvent[$HBSE++] = "Off";
	$hBotSearchEvent[$HBSE++] = "Only_React";
	$hBotSearchEvent[$HBSE++] = "AlwaysFindPlayer";
	$hBotSearchEvent[$HBSE++] = "FOV------>";
	$hBotSearchEvent[$HBSE++] = "Radius--->";
	%count = $hBSE;
	%list = $hBotSearchEvent[0] SPC 0;
	for(%a = 1; %a <= %count; %a++)
	{
		%gesture = $hBotSearchEvent[%a];

		%list = %list SPC %gesture SPC %a;
	}
	
	if( $pref::server::isDebugCrap )
		echo(%list);
		
	registerOutputEvent(fxDTSBrick, "bSetSearchRadius", list SPC %list TAB "int 0 1024 32" , 0);
}

function fxDTSBrick::bSetSearchRadius(%object, %list, %radius)
{
	//AlreadyRegistered
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.SetSearchRadius(%bot,%list,%radius);
	}
}
//--------------------------------------------------------------------
$hBIE = -1;
$hBotIdleEvent[$hBIE++] = "Off";
$hBotIdleEvent[$hBIE++] = "On";
$hBotIdleEvent[$hBIE++] = "Anim_Off";
$hBotIdleEvent[$hBIE++] = "Anim_On";
$hBotIdleEvent[$hBIE++] = "Emote_Off";
$hBotIdleEvent[$hBIE++] = "Emote_On";
$hBotIdleEvent[$hBIE++] = "Look_Off";
$hBotIdleEvent[$hBIE++] = "Look_On";
$hBotIdleEvent[$hBIE++] = "Spam_Off";
$hBotIdleEvent[$hBIE++] = "Spam_On";
// $hBotIdleEvent[$hBIE++] = "SpasLook_Off";
// $hBotIdleEvent[$hBIE++] = "SpasLook_On";

function hCreateExtIdleList()
{
	%count = $hBIE;
	%list = $hBotIdleEvent[0] SPC 0;
	for(%a = 1; %a <= %count; %a++)
	{
		%gesture = $hBotIdleEvent[%a];

		%list = %list SPC %gesture SPC %a;
	}
	
	if( $pref::server::isDebugCrap )
		echo(%list);
		
	registerOutputEvent(fxDTSBrick, "bSetIdleBehavior", list SPC %list, 0);
}

function fxDTSBrick::bSetIdleBehavior(%object, %list)
{
	//AlreadyRegistered
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setIdleBehavior(%bot,%list);
	}
}
//-----------------------------------------------------------------------------
$hBWE = -1;
$hBotWanderEvent[$hBWE++] = "Off";
$hBotWanderEvent[$hBWE++] = "StayAtSpawn";
$hBotWanderEvent[$hBWE++] = "Grid------>";
$hBotWanderEvent[$hBWE++] = "Grid_Infinite";
$hBotWanderEvent[$hBWE++] = "Distance-->";
$hBotWanderEvent[$hBWE++] = "Distance_Infinite";

function hCreateExtWanderList()
{
	%count = $hBWE;
	%list = $hBotWanderEvent[0] SPC 0;
	for(%a = 1; %a <= %count; %a++)
	{
		%gesture = $hBotWanderEvent[%a];

		%list = %list SPC %gesture SPC %a;
	}
	
	if( $pref::server::isDebugCrap )
		echo(%list);
		
	registerOutputEvent(fxDTSBrick, "bSetWanderDist", list SPC %list TAB "int 8 1024 64", 0);
}

function fxDTSBrick::bSetWanderDist(%object, %list, %radius)
{
	//AlreadyRegistered
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setWanderDistance(%bot,%list,%radius);
	}
}
//---------------------------------------------------------------------------------
function fxDTSBrick::bDropItem(%object, %dataBlock, %per) //done
{
	//Bot,"DropItem", "dataBlock itemData" TAB "float 0 100 5 100", 0)
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.dropItem(%bot,%dataBlock,%per);
	}
}

function fxDTSBrick::bSetItem(%object, %item) //done
{
	//Bot,"SetWeapon", "dataBlock itemData",0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setWeapon(%bot,%item);
	}
}

function fxDTSBrick::bSetName(%object, %name) //done
{
	//Bot,"SetBotName","string 20 100"
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setBotName(%bot,%name);
	}
}

function fxDTSBrick::bSetTeam(%object, %list, %custom) //done
{
	//Bot,"SetTeam","list Enemy 0 Neutral 1 Friendly 2 Mercenary 3 Owner 4 Custom 5" TAB "string 20 100"
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setTeam(%bot,%list,%custom);
	}
}

function fxDTSBrick::bSetMeleeDamage(%object, %dmg) //done
{
	//Bot,"SetMeleeDamage", "int 0 1024 15", 0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setMeleeDamage(%bot,%dmg);
	}
}

function fxDTSBrick::bRandomAppearance(%object, %style) //done
{
	//Bot, "SetRandomAppearance", "List City 0 Space 1",0 
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setRandomAppearance(%bot,%style);
	}
}

function fxDTSBrick::bSetAppearance(%object, %list, %body, %colorA, %colorB) //done
{
	//Bot, "SetAppearance", "list Blockhead 0 Caveman 1 Cop 2 Criminal 3 Nazi 4 Zombie 5 Custom 6" TAB "string 200 19" TAB "string 200 19 0" TAB "string 200 19 0",0
	%bot = %object.hBot;
	if(%bot.getClassName() $= "AIPlayer")
	{
		%bot.setRandomAppearance(%bot,%list,%body,%colorA,%colorB);
	}
}

//-------------------------------------------------------------------------------
//                  REGISTER EVENTS
registerOutputEvent(fxDTSBrick,"bLookAtPlayer","list Clear 0 Activator 1 Closest 2 Reset 3",1);
registerOutputEvent(fxDTSBrick,"bLookAtBrick","string 20 100",0);
registerOutputEvent(fxDTSBrick,"bGoToBrick","string 20 100",0);
registerOutputEvent(fxDTSBrick,"bSetBotPowered","list Off 0 On 1 Reset 2",0);
registerOutputEvent(fxDTSBrick,"bSetRunSpeed","float 0.2 1.0 0.05 1.0",0);
registerOutputEvent(fxDTSBrick,"bSetDataBlock","datablock PlayerData",0);
registerOutputEvent(fxDTSBrick,"bSetActivateDirection","list Both 0 Front 1 Back 2",0);
registerOutputEvent(fxDTSBrick,"bDropItem","dataBlock itemData" TAB "float 0 100 5 100",0);
registerOutputEvent(fxDTSBrick,"bSetItem","dataBlock itemData",0);
registerOutputEvent(fxDTSBrick,"bSetName","string 20 100",0);
registerOutputEvent(fxDTSBrick,"bSetTeam","list Enemy 0 Neutral 1 Friendly 2 Mercenary 3 Owner 4 Custom 5" TAB "string 20 100",0);
registerOutputEvent(fxDTSBrick,"bSetMeleeDamage","int 0 1024 15", 0);
registerOutputEvent(fxDTSBrick,"bRandomAppearance","List City 0 Space 1",0); 
registerOutputEvent(fxDTSBrick,"bSetAppearance", "list Blockhead 0 Caveman 1 Cop 2 Criminal 3 Nazi 4 Zombie 5 Custom 6" TAB "string 200 19" TAB "string 200 19 0" TAB "string 200 19 0",0);
//-----------------------------------------------------------------------------------
