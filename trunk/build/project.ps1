properties{#misc
  $framework_dir = "$env:windir\microsoft.net\framework\v2.0.50727"
}  

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

