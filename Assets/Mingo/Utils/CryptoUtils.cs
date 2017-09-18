using System;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mingo {

  public static class CryptoUtils {
    
    public static string Encript(string key, string message) {
      using(DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider()) {
        desProvider.Mode = CipherMode.CBC;
        desProvider.Padding = PaddingMode.Zeros;
        desProvider.Key = Encoding.ASCII.GetBytes(key);
        desProvider.IV = Encoding.ASCII.GetBytes(key);
        using (var ms = new MemoryStream()) {
          using (var cs = new CryptoStream(ms, desProvider.CreateEncryptor(), CryptoStreamMode.Write)) {
            using (var sw = new StreamWriter(cs)) {
              sw.Write(message);
              sw.Flush();
              cs.FlushFinalBlock();
              sw.Flush();
              return Convert.ToBase64String(ms.ToArray());
            }
          }
        }
      }
    }

    public static string Decript(string key, string message) {
      using(DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider()) {
        desProvider.Mode = CipherMode.CBC;
        desProvider.Padding = PaddingMode.Zeros;
        desProvider.Key = Encoding.ASCII.GetBytes(key);
        desProvider.IV = Encoding.ASCII.GetBytes(key);
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(message))) {
          using (CryptoStream cs = new CryptoStream(ms, desProvider.CreateDecryptor(), CryptoStreamMode.Read)) {
            using (StreamReader sr = new StreamReader(cs, Encoding.UTF8)) {
              return sr.ReadToEnd();
            }
          }
        }
      }
    }

  }

}