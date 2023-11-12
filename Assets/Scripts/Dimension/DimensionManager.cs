using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _dimensionList;
    
    private GameObject _activeDimension;

    private void Start()
    {
        SwitchDimension();
    }

    private int GetNextDimensionIdx()
    {
        if (_activeDimension == null)
        {
            return 0;
        }
        else
        {
            var idx = _dimensionList.IndexOf(_activeDimension) + 1;

            if (idx >= _dimensionList.Count)
            {
                return 0;
            }

            return idx;
        }
    }

    public void SwitchDimension()
    {
        var nextIdx = GetNextDimensionIdx();

        _activeDimension = _dimensionList[nextIdx];

        foreach(var dimension in _dimensionList)
        {
            if(dimension == _activeDimension)
            {
                dimension.SetActive(true);
            }
            else
            {
                dimension.SetActive(false);
            }
        }
    }

    #region Instance

    public static DimensionManager Instance;

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
