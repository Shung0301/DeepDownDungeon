using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct DayNightInfoTemplate
{
    public enum DayNight { Day, Night };
    public DayNight DayOrNight;
    public bool SpecailEvent;

    public static explicit operator DayNightInfoTemplate(ResourceRequest v)
    {
        throw new NotImplementedException();
    }
}

[CreateAssetMenu(fileName = "DayNightSetting", menuName = "Battle/Data", order = 1)]
public class DayNightSetting : ScriptableObject, IEnumerable
{
    public List<DayNightInfoTemplate> DayNightInfo;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
}