//Client sided version of time.cs for paycheck counters and birthdays
$PacCity::Loop::ClientTime = 1;
function PacCity_ClientTime(%client)
{
    schedule(300000, "", "PacCity_PayCounter", %client);
    schedule(300000, "", "PacCity_PassHunger", %client);
    schedule(300000, "", "PacCity_BirthdayCheck", %client);
    schedule(2000, "", "PacCity_UpdateOverlay", %client);
    schedule(2000, "", "PacCity_noVehi", %client);
    schedule(2000, "", "PacCity_ClientTime", %client);
}
function PacCity_Debouncer(%debounce)
{
    %debounce = 0;
}
function PacCity_UpdateOverlay(%client)
{
    %job = %client.job;
    %cash = %client.hand;
    %bank = %client.bank;
    %food = %client.hunger;
    commandToClient(%client, "UpdateStatsOverlay",%job, %cash, %bank, %food);
}
function PacCity_PassHunger(%client)
{   
    %client.hits = %client.hits - 1;
    %client.hunger = %client.hunger - 10;
    if(%client.hunger == 0)
    {
        %client.player.kill("suicide");
        messageClient(%client,'','\c4You were too hungry.');
    }
}
function PacCity_PayCounterOne(%client)
{
    %client.lastpay = %client.lastpay + 1;
    messageClient(%client,'','\c4Alright, it has been %1 days since your last payment.', %client.lastpay);
    if(%client.lastpay >= 5)
    {
        commandToClient(%client, 'centerPrint' , "\c6Alert : It has been 5 or more days since your last payment! You should go type /getPay before you lose your paycheck !!", 3);
    }   
}
function PacCity_PayCounterTwo(%client)
{
    if(%client.pay2 != 0)
    {
        %client.lastpay2 = %client.lastpay2 + 1;
        messageClient(%client,'','\c4Alright, it has been %1 days since your last payment on job slot two.', %client.lastpay2);
        if(%client.lastpay2 >= 5)
        {
            commandToClient(%client, 'centerPrint' , "\c6Alert : It has been 5 or more days since your last payment! You should go type /getPayTwo before you lose your paycheck !!", 3);
        }
    }
}
function PacCity_PayCounterThree(%client)
{
    if(%client.pay3 != 0)
    {
        %client.lastpay3 = %client.lastpay3 + 1;
        messageClient(%client,'','\c4Alright, it has been %1 days since your last payment on job slot three.', %client.lastpay3);
        if(%client.lastpay3 >= 5)
        {
            commandToClient(%client, 'centerPrint' , "\c6Alert : It has been 5 or more days since your last payment! You should go type /getPayThree before you lose your paycheck !!", 3);
        }
    }
}
function PacCity_BirthdayCheck(%client)
{
    if($PacCity::Calendar::Day == %client.birthday)
    {
        if($PacCity::Calendar::Month == %client.birthmonth)
        {
            %client.age = %client.age + 1;
            %client.bank = %client.bank + 100;
            commandToClient(%client, 'centerPrint' , "\c6Alert : It's your birthday! 100 bucks has been deposited in your account!", 3);
            messageAll('MsgAdminForce','\c4It is %1 s birthday! he/she has turned %2 ! ', %client.name, %client.age);
        }
    }
}
   