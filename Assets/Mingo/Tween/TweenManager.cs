using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public class TweenManager : MonoBehaviour {

    internal static readonly BridgeTable bridgeTable = new BridgeTable();

    public static void CheckInit() {}

    static TweenManager() {
      bridgeTable.AddBridge(new TransformBridge());
      bridgeTable.AddBridge(new RectTransformBridge());
    }

    void Awake() {
      DontDestroyOnLoad(this);

      GameObject oTweenProvider = GameObject.FindGameObjectWithTag("TweenBridgeProvider");
      IBridgeProvider[] providers = oTweenProvider.GetComponents<IBridgeProvider>();
      foreach(var provider in providers) {
        foreach(var bridge in provider.GetTweenBridges()) {
          bridgeTable.AddBridge(bridge);
        }
      }
    }

    internal class BridgeTable : Hashtable {

      internal void AddBridge(IBridge bridge) {
        Type type = bridge.SupportedType;
        Dictionary<string, IBridge> keyDict;
        if (!ContainsKey(type)) {
          keyDict = new Dictionary<string, IBridge>();
          Add(type, keyDict);
        } else {
          keyDict = this[type] as Dictionary<string, IBridge>;
        }
        foreach(var key in bridge.SupportedKeys) {
          if (keyDict.ContainsKey(key)) {
            throw TweenException.BridgeKeyHasBeenUsed(key, type);
          }
          keyDict.Add(key, bridge);
        }
      }

      internal Dictionary<string, IBridge> GetBridgeDict(object target) {
        var type = target.GetType();
        if (!ContainsKey(type)) {
          throw TweenException.NotATweenTarget(type);
        }
        return this[type] as Dictionary<string, IBridge>;
      }

    }

  }

}