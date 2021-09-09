$appNameShort = "ALL-I"
$lastVersion = "2_1_0_2"

$path = "C:\inetpub\wwwroot\$appNameShort"
Set-Location -Path $path 

$appName = "$appNameShort.application"
$version = $lastVersion.Replace("_", ".")
$folderSegment = "Application Files\$appNameShort" + "_$lastVersion"

$deploymentApplicationPath = "$path\$folderSegment\$appNameShort.application"
$deploymentManifestRelativePath = "$folderSegment\$appNameShort.exe.manifest"
$deploymentManifestPath = "$path\$deploymentManifestRelativePath"

$appApplicationPath = "$path\$appName"
$certFilePath = "$path\MAGE\ALL-I_Key.pfx"
$certPassword= "123456"

$mage = "$path\MAGE\mage.exe"

$setupPath = "$path\setup.exe"
$publishUrl= "http://$env:computername/$appNameShort"
$url  = "$publishUrl/$appName"

#########################################################################################
# Get the application manifest directory name and application manifest file name.
# [xml]$doc = Get-Content $appName
# $ns = New-Object Xml.XmlNamespaceManager $doc.NameTable
# $ns.AddNamespace( "asmv1", "urn:schemas-microsoft-com:asm.v1" )
# $ns.AddNamespace( "asmv2", "urn:schemas-microsoft-com:asm.v2" )
# $xpath = "/asmv1:assembly/asmv2:dependency/asmv2:dependentAssembly" 
# $deploymentManifestRelativePath = $doc.SelectSingleNode( $xpath, $ns ).codebase # Example: = "Application Files\ALL-I_2_1_0_2\ALL-I.exe.manifest"
# $position = $deploymentManifestRelativePath.LastIndexOf('\');
# $appManifestDir = $deploymentManifestRelativePath.SubString(0, $position); # Example: "Application Files\ALL-I_2_1_0_2"
# $appManifestFile = $deploymentManifestRelativePath.SubString($position + 1); # Example: "ALL-I.exe.manifest"

##### 1 remove all .deploy extensions
write-host "renaming all .deploy files to remove deploy extension"
#Need to resign the application manifest, but before we do we need to rename all the files back to their original names (remove .deploy)
Get-ChildItem "$path\$folderSegment\*.deploy" -Recurse | Rename-Item -NewName { $_.Name -replace '\.deploy','' }
##METODO ALTERNATIVO
##Set-Location $path\$folderSegment
##Get-ChildItem -Include *.deploy -Recurse | Rename-Item -NewName { [System.IO.Path]::ChangeExtension($_.Name, "") }

##### 2 set properties on the application manifest file ( NON DOVREI TOCCAR NULLA)
#########################################################################################
# Modify the XML in the app.config file per your needs (e.g. change the connectionStrings)
##[xml]$doc = Get-Content $appName

##$node = $doc.SelectSingleNode("deployment/deploymentProvider/add[@name='$ConnStringName']")
##$node.connectionString = $ConnStringValue

##$xmldocPath = $PWD.ProviderPath # hack to avoid getting the silly namespace prefixed to the path for UNC paths
##$doc.Save("$xmldocPath\$appName") # For some reason, seems to require the fully qualified path


##### 3 update application manifest file directly
& "$mage" -Update "$deploymentManifestPath" -CertFile "$certFilePath" -Password $certPassword


##### 4 set properties on .application file
write-host "Running: $mage -Update $appApplicationPath -ProviderUrl $url"
& "$mage" -Update "$appApplicationPath" -ProviderUrl $url
write-host "Running: $mage -Update $deploymentApplicationPath -ProviderUrl $url"
& "$mage" -Update "$deploymentApplicationPath" -ProviderUrl $url


##### 5 update .application file directly
write-host "Running: $mage -Update $appApplicationPath -AppManifest $deploymentManifestRelativePath"
& "$mage" -Update "$appApplicationPath" -AppManifest "$deploymentManifestRelativePath"


##### 6 sign application manifest ( NON DOVREBBE SERVIRE MA LO FACCIO LO STESSO)
write-host "Running: $mage -Sign $deploymentManifestPath -CertFile $certFilePath -Password $certPassword"
& "$mage" -Sign "$deploymentManifestPath" -CertFile "$certFilePath" -Password $certPassword
##### 7 sign .application file
write-host "Running: $mage -Sign $appApplicationPath -CertFile $certFilePath  -Password $certPassword"
& "$mage" -Sign "$appApplicationPath" -CertFile "$certFilePath" -Password $certPassword
##### 8 update setup.exe
write-host "Running: $setupPath -url=$publishUrl/"
& "$setupPath" "-url=$publishUrl/"
##### 9 put .deploy back on files
write-host "update files to have deploy extension again"
#Rename files back to the .deploy extension, skipping the files that shouldn't be renamed
Get-ChildItem -Path "$path\$folderSegment\*"  -Recurse | Where-Object {!$_.PSIsContainer -and $_.Name -notlike "*.manifest" -and $_.Name -notlike "*.application"} | Rename-Item -NewName {$_.Name + ".deploy"}

