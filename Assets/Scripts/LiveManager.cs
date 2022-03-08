using UnityEngine;

public class LiveManager : MonoBehaviour
{
    [Min(0)]
    public int maxLive;

    [HideInInspector] public int currentLive;

    public void DealDamage()
    {
        currentLive--;
        UIManager.Instance.SetLiveValue(currentLive.ToString());
        
        if (currentLive <= 0)
        {
            //ResetLive();
            GameManager.Instance.GameOver();
        }
    }

    public void ResetLive()
    {
        currentLive = maxLive;
        UIManager.Instance.SetLiveValue(currentLive.ToString());
    }
}
