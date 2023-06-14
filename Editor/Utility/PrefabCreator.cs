namespace Tilia.Visuals.Vignette.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Visuals/Vignette/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.visuals.vignette.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabVignette = "Visuals.Vignette";

        [MenuItem(menuItemRoot + prefabVignette, false, priority)]
        private static void AddTooltip()
        {
            string prefab = prefabVignette + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}