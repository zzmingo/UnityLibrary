using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mingo.Tween {

  public class TweenProps : Dictionary<string, float> {

    public static TweenProps FromParams(params object[] args) {
      if (args.Length % 2 != 0) {
        throw TweenException.ArgsMustBeEven();
      }
      var props = new TweenProps();
      int i = 0;
			while(i < args.Length - 1) {
				props.Add(args[i].ToString(), float.Parse(args[i+1].ToString()));
				i += 2;
			}
			return props;
    }

  }

}