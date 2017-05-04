# Build and publish NuGet packages

# Clean all projects
$bins = Get-ChildItem -Directory -Recurse -Filter bin
foreach ($bin in $bins) {
    Remove-Item $bin.FullName -Recurse -Force
}
dotnet clean --configuration "Release"
if ($lastExitCode -ne $null -and $lastExitCode -ne 0) { exit $lastExitCode }

# Restore NuGet packages for all projects
dotnet restore
if ($lastExitCode -ne $null -and $lastExitCode -ne 0) { exit $lastExitCode }

# Build projects
dotnet build --configuration "Release"
if ($lastExitCode -ne $null -and $lastExitCode -ne 0) { exit $lastExitCode }

# Execute the tests
dotnet test "test/MarkEmbling.Grammar.Tests/MarkEmbling.Grammar.Tests.csproj" --configuration "Release"
if ($lastExitCode -ne $null -and $lastExitCode -ne 0) { exit $lastExitCode }

# Publish packages to the NuGet gallery
$packages = Get-ChildItem src -Recurse -Filter *.nupkg
foreach ($package in $packages) {
    $choices = @(
        [Management.Automation.Host.ChoiceDescription]::new("&Publish", "Publish this package to the NuGet gallery"),
        [Management.Automation.Host.ChoiceDescription]::new("&Skip", "Skip this package")
    )
    $answer = $Host.UI.PromptForChoice("Publish Package", "Publish $package to the NuGet gallery?", $choices, 1)
    if ($answer -eq 0) {
        dotnet nuget push $package.FullName --source https://www.nuget.org
    }
}
