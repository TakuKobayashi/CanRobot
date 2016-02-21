using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using CanRobot;

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
        [SerializeField]
        private RobotState _RobotState = RobotState.Idle;
        [SerializeField]
        private AudioSource _AudioSource = null;
        public void Awake()
        {
            _AudioSource = this.GetComponent<AudioSource>();
        }

        /// <summary>
        /// 動く アニメーション切り替え
        /// </summary>
        public void Idle()
        {
            _AudioSource.loop = false;
            //_AudioSource.clip = Resources.Load("Sounds/SE/SE_Idle_000") as AudioClip;

            _AudioSource.Stop();
            _RobotState = RobotState.Idle;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 動く アニメーション切り替え
        /// </summary>
        public void Move()
        {
            _AudioSource.loop = true;
            _AudioSource.clip = Resources.Load("Sounds/SE/SE_Move_000") as AudioClip;

            _AudioSource.Play();
            _RobotState = RobotState.Move;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 右向く アニメーション切り替え
        /// </summary>
        public void RightTurn()
        {
            _AudioSource.loop = false;
            _AudioSource.clip = Resources.Load("Sounds/SE/SE_Turn_000") as AudioClip;

            _AudioSource.Play();
            _RobotState = RobotState.Turn;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 左向く アニメーション切り替え
        /// </summary>
        public void LeftTurn()
        {
            _AudioSource.loop = false;
            _AudioSource.clip = Resources.Load("Sounds/SE/SE_Turn_000") as AudioClip;

            _AudioSource.Play();
            _RobotState = RobotState.Turn;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        /// <summary>
        /// 拾う アニメーション切り替え
        /// </summary>
        public void PickUp()
        {
            _AudioSource.loop = false;
            _AudioSource.clip = Resources.Load("Sounds/SE/SE_PickUp_000") as AudioClip;

            _AudioSource.Play();
            _RobotState = RobotState.PickUp;
            this.GetComponent<Animator>().SetInteger("State", (int)_RobotState);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("呼ばれた");
            if (collision.gameObject.tag == "Goal")
            {
                SceneManager.GameClearLoad(00);
            }
        }
    }
}
