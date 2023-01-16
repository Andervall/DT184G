using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] private int spinModifier = 3;
    //custom delegate declaration, we can use action delegate is it returns void
    //public delegate void SpinCompleteDelegate(); //private SpinCompleteDelegate onSpinComplete;

    //private Action onSpinComplete; //we use onActionComplete from baseclass
    private float totalSpinAmount;

    
    
    private void Update()
    {
        if(!isActive)
        {
            return;
        }
        float spinAddAmount = 360f  * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount * spinModifier, 0);

        totalSpinAmount += spinAddAmount;
        if(totalSpinAmount >= 360f)
        {
            ActionComplete();
        }
    }



    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {

        totalSpinAmount = 0f;
        ActionStart(onActionComplete);
    }

    public override string GetActionName()
    {
        return "SPEEN";
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGrisPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();

        return new List<GridPosition>
        { 
            unitGridPosition
        };
    }

    public override int GetActionPointsCost()
    {
        return 1;
    }

    public override EnemyAIAction GetBestEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0,
        };
    }
}
