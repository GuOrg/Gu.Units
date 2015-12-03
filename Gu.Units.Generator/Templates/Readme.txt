The T4 is really buggy but here goes:
1) Build, use GeneratorOnly if the real projects does not build due to previous failure.
2) Build > Transform All Templates.
3) This is the happy path. I often have to restart VS, reboot reinstall etc. Standard Windows procedures, to get it to generate.

Cleaning up here might be required:
%LOCALAPPDATA%\Microsoft\VisualStudio\14.0\ProjectAssemblies\
%LOCALAPPDATA%\assembly\dl3
%TEMP%