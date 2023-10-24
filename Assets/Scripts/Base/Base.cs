using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private DetectorResources _detectorResources;
    [SerializeField] private Unit[] _units;
    [SerializeField] private DropOffPoint _dropOffPoint;

    private int _scoreMushrooms;
    private int _scoreCristallGolds;
    private int _scoreCristallUran;
    private int _scoreTree;
    private int _scoreRock;

    public event UnityAction<int> ScoreChangedMushrooms;
    public event UnityAction<int> ScoreChangedGolds;
    public event UnityAction<int> ScoreChangedUran;
    public event UnityAction<int> ScoreChangedTree;
    public event UnityAction<int> ScoreChangedRock;

    private void OnEnable()
    {
        _detectorResources.ResourcesPositionsFound += TrySendingUnits;
        _dropOffPoint.Droped += OnDroped;
    }

    private void OnDisable()
    {
        _detectorResources.ResourcesPositionsFound -= TrySendingUnits;
        _dropOffPoint.Droped -= OnDroped;
    }

    private void OnDroped(Resource resources)
    {
        switch (resources)
        {
            case Mushrooms:
                IncraceScore(++_scoreMushrooms, ScoreChangedMushrooms);
                break;

            case CristallGolds:
                IncraceScore(++_scoreCristallGolds, ScoreChangedGolds);
                break;

            case CristallUran:
                IncraceScore(++_scoreCristallUran, ScoreChangedUran);
                break;
            case Tree:
                IncraceScore(++_scoreTree, ScoreChangedTree);
                break;
            case Rock:
                IncraceScore(++_scoreRock, ScoreChangedRock);
                break;
            default:
                break;
        }
    }

    private void IncraceScore(int score, UnityAction<int> unityAction)
    {
        unityAction?.Invoke(score);
    }

    private void TrySendingUnits(Resource[] resources)
    {
        for (int i = 0; i < resources.Length; i++)
        {
            Unit unit = GetFreeUnit();

            if (unit != null)
                unit.NavigateToAndFromResource(resources[i], _dropOffPoint);
        }
    }

    private Unit GetFreeUnit()
    {
        for (int i = 0; i < _units.Length; i++)
        {
            if (_units[i].IsMoving() == false)
                return _units[i];
        }

        return null;
    }
}
