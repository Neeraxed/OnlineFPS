using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
    [SerializeField] private Image _healthbarImage;
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _cameraHolder;
    [SerializeField] private float _mouseSensitivity, _sprintSpeed, _walkSpeed, _jumpForce, _smoothTime;
    [SerializeField] private Item[] items;

    private int _itemIndex;
    private int _previousItemIndex = -1;
    private float _verticalLookRotation;
    private bool _grounded;
    private Vector3 _smoothMoveVelocity;
    private Vector3 _moveAmount;
    private Rigidbody _rb;
    private PhotonView _PV;
    private const float _maxHealth = 100f;
    private float _currentHealth = _maxHealth;
    private PlayerManager _playerManager;

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("ItemIndex") && !_PV.IsMine && targetPlayer == _PV.Owner)
        {
            EquipItem((int)changedProps["ItemIndex"]);
        }
    }

    public void SetGroundedState(bool grounded)
    {
        _grounded = grounded;
    }

    public void TakeDamage(float damage)
    {
        _PV.RPC(nameof(RPC_TakeDamage), _PV.Owner, damage);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _PV = GetComponent<PhotonView>();

        _playerManager = PhotonView.Find((int)_PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    private void Start()
    {
        if (_PV.IsMine)
        {
            EquipItem(0);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(_rb);
            Destroy(_ui);
        }
    }

    private void Update()
    {
        if (!_PV.IsMine)
            return;

        Look();
        Move();
        Jump();

        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                EquipItem(i);
                break;
            }
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (_itemIndex >= items.Length - 1)
            {
                EquipItem(0);
            }
            else
            {
                EquipItem(_itemIndex + 1);
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (_itemIndex <= 0)
            {
                EquipItem(items.Length - 1);
            }
            else
            {
                EquipItem(_itemIndex - 1);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            items[_itemIndex].Use();
        }

        //TODO remove it from update and invoke an event
        if (transform.position.y < -10f) // Die if you fall out of the world
        {
            Die();
        }
    }

    private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);

        _verticalLookRotation += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraHolder.transform.localEulerAngles = Vector3.left * _verticalLookRotation;
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        _moveAmount = Vector3.SmoothDamp(_moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? _sprintSpeed : _walkSpeed), ref _smoothMoveVelocity, _smoothTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rb.AddForce(transform.up * _jumpForce);
        }
    }

    private void EquipItem(int _index)
    {
        if (_index == _previousItemIndex)
            return;

        _itemIndex = _index;

        items[_itemIndex].ItemGameObject.SetActive(true);

        if (_previousItemIndex != -1)
        {
            items[_previousItemIndex].ItemGameObject.SetActive(false);
        }

        _previousItemIndex = _itemIndex;

        if (_PV.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("ItemIndex", _itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    private void FixedUpdate()
    {
        if (!_PV.IsMine)
            return;

        _rb.MovePosition(_rb.position + transform.TransformDirection(_moveAmount) * Time.fixedDeltaTime);
    }

    [PunRPC]
    private void RPC_TakeDamage(float damage, PhotonMessageInfo info)
    {
        _currentHealth -= damage;

        _healthbarImage.fillAmount = _currentHealth / _maxHealth;

        if (_currentHealth <= 0)
        {
            Die();
            PlayerManager.Find(info.Sender).GetKill();
        }
    }

    private void Die()
    {
        _playerManager.Die();
    }
}