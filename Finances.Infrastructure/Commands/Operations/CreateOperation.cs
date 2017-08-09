namespace Finances.Infrastructure.Commands.Operations
{
    public class CreateOperation : ICommand
    {
        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
