using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.System
{
    public class DayCounter
    {
        public int CurrentDay { get { return _currentDay; } }
        private int _currentDay;

        public delegate Action DelDayPassed();
        public DelDayPassed DayPassed;

        public void Initial(Action doneAction)
        {
            _currentDay = 1;

            BattleHandler.Instance.PhaseLogic.DayChange += GoNextDay;
            //BattleHandler.Instance.AddUpdateAction(null);


            doneAction?.Invoke();
        }

        public void GoNextDay()
        {
            DayPassed?.Invoke();
        }

    }
}
