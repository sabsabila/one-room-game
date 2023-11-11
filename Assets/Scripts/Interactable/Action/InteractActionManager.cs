using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractActionManager : MonoBehaviour
{
    

    #region Instance

    public static InteractActionManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
}
