namespace TennisCalculator.Interfaces;

public interface IGameScore
{
    bool HasAdvantage { get; }
    bool HasFortyPoints { get; }
    bool HasLessThanFortyPoints { get; }
    bool IsDeuce { get; }
    bool IsWinner { get; }
    IPlayer Player { get; }
    IPointValue PointValue { get; set; }

    void DeuceScore();
    void FortyScore();
    void IncreaseScore();
    void TakeTheAdvantage();
    void WinTheGame();
}