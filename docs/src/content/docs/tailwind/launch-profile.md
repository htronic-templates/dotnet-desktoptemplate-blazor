---
title: Tailwind Launch Profile
---

For Tailwind.MSBuild the tailwind executable doesn't always launch / run
when the app is being debugged, normally it just runs during a build if there have been file changes.

With the below example we're specifying `../DesktopTemplate2.App` as the directory of the project
that actually has Tailwind.MSBuild setup

## Example Launch Profile

To for it to launch in watch mode under visual studio
we can add a launch profile that looks like this

```json
    "Tailwind Watch": {
      "commandName": "Executable",
      "executablePath": "dotnet",
      "commandLineArgs": "msbuild ../DesktopTemplate2.App -target:BuildTailwind -property:Configuration=Debug -property:TailwindWatch=true",
      "workingDirectory": "$(ProjectDir)"
    }
```

The final launch profile will likely look like this for a project
```json
{
  "profiles": {
    "DesktopTemplate2.GUI.PhotinoX": {
      "commandName": "Project"
    },
    "Tailwind Watch": {
      "commandName": "Executable",
      "executablePath": "dotnet",
      "commandLineArgs": "msbuild ../DesktopTemplate2.App -target:BuildTailwind -property:Configuration=Debug -property:TailwindWatch=true",
      "workingDirectory": "$(ProjectDir)"
    }
  }
}
```
