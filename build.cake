#addin "wk.StartProcess"

using PS = StartProcess.Processor;

var publishDir = ".publish";
Task("Publish").Does(() => {

    CleanDirectory(publishDir);

    var project = "src/Antiforgery";
    DotNetCorePublish(project, new DotNetCorePublishSettings {
        OutputDirectory = publishDir,
        Configuration = "Release"
    });
});

Task("Start").Does(() => {
    PS.StartProcess("dotnet watch --project src/Antiforgery/Antiforgery.csproj run");
});

var target = Argument("target", "Publish");
RunTarget(target);