using UnityEngine;
public static class PrefabLoadder {
    public static GameObject loadPrefab(string path) {
        return Resources.Load<GameObject>(path);
    }

    public static GameObject[] loadAllPrefab(string path) {
        return Resources.LoadAll<GameObject>(path);
    }
}