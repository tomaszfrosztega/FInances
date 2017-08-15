namespace Finances.Infrastructure.Commands.Accounts
{
    public class CreateAccount : ICommand
    {
        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
