//Good. I took care of the %client.pay stuff in jobs.cs.
//Payments are at a request. You only can get it every 5 days.
function serverCmdgetPay(%client)
{
    if(%client.lastpay >= 5)
    {
        messageClient(%client,'','\c4%1 was put into your account.', %client.pay);
        %client.bank = %client.bank + %client.pay;
        %client.lastpay = 0;
    }
    else
    {
        messageClient(%client,'','\c4It was less than 5 days ago you got your paycheck. You have to wait longer.');
    }
}
function serverCmdgetPayTwo(%client)
{
    if(%client.jobs2 !$= "")
    {
        if(%client.lastpay2 >= 5)
        {
            messageClient(%client,'','\c4%1 was put into your account.', %client.pay2);
            %client.bank = %client.bank + %client.pay2;
            %client.lastpay2 = 0;
        }
        else
        {
            messageClient(%client,'','\c4It was less than 5 days ago you got your paycheck. You have to wait longer.');
        }
    }
}
function serverCmdgetPayThree(%client)
{
    if(%client.jobs3 !$= "")
    {
        if(%client.lastpay3 >= 5)
        {
            messageClient(%client,'','\c4%1 was put into your account.', %client.pay3);
            %client.bank = %client.bank + %client.pay3;
            %client.lastpay3 = 0;
        }
        else
        {
            messageClient(%client,'','\c4It was less than 5 days ago you got your paycheck. You have to wait longer.');
        }
    }
}




