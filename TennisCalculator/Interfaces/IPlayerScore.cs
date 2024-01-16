namespace TennisCalculator.Interfaces;

public interface IPlayerScore
{
    bool HasAdvantage { get; }
    bool HasFortyPoints { get; }
    bool HasLessThanFortyPoints { get; }
    bool IsDeuce { get; }
    bool IsWinner { get; }
    IPlayer Player { get; }
    IScore Score { get; set; }

    void DeuceScore();
    void FortyScore();
    void IncreaseScore();
    void TakeTheAdvantage();
    void WinTheGame();
}