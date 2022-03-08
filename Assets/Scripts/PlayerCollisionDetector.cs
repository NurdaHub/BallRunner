using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public LiveManager liveManager;
    public PointCalculator pointCalculator;
    
    private string bonusTag = "Bonus";
    private string enemyTag = "Damageable";

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(bonusTag))
            OnBonusCollided();
        
        if (otherCollider.CompareTag(enemyTag))
            OnEnemyCollided();
    }

    private void OnBonusCollided()
    {
        pointCalculator.AddPoint();
    }

    private void OnEnemyCollided()
    {
        liveManager.DealDamage();
    }
}
