using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    [SerializeField] private List<Route> _routeList;

    [SerializeField] private List<string> _acquiredRequirementList;

    [SerializeField] private Route _completedRoute;

    public void AddRequirementToList(string id)
    {
        if (!CheckRequirementExist(id))
        {
            _acquiredRequirementList.Add(id);
        }

        CheckForRoute();
    }

    public void RemoveRequirementFromList(string id)
    {
        if (CheckRequirementExist(id))
        {
            _acquiredRequirementList.Remove(id);
        }
    }

    public bool CheckRequirementExist(string id)
    {
        return _acquiredRequirementList.Contains(id);
    }

    public void CheckForRoute()
    {
        bool isCompleted = true;

        foreach(var route in _routeList)
        {
            foreach(var requirement in route.RequirementList)
            {
                if(!_acquiredRequirementList.Exists(x => x.Equals(requirement.RequirementId)))
                {
                    isCompleted = false;

                    break;
                }
            }

            if (isCompleted)
            {
                _completedRoute = route;

                break;
            }
        }

        if (isCompleted)
        {
            GameManager.EndingNote = _completedRoute.EndingNote;
            GameManager.EndGame();
        }
    }

    #region Instance

    public static RouteManager Instance;

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
