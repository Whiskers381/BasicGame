**
-XmlLoad needs to be changed to implement the singleten patttern to allow all classes access if they need more data down the line(This will become apparent when multiplayer becomes a thing)

-PlayerCharactor needs to control it's own instances much like a singleten so that multiplayer can more easily be implemented
**

-Fuck art(It's an afterthought just make everything plain colored rectangles for now)

-Dev enviroment will be a thing so don't bother makeing maps unless you hate yourself

-Xml conversion will be handled by James W so no one worry about just throwing things you make all over the place

--Levels will be stored in xml and have links to the next level and the coordinets that it will switch at. This allows for easy linear or complex map design without much extra effort.

--There will be a main XML file that has a cache of the sprite info much like the setup of FMEA for the FaultTree project