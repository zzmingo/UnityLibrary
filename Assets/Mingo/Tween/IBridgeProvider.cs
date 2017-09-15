namespace Mingo.Tween {

  public interface IBridgeProvider {
    
    IBridge[] GetTweenBridges();
    IValueHandler[] GetTweenValueHandlers();

  }

}