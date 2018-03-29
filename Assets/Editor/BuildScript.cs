using UnityEditor;
using UnityEngine;

public class BuildScript {
    static string GetProjectName () {
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }

    static string[] GetScenePaths () {
        string[] scenes = new string[EditorBuildSettings.scenes.Length];

        for (int i = 0; i < scenes.Length; i++) {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }

        return scenes;
    }

    public static void WebGL () {
        Build(BuildTargetGroup.WebGL, BuildTarget.WebGL, "Build/webgl/");
    }

    public static void OSX () {
        Build(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX, "Build/osx/" + GetProjectName() + ".app");
    }

    public static void Windows () {
        Build(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64, "Build/windows/" + GetProjectName() + ".exe");
    }

    public static void Linux () {
        Build(BuildTargetGroup.Standalone, BuildTarget.StandaloneLinux64, "Build/linux/" + GetProjectName());
    }

    public static void Android () {
        Build(BuildTargetGroup.Android, BuildTarget.Android, "Build/android");
    }

    public static void iOS () {
        Build(BuildTargetGroup.iOS, BuildTarget.iOS, "Builds/ios");
    }

    public static void Build (BuildTargetGroup targetGroup, BuildTarget target, string buildPath) {
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);
        BuildPipeline.BuildPlayer(GetScenePaths(), buildPath, target,
            BuildOptions.None);
    }
}