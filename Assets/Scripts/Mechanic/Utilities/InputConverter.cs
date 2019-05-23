using UnityEngine;

namespace Mechanic.Utilities
{
    public class InputConverter : MonoBehaviour
    {
        public enum ConversionType { Vector3ToVector2, Vector2ToVector3 }
        public ConversionType Type = ConversionType.Vector2ToVector3;

        public Vector3InputCallback Vector3InputCallback = new Vector3InputCallback();
        public Vector2InputCallback Vector2InputCallback = new Vector2InputCallback();

        private void Awake()
        {
            switch (Type)
            {
                case ConversionType.Vector3ToVector2:
                    Vector3InputCallback.AddListener(Vector3ToVector2);
                    break;
                case ConversionType.Vector2ToVector3:
                    Vector2InputCallback.AddListener(Vector2ToVector3);
                    break;
                default:
                    break;
            }
        }

        public void Vector2ToVector3(Vector2 input)
        {
            Vector3InputCallback.Invoke(input);
        }

        public void Vector3ToVector2(Vector3 input)
        {
            Vector2InputCallback.Invoke(input);
        }
    }
}