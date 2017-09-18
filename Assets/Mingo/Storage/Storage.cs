using Newtonsoft.Json;

namespace Mingo.Storage {

  public abstract class Storage {

    public static string SavesDir = "SavesDir";

    public static Storage shared {
      get {
        if (internalShared == null) {
#if UNITY_STANDALONE
          internalShared = new StandaloneStorage();
#else
          internalShared = null;
#endif
        } 
        return internalShared;
      }
    }

    private static Storage internalShared = null;

    public abstract void Save(string path, string data, bool encript = true, string key = null);
    public abstract string Load(string path, bool decript = true, string key = null);

    public void SerializeSave<T>(string path, T data, bool encript = true, string key = null) {
      Save(path, JsonConvert.SerializeObject(data), encript, key);
    }

    public T DeserializeLoad<T>(string path, T defaults, bool decript = true, string key = null) {
      string data = Load(path, decript, key);
      if (data == null) {
        return defaults;
      } else {
        return JsonConvert.DeserializeObject<T>(data);
      }
    }

  }

}