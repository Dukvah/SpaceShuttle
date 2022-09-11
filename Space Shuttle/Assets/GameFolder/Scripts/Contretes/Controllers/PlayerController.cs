using SpaceShuttle.Inputs;
using SpaceShuttle.Movements;
using UnityEngine;
using DG.Tweening;

namespace SpaceShuttle.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject _radar, _leftStick, _rightStick;
        [SerializeField] OxygenSlider _oxygen;
        [SerializeField] float _speed;
        [SerializeField] float _gunRotationSpeed;

        public UIManager _uiManager;
        
        Animator _animator;
        GunMover _gunMover;
        Mover _mover;
        Rotator _rotator;
        InputController _input;
        Rigidbody _rigidbody;

        Vector2 _moveJoystickDir;
        Vector2 _gunJoystickDir;
        
        bool _canMove;
        bool _canForceForward;
        bool _canMining;

        public GameObject Radar => _radar;
        public float Speed => _speed;
        public float GunRotationSpeed => _gunRotationSpeed;
        public bool _breathable { get; set; }

        private void Awake()
        {
            _input = new InputController();
            _mover = new Mover(this);
            _gunMover = new GunMover(this);
            _rotator = new Rotator(this);
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _breathable = true;
            _canMove = true;
            
        }
        private void Update()
        {
            if (!_canMove) return;

            if (_input.IsForceForward)
            {
                _rightStick.SetActive(false);
                _canForceForward = true;
                _animator.SetBool("isFly", true);
            }
            else
            {
                _rightStick.SetActive(true);
                _canForceForward = false;
                _animator.SetBool("isFly", false);
            }

            if (_input.IsMining)
            {
                _radar.SetActive(true);
                _canMining = true;
            }
            else
            {
                _radar.SetActive(false);
                _canMining = false;
            }

            _moveJoystickDir = _input.MoveJoystickDirection;
            _gunJoystickDir = _input.GunJoystickDirection;
        }

        private void FixedUpdate()
        {
            Breath();
            
            if (_canForceForward)
            {
                _mover.FixedTick(_canForceForward);
            }

            if (_canMining)
            {
                _gunMover.FixedTick(_gunJoystickDir);
            }

            _rotator.FixedTick(_moveJoystickDir);
        }

        public void OnBoard(Vector3 sitPositon)
        {
            _rigidbody.velocity = Vector3.zero;
            _uiManager.OnBoardButton();
            
            transform.DOMove(sitPositon, 2f).OnComplete(() =>
            {
                _animator.SetBool("inShip", true);
                _canMove = false;
                _breathable = true;
                
            });
        }

        public void Launch()
        {
            this.gameObject.transform.parent = null;

            transform.DOMove(new Vector3(transform.position.x, 0, transform.position.z + 1), 1f).OnComplete(() =>
            {
                _animator.SetBool("inShip", false);
                _canMove = true;
                _breathable = false;
            });
        }

        private void Breath()
        {
            if (_breathable)
            {
                _oxygen.IncreaseProgress(0.001f);
            }
            else if (_oxygen.DecreaseProgress(0.0005f))
            {
                _uiManager.GameOver();
            }
        }
    }
}
