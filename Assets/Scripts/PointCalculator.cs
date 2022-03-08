using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    private int pointCount;
    
    public void AddPoint()
    {
        pointCount++;
        UIManager.Instance.SetPointsValue(pointCount.ToString());
        SpeedUpManager.Instance.CheckToSpeedUp(pointCount);
    }

    public void ResetPoints()
    {
        pointCount = 0;
        UIManager.Instance.SetPointsValue(pointCount.ToString());
    }
}
