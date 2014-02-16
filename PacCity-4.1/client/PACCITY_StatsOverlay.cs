exec("Add-Ons/Gamemode_PacCity/client/PACCITY_StatsOverlay.gui");
function clientCmdUpdateStatsOverlay(%job, %cash, %bank, %food)
{
    canvas.pushDialog(PACCITY_StatsOverlay);
    PACCITY_OVERLAY_JOB.setValue(%job);
    PACCITY_OVERLAY_CASH.setValue(%cash);
    PACCITY_OVERLAY_BANK.setValue(%bank);
    PACCITY_OVERLAY_FOOD.setValue(%food);
}