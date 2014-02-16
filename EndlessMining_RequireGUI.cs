package johnDoe 
{
	function gameconnection::OnClientEnterGame(%this,%obj,%a,%b,%c,%d,%e)
	{
		if(%client.GUI != 1)
            	{
                	%client.delete("You need the Endless Mining client. Click <a:furlingaddons.freeforums.org/download/file.php?id=82>this link</a> to download it.");
            	}
		Parent::OnClientEnterGame(%this,%a,%b,%c,%d,%e);
	}
};
activatePackage(johnDoe);
