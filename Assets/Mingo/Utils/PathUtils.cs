using System;
using System.IO;
using UnityEngine;

namespace Mingo {

  public static class PathUtils {

    public static string GetAppPersistentPath() {
      return Path.GetFullPath(".");
    }

    public static string Combine(params string[] paths) {
      return string.Join(System.IO.Path.DirectorySeparatorChar + "", paths);
    }

  }

}