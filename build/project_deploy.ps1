properties{
	$assembly_config = "$build_config_dir\AssemblyInfo.cs"
	$log4net_config = "$build_config_dir\log4net.config.xml"
}	

task copy_app_dependencies {
}

task create_licenses -depends clean {

}

task deploy {

}

task run -depends deploy {

}
