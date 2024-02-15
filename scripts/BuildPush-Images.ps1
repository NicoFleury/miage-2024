param (
    [Parameter(Mandatory=$true)]
    [string]$tag
)

function Get-ImageName {
	param (
		[string]$folder
	)

	switch ($folder) {
		"MiageCorp.AwesomeShop.BasketApi" { return "nicolasfy/basket" }
		"MiageCorp.AwesomeShop.BackForFront" { return "nicolasfy/backforfront" }
		"MiageCorp.AwesomeShop.ProductApi" { return "nicolasfy/product" }
	}
	
}

$folders=Get-ChildItem -Filter "MiageCorp.*" -Directory -Path $PSScriptRoot\..

foreach ($folder in $folders) {
	$dockerFile="$($folder.FullName)\$($folder.Name)\Dockerfile"
	if(Test-Path $dockerFile) {
		Write-Host "Building and pushing image for $folder"
		$imageName=Get-ImageName $folder.Name
		$dockerBuildCommand = "docker build --rm -t $($imageName):$tag -f $dockerFile $($folder.FullName)"
		Write-Host "Generating docker build command: $dockerBuildCommand"
		Invoke-Expression $dockerBuildCommand

		$dockerPushCommand = "docker push $($imageName):$tag"
		Write-Host "Executing docker push command: $dockerPushCommand"
		Invoke-Expression $dockerPushCommand
	}
}