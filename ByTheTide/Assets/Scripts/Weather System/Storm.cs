using UnityEngine;

public class Storm : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] characterMovement player;
    [SerializeField] ParticleSystem hurricane;
    [SerializeField] Transform hurricaneTransform;
    [SerializeField] GameObject tide;
    [SerializeField] Vector3 hurricanePos;
    Vector3 playerSpawnPos;
    [SerializeField] float newPos = 20.0f;

    [SerializeField] float minMoveSpeed = 0.5f;
    [SerializeField] float minJumpHeight = 0.5f;

    private void Start()
    {
        playerSpawnPos = playerTransform.position;
        hurricanePos = playerSpawnPos + new Vector3(20.0f, 0.0f, 20.0f);
    }

    private void Update()
    {
        hurricaneTransform.position = hurricanePos;

        // 35.0f is used to offset the numerator to 0 when the tide is at -35.0f
        // The 1.75f just keeps the range of the hurricane's positions more confined
        newPos = Mathf.Abs(tide.transform.position.y + 35.0f) / 1.75f;

        hurricanePos = playerSpawnPos + new Vector3(newPos, 0.0f, newPos);

        // Player movement speed should be 5 when water level is at 0
        if (newPos <= 20.0f && player.GetMovementSpeed() > minMoveSpeed)
            player.SetMovementSpeed(newPos / 4.0f);

        // Player jump height should be 2 when water level is at 0
        if (newPos <= 20.0f && player.GetJumpHeight() > minJumpHeight)
            player.SetJumpHeight(newPos / 10.0f);
    }
}
