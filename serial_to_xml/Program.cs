using System.IO;
using System.Xml.Serialization;

namespace serial_to_xml
{//Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
 // класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
 // таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.

    // для сериализации в XML: 1 public class, public members, ctor без параметров
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
            // просто сериализация в XML
            Citizen citizen = new Citizen("Вася", 25);
            FileStream stream = new FileStream("serialization.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Citizen));

            serializer.Serialize(stream, citizen); //гражданина засериализовать в поток
            stream.Close();

            // сериализация с атрибутами
            CitizenAtr citizenAtr = new CitizenAtr("Вася", 25);
            FileStream streamAtr = new FileStream("serializationAtr.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializerAtr = new XmlSerializer(typeof(CitizenAtr));

            serializerAtr.Serialize(streamAtr, citizenAtr);
            streamAtr.Close();
        }
    }
}
