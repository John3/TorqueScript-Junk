exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Bank.gui");
function clientCmdgetBankData(%client, %hand, %bank)
{
    //This mod was made for people to be able to learn scripting from it.
    //Client_CityRPG uses Datum.var which is fine but can be complex for learners so i will use get[GuiName]Data.
    //If you are learning from this script, you may want to open the gui in blockland and follow along with it.
    PACCITY_BANK_AMOUNT.setValue(%bank);
    PACCITY_BANK_HAND_AMOUNT.setValue(%hand);
}
function PACCITY::deposit(%gui)
{
    %deposit = PACCITY_BANK_DEPOSIT_AMOUNT.getValue();
    %hand = PACCITY_BANK_HAND_AMOUNT.getValue();
    %bank = PACCITY_BANK_AMOUNT.getValue();
    if(%deposit <= %hand)
    { 
        commandToServer("bank", "deposit", %deposit, %hand, %bank);
    }
    else
    {
        PACCITY.showError();
    }
}
function PACCITY::withdraw(%gui)
{
    %withdraw = PACCITY_BANK_WITHDRAW_AMOUNT.getValue();
    %hand = PACCITY_BANK_HAND_AMOUNT.getValue();
    %bank = PACCITY_BANK_AMOUNT.getValue();
    if(%withdraw <= %bank)
    { 
        commandToServer("bank", "withdraw", %withdraw, %hand, %bank);
    }
    else
    {
        PACCITY.showError();
    }
}
