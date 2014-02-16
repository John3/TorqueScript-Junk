package RTBColorManagerGameModeGui
{
    function GameModeGui::onWake(%this)
    {
        Parent::onWake(%this);

        if(isObject(RTBColorsetGameMode))
        {
            return;
        }

        %btn = new GuiBitmapButtonCtrl(GameModeGui_ChooseColorset)
        {
            profile = ImpactForwardButtonProfile;
            horizSizing = "relative";
            vertSizing = "relative";
            position = "0 31";
            extent = "160 31";
            command = "canvas.pushDialog(RTB_ColorManager);";
            text = "Colorset >>";
            bitmap = "base/client/ui/btnBlank";
            mcolor = "255 255 255 255";
        };
        GameModeGui.add(%btn);
    }
};
 activatePackage(RTBColorManagerGameModeGui);