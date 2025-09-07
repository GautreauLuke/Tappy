using Godot;
using System;

public partial class ScoreManager : Node
{
    private uint _score = 0;
    private uint _highScore = 0;

    private const string SCORE_FILE = "user://tappy.save";


    public static ScoreManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
        LoadScoreFromFile();
    }

    public override void _ExitTree()
    {
        SaveScoreToFile();
    }


    public static uint GetScore()
    {
        return Instance._score;
    }

    public static uint GetHighScore()
    {
        return Instance._highScore;
    }

    public static void SetScore(uint value)
    {
        Instance._score = value;
        if (Instance._score > Instance._highScore)
        {
            Instance._highScore = Instance._score;
        }
        GD.Print($"Score: {Instance._score}. High Score: {Instance._highScore}");
        SignalManager.EmitOnScored();
    }

    public static void ResetScore()
    {
        SetScore(0);
    }

    public static void IncrimentScore()
    {
        SetScore(GetScore() + 1);
    }

    private void SaveScoreToFile()
    {
        using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Write);
        if (file != null)
        {
            file.Store32(_highScore);
        }
    }

    private void LoadScoreFromFile()
    {
        using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Read);
        if (file != null)
        {
            _highScore = file.Get32();
        }
        else
        {
            _highScore = 0;
        } 
            
    }
}
