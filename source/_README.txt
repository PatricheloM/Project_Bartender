If you want to compile with mono you have to comment out a line in "ablak.Designer.cs" becouse mono can't compile .resx files.
This way the app won't have an icon but will work properly on Linux operating systems or WinCMD compilatons.

Line 163

Mono Download for both Windows and Linux: https://www.mono-project.com/download/stable/
Mono Guide: https://www.mono-project.com/docs/getting-started/mono-basics/

Note that the Linux version is not fully optimized.