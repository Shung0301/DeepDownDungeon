using Battle.System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler Instance;

    public UIManager UIManager;


    public DayCounter DaySystem = new DayCounter();
    public MovingCount MovingCount = new MovingCount();


    private PhaseLogic phaseLogic;
    private List<Action> UpdateDo = new List<Action>();

    private void Awake()
    {
        Instance = this;
    }


    // Use this for initialization
    void Start()
    {
        phaseLogic = Instance.gameObject.AddComponent<PhaseLogic>();
        StartCoroutine("SystemLoading");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Action todo in UpdateDo)
        {
            todo();
        }
    }

    #region Public Methods
    public void AddUpdateAction(Action todo)
    {
        if (!UpdateDo.Contains(todo) && todo != null)
        {
            UpdateDo.Add(todo);
        }
    }

    public void RemoveUpdateAction(Action todo)
    {
        if (UpdateDo.Contains(todo))
        {
            UpdateDo.Remove(todo);
        }
    }

    public void ClearUpdateAction()
    {
        UpdateDo.Clear();
    }

    #endregion

    IEnumerator SystemLoading()
    {
        bool isDone = false;
        phaseLogic.Initial(() => isDone = true);

        yield return new WaitUntil(() => isDone);

        isDone = false;
        DaySystem.Initial(() => isDone = true);




        yield return new WaitUntil(() => isDone);
        yield return null;
    }

}
