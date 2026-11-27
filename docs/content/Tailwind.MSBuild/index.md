---
icon: lucide/folder-kanban
---

# Tailwind.MSBuild

Tailwind.MSBuild is a dotnet library availble on NuGet

  * https://github.com/MJRasicci/Tailwind.MSBuild

It allows for the running of tailwind via the MSBuild system instead of using node packages.  
That being said it can be a bit fiddly when trying to use css files across from one project to another.  
I've included some details here on how to do that by using `Directory.Build.props`.  
Typically you want to use Tailwind.MSBuild on a single consuming project, with all other projects providing the source css if needed.
