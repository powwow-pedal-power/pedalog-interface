; This examples demonstrates how libusb's drivers
; can be installed automatically along with your application using an installer.
;
; Requirements: Inno Setup (http://www.jrsoftware.org/isdl.php)
;
; To use this script, do the following:
; - generate a setup package using inf-wizard and save the generated files to
;   "this folder\driver"
; - in this script replace <your_inf_file.inf> with the name of your .inf file
; - customize other settings (strings)
; - open this script with Inno Setup
; - compile and run

[Setup]
AppName = Pedalog Interface
AppVerName = Pedalog Interface
AppPublisher = Renewable Energy Innovation
AppPublisherURL = http://www.re-innovation.co.uk/
AppVersion = 0.1.0
DefaultDirName = {pf}\Pedalog Interface
DefaultGroupName = Renewable Energy Innovation
Compression = lzma
SolidCompression = yes
; Win2000 or higher
MinVersion = 5,5

; This installation requires admin priveledges.  This is needed to install
; drivers on windows vista and later.
PrivilegesRequired = admin

; "ArchitecturesInstallIn64BitMode=x64 ia64" requests that the install
; be done in "64-bit mode" on x64 & Itanium, meaning it should use the
; native 64-bit Program Files directory and the 64-bit view of the
; registry. On all other architectures it will install in "32-bit mode".
ArchitecturesInstallIn64BitMode=x64 ia64

; Inno pascal functions for determining the processor type.
; you can use these to use (in an inno "check" parameter for example) to
; customize the installation depending on the architecture. 
[Code]
function IsX64: Boolean;
begin
  Result := Is64BitInstallMode and (ProcessorArchitecture = paX64);
end;

function IsI64: Boolean;
begin
  Result := Is64BitInstallMode and (ProcessorArchitecture = paIA64);
end;

function IsX86: Boolean;
begin
  Result := not IsX64 and not IsI64;
end;

function Is64: Boolean;
begin
  Result := IsX64 or IsI64;
end;

[Files]
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\Pedalog_Interface.exe"; DestDir: "{app}"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\Pwpp.Pedalog.dll"; DestDir: "{app}"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\Pwpp.Pedalog.dll.config"; DestDir: "{app}"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\libpedalog.dll"; DestDir: "{app}"     
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\ZedGraph.dll"; DestDir: "{app}"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\de\*"; DestDir: "{app}\de"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\es\*"; DestDir: "{app}\es"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\fr\*"; DestDir: "{app}\fr"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\hu\*"; DestDir: "{app}\hu"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\it\*"; DestDir: "{app}\it"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\ja\*"; DestDir: "{app}\ja"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\pt\*"; DestDir: "{app}\pt"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\ru\*"; DestDir: "{app}\ru"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\sk\*"; DestDir: "{app}\sk"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\sv\*"; DestDir: "{app}\sv"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\tr\*"; DestDir: "{app}\tr"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\zh-ch\*"; DestDir: "{app}\zh-ch"
Source: "..\..\Pedal_Power_Interface_v2\bin\Debug\zh-tw\*"; DestDir: "{app}\zh-tw"

; copy your libusb-win32 setup package to the App folder
Source: "driver\*"; Excludes: "*.exe"; Flags: recursesubdirs; DestDir: "{app}\driver"

; also copy the native (32bit or 64 bit) libusb0.dll to the 
; system folder so that rundll32.exe will find it
Source: "driver\x86\libusb0_x86.dll"; DestName: "libusb0.dll"; DestDir: "{sys}"; Flags: uninsneveruninstall replacesameversion restartreplace promptifolder; Check: IsX86;
Source: "driver\amd64\libusb0.dll"; DestDir: "{sys}"; Flags: uninsneveruninstall replacesameversion restartreplace promptifolder; Check: IsX64;
Source: "driver\ia64\libusb0.dll"; DestDir: {sys}; Flags: uninsneveruninstall replacesameversion restartreplace promptifolder; Check: IsI64;

[Icons]
Name: "{group}\Pedalog Interface"; Filename: "{app}\Pedalog_Interface.exe"; WorkingDir: "{app}"
Name: "{group}\Uninstall Pedalog Interface"; Filename: "{uninstallexe}"

[Run]
; invoke libusb's DLL to install the .inf file
Filename: "rundll32"; Parameters: "libusb0.dll,usb_install_driver_np_rundll {app}\driver\Pedalog.inf"; StatusMsg: "Installing driver (this may take a few seconds) ..."

