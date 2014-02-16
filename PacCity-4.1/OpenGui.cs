function serverCmdOpenGui(%client)
{
    commandToClient(%client, "OpenGui");
}
function serverCmdOpenBank(%client)
{
    %hand = %client.hand;
    %bank = %client.bank;
    %type = "bank";
    commandToClient(%client, "OpenGuiTwo", %type);
    commandToClient(%client, "getBankData", %hand, %bank);
}
function serverCmdOpenPd(%client)
{
    %hits = %client.hits;
    %jailed = %client.jailed;
    %type = "pd";
    commandToClient(%client, "OpenGuiTwo", %type);
    commandToClient(%client, "getPdData", %hits, %jailed);
}
function serverCmdOpenStats(%client)
{
    %job = %client.job;
    %hunger = %client.hunger;
    %training = %client.training;
    %age = %client.age;
    %type = "status";
    commandToClient(%client, "OpenGuiTwo", %type);
    commandToClient(%client, "getStatusData", %job, %hunger, %training, %age);
}
