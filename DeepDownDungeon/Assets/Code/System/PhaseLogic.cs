using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.System
{
    public class PhaseLogic : MonoBehaviour
    {

        private List<DayNightInfoTemplate> _dayList;
        private List<DayNightInfoTemplate> _nightList;


        public void CheckStat()
        {
            StartCoroutine("CheckStatProcess");
        }

        public void Initial(Action doneAction)
        {
            SetDayNightList();
            doneAction?.Invoke();
        }

        private void SetDayNightList()
        {
            string dayNightPath = "ScriptableObjects/DayNightSetting";
            string fileName = "asset";

            DayNightSetting dayNightSetting = Resources.Load<DayNightSetting>(dayNightPath + fileName);

            foreach (DayNightInfoTemplate info in dayNightSetting)
            {
                if (info.DayOrNight == DayNightInfoTemplate.DayNight.Day)
                {
                    _dayList.Add(info);
                }
                else
                {
                    _nightList.Add(info);
                }

            };
        }

        IEnumerator CheckStatProcess()
        {
            
            yield return null;
        }
    }
}
