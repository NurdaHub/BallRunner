using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    public static SpeedUpManager Instance { get; private set; }
    
    public List<int> pointsToSpeedUpList;
    public List<float> multiplierList;

    private int pointsToSpeedUp;
    private int speedLevel;

    private void Awake()
    {
        Instance = this;
        pointsToSpeedUp = pointsToSpeedUpList[0];
    }

    public void CheckToSpeedUp(int pointsCount)
    {
        if (pointsCount >= pointsToSpeedUp)
        {
            StartCoroutine(SpeedUp());
            speedLevel++;
            pointsToSpeedUp = pointsToSpeedUpList[speedLevel];
        }
    }

    private IEnumerator SpeedUp()
    {
        float currentSpeed = MoveForward.moveSpeed;
        float newSpeed = currentSpeed * multiplierList[speedLevel];
        float t = 0.1f;
        
        while (currentSpeed < newSpeed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, newSpeed, t);
            MoveForward.moveSpeed = currentSpeed;

            yield return null;
        }
    }
}
