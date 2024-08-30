using UnityEngine;
using Player.Controls;

namespace Player.Audio
{
    public class PlayerSoundController : MonoBehaviour
    {
        [SerializeField] private float walkInterval = 0.5f;
        [SerializeField] private float runIntervalFactor = 0.1f;

        private Footsteps _footsteps;
        private FirstPersonController _player;

        private bool _isMoving;
        private float _timer;

        private void Awake()
        {
            _player = GetComponent<FirstPersonController>();
            _footsteps = GetComponent<Footsteps>();
        }

        private void Update()
        {
            _isMoving = _player.IsWalking || _player.IsRunning;
            OnFootstep();
        }

        private void OnFootstep()
        {
            if (!_isMoving) return;

            _timer += Time.deltaTime;
            float stepInterval = _player.IsRunning ? walkInterval - runIntervalFactor : walkInterval;

            if (_timer >= stepInterval)
            {
                _footsteps.PerformStep(_player.IsRunning);
                _timer = 0f;
            }
        }
    }

}