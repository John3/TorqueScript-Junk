function makeGP()
{
       new fxPlane(groundPlane) {
       position = "0 0 -0.5";
       rotation = "1 0 0 0";
       scale = "1 1 1";
       topTexture = "Add-Ons/Ground_Plate/plate.png";
       bottomTexture = "Add-Ons/Ground_Plate/plate.png";
       loopsPerUnit = "2";
       scrollSpeed = "0.000000 0.000000";
       color = "0 128 64 255";
       rayCastColor = "128 128 128 255";
       blend = "0";
       additiveBlend = "0";
       colorMultiply = "0";
       isSolid = "1";
    };
}
package noGroundG
{
    function setGround(%file)
    {
        if(%file $= "Add-Ons/Ground_None/none.ground")
        {
            groundPlane.delete();
        }
        else
        {
            if(!isObject(groundPlane))
            {
                makeGP();
            }
        }
        parent::setGround(%file);
    }
};
activatePackage(noGroundG);


