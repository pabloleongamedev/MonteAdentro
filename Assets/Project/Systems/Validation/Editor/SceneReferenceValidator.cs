using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonteAdentro.Systems.Validation.Runtime;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonteAdentro.Systems.Validation.Editor
{
    public class SceneReferenceValidator : IPreprocessBuildWithReport
    {
        private const BindingFlags FieldFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            var failures = CollectFromScenes().Concat(CollectFromPrefabs()).ToList();

            foreach (var failure in failures.Where(f => f.Criticality == ReferenceCriticality.SoftFail))
            {
                Debug.LogWarning(failure.Describe());
            }

            var hardFailures = failures.Where(f => f.Criticality == ReferenceCriticality.HardFail).ToList();
            foreach (var failure in hardFailures)
            {
                Debug.LogError(failure.Describe());
            }

            if (hardFailures.Count > 0)
            {
                throw new BuildFailedException(
                    $"SceneReferenceValidator: {hardFailures.Count} referencia(s) [RequiredReference] hard-fail vacías. Build bloqueado — ver errores arriba.");
            }
        }

        private static IEnumerable<Failure> CollectFromScenes()
        {
            var failures = new List<Failure>();
            var originalSetup = EditorSceneManager.GetSceneManagerSetup();

            try
            {
                foreach (var sceneAsset in EditorBuildSettings.scenes)
                {
                    if (!sceneAsset.enabled) continue;

                    if (!System.IO.File.Exists(sceneAsset.path))
                    {
                        Debug.LogWarning($"SceneReferenceValidator: la escena '{sceneAsset.path}' está en Build Settings pero no existe en disco. Se omite.");
                        continue;
                    }

                    var scene = EditorSceneManager.OpenScene(sceneAsset.path, OpenSceneMode.Additive);

                    foreach (var root in scene.GetRootGameObjects())
                    {
                        foreach (var behaviour in root.GetComponentsInChildren<MonoBehaviour>(true))
                        {
                            CollectFromComponent(behaviour, sceneAsset.path, failures);
                        }
                    }

                    EditorSceneManager.CloseScene(scene, true);
                }
            }
            finally
            {
                if (originalSetup != null && originalSetup.Length > 0)
                {
                    EditorSceneManager.RestoreSceneManagerSetup(originalSetup);
                }
            }

            return failures;
        }

        private static IEnumerable<Failure> CollectFromPrefabs()
        {
            var failures = new List<Failure>();

            foreach (var guid in AssetDatabase.FindAssets("t:Prefab"))
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (prefab == null) continue;

                foreach (var behaviour in prefab.GetComponentsInChildren<MonoBehaviour>(true))
                {
                    CollectFromComponent(behaviour, path, failures);
                }
            }

            return failures;
        }

        private static void CollectFromComponent(MonoBehaviour behaviour, string assetPath, List<Failure> failures)
        {
            if (behaviour == null) return; // script faltante (missing script) en el GameObject

            foreach (var field in behaviour.GetType().GetFields(FieldFlags))
            {
                var attribute = (RequiredReferenceAttribute)Attribute.GetCustomAttribute(field, typeof(RequiredReferenceAttribute));
                if (attribute == null) continue;
                if (!typeof(Object).IsAssignableFrom(field.FieldType)) continue;

                var value = (Object)field.GetValue(behaviour);
                if (value != null) continue;

                failures.Add(new Failure(assetPath, behaviour.GetType().Name, field.Name, attribute.Criticality));
            }
        }

        private readonly struct Failure
        {
            private readonly string assetPath;
            private readonly string componentName;
            private readonly string fieldName;

            public ReferenceCriticality Criticality { get; }

            public Failure(string assetPath, string componentName, string fieldName, ReferenceCriticality criticality)
            {
                this.assetPath = assetPath;
                this.componentName = componentName;
                this.fieldName = fieldName;
                Criticality = criticality;
            }

            public string Describe() =>
                $"[RequiredReference:{Criticality}] {assetPath} -> {componentName}.{fieldName} está vacío.";
        }
    }
}
