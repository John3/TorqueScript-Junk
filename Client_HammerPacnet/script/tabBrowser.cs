//----------------------------------------
//PACNET2013 SCRIPTS blid 22696
//----------------------------------------

//STATS Tab notes - add support (exceptions) for other tabs made
//exceptions : stats admin
function statsTab(%this)
{
    if(TabStats.visible == false)
    {
        //EXCEPTIONS GO HERE
        TabACP.visible = false;
        adminTabButton.color = "184 184 184 255";
        //----------------THE ACTUAL TAB
        TabStats.visible = true;
        statsTabButton.color = "0 184 246 255";
    }
}
               