using FluentValidation;
using Minesweeper_WPF.Core.Core;

namespace MinesweeperBlazor.FluentValidators
{
    public class GameConfigurationValidator : AbstractValidator<GameConfiguration>
    {
        public GameConfigurationValidator()
        {
            RuleFor(r => r.Rows).InclusiveBetween(2, 30);
            RuleFor(r => r.Columns).InclusiveBetween(2, 60);
            RuleFor(r => r.BombsCount).GreaterThan(0);
            RuleFor(r => r.BombsCount).LessThan(r => r.Columns * r.Rows);
        }
    }
}
