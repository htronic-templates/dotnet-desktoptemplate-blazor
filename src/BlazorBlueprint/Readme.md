# Readme

This is a collection of templates using BlazorBlueprint UI and PhotinoX.Blazor.  
That can ether be hosted as a desktop or web application

## templates

  * Desktop1 - Simple Desktop App as a starting point
  * Desktop2 - This is a copy of the BlazorBlueprint UI Demo

Desktop1 uses Tailwind.MSBuild.  
Dekstop2 uses instead a locally run copy of Tailwind in the same way as the original demo code.

## Layout

  * TemplateName.App - This is the main application razor control library  
    All the other projects are Frontends for this one
  * TemplateName.GUI.PhotinoX - Desktop Frontend
  * TemplateName.GUI.WebWasm - Web Assembly FrontEnd
  * TemplateName.GUI.WebServer - Web Server Frontend
  * TemplateName.GUI.WebAuto - Combination WebServer / Wasm Frontend
  * TemplateName.GUI.WebAuto.Client - Combination WebServer / Wasm Frontend

PhotinoX represents hosting the App contents as a desktop applications (similar to Electron).  
WebAuto initially loads a page to preview the page before the web assembly is fully loaded

## Libs

PhotinoX is a frontend that allows desktop apps to be designed using blazor controls

  * https://github.com/ivanvoyager/PhotinoX
  * https://github.com/ivanvoyager/PhotinoX.Blazor

BlazorBlueprint is a UI component library that can use tweakcn themes

  * https://blazorblueprintui.com
