----------------------------------------
 Virtual Controls Suite for Unity
 © 2012 Bit By Bit Studios, LLC
 Use of this software means you accept the Unity provided license agreement.  
 Please don't redistribute without permission :)
---------------------------------------------------------------
Thanks very much for purchasing Virtual Controls Suite!

Please see the Virtual Controls Suite homepage listed below for an overview of the package
and links to all the items listed below.

Email: 		support@bitbybitstudios.com
Homepage:	http://bitbybitstudios.com/portfolio/virtual-controls-suite
Forums:		http://bitbybitstudios.com/forum/categories/virtual-controls-suite-support
Reference:	http://bitbybitstudios.com/docs/virtual-controls-suite/
Tutorials: 	http://bitbybitstudios.com/2012/06/tutorials/virtual-controls-suite-tutorials/

-----------------
 Importing / Updating VCS
-----------------------------

1. Unity: File > New Scene
2. Locate VCS in the Asset Store window, and import.

-----------------
 Using NGUI 
-----------------------------

VCS now includes the free "distributable" version of NGUI, located in this directory 
in the NGUI folder.  You may use the example prefabs and nguiSuite example scene
for already setup VCS controls.  If you have your own copy of NGUI, in a New Scene, 
you should delete the VCS supplied NGUI folder, and then import your NGUI package into the project.

-----------------
 Using EZGUI 
-----------------------------

If you would like to use EZGUI with VCS, you will need to obtain that package
separately in order for VCS to work with them.  Also, the ezguiSuite example
scene may not have its scripts linked properly when opening, due to the inability
to distribute EZGUI along with VCS.  You will need to relink scripts in the scene.

After importing the EZGUI package, you will need to edit 3 lines in the
file VCPluginSettings.cs in order to enable EZGUI and disable NGUI.
That file has more details, but you just need to look for something like this:

//==============
// EZGUI - change the #if true to: 
// #if false
// if you want to use EZGUI Virtual Controls
//==============

-----------------
 Note to JavaScript Users
-----------------------------
Please see this page for more info on how to use VCS with JavaScript:
http://bitbybitstudios.com/forum/discussion/1/virtual-controls-suite-faq#q1

-----------------
 Changelog
-----------------------------

1.3:
- Added deltaPosition property to VCTouchWrapper class.
- Added positionAtTouchLocationAreaMin and Max properties for VCAnalogJoystickBase.
- Added useLateUpdate property to VCAnalogJoystickBase.
- Added RequireExclusiveTouch property to VCAnalogJoystickBase.

1.2:
- Added distributable version of NGUI to package
- Added TapCount and OnDoubleTap callback to VCAnalogJoystickBase

1.1:
- Added debug keys to all controls, see video here: http://youtu.be/JByiuqGlYKE

1.0:
- Initial implementation