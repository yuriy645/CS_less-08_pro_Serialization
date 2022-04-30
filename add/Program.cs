using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace add
{//Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
 //типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.
    [Serializable]
    class Citizen
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen = new Citizen("Вася", 25);
            FileStream stream = File.Create("Base.data");
            BinaryFormatter formatter = new BinaryFormatter(); //сериализатор 
            
            formatter.Serialize(stream, citizen); //гражданина засериализовать в поток
            stream.Close();
            
            FileStream streamDe = File.Open("Base.data", FileMode.Open);
            Citizen citizenDe = formatter.Deserialize(streamDe) as Citizen; //десериализовать поток в гражданина, если можно
            streamDe.Close();
            if (citizen != null)
            {
                Console.WriteLine("Name: {0}, Age: {1}", citizenDe.Name, citizenDe.Age);
            }

            Console.ReadLine();
        }
       
    }
}
