properties{#directories
	$project_name = "mo.money"
	$base_dir = new-object System.IO.DirectoryInfo $pwd
	$base_dir = $base_dir.Parent.FullName
	
	$product_dir = "$base_dir\product"
	$build_dir = "$base_dir\build"
	$build_tools_dir = "$build_dir\tools"
	$build_lib_dir = "$build_dir\lib"
	$build_resources_dir = "$build_dir\resources"
	$build_icons_dir = "$build_resources_dir\icons"
	$build_config_dir = "$build_dir\config"
	$build_compile_dir = "$build_dir\compile"
	
	$app_output = "$project_name.exe"
}	

properties {#load in the build utilities file
  . $build_dir\tools\psake\build_utilities.ps1
}

properties {#load in the file that contains the name for the project
	. .\project_test.ps1
#	. .\project_test_reports.ps1
#	. .\project_deploy.ps1
#	. .\project_install.ps1
#	. .\project_ci.ps1
	. .\local_properties.ps1
}

task default -depends init

task clean{
	taskkill /f /im:"$($local_settings.editor)" /FI 'STATUS eq RUNNING'
	remove-item $build_compile_dir -recurse -ErrorAction SilentlyContinue 
}

task init -depends clean {
	make_folder $build_compile_dir 
}

task app_compile -depends init {
#	invoke-item "$build_tools_dir\nant\nant.exe -nologo -buildfile:$build_dir\project.build compile"

#	dir -recurse $build_lib_dir\ *.dll | copy -destination $build_compile_dir
#	csc.exe /target:library /out:"$build_compile_dir/powershell_lib.dll" /recurse:"$product_dir\*.cs" /lib:"$build_compile_dir"

	$result = MSBuild.exe "$base_dir\solution.sln" /t:Rebuild /p:Configuration=Debug
	$script:product_outputs = get_file_names(get-childitem -path $product_dir -recurse -filter *.dll)
	$script:product_debug_outputs = get_file_names(get-childitem -path $product_dir -recurse -filter *.pdb)

	$result
}

task expand_template_file($files) {
  expand_all_template_files $files $local_settings
}

