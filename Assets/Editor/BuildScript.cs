using System;
using System.Linq;
using UnityEditor;

public class BuildScript {
    public static string[] BuildScenes = {
        "Assets/_Projeto/Scenes/Scene.unity",
    };

    public static void WebGL () {
        Build(BuildTarget.WebGL);
    }

    public static void OSX () {
        Build(BuildTarget.StandaloneOSX);
    }

    public static void Windows () {
        Build(BuildTarget.StandaloneWindows64);
    }

    public static void Linux () {
        Build(BuildTarget.StandaloneLinux64);
    }

    public static void Build (BuildTarget target) {
        BuildPipeline.BuildPlayer(BuildScenes.ToArray(), Environment.GetCommandLineArgs().Last(), target,
            BuildOptions.None);
    }
}