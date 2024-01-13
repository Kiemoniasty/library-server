#Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

#Variables
$resourceGroupName = "ZdunekSQLDB"
$appPlanName = "ASP-ZdunekSQLDB-b834"
$webappName = "librarybackend"
$outputFolder = "C:\Users\wojte\source\repos\xmooncake\library-server\Built"
$zipFilePath = "C:\Users\wojte\source\repos\xmooncake\library-server\Packed.zip"
#"./Packed/Packed.zip"

#Login
az login

# Compile the Azure Function
dotnet publish -c Release -o $outputFolder --os linux

# Create a zip file for the Azure Function
Compress-Archive -Path "$outputFolder\*" -DestinationPath $zipFilePath -Force

# Deploy the Azure function
az webapp deployment source config-zip --name $webappName --resource-group $resourceGroupName --src $zipFilePath 
