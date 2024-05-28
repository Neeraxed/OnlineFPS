using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private string _groundTag;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _playerController.gameObject)
            return;
        else if (other.gameObject.CompareTag(_groundTag))
            _playerController.SetGroundedState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _playerController.gameObject)
            return;
        else if (other.gameObject.CompareTag(_groundTag))
            _playerController.SetGroundedState(false);
    }
}