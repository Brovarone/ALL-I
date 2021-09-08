$MAGE="MAGE"
$ROOT="C:\inetpub\wwwroot\ALL-I\"
$F1 = "C:\inetpub\wwwroot\ALL-I\index.htm"
$F2= "C:\inetpub\wwwroot\ALL-I\setup.exe"
$F3= "C:\inetpub\wwwroot\ALL-I\ALL-I.application"

$DEST = $ROOT+"ALL-I.zip"

#Prendo l'elenco delle directory
$D = Get-ChildItem -Path "C:\inetpub\wwwroot\ALL-I\Application Files" -Depth 0 -Directory -Name -Recurse #| Sort-Object -Property {[int]$_.ToString().Split("_")[4]}
#Converto in stringa l'array, lo splitto per underscore e prendo l'ultimo valore 
#Write-host $D[0].ToString().Split("_")[4]
#ordino per il criterio di cui sopra
$D=$D | Sort-Object -Property {[int]$_.ToString().Split("_")[4]}
#Write-Host $D[$D.GetUpperBound(0)]
#Ultima Cartella
$D1= $Root+"Application Files\"+ $D[$D.GetUpperBound(0)] 
$FD1 = "$env:TEMP/ALL/Application Files"
$App = $FD1+"/"+$D[$D.GetUpperBound(0)]
Write-Host $app
#creo una struttura temporaneada zippare
New-Item -Force -ItemType Directory $env:TEMP/ALL
#copio i file
Copy-Item -Recurse -Force $ROOT$MAGE $env:TEMP/ALL/$Mage
New-Item -Force -ItemType Directory $FD1
Copy-Item -Recurse -Force $D1 $App
Copy-Item -Recurse -Force $F1,$F2,$F3 $env:TEMP/ALL
#zippo
Compress-Archive -Path $env:TEMP/ALL/* -DestinationPath  $DEST -Force
#cancello la cartella temporanea
Remove-Item $env:TEMP/ALL -Recurse 

# Create a zip file with the contents of C:\Stuff\
#Compress-Archive -Path $ROOT$MAGE,$F1,$F2,$F3,$D1 -DestinationPath $DEST -Force
Write-Host "Eseguito"

# Add more files to the zip file
# (Existing files in the zip file with the same name are replaced)
# Compress-Archive -Path C:\OtherStuff\*.txt -Update -DestinationPath archive.zip

