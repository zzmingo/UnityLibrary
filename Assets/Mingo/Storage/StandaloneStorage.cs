#if UNITY_STANDALONE
using System.IO;

namespace Mingo.Storage {

  public class StandaloneStorage : Storage {

    public override void Save(string path, string data, bool encript = true, string key = null) {
      string savePath = GetSavePath(path);
      if (encript) {
        data = CryptoUtils.Encript(key, data);
      }
      File.WriteAllText(savePath, data);
    }
    public override string Load(string path, bool decript = true, string key = null) {
      string savePath = GetSavePath(path);
      string data = File.Exists(savePath) ? File.ReadAllText(savePath) : null;
      if (decript && data != null) {
        data = CryptoUtils.Decript(key, data);
      }
      return data;
    }

    private string GetSavePath(string subpath) {
      string savePath = PathUtils.Combine(PathUtils.GetAppPersistentPath(), Storage.SavesDir, subpath);
      string saveDir = Path.GetDirectoryName(savePath);
      if (!Directory.Exists(saveDir)) {
        Directory.CreateDirectory(saveDir);
      }
      return savePath;
    }

  }

}

#endif