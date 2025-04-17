var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Clean")
    .Does(() =>
    {
        CleanDirectories("**/bin");
        CleanDirectories("**/obj");
        CleanDirectory("./docs");
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetRestore("HelloWorld.sln");
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetBuild("HelloWorld.sln", new DotNetBuildSettings
        {
            Configuration = configuration,
            NoRestore = true
        });
    });

// Modify or comment out the Test task if you don't have test projects
// Task("Test")
//     .IsDependentOn("Build")
//     .Does(() =>
//     {
//         // Update this to your actual test project path if you have one
//         // DotNetTest("HelloWorld.Tests/HelloWorld.Tests.csproj", new DotNetTestSettings
//         // {
//         //     Configuration = configuration,
//         //     NoRestore = true,
//         //     NoBuild = true
//         // });
//     });

Task("StyleCop")
    .Does(() =>
    {
        // This runs as part of the build process with FxCop analyzers
        Information("StyleCop checks run as part of the build");
    });

Task("Documentation")
    .Does(() =>
    {
        // Run Doxygen to generate documentation
        if (IsRunningOnWindows())
        {
            StartProcess("doxygen", "Doxyfile");
        }
        else
        {
            StartProcess("doxygen", new ProcessSettings { Arguments = "Doxyfile" });
        }
    });

Task("Default")
    .IsDependentOn("StyleCop")
    .IsDependentOn("Build")
    // Comment out this line if you don't have tests
    // .IsDependentOn("Test")
    .IsDependentOn("Documentation");

RunTarget(target);