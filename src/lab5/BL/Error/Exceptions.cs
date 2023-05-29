namespace Error
{
    //room
    [Serializable]
    public class RoomExistsException : Exception
    {
        public RoomExistsException(string information = "\nThe room already exists!\n") : base(information) { }
        public RoomExistsException(Exception inner, string information = "\nThe room already exists!\n") : base(information, inner) { }
    }
    [Serializable] public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(string information = "\nRoom not found!\n") : base(information) { }
        public RoomNotFoundException(Exception inner, string information = "\nRoom not found!\n") : base(information, inner) { }
    }
    [Serializable]
    public class RemoveRoomErrorException : Exception
    {
        public RemoveRoomErrorException(string information = "\nRemoving failed!\n") : base(information) { }
        public RemoveRoomErrorException(Exception inner, string information = "\nRemoving failed!\n") : base(information, inner) { }
    }
    //user
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string information = "\nUser is not found!\r\n\n") : base(information) { }
        public UserNotFoundException(Exception inner, string information = "\nUser is not found!\r\n\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddUserErrorException : Exception
    {
        public AddUserErrorException(string information = "Failed to add user!\n") : base(information) { }
        public AddUserErrorException(Exception inner, string information = "Failed to add user!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UserExistsException : Exception
    {
        public UserExistsException(string information = "User already exists\n") : base(information) { }
        public UserExistsException(Exception inner, string information = "User already exists\n") : base(information, inner) { }
    }
    [Serializable]
    public class PasswordWrongException : Exception
    {
        public PasswordWrongException(string information = "Password Wrong!\n") : base(information) { }
        public PasswordWrongException(Exception inner, string information = "Password Wrong!\n") : base(information, inner) { }
    }
    [Serializable]
    public class LoginNotFoundException : Exception
    {
        public LoginNotFoundException(string information = "Login not found!\n") : base(information) { }
        public LoginNotFoundException(Exception inner, string information = "Login not found!\n") : base(information, inner) { }
    }

    //Guest and Staff
    [Serializable]
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(string information = "\nPerson not found!\n") : base(information) { }
        public PersonNotFoundException(Exception inner, string information = "\nЧPerson not found!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddPersonErrorException : Exception
    {
        public AddPersonErrorException(string information = "\nPerson could't be added!\n") : base(information) { }
        public AddPersonErrorException(Exception inner, string information = "\nPerson could't be added!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UpdatePersonErrorException : Exception
    {
        public UpdatePersonErrorException(string information = "\nЧеловека не удалось добавить!\n") : base(information) { }
        public UpdatePersonErrorException(Exception inner, string information = "\nЧеловека не удалось добавить!\n") : base(information, inner) { }
    }
    //request
    [Serializable]
    public class AddRequestErrorException : Exception
    {
        public AddRequestErrorException(string infomation = "\nRequest can't add!") : base(infomation) { }
        public AddRequestErrorException(Exception inner, string infomation = "\nRequest can't add!") : base(infomation, inner) { }
    }
    [Serializable]
    public class RequestNotFoundException : Exception
    {
        public RequestNotFoundException(string infomation = "\nRequest Not Found!") : base(infomation) { }
        public RequestNotFoundException(Exception inner, string infomation = "\nRequest Not Found!") : base(infomation, inner) { }
    }

    //history
    [Serializable]
    public class AddHistoryErrorException : Exception
    {
        public AddHistoryErrorException(string infomation = "\nRequest can't add!") : base(infomation) { }
        public AddHistoryErrorException(Exception inner, string infomation = "\nRequest can't add!") : base(infomation, inner) { }
    }
    [Serializable]
    public class HistoryNotFoundException : Exception
    {
        public HistoryNotFoundException(string infomation = "\nRequest Not Found!") : base(infomation) { }
        public HistoryNotFoundException(Exception inner, string infomation = "\nRequest Not Found!") : base(infomation, inner) { }
    }

    //database
    [Serializable]
    public class DataBaseConnectException : Exception
    {
        public DataBaseConnectException(string information = "Could't connect to Data Base!\n") : base(information) { }
        public DataBaseConnectException(Exception inner, string information = "Could't connect to Data Base!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DataBaseRunErrorException : Exception
    {
        public DataBaseRunErrorException(string information = "Wrong in Data Base!\n") : base(information) { }
        public DataBaseRunErrorException(Exception inner, string information = "Wrong in Data Base!\n") : base(information, inner) { }
    }
}
