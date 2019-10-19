using UnityEditor;
class WebGLBuilder {
    static void build() {

        // Place all your scenes here
        string[] scenes = {"Assets/scenes/SampleScene.unity"};

        string pathToDeploy = "build/web/";       

        BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);      
    }
}