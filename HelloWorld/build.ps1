$ErrorActionPreference = 'Stop'

$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1

# Install the Cake.Tool
dotnet tool restore

# Execute Cake script
dotnet cake build.cake $args