exec("Add-Ons/Gamemode_PacCity/client/PACCITY_Status.gui");
function clientCmdgetStatusData(%client, %job, %hunger, %training, %age)
{
    //This mod was made for people to be able to learn scripting from it.
    //Client_CityRPG uses Datum.var which is fine but can be complex for learners so i will use get[GuiName]Data.
    //If you are learning from this script, you may want to open the gui in blockland and follow along with it.
    PACCITY_STATS_JOB.setValue(%job);
    PACCITY_STATS_HUNGER.setValue(%hunger);
    PACCITY_STATS_TRAINING.setValue(%training);
    PACCITY_STATS_AGE.setValue(%age);
}
//Nothing special here.