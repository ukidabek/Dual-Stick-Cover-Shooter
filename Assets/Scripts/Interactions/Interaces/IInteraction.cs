using UnityEngine;

namespace Interactions
{
    public interface IInteraction
    {
        Vector3 Position { get; }
        void Use(GameObject user);
        void Leave();
        void Show();
        void Hide();
    }
}