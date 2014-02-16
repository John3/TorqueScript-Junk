messageAll('', '\c4Note : If you are the host, you will have to type /loadCalendar if you already have hosted this gamemode before or /newCalendar if you have not to start a time system.This only appears once - when you start your server.');
$PacCity::LoopVar::Days = 1;
function PacCity_LoopCalendar()
{
    schedule(300000, "", "PacCity_NewDay");
    schedule(300000, "", "PacCity_LoopCalendar");
}
PacCity_LoopCalendar();
$PacCity::Calendar::NewBlank = "";
$PacCity::Calendar::Day = 1;
$PacCity::Calendar::Month = 1;
$PacCity::Calendar::Year = 2011;
function serverCmdnewCalendar(%client)
{
    if(%client.isSuperAdmin)
    {
        export("$PacCity::Calendar::NewBlank", "config/server/PacCity/Calendar.dat");
        %file = new fileObject();
	    %file.openForWrite("config/server/PacCity/Calendar.dat");
        %file.writeLine($PacCity::Calendar::Day SPC $PacCity::Calendar::Month SPC $PacCity::Calendar::Year);
        messageAll('', '\c4Calendar System Created.');
        %file.close();
    }
}
function serverCmdloadCalendar(%client)
{
    %file = new FileObject();
	%file.openForRead("config/server/PacCity/Calendar.dat");
    %line = %file.readLine();
    $PacCity::Calendar::Day = getWord(%line, 0);
    $PacCity::Calendar::Month = getWord(%line, 1);
    $PacCity::Calendar::Year = getWord(%line, 2);
    messageAll('MsgAdminForce','\c4Loaded calendar file..');
    %file.deleteLine();
}
function PacCity_NewDay()
{
    $PacCity::Calendar::Day = $PacCity::Calendar::Day + 1;
    if($PacCity::Calendar::Day == 31)
    {
        if($PacCity::Calendar::Month == 12)
        {
            $PacCity::Calendar::Year = $PacCity::Calendar::Year + 1;
            $PacCity::Calendar::Month = 1;
            $PacCity::Calendar::Day = 1;
            messageAll('MsgAdminForce','\c4HAPPY NEW YEAR, EVERYONE! WHAT IS YOUR NEW YEARS RESOLUTION?');
            messageAll('MsgAdminForce','\c4Today is %1/%2/%3', $PacCity::Calendar::Month, $PacCity::Calendar::Day, $PacCity::Calendar::Year);
        }
    }
    else if($PacCity::Calendar::Day == 25)
    {
        if($PacCity::Calendar::Month == 12)
        {
            messageAll('MsgAdminForce','\c4Merry Christmas!');
            messageAll('MsgAdminForce','\c4Today is %1/%2/%3', $PacCity::Calendar::Month, $PacCity::Calendar::Day, $PacCity::Calendar::Year);
        }
    }
    else if($PacCity::Calendar::Day == 1)
    {
        if($PacCity::Calendar::Month == 4)
        {
            messageAll('MsgAdminForce','\c4April Fools! What joke will you play on your friends/family?');
            messageAll('MsgAdminForce','\c4Today is %1/%2/%3', $PacCity::Calendar::Month, $PacCity::Calendar::Day, $PacCity::Calendar::Year);
        }
    }
    else
    {
        messageAll('MsgAdminForce','\c4Today is %1/%2/%3', $PacCity::Calendar::Month, $PacCity::Calendar::Day, $PacCity::Calendar::Year);
    }
    %file = new fileObject();
	%file.openForWrite("config/server/PacCity/Calendar.dat");
    %file.writeLine($PacCity::Calendar::Day SPC $PacCity::Calendar::Month SPC $PacCity::Calendar::Year);
}    
