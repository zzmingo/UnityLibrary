using UnityEngine;

namespace Mingo {

  public static class UnityObjectExtensions {

    public static T Query<T>(this Transform transform, string path) {
      if (string.IsNullOrEmpty(path)) {
        return transform.GetComponent<T>();
      }
      return transform.Find(path).GetComponent<T>();
    }

    public static T Query<T>(this GameObject gameObject, string path) {
      return Query<T>(gameObject.transform, path);
    }

    public static T Query<T>(this MonoBehaviour monoBehaviour, string path) {
      return Query<T>(monoBehaviour.transform, path);
    }

    public static T[] QueryAll<T>(this Transform transform, string path) {
      if (string.IsNullOrEmpty(path)) {
        return transform.GetComponentsInChildren<T>();
      }
      return transform.Find(path).GetComponentsInChildren<T>();
    }

    public static T[] QueryAll<T>(this GameObject gameObject, string path) {
      return QueryAll<T>(gameObject.transform, path);
    }

    public static T[] QueryAll<T>(this MonoBehaviour monoBehaviour, string path) {
      return QueryAll<T>(monoBehaviour.transform, path);
    }

  }

}