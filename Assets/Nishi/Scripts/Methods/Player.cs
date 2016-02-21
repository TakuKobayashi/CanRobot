using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

// RS
namespace CanRobot.Methods
{
    enum RobotState
    {
        Idle,
        Move,
        Turn,
        PickUp
    }
    public class Player : MonoBehaviour
    {
        [SerializeField] private RobotState _RobotState = RobotState.Idle;
        [SerializeField] private AudioSource _AudioSource = null;
        public void Awake()
        {
            _AudioSource = this.GetComponent<AudioSource>();
        }
        public void Update()
        {
            SEUpdate();
        }

        /// <summary>
        /// サウンドエフェクトのアップデート
        /// </summary>
        private void SEUpdate()
        {
            if (_RobotState == RobotState.Idle)
            {
                _AudioSource.loop = false;
                _AudioSource.clip = Resources.Load("Sounds/SE/Idle") as AudioClip;
            }
            else if
                (_RobotState == RobotState.Move)
            {
                _AudioSource.loop = false;
                _AudioSource.clip = Resources.Load("Sounds/SE/Move") as AudioClip;
            }
            else if (_RobotState == RobotState.Turn)
            {
                _AudioSource.loop = false;
                _AudioSource.clip = Resources.Load("Sounds/SE/Turn") as AudioClip;
            }
            else if (_RobotState == RobotState.PickUp)
            {
                _AudioSource.loop = false;
                _AudioSource.clip = Resources.Load("Sounds/SE/PickUp") as AudioClip;
            }
        }

        /// <summary>
        /// 動く アニメーション切り替え
        /// </summary>
        public void Idle()
        {
            _AudioSource.Stop();
            _RobotState = RobotState.Idle;
            //アニメーション切り替え
        }

        /// <summary>
        /// 動く アニメーション切り替え
        /// </summary>
        public void Move()
        {
            _AudioSource.Play();
            _RobotState = RobotState.Move;
            this.GetComponent<Animator>().SetInteger("State",(int)_RobotState);
        }

        /// <summary>
        /// 右向く アニメーション切り替え
        /// </summary>
        public void RightTurn()
        {
            _AudioSource.Play();
            _RobotState = RobotState.Turn;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 左向く アニメーション切り替え
        /// </summary>
        public void LeftTurn()
        {
            _AudioSource.Play();
            _RobotState = RobotState.Turn;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 拾う アニメーション切り替え
        /// </summary>
        public void PickUp()
        {
            _AudioSource.Play();
            _RobotState = RobotState.PickUp;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);

        }

    }
}
