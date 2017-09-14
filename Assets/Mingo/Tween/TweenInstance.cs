using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

	using EasingFunc = Func<float, float>;
  using InterpolationFunc = Func<float[], float, float>;
  using BridgeKeyDict = Dictionary<string, IBridge>;

	public class TweenInstance {

		private class TargetWrapper {

			private readonly object target;
      private readonly BridgeKeyDict bridgeKeyDict;

			public TargetWrapper(object target) {
				this.target = target;
        this.bridgeKeyDict = TweenManager.bridgeTable.GetBridgeDict(target);
			}

      public float GetValue(string key) {
        return this.bridgeKeyDict[key].GetValueFrom(target, key);
      }

      public void SetValue(string key, float value, float delta) {
        this.bridgeKeyDict[key].SetValueTo(target, key, value, delta);
      }

		}

    public float Duration { get { return duration; } }
    public float Time { get { return time; } }
    public bool Completed { get { return completed; } }
    public bool Started { get { return started; } }
    public bool Paused { get { return paused; } }

		private float duration = 1f;
    private float time = 0;
    private EasingFunc easingFunc = Mingo.Tween.Easing.Linear;
    private InterpolationFunc interpolationFunc = Mingo.Tween.Interpolation.Linear;
    private bool yoyoBack = false;
    private bool playingYoyo = false;
    private bool started = false;
    private bool completed = false;
    private bool paused = false;
    private int repeatTimes = 0;

    private TweenProps startValues = new TweenProps();
    private TweenProps lastValues = new TweenProps();
    private TweenProps endValues = new TweenProps();
    private string[] keys;

		private TargetWrapper target;

		public TweenInstance(object target) {
			this.target = new TargetWrapper(target);
		}

		public TweenInstance To(TweenProps properties, float duration=1f) {
      this.duration = duration;
      List<string> keys = new List<string>();
      foreach(var entry in properties) {
        var valueStart = target.GetValue(entry.Key);
        var valueEnd = entry.Value;
        // TODO support +100 -100
        // TODO support array
        startValues.Add(entry.Key, valueStart);
        lastValues.Add(entry.Key, valueStart);
        endValues.Add(entry.Key, valueEnd);
        keys.Add(entry.Key);
      }
      this.keys = keys.ToArray();
      started = true;
      return this;
    }

    public TweenInstance Easing(EasingFunc easingFunc) {
      this.easingFunc = easingFunc;
      return this;
    }

    public TweenInstance Interpolation(InterpolationFunc interpolationFunc) {
      this.interpolationFunc = interpolationFunc;
      return this;
    }

    public TweenInstance Yoyo() {
      this.yoyoBack = true;
      return this;
    }

    public TweenInstance Repeat(int times=int.MaxValue) {
      this.repeatTimes = times;
      return this;
    }

    public IEnumerator WaitForComplete() {
      while(!completed) {
        yield return 0;
      }
    }

    public TweenInstance Stop(bool complete=false) {
      if(complete) {
        this.Update(this.duration);
      }
      this.completed = complete;
      return this;
    }

    public TweenInstance Pause() {
      this.paused = true;
      return this;
    }

    public TweenInstance Resume() {
      this.paused = false;
      return this;
    }

    public bool Update(float deltaTime) {
      if(!this.started) return false;
      if(this.paused) return false;
      if(this.completed) return true;

      this.time += deltaTime;
      if(this.time >= this.duration) {
        this.time = this.duration;
      }
      float elapsed = this.time / this.duration;
      elapsed = elapsed > 1 ? 1 : elapsed;
      float easingValue = this.easingFunc(this.playingYoyo ? (1-elapsed) : elapsed);

      for(int i=0,len=this.keys.Length; i<len; i++) {
        string key = this.keys[i];
        float valueStart = this.startValues[key];
        float valueLast = this.lastValues[key];
        float valueEnd = this.endValues[key];
        float value, delta;
        value = valueStart + (valueEnd - valueStart) * easingValue;
        delta = value - valueLast;
        this.lastValues[key] = value;
        target.SetValue(key, value, delta);
      }

      if(elapsed == 1) {

        if(this.yoyoBack && !this.playingYoyo) {
          this.playingYoyo = true;
          this.time = 0;
          return false;
        }

        if(this.yoyoBack && this.playingYoyo) {
          this.playingYoyo = false;
        }

        if(this.repeatTimes > 1) {
          this.repeatTimes --;
          this.time = 0;
          return false;
        }

        this.completed = true;
      }

      return this.completed;
    }
	}

}
