$PacCity::SkyJail::Loopy = 1;
function PacCity_SkyJail(%criminalclient)
{
    commandToClient(%criminalclient,'playMusic',"Distort.ogg");
    messageClient(%criminalclient, '', '\c4Welcome to jail. Your new home for some time.');
    if($PacCity::Spawn::Jail !$= "")
    {
        %obj = $PacCity::Spawn::Jail;
        %dir = 1;
        %velocityop = 0;
        %client = %criminalclient;
        fxDTSbrick::setPlayerTransform(%obj,%dir,%velocityop,%client);   
    }
}
function PacCity_Arrest(%arrester, %criminal)
{
	%arresterclient = findclientbyname(%arrester);
	%criminalclient = findclientbyname(%criminal);
	if(%criminalclient.hits == 1)
	{
		%arresterclient.bank = %arresterclient + 100;
		%criminalclient.jailed = 1;
		PacCity_SkyJail(%criminalclient);
		if(%criminalclient.lawyer !$= "")
		{
			messageClient(%arresterclient, '', '\c4Okay. Your case has now been forwarded to %1 s lawyer.', %criminalclient.name);
			%criminallawyer = findclientbyname(%criminalclient.lawyer);
			messageClient(%criminalclient, '', '\c4Your lawyer is now going to court to lower your chances of being jailed.');
			messageClient(%criminallawyer, '', '\c4Okay. Your client %1 has been arrested for %2 hits. You can type /lawyer forwardcase judgename for the judge specified to review your case. By sending the case to a judge your client will be less likely to be jailed and this earns you 50 bucks. If the judge releases your client, you get 300 bucks ', %criminalclient.name, %criminalclient.hits);		
		}
    }
}
function PacCity_JudgeGetCase(%criminal, %lawyer, %judge)
{
    messageClient(%judge, '', '\c4You have recieved a case from lawyer %1. His/her client is %2. His/her client has %3 hits. Type /judge approve criminalsName to approve the case or to decline it do nothing.', %lawyer.name, %criminal.name, %criminal.hits);

}
function serverCmdlawyer(%client, %type, %victim)
{
    if(%client.job $= "Lawyer")
    {    
        if(%type $= "forwardcase")
        {
            %judge = findclientbyname(%victim);
            %lawyer = %client;
            %criminal = findclientbyname(%lawyer.lawyercl);
            if(%criminal.jailed == 1)
            {
                if(%judge.job $= "Judge")
                {
                    PacCity_JudgeGetCase(%criminal, %lawyer, %judge);
                    messageClient(%lawyer, '', '\c450 bucks was put into your account. If the judge approves the case you earn 300!');
                    %lawyer.bank = %lawyer.bank + 50;
                }
                else
                {
                    messageClient(%lawyer, '', '\c4That person is not the job Judge.');
                }
            }
            else
            {
                messageClient(%lawyer, '', '\c4Your client is not in jail.');
            }
        }
    }
    else
    {
        messageClient(%client, '', '\c4You are not the job Lawyer.');
    }
}
function serverCmdjudge(%client, %type, %target)
{
    if(%client.job $= "Judge")
    {
        if(%type $= "approve")
        {
            %criminal = findclientbyname(%target);
            if(%criminal.jailed == 1)
            {
                %criminal.jailed = 0;
                %criminal.player.kill("suicide");
                messageClient(%client, '', '\c4You are out of jail!');
            }
        }
    }
}
