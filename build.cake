Task("Publish").Does(() => {

    CleanDirectory("publish");

    var project = "src/Antiforgery";
    DotNetCorePublish(project, new DotNetCorePublishSettings {
        OutputDirectory = "publish",
        Configuration = "Release"
    });
});

var target = Argument("target", "Publish");
RunTarget(target);