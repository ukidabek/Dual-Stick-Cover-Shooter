using UnityEngine;

namespace Characters.Player
{
    public abstract class OnPlayerEventHadler : MonoBehaviour
    {
        [SerializeField, Tooltip("The player's id on which the event will be called. If -1 event reacts to all players.")] private int _playerID = -1;

        [Space] public OnPlayerEvent OnPlayerEvent = new OnPlayerEvent();

        protected abstract void Register();
        protected abstract void UnRegister();

        private void Awake()
        {
            Register();
        }

        private void OnDestroy()
        {
            UnRegister();
        }

        protected void OnPlayerCallback(PlayerController playerController)
        {
            if (_playerID < 0)
                OnPlayerEvent.Invoke(playerController);
            else if (playerController.PlayerID == _playerID)
                OnPlayerEvent.Invoke(playerController);
        }
    }
}