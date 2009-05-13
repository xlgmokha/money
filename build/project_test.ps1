properties{
	$test_output = "$project_name.exe"
	$xunit_cons_exe = "$build_tools_dir/gallio/gallio.echo.exe"
}  

properties{#filesets
  $test_references_fileset = get_file_names(get-childitem -path $build_lib_dir -recurse -filter *.dll)
}

task test_copy_dependencies {
	#$test_references_fileset | foreach-object {copy-item -path $_ -destination $build_compile_dir}
	dir -recurse $build_lib_dir\ *.dll | copy -destination $build_compile_dir
}

task test_compile -depends init,test_copy_dependencies {
	$result = MSBuild.exe "$base_dir\solution.sln" /t:Rebuild /p:Configuration=Debug
	$script:product_outputs = get_file_names(get-childitem -path $product_dir -recurse -filter *.dll)
	$script:product_outputs | foreach-object {copy-item -path $_ -destination $build_compile_dir}
	$product_outputs | foreach-object { write-host "product output: $_" }

	$script:product_exes = get_file_names(get-childitem -path $product_dir -recurse -filter *.exe)
	$script:product_exes | foreach-object {copy-item -path $_ -destination $build_compile_dir}
	$product_exes | foreach-object { write-host "product exe: $_" }

	$script:product_debug_outputs = get_file_names(get-childitem -path $product_dir -recurse -filter *.pdb)
	$script:product_debug_outputs | foreach-object {copy-item -path $_ -destination $build_compile_dir}
	$product_debug_outputs | foreach-object { write-host "product debug: $_" }

	$result
}

task test -depends test_compile {
	$test_output = "$project_name.exe"

    $xunit_cons_exe = "$build_tools_dir/gallio/gallio.echo.exe"
    $result = .$xunit_cons_exe $build_compile_dir\$test_output /sr /rt:text /rd:$build_compile_dir
    $result
}

task test_html -depends test_compile { 
	$test_output = "$project_name.exe"

    $xunit_cons_exe = "$build_tools_dir/gallio/gallio.echo.exe"
    $result = .$xunit_cons_exe $build_compile_dir\$test_output /sr /rt:html /rd:$build_compile_dir
    $result

	$a = new-object -type system.media.soundplayer
	$a.soundlocation = "c:\windows\media\ringin.wav"
	$a.play()
}
