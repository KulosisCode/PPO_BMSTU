namespace HotelBooking
{
    //room
    [Serializable]
    public class RoomExistsException : Exception
    {
        public RoomExistsException() { }
        public RoomExistsException(string information = "\nКомната уже существует!\n") : base(information) { }
        public RoomExistsException(Exception inner, string information = "\nКомната уже существует!\n") : base(information, inner) { }
    }
    [Serializable] public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException() { }
        public RoomNotFoundException(string information = "\nКомната не найдена!\n") : base(information) { }
        public RoomNotFoundException(Exception inner, string information = "\nКомната не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class RemoveRoomErrorException : Exception
    {
        public RemoveRoomErrorException() { }
        public RemoveRoomErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public RemoveRoomErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    //user
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string information = "\nПользователь не найден!\n") : base(information) { }
        public UserNotFoundException(Exception inner, string information = "\nПользователь не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddUserErrorException : Exception
    {
        public AddUserErrorException() { }
        public AddUserErrorException(string information = "Пользователя не удалось добавить!\n") : base(information) { }
        public AddUserErrorException(Exception inner, string information = "Пользователя не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UserExistsException : Exception
    {
        public UserExistsException() { }
        public UserExistsException(string information = "Пользователя уже существует\n") : base(information) { }
        public UserExistsException(Exception inner, string information = "Пользователя уже существует\n") : base(information, inner) { }
    }
    //Guest and Staff
    [Serializable]
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException() { }
        public PersonNotFoundException(string information = "\nЧеловек не найден!\n") : base(information) { }
        public PersonNotFoundException(Exception inner, string information = "\nЧеловек не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddPersonErrorException : Exception
    {
        public AddPersonErrorException() { }
        public AddPersonErrorException(string information = "\nЧеловека не удалось добавить!\n") : base(information) { }
        public AddPersonErrorException(Exception inner, string information = "\nЧеловека не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UpdatePersonErrorException : Exception
    {
        public UpdatePersonErrorException() { }
        public UpdatePersonErrorException(string information = "\nЧеловека не удалось добавить!\n") : base(information) { }
        public UpdatePersonErrorException(Exception inner, string information = "\nЧеловека не удалось добавить!\n") : base(information, inner) { }
    }
    //request
    [Serializable]
    public class AddRequestErrorException : Exception
    {
        public AddRequestErrorException() { }
        public AddRequestErrorException(string infomation = "\nRequest can't add!") : base(infomation) { }
        public AddRequestErrorException(Exception inner, string infomation = "\nRequest can't add!") : base(infomation, inner) { }
    }
    [Serializable]
    public class RequestNotFoundException : Exception
    {
        public RequestNotFoundException() { }
        public RequestNotFoundException(string infomation = "\nRequest Not Found!") : base(infomation) { }
        public RequestNotFoundException(Exception inner, string infomation = "\nRequest Not Found!") : base(infomation, inner) { }
    }

    //history
    [Serializable]
    public class AddHistoryErrorException : Exception
    {
        public AddHistoryErrorException() { }
        public AddHistoryErrorException(string infomation = "\nRequest can't add!") : base(infomation) { }
        public AddHistoryErrorException(Exception inner, string infomation = "\nRequest can't add!") : base(infomation, inner) { }
    }
    [Serializable]
    public class HistoryNotFoundException : Exception
    {
        public HistoryNotFoundException() { }
        public HistoryNotFoundException(string infomation = "\nRequest Not Found!") : base(infomation) { }
        public HistoryNotFoundException(Exception inner, string infomation = "\nRequest Not Found!") : base(infomation, inner) { }
    }
}
