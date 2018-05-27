using System;
using UnityEngine;

namespace NRPG {

  public enum TriggerTimes {
    Once,
    EveryTime,
    Manual,
  }

  public enum TriggerDestroyTiming {
    OnTrigger,
    OnEventProcessed,
    OnEventCompleted,
  }

  public abstract class TriggerBase : MonoBehaviour {
    
    [Header("Conditions")]
    public TriggerTimes times = TriggerTimes.Once;
    public int manualTimes = 1;
    public TriggerDestroyTiming destroyTiming = TriggerDestroyTiming.OnTrigger;
    public bool triggerOnProcessing = false;
    public bool destroyObject = true;

    // 正在执行的事件
    private EventBase processingEvent;
    
    // 触发了几次 
    private int triggerTimes = 0;
    // 事件执行了多少次
    private int timesProcessed = 0;

    public void OnTrigger() {
      if (CheckProcessingEvent()) {
        return;
      }

      triggerTimes ++;

      bool destroyOnTrigger = CheckTriggerTimesEnough() && destroyTiming == TriggerDestroyTiming.OnTrigger;
      if (destroyOnTrigger) {
        DestroyTrigger();
      }

      var eventBase = QueryEvent();
      EventState eventState = EventState.Completed;
      if (eventBase != null) {

        if (!eventBase.CanProcess()) {
          return;
        }

        processingEvent = eventBase;
        eventBase.Process();
        timesProcessed ++;
        eventState = eventBase.state;

        // 如果一触发就销毁
        if (destroyOnTrigger) {
          return;
        }

        // 如果是事件执行过就销毁
        if (CheckTriggerTimesEnough() && destroyTiming == TriggerDestroyTiming.OnEventProcessed) {
          DestroyTrigger();
          return;
        }

      }

      // 在此先检查一下事件执行情况，后续状态在Update中检查
      if (eventState == EventState.Completed) {
        processingEvent = null;
        OnEventCompleted();
      }
    }

    public EventBase QueryEvent() {
      EventBase eventBase;
      var eventQuery = GetComponent<EventQuery>();
      if (eventQuery == null) {
        eventBase = GetComponent<EventBase>();
      } else {
        eventBase = eventQuery.Query();
      }
      return eventBase;
    }

    public void OnEventCompleted() {
      if (CheckTriggerTimesEnough() && destroyTiming == TriggerDestroyTiming.OnEventCompleted) {
        DestroyTrigger();
      }
    }

    bool CheckTriggerTimesEnough() {
      switch (times) {
        case TriggerTimes.Once:
          return triggerTimes == 1;
        case TriggerTimes.EveryTime:
          return false;
        case TriggerTimes.Manual:
          return manualTimes == triggerTimes;
      }
      return false;
    }

    bool CheckProcessingEvent() {
      return processingEvent != null && !triggerOnProcessing;
    }

    void DestroyTrigger() {
      if (destroyObject) {
        Destroy(gameObject);
      } else {
        Destroy(this);
      }
    }

    void Update() {
      if (processingEvent != null && processingEvent.state == EventState.Completed) {
        processingEvent = null;
        OnEventCompleted();
      }
    }

  }

}