---
icon: lucide/folder-kanban
---

# Overview

This is just a collection of templates I use for desktop applications.  
In the case of the blazor blueprint ones, this is just a webview containing components from blazor blurpint ui.  
THen hosted ether as a PhotinoX desktop app (similar to Tauri or Electron), or hosted as a website.

## Layout

  * `TemplateName.App` - This is the main application razor control library  
    All the other projects are Frontends for this one
  * `TemplateName.GUI.PhotinoX` - Desktop Frontend
  * `TemplateName.GUI.WebWasm` - Web Assembly FrontEnd
  * `TemplateName.GUI.WebServer` - Web Server Frontend
  * `TemplateName.GUI.WebAuto` - Combination WebServer / Wasm Frontend
  * `TemplateName.GUI.WebAuto.Client` - Combination WebServer / Wasm Frontend

PhotinoX represents hosting the App contents as a desktop applications (similar to Electron).  
WebAuto initially loads a page to preview the page before the web assembly is fully loaded

## Libraries

PhotinoX is a frontend that allows desktop apps to be designed using blazor controls

  * https://github.com/ivanvoyager/PhotinoX
  * https://github.com/ivanvoyager/PhotinoX.Blazor

BlazorBlueprint is a UI component library that can use tweakcn themes

  * https://blazorblueprintui.com
