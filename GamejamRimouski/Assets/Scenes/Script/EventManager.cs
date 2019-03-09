using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Event : UnityEvent<Hashtable> { }
public class EventManager : MonoBehaviour
{

    private Dictionary<string, Event> m_Events;


    private static EventManager eventManager;

    //	SINGLETON
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");

                    //Pour les tests
                    Camera.main.gameObject.AddComponent(typeof(EventManager));
                    eventManager = Camera.main.GetComponent<EventManager>();
                    eventManager.Init();
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (m_Events == null)
        {
            m_Events = new Dictionary<string, Event>();
        }
    }

    public static void AddListner(string a_EventName, UnityAction<Hashtable> listener)
    {
        Event thisEvent = null;
        if (instance.m_Events.TryGetValue(a_EventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new Event();
            thisEvent.AddListener(listener);
            instance.m_Events.Add(a_EventName, thisEvent);
        }
    }

    public static void RemoveListner(string a_EventName, UnityAction<Hashtable> listener)
    {
        if (eventManager == null) return;
        Event thisEvent = null;
        if (instance.m_Events.TryGetValue(a_EventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string a_EventName)
    {
        TriggerEvent(a_EventName, null);
    }

    public static void TriggerEvent(string a_EventName, Hashtable eventParams = default(Hashtable))
    {
        Event thisEvent = null;
        if (instance.m_Events.TryGetValue(a_EventName, out thisEvent))
        {
            thisEvent.Invoke(eventParams);
        }
    }
}