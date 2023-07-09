

//Задание 1.
// Реализовать класс Student, хранящий информацию о студенте
// +1)(хранимые данные:
//  1.1)ФИО (как отдельные поля),
//  1.2)учебная группа (в формате M[Номеринститута]O-[Номер группы][Б,М,А]-[Год поступления];
//  1.3)строку считаем априори валидной),
//  1.4)выбранный курс для прохождения практики (C#, Go, Yandex, Сбор и разметка данных, Инфраструктурная деятельность, etc.)).
// +2)Реализуйте конструктор объекта класса, позволяющий заполнить поля
// объекта
// +3)(для ссылок на объекты строк не допускаются значения null в качестве параметров конструктора
//    при возникновении такой ситуации генерируйте исключительную ситуацию типа System.ArgumentNullException;
// исключительная ситуация также должна быть перехвачена в вызывающем коде).
// +4)Реализуйте свойства, позволяющие запрашивать значения отдельных полей объекта класса.
// +5)Также реализуйте свойство, позволяющее получить номер курса по учебной группе.
// Переопределите методы object.ToString, object.Equals, object.GetHashCode.
// +В классе реализуйте интерфейс System.IEquatable<Student>.
// +Продемонстрируйте взаимодействие с объектами класса


using lab1;

class Program1
{
    static void Main(string[] args)
    {
        try
        {
            Student obj = new Student("Alexey", "Sergeevich",
                "Pupa", "M8O-210b-21", "C#");
            Student obj2 = new Student("Alexey", "Sergeevich",
                "Pupa", "M8O-210b-21", "C#");
            Console.WriteLine($"{obj._Practice}");
            int hashCode = obj.GetHashCode();
            Console.WriteLine($"Hash code BEFORE changes: {hashCode}");
            bool areEqual = obj.Equals(obj2);
            Console.WriteLine($"Is obj equal to obj2? {areEqual}");
            obj._SecondName = "Lupa";
            Console.WriteLine($"Secondname of obj was changed to {obj._SecondName}");
            hashCode = obj.GetHashCode();
            Console.WriteLine($"Hash code AFTER changes: {hashCode}");
            areEqual = obj.Equals(obj2);
            Console.WriteLine($"Is obj equal to obj2 AFTER changes? {areEqual}");
            areEqual = obj._Practice.Equals(obj2._Practice);
            Console.WriteLine($"Is obj practice equal to obj2 practice? {areEqual}");
            Console.WriteLine($"Course: {obj.courseNumber}");
            string objString = obj.ToString();
            Console.WriteLine($"String form of obj: {objString}");
            

        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
    }
}


