using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Mingo.Graphics;

namespace Mingo.Tween {

	using EasingFunc = Func<float, float>;

	public class MingoTweenDemo : MonoBehaviour {

		public UILineRenderer lineRenderer;
		public InputField durationField;
		public Toggle yoyoToggle;
		public InputField repeatTimesField;

		private EasingFunc easingFunc = Easing.Linear;
		private float duration = 1f;
		private bool yoyo = false;
		private int repeatTimes = 0;

		private EasingFunc[] easings = new EasingFunc[] {
			Easing.Linear,
			Easing.Quad.In,
			Easing.Quad.Out,
			Easing.Quad.InOut,
			Easing.Cubic.In,
			Easing.Cubic.Out,
			Easing.Cubic.InOut,
			Easing.Quart.In,
			Easing.Quart.Out,
			Easing.Quart.InOut,
			Easing.Quint.In,
			Easing.Quint.Out,
			Easing.Quint.InOut,
			Easing.Sin.In,
			Easing.Sin.Out,
			Easing.Sin.InOut,
			Easing.Exp.In,
			Easing.Exp.Out,
			Easing.Exp.InOut,
			Easing.Circ.In,
			Easing.Circ.Out,
			Easing.Circ.InOut,
			Easing.Elast.In,
			Easing.Elast.Out,
			Easing.Elast.InOut,
			Easing.Back.In,
			Easing.Back.Out,
			Easing.Back.InOut,
			Easing.Bounce.In,
			Easing.Bounce.Out,
			Easing.Bounce.InOut,
		};

		private Coroutine drawLineCoroutine;
		
		public void Play() {
			lineRenderer.Points = new Vector2[0];
			gameObject.ClearAllTweens();
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			var width = transform.parent.GetComponent<RectTransform>().rect.width;
			var tween = gameObject.TweenBy("x", width);
			tween.Easing(easingFunc)
					 .Duration(duration)
					 .Yoyo(yoyo)
					 .Repeat(repeatTimes);

			if (drawLineCoroutine != null) {
				StopCoroutine(drawLineCoroutine);
			}
			drawLineCoroutine = StartCoroutine(DrawLine(tween));
		}

		public void OnEasingChanged(int index) {
			easingFunc = easings[index];
		}

		public void OnDurationChange(string durationStr) {
			durationStr = durationField.text;
			if (string.IsNullOrEmpty(durationStr.Trim())) {
				return;
			}
			duration = float.Parse(durationStr);
			if (duration <= 0) {
				durationField.text = "1";
				duration = 1;
			}
		}

		public void OnYoyoChange(bool yoyo) {
			this.yoyo = yoyoToggle.isOn;
		}

		public void OnRepeatTimesChange(string repeatTimesStr) {
			repeatTimesStr = repeatTimesField.text;
			if (string.IsNullOrEmpty(repeatTimesStr.Trim())) {
				return;
			}
			repeatTimes = int.Parse(repeatTimesStr);
			if (repeatTimes <= 0) {
				repeatTimesField.text = "1";
				repeatTimes = 1;
			}
		}

		private IEnumerator DrawLine(TweenInstance tween) {
			var rect = lineRenderer.gameObject.GetComponent<RectTransform>().rect;
			List<Vector2> points = new List<Vector2>();
			points.Add(new Vector2(0, 0));
			lineRenderer.Points = new Vector2[0];
			float duration = tween.duration;
			if (tween.repeatTimes >= 1) {
				duration = (tween.repeatTimes + 1) * tween.duration;
			}
			if (tween.yoyo) {
				duration *= 2;
			}
			while(!tween.completed) {
				yield return new WaitForFixedUpdate();
				var x = tween.time / duration * rect.width;
				var y = tween.easingValue * rect.height;
				points.Add(new Vector2(x, y));
				lineRenderer.Points = points.ToArray();
				lineRenderer.SetVerticesDirty();
			}
		}
	}

}
