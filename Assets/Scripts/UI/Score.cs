using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private TMP_Text _scoreMushrooms;
    [SerializeField] private TMP_Text _scoreCristallGolds;
    [SerializeField] private TMP_Text _scoreCristallUran;
    [SerializeField] private TMP_Text _scoreTree;
    [SerializeField] private TMP_Text _scoreRock;

    private void OnEnable()
    {
        _base.ScoreChangedMushrooms += OnScoreChangedMushrooms;
        _base.ScoreChangedGolds += OnScoreChangedGolds;
        _base.ScoreChangedUran += OnScoreChangedUran;
        _base.ScoreChangedTree += OnScoreChangedTree;
        _base.ScoreChangedRock += OnScoreChangedRock;
    }

    private void OnDisable()
    {
        _base.ScoreChangedMushrooms -= OnScoreChangedMushrooms;
        _base.ScoreChangedGolds -= OnScoreChangedGolds;
        _base.ScoreChangedUran -= OnScoreChangedUran;
        _base.ScoreChangedTree -= OnScoreChangedTree;
        _base.ScoreChangedRock -= OnScoreChangedRock;
    }

    private void OnScoreChangedMushrooms(int score)
    {
        _scoreMushrooms.text = score.ToString();
    }

    private void OnScoreChangedGolds(int score)
    {
        _scoreCristallGolds.text = score.ToString();
    }

    private void OnScoreChangedUran(int score)
    {
        _scoreCristallUran.text = score.ToString();
    }

    private void OnScoreChangedTree(int score)
    {
        _scoreTree.text = score.ToString();
    }

    private void OnScoreChangedRock(int score)
    {
        _scoreRock.text = score.ToString();
    }
}
