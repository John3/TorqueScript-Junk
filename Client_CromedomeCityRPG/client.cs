CromeAbout::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeAbout);
	}
}
CromeMain::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeMain);
	}
}
CromeReset::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeReset);
	}
}
CromeGiveCash::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeGiveCash);
	}
}
CromeReincarnate::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeReincarnate);
	}
}
CromeEducation::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeEducation);
	}
}
CromeJob::OnWake(%this)
{
	if($ServerInfo::Name $= "Cromedome's CityRPG")
	{
		return;
	}
	else
	{
		canvas.popDialog(CromeJob);
	}
}
function crome_givecash(%gui)
{
    schedule(5000, false, "crome_reallygivemoney", %gui);
}
function crome_reallygivecash(%gui)
{
    %amount = CROME_GIVEAMOUNT.getValue();
    commandToServer('givemoney', %amount);
}
function crome_applyjob(%gui)
{
    %job = CROME_APPLYJOB.getValue();
    commandToServer('job', %job);
}
$remapDivision[$remapCount] = "Cromedome's CityRPG";
$remapName[$remapCount] = "Main GUI";
$remapCmd[$remapCount] = "canvas.pushDialog(CromeMain)";
$remapCount++;
