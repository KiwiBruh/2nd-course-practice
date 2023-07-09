// Класс Student, хранящий информацию о студенте
// 1)(хранимые данные:
//  1.1)ФИО (как отдельные поля),
//  1.2)учебная группа (в формате M[Номеринститута]O-[Номер группы][Б,М,А]-[Год поступления];
//  1.3)строку считаем априори валидной),
//  1.4)выбранный курс для прохождения практики (C#, Go, Yandex, Сбор и разметка данных, Инфраструктурная деятельность, etc.))


using System.Text;

namespace lab1;

public class Student :
    IEquatable<Student>,
    IEquatable<object>
{

    private const int IntValueDefault = 15;
    private const string StringValueDefault = "";
    private static readonly object SomeObject;

    public string _FirstName { get; set; }

    public string _SecondName { get; set; }

    public string _Patronymic { get; set; }

    public string _Group { get; set; }

    public string _Practice { get; set; }

    static Student()
    {

        SomeObject = new object();
    }

    public Student(string FirstName = "", string Patronymic = "",
        string SecondName = "", string Group = "", string Practice = "")
    {
        _FirstName = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
        _SecondName = SecondName ?? throw new ArgumentNullException(nameof(SecondName));
        _Patronymic = Patronymic ?? throw new ArgumentNullException(nameof(Patronymic));
        _Group = Group ?? throw new ArgumentNullException(nameof(Group));
        _Practice = Practice ?? throw new ArgumentNullException(nameof(Practice));
        Console.WriteLine("Your input:");
        Console.WriteLine($"Student: {FirstName} {Patronymic} {SecondName}");
        Console.WriteLine($"Group: {Group}");
        Console.WriteLine($"Practice: {Practice}");
    }



    public char courseNumber
    {
        get
        {
            if (_Group[3] == '-')
            {
                return _Group[4];
            }
            else
            {
                return _Group[5];
            }

        }
    }
    
    public override string ToString()
    {
        
        
        var builder = new StringBuilder("[ _FirstName: ");
        builder
            .Append(_FirstName)
            .Append(", _SecondName: ")
            .Append(_SecondName)
            .Append(",  _Patronymic: ")
            .Append( _Patronymic)
            .Append(",  _Group: ")
            .Append( _Group)
            .Append(",  _Practice: ")
            .Append( _Practice)
            .Append(" ]");
        return builder.ToString();
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is Student std)
        {
            return Equals(std);
        }

        return false;
    }

    public bool Equals(Student std)
    {
        if (std == null)
        {
            return false;
        }

        return _FirstName.Equals(std._FirstName)
               && _SecondName.Equals(std._SecondName)
               && _Patronymic.Equals(std._Patronymic)
               && _Group.Equals(std._Group)
               && _Practice.Equals(std._Practice);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(_FirstName, _SecondName, _Patronymic, _Group, _Practice);
    }

}


