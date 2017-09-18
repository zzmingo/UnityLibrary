using System;
using UnityEngine;

namespace Mingo {

  public static class Base64Utils {

    public static Texture2D CreateTexture(string base64, TextureFormat format=TextureFormat.RGBA32, bool mipmap=false) {
      Texture2D texture = new Texture2D(1, 1, format, mipmap);
      byte[] bytes = System.Convert.FromBase64String(base64);
      texture.LoadImage(bytes);
      return texture;
    }

    public static Sprite CreateSprite(string base64, float pivotX=0.5f, float pivotY=0.5f, float pixelsPerUnit=100f) {
      var texture = CreateTexture(base64);
      return Sprite.Create (texture, new Rect(0, 0, texture.width, texture.height), new Vector2(pivotX, pivotY), pixelsPerUnit);
    }

  }

}