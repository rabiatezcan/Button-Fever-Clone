using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicListener : MonoBehaviour
{
    public GameEnums.TriggerBehavior Trigger = GameEnums.TriggerBehavior.OnTriggerEnter;

    public string CompareTagName;

    public UnityEvent<Collider> TriggerEnterCallback;
    public UnityEvent<Collider> TriggerExitCallback;

    private void OnTriggerEnter(Collider other)
    {
        if (Trigger == GameEnums.TriggerBehavior.OnTriggerEnter || Trigger == GameEnums.TriggerBehavior.Both)
        {
            if (other.tag == CompareTagName || CompareTagName == "")
            {
                TriggerEnterCallback.Invoke(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Trigger == GameEnums.TriggerBehavior.OnTriggerExit || Trigger == GameEnums.TriggerBehavior.Both)
        {
            if (other.tag == CompareTagName || CompareTagName == "")
            {
                TriggerExitCallback.Invoke(other);
            }
        }
    }
}

