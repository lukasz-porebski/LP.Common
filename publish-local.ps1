dotnet test -c Release
dotnet pack -c Release
Get-ChildItem -Recurse -Filter "*.nupkg" | ForEach-Object {
    dotnet nuget push $_.FullName --source "Local"
}