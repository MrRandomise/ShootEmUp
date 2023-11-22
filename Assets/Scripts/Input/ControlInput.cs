using UnityEngine;

public abstract class ControlInput: MonoBehaviour
{
    public event System.Action OnFireAction;
    public event System.Action<int> OnMoveAction;
    
    public virtual void OnFireInput()
    {
        OnFireAction?.Invoke();
    }

    public virtual void OnMoveInput(int dir)
    {
        OnMoveAction?.Invoke(dir);
    }
}