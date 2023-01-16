using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathfindingGridDebugObject : GridDebugObject
{
    [SerializeField] private TextMeshPro gCostText;
    [SerializeField] private TextMeshPro fCostText;
    [SerializeField] private TextMeshPro hCostText;
    [SerializeField] private SpriteRenderer isWalkableRenderer;

    private PathNode pathNode;
    public override void SetGridObject(object gridObject)
    {
        base.SetGridObject(gridObject);
        pathNode = (PathNode)gridObject;
        
    }

    protected override void Update()
    {
        base.Update();
        gCostText.text = pathNode.GetGCost().ToString();
        hCostText.text = pathNode.GetHCost().ToString();
        fCostText.text = pathNode.GetFCost().ToString();
        Color fadeGreen = new Color(0, 1, 0, 0.2f);
        Color fadeRed = new Color(1, 0, 0, 0.2f);
        isWalkableRenderer.color = pathNode.IsWalkable() ? fadeGreen : fadeRed;
    }
}
