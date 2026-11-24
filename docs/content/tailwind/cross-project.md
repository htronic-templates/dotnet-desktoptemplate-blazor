# Cross Project Use

In some cases you might want to use css files from one razor control library to another.  
Handling this via node packages is one approach which probably works better with hotreload.  
But if the end goal is to keep things within a dotnet project scoipe below is one possible workaround.

with the below example

  * ConsumerProject is the project running Tailwind.MSBuild  
  * ProviderProject is the project providing css files that ConsumerProj will use.

## ProviderProject

First we're going to setup a project that will provide css files across to the consumer project.  
Lets assume we have a collection of css files under a `styles/` directory within the project.  
We can add a section to the csproj project file that looks like this

```xml
<ItemGroup>
  <None Include="styles\**\*.css"
    Pack="true"
    PackagePath="contentFiles/any/any/styles/%(RecursiveDir)"
    PackageCopyToOutput="true"
    PackageFlatten="false"
    CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```

If we need to use this for both as a nuget package or as a referenced project.  
Then this approach covers both situations

## ConsumerProject

For the consumer project we're going to use a `Directory.Build.props` file.  
This will add a custom target to the project without having to edit the main .csproj file.

What the below target does

  * First it's set to run before BuildTailwind which is the Tailwind.MSBuild task
  * Next it builds a list of css files from ether nuget or referenced projects
  * It then copies those files into `obj/tailwind-importedlibs/` maintaining the directory layout

Note this doesn't work with hotreload  
also the css files need to be outside of the wwwroot directory

`Directory.Build.props`
```xml
<Project>
  
  <!-- Run before tailwind is called -->
  <Target Name="PrepareTailwindDependencies"
		  BeforeTargets="BuildTailwind">

	<!-- Destination directory for exported css files (obj/tw-css) -->
	<PropertyGroup>
	  <_TailwindCssDir>$(BaseIntermediateOutputPath)tailwind-importedlibs\</_TailwindCssDir>
	</PropertyGroup>
	
	<!-- Files from referenced source projects -->
	<MSBuild Projects="@(ProjectReference)"
             Targets="GetCopyToOutputDirectoryItems"
             BuildInParallel="false"
             SkipNonexistentTargets="true"
             Condition="'@(ProjectReference)' != ''">
	  <Output TaskParameter="TargetOutputs"
			  ItemName="_ReferencedContent" />
	</MSBuild>

	<!-- Files from NuGet contentFiles -->
	<ItemGroup>
	  <_NuGetCss Include="@(None)"
				 Condition="'%(None.Extension)' == '.css'
                          and $([System.String]::Copy('%(None.Identity)').Contains('contentFiles'))" />

	  <_NuGetCss Include="@(Content)"
				 Condition="'%(Content.Extension)' == '.css'
                          and $([System.String]::Copy('%(Content.Identity)').Contains('contentFiles'))" />
	</ItemGroup>

	<!-- Combine both sources -->
	<ItemGroup>
	  <_AllCss Include="@(_ReferencedContent)"
			   Condition="'%(Extension)' == '.css'" />
	  <_AllCss Include="@(_NuGetCss)" />
	</ItemGroup>

	<Message Text="Tailwind External CSS files: @(_AllCss)"
             Importance="high" />

	<!-- Ensure destination directory exists -->
	<MakeDir Directories="$(_TailwindCssDir)" />
	
	<!-- Copy CSS files into obj/tailwind-importedlibs/ -->
	<Copy SourceFiles="@(_AllCss)"
          DestinationFiles="@(_AllCss->'$(_TailwindCssDir)%(TargetPath)')"
          SkipUnchangedFiles="true"
          Condition="'@(_AllCss)' != ''" />
	
  </Target>
  
</Project>
```

## Referencing the copied files

Within the input file that Tailwind.MSBuild searches for  
(this is normally `Properties\tailwind.input.css`)

We can now import any css files we need
```css
@import "tailwindcss";
@import "../obj/tailwind-importedlibs/styles/test1.css";
@source "../";
```
