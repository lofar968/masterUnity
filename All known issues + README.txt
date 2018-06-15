Controls: P to pause. Go into settings > controls to set everything else (reccomended settings from top down are: W S Q E M1 M2). In the first menu, you can toggle which opponent weapons (all are stationary and will just aim at the player) are active. Ship continues moving at whatever speed the accellerate key is lifted at.

Start on "StartingScene" to make sure ALL functionality is enabled.

To see how our AI is going to behave, just look at the flowcharts folder.

KNOWN ISSUES:
-HP doesn't work. Tried to program it, it failed. Should be able to figure it out, though
-AI is only partially programmed. It only does "Block A" from the flowcharts so far, and not perfectly at that.
>Player must stay still for Block A to actually finish
-There is no sound. The sound sliders work, but we don't have any SFX yet.
-The camera position and control could be better, but will take significant effort
-menus are a bit haphazard, not even properly centered at times.
-Pause screens are ugly.
>Last 2 don't apply to the main menu; once Kristian gets around to more menu design those will be fixed.
-Crosshair moves the wrong way on mouse movement, but otherwise behaves as expected
-Player can't shoot
>Not as if it matters with HP not working anyways
-Unity is occasionally stupid and just loses public variable data. Not much we can do about it, but it will be fixed in the built version.
-Controls and the like will not save in the built version. This will be easy to fix, at least (just need to add  line of code somewhere). 
-All UI elements look... wierd... if scaled at all. The current supported resolution is ~ 960 x 720. This will take about a week if not more to fix. (the res was judged based on Unity window size compared to moniter res)
-Blender to Unity importing issues don't allow us to use our best ships. Once this is fixed every ship is getting an upgrade.