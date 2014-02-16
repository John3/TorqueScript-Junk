registerOutputEvent(GameConnection,"r", 0, 1);
function GameConnection::r(%this)
{
	%this.spawnPlayer();
}