# Tailwind Notes

## Consumer Project

Within the consumer project
to auto copy exported css files into an obj directory we can find them

this picks up project references and nuget packages

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
	  <_NuGetCss Include="@(Content)"
				 Condition="'%(Content.Extension)' == '.css'
                              and '%(Content.NuGetPackageId)' != ''" />
	</ItemGroup>

	<!-- Combine both sources -->
	<ItemGroup>
	  <_AllCss Include="@(_ReferencedContent)"
			   Condition="'%(Extension)' == '.css'" />
	  <_AllCss Include="@(_NuGetCss)" />
	</ItemGroup>

	<Message Text="CSS files: @(_AllCss)"
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

TODO

For the project the css is being pulled from
we can pack the css into the nuget package bundle

<ItemGroup>
    <Content Include="test1.css"
             Pack="true"
             PackagePath="contentFiles/any/any/"
             PackageCopyToOutput="true"
             CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
