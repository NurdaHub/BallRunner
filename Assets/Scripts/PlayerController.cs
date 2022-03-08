using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public LiveManager liveManager;
    public PointCalculator pointCalculator;
    [SerializeField] private float limitPosition = 3.5f;
    
    [HideInInspector] 
    public bool canMove;
    private PointerEventData currentEventData;
    private float distance;

    private void Awake()
    {
        Instance = this;
        canMove = false;
    }

    private void Update()
    {
        if (canMove)
            Move();
    }

    private void Move()
    {
        var playerPosition = transform.position;
        var worldPosition = Camera.main.ScreenToWorldPoint(currentEventData.position);
        var newXPosition = worldPosition.x + distance;
        playerPosition = new Vector3(newXPosition, playerPosition.y, playerPosition.z);

        if (playerPosition.x > limitPosition)
            playerPosition = new Vector3(limitPosition, playerPosition.y, playerPosition.z);
        
        if (playerPosition.x < -limitPosition)
            playerPosition = new Vector3(-limitPosition, playerPosition.y, playerPosition.z);

        transform.position = playerPosition;
    }

    public void OnPointerStateChanged(PointerEventData _eventData, bool _canMove)
    {
        currentEventData = _eventData;
        canMove = _canMove;
        
        if (currentEventData != null)
            distance = transform.position.x - Camera.main.ScreenToWorldPoint(currentEventData.position).x;
    }
}
