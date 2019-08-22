using UnityEngine;

public class LookInputMiddleman : BaseVector3InputMiddleman, ILook
{
    public void Set(Vector3 input)
    {
        Notify(input);
    }
}