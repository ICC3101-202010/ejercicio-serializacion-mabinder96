using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio_serializacion
{
    class Program
    {
        //Serializando
        private static void SavePerson(Persona persona)
        {
            Console.WriteLine("Nombre del archivo: ");
            string fileName = Console.ReadLine();

            if  (File.Exists(fileName)==true)
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, persona);
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);

                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, persona);
                fs.Close();
            }
            
        }

        //Deserealizar
        private static Persona LoadPerson()
        {
            Console.WriteLine("Nombre del archivo: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName) == true)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);

                IFormatter formatter = new BinaryFormatter();
                Persona persona = formatter.Deserialize(fs) as Persona;
                fs.Close();
                return persona;
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo, por favor asegúrese de escribirlo bien");
                string fileName2 = Console.ReadLine();

                do
                {
                    Console.WriteLine("No se ha encontrado el archivo, por favor asegúrese de escribirlo bien");
                    fileName2 = Console.ReadLine();

                }
                while (File.Exists(fileName2)==false);
                FileStream fs = new FileStream(fileName2, FileMode.Open);
                IFormatter formatter = new BinaryFormatter();
                Persona persona = formatter.Deserialize(fs) as Persona;
                fs.Close();
                return persona;
            }
            
        }
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();

            bool turnon = true;
            do
            {
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("Opción 1: Almacenar una persona");
                Console.WriteLine("Opción 2: Cargar una persona ");
                Console.WriteLine("Opción 3: Mostrar personas disponibles ");
                Console.WriteLine("Opción 4: Salir ");
                string election = Console.ReadLine();

                //Si elige la opción 1, le pido al usuario las características de su persona y la almaceno
                if (election == "1")
                {
                    Console.WriteLine("Ingese el nombre de la persona");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Ingese el apellido de la persona");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Ingese la edad de la persona");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Persona persona = new Persona(firstName, lastName, age);
                    personas.Add(persona);
                    SavePerson(persona);
                }
                else if (election == "2")
                {
                    Persona persona = LoadPerson();
                    personas.Add(persona);

                }
                else if (election == "3")
                {
                    foreach (Persona persona in personas)
                    {
                        persona.Informacion();
                    }
                }
                else if (election == "4")
                {
                    turnon = false;
                }
            }
            while (turnon == true);
        }
    }
}
