using System;
using System.Linq;
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
        Build(BuildTarget.WebGL, "Builds/webgl/");
    }

    public static void OSX () {
        Build(BuildTarget.StandaloneOSX, "Builds/osx/" + GetProjectName() + ".app");
    }

    public static void Windows () {
        Build(BuildTarget.StandaloneWindows64, "Builds/windows/" + GetProjectName() + ".exe");
    }

    public static void Linux () {
        Build(BuildTarget.StandaloneLinux64, "Builds/linux/" + GetProjectName());
    }

    public static void Android () {
        Build(BuildTarget.Android, "Builds/android");
    }

    public static void iOS () {
        Build(BuildTarget.iOS, "Builds/iOS");
    }

    public static void Build (BuildTarget target, string buildPath) {
        BuildPipeline.BuildPlayer(GetScenePaths(), buildPath, target,
            BuildOptions.None);
    }
}