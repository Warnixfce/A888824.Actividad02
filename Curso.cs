using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad02
{
    class Curso
    {
        //cro la clase curso asi uso a los cursos como objetos

        public int id;
        public int capacidad;

        public List<Alumno> alumnos = new List<Alumno>(); //cada curso tiene una lista de alumnos (con objetos de tipo alumno)

        public bool AgregarAlumno(Alumno alumno) //solo se va a gregar al alumno al curso (a la lista) si la capacidad del curso lo permite. Viene como parametro el alumno
        {
            if(capacidad > alumnos.Count)
            {
                alumnos.Add(alumno); //agrego a lista
                return true;
            }

            return false;
        }
    }
}
