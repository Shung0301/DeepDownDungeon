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

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler DayPassed;

        public void Initial(Action doneAction)
        {
            _currentDay = 1;
            //BattleHandler.Instance.AddUpdateAction(null);


            doneAction?.Invoke();
        }

        public void GoNextDay()
        {
            DayPassed?.Invoke(this, EventArgs.Empty);
        }

    }
}
