using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private string GroundTag;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
            return;
        else if (other.gameObject.CompareTag("Ground"))
            playerController.SetGroundedState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
            return;
        else if (other.gameObject.CompareTag("Ground"))
            playerController.SetGroundedState(false);
    }
}