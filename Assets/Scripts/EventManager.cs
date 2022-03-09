using System;
using System.Collections.Generic;
using UnityEngine;


namespace VR2021.Events
{

    public static class EventNames
    {
        public const string NewLevel = "newLevel";
        public const string EndLevel = "endLevel";
        public const string Pause = "pause";
        public const string Restart = "restart";  
    }
   /// <summary>
    /// Messaging System which will allow objects to subscribe to events, having associated callbacks.
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton private instance
        /// </summary>
        private static EventManager eventManager;

        private Dictionary<string, Action<object>> eventDictionary;
        private Dictionary<string, int> listenersCount;// Counts the number of subscriptions to an event 

        public Dictionary<string, Action<object>> EventDictionary { get => eventDictionary; }
        public Dictionary<string, int> ListenersCount { get => listenersCount; }
        
        /// <summary>
        /// Singleton instance with lazy initialization
        /// </summary>
        private static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError("An active GameObject containing an EventManager component is required in the scene");
                    }
                    else
                    {
                        eventManager.Init();
                        //  Sets this to not be destroyed when reloading scene
                        DontDestroyOnLoad(eventManager);
                    }
                }
                return eventManager;
            } 
        }

        /// <summary>
        /// Lazy constructor of the class
        /// </summary>
        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, Action<object>>();
                listenersCount = new Dictionary<string, int>();
            }
        }

        /// <summary>
        /// Add new listener to event to the eventDictionary. The event is added to the dictionary if the event does not exist.
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="listener">Action to invoke</param>
        public static void StartListening(string eventName, Action<object> listener)
        {
            Action<object> thisEvent;

            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;
                instance.eventDictionary[eventName] = thisEvent;
                instance.listenersCount[eventName]++;
            }
            else
            {
                thisEvent += listener;
                instance.eventDictionary.Add(eventName, thisEvent);
                instance.listenersCount.Add(eventName, 1);
            }
        }

        /// <summary>
        /// Remove a listener to event in eventDictionary
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="listener">Action to invoke</param>
        public static void StopListening(string eventName, Action<object> listener)
        {       
            Action<object> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
                instance.eventDictionary[eventName] = thisEvent;
                instance.listenersCount[eventName]--;
            }
        }
        /// <summary>
        /// Invoke a event from eventDictionary
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="message"> Action to invoke with Dictionary<string, object> as param</param>
        public static void TriggerEvent(string eventName, object message = null)
        {
            if (message == null) { message = "No message"; }
            // Debug.Log("EventManager: "+eventName+ " triggered...");

            Action<object> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                if (thisEvent != null)
                {
                    // Debug.Log("EventManager: Invoke message" + message.ToString());
                    thisEvent.Invoke(message);
                }
                else
                {
                    Debug.LogWarning("EventManager: event null");
                }
            }
        }  
    }

}