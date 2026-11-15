# Tailwind Notes

## Consumer Project

Within the consumer project
to auto copy exported css files into an obj directory we can find them

this picks up project references and nuget packages
make sure css is under something other than wwwroot
such as styles\

Also this won't work with hotreload

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

## Nuget Packages

For the project the css is being pulled from
we can pack the css into the nuget package bundle

  <ItemGroup>
	<None Include="styles\**\*.css"
		  Pack="true"
		  PackagePath="contentFiles/any/any/styles/%(RecursiveDir)"
		  PackageCopyToOutput="true"
		  PackageFlatten="false"
		  CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

## TODO

when debugging Tailwind.MSBuild doesn't always run without cleaning first?
I don't think it's any of the custom xml I'm using

seems to build twice but not a third time?
