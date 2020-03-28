using UnityEditor;
using UnityEngine.Rendering;


public class MultiPlatformExportAssetBundles
{
    public static BuildAssetBundleOptions scripBuildTarget { get; private set; }

    [MenuItem("Assets/Build Multi-Platform AssetBundle From Selection")]
    static void ExportResource()
    {
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0)
        {
			
			// include the following Graphic APIs
            PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows, new GraphicsDeviceType[] { GraphicsDeviceType.Direct3D11, GraphicsDeviceType.OpenGLCore, GraphicsDeviceType.Vulkan});

            // Build the resource file from the active selection.
            UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
#pragma warning disable CS0618 // Type or member is obsolete
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.None | BuildAssetBundleOptions.ForceRebuildAssetBundle, BuildTarget.StandaloneWindows);
#pragma warning restore CS0618 // Type or member is obsolete
              Selection.objects = selection;

            AssetDatabase.Refresh();

        }
    }
}