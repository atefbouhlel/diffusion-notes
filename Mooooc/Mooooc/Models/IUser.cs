namespace Mooooc.Models
{
    public interface IUser
    {
        int ID { get; }
        string FirstName { get; }
        string LastName { get;  }
        string Username { get;  }
        string Password { get;  }
    }
}