Controls: P to pause. Go into settings > controls to set everything else (reccomended settings from top down are: W S Q E M1 M2). In the first menu, you can toggle which opponent weapons (all are stationary and will just aim at the player) are active. Ship continues moving at whatever speed the accellerate key is lifted at.

Start on "StartingScene" to make sure ALL functionality is enabled.

To see how our AI is going to behave, just look at the flowcharts folder.

The playership's turn speed is set a bit low. If you go to (in the "test" scene, object list) Fighter > Ship Control Script > Turn speed, you can increase it. Set it to something like 75 or 85.

The standard gun (obj "Gun") may not be working. If this is true, go to it on the object list, and drag the "Bullet" object into the Bullet Firing Script's "Bullet" variable slot. If the bullets from any gun despawn too soon, go to that gun andup the "Bullet Lifetime" var.

Finally, in the case that the difference between the shotgun and carpet gun is hard to see, it is that the carpet gun has a much tighter spread with the same bullet count, but has one tight enough for the player to just fly perpendicular from it to escape. That will not work on the shotgun.

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
-Shotguns sometimes have wierd bullet patterns
>Probably caused by how we programed the rotation, as it is possible that the first rotation's effects could effect the second's in undesirable ways.