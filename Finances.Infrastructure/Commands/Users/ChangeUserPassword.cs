namespace Finances.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
