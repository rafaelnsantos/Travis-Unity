using System;
using System.Linq;
using UnityEditor;

public class BuildScript {

    public static void BuildWebGL()
    {
        Build(BuildTarget.WebGL);
    }

    public static void Build(BuildTarget target) {
        string[] levels = { "Assets/_Projeto/Scenes/Scene.unity" };
        BuildPipeline.BuildPlayer(levels.ToArray(), Environment.GetCommandLineArgs().Last(), target, BuildOptions.None);
    }
}