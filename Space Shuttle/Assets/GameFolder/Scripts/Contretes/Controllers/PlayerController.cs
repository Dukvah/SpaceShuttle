using SpaceShuttle.Inputs;
using SpaceShuttle.Movements;
using UnityEngine;
using DG.Tweening;

namespace SpaceShuttle.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] OxygenSlider _oxygen;
        [SerializeField] float _force;

        public UIManager _uiManager;
        
        Animator _animator;
        Mover _mover;
        Rotator _rotator;
        InputController _input;
        Rigidbody _rigidbody;

        Vector2 _joystickDir;
        bool _canMove;
        bool _canForceForward;

        public float Force => _force;
        public bool _breathable { get; set; }

        private void Awake()
        {
            _input = new InputController();
            _mover = new Mover(this);
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
                _canForceForward = true;
                _animator.SetBool("isFly", true);
            }
            else
            {
                _canForceForward = false;
                _animator.SetBool("isFly", false);
            }

            _joystickDir = _input.JoystickDirection;
        }

        private void FixedUpdate()
        {
            Breath();
            
            if (_canForceForward)
            {
                _mover.FixedTick(_canForceForward);
            }

            _rotator.FixedTick(_joystickDir);
        }

        public void OnBoard(Vector3 sitPositon)
        {
            _rigidbody.velocity = Vector3.zero;
            _uiManager.OnBoardButton();
            
            transform.DOMove(sitPositon, 2f).OnComplete(() =>
            {
                _canMove = false;
                _breathable = true;
            });
        }

        public void Launch()
        {
            this.gameObject.transform.parent = null;

            transform.DOMove(new Vector3(transform.position.x, 0, transform.position.z + 1), 1f).OnComplete(() =>
            {
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
