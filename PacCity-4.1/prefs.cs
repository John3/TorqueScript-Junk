$PacCity::Pref::StartingCash = 100;
$PacCity::Pref::ChangeWelcomeMessage = 1;
$PacCity::Pref::ChangeName = 1;
$PacCity::Pref::Crime = 1;
$PacCity::Slash = "36720925625";
if($PacCity::Pref::ChangeWelcomeMessage == 1)
{
    $Pref::Server::WelcomeMessage = "<color:00FF00> PacCity 3 Made by Pacnet2012 is running. Use /registerAccount to start playing or /loginAccount if you have been here before.";
    if($PacCity::Pref::ChangeName = 1)
    {
        $Pref::Server::Name = "PacCity (Like CityRPG)"; //"What the heck is that server?"
    }  
}
