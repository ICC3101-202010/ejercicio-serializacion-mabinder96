using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace Ejercicio_serializacion
{   [Serializable]
    class Persona
    {

        

        private string firstName;
        private string lastName;
        private int age;

        public Persona(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }

        public void  Informacion() //Creo el método Informacion()
        {
            Console.WriteLine( $"Nombre: {firstName}; Apellido: {lastName}; Edad: {age}");
        }

        

    }
}
