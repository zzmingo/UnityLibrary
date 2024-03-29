using UnityEngine;

namespace Mingo {

  public class Singleton<T> : MonoBehaviour where T: MonoBehaviour {

    public static T shared {
      get {
        if (instance == null) {
          GameObject gameObject = new GameObject("Singleton-" + typeof(T).FullName);
          instance = gameObject.AddComponent<T>();
        }
        return instance;
      } 
    }

    private static T instance;

    protected virtual void Awake() {
      if (this == shared) {
        return;
      }
      Destroy(this);
    }

  }

  public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {

    protected override void Awake() {
      if (this == shared) {
        DontDestroyOnLoad(gameObject);
        return;
      }
      Destroy(this);
    }

  }

}