//Pacnet2012
//I am too lazy to press SHIFT + TAB to see my messages. Let me help myself.
//Uhoh, any for loops with arrays don't work, I have to do this the slow way.
exec("./PacRTBPopup.gui");

package pacRtbMessage
{
   function RTBCC_Session::receive(%this,%message)
   {
   	   	parent::receive(%this,%message);
   		if(RTBCO_getPref("CC::Message::Note"))
   		{
   			if(!RTB_Overlay.isAwake())
   			{
   				%person = %this.user.name;
   				%talk = %message.find("body").cData;
                RTBCC_NotificationManager.push(%person, %talk,"comment_add",%this.user.id@"_msg",-1);
   			}
   		}
   }
};
activatePackage(pacRtbMessage);

