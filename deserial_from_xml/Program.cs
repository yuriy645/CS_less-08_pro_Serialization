using System;
using System.IO;
using System.Xml.Serialization;

namespace deserial_from_xml
{// Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего
 // примера.Отобразите состояние объекта на экране.
    public class Citizen
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Citizen()
        {

        }
    }

    [XmlRoot("Heading")] // будет заголовок Heading 
    public class CitizenAtr
    {
        [XmlElement("NAME")] // NAME будет имя тега в столбик
        public string Name { get; set; }
        [XmlAttribute("AGE")] // будет атрибут в заголовке AGE="25"
        public int Age { get; set; }

        public CitizenAtr(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public CitizenAtr()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // просто десериализация из XML
            XmlSerializer serializer = new XmlSerializer(typeof(Citizen));
            FileStream stream = new FileStream("serialization.xml", FileMode.Open, FileAccess.Read);

            Citizen citizen = (Citizen)serializer.Deserialize(stream);
            stream.Close();
            Console.WriteLine(citizen.Name + ", " + citizen.Age);

            // сериализация с атрибутами
            XmlSerializer serializerXML = new XmlSerializer(typeof(CitizenAtr));
            FileStream streamAtr = new FileStream("serializationAtr.xml", FileMode.Open, FileAccess.Read);

            CitizenAtr citizenAtr = (CitizenAtr)serializerXML.Deserialize(streamAtr);
            streamAtr.Close();
            Console.WriteLine(citizenAtr.Name + ", " + citizenAtr.Age);
        }
    }
}
