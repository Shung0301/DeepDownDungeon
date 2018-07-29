using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.System
{
    public class PhaseLogic
    {

        private List<DayNightInfoTemplate> _dayList;
        private List<DayNightInfoTemplate> _nightList;

        public delegate void delDayChange();
        public delDayChange DayChange;

        public void CheckStat(MonoBehaviour mono)
        {
            mono.StartCoroutine("CheckStatProcess");
        }

        public void Initial(Action doneAction)
        {
            BattleHandler.Instance.WhenDestroy += UnsubscribeAll;
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

        private void UnsubscribeAll()
        {
            DayChange = null;
        }

        IEnumerator CheckStatProcess()
        {

            yield return new WaitForSeconds(1);
        }
    }
}
