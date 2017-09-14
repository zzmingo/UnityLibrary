namespace Mingo.Tween {

  public static class TN {

    public static TweenProps p(params object[] args) {
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