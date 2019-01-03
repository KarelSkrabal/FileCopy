Edgecam plugin pro kopirovani souboru vytvorenych v CAD/CAM Edgecam
------
Pamscl.cs -> cteni souboru pamscl.dat 
ECInfo.cs,FileReader.cs -> parsovani informaci nactenych z pamscl.dat
FileMover.cs -> kopirovani souboru do uloziste dle nastaveni ECSetting.json

Kompilace pro .Net 4, verze Edgecam 2016R2

Nezbytne knihovny :
------------------
Interop.Edgecam.dll
EdgecamPluginInterface.dll
Newtonsoft.Json.dll
