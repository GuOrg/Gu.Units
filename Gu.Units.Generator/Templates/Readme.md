# Code generation
The code generation uses the contents of GeneratorSettings.xml.
The preferred way to edit this file is by running the Gu.Units.Generator WPF project.
By inputting units this way all needed operator overloads are calculated.

When you are happy with the units and quantities it is T4 time:
1) Build, use GeneratorOnly if the real projects does not build due to previous failure.
2) Build > Transform All Templates. You should see all templates open and close in VS if things go well.
   Also check the diff that the templates generated correct code.
3) This is the happy path. I often have to restart VS, reboot reinstall etc. Standard Windows procedures, to get it to generate.

The T4 is really buggy and I'm not even sure it is deterministic.

Cleaning up here might be required:
%LOCALAPPDATA%\Microsoft\VisualStudio\14.0\ProjectAssemblies\
%LOCALAPPDATA%\assembly\dl3
%TEMP%