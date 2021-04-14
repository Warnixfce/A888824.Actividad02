using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad02
{
    class Program
    {
        static void Main(string[] args)
        {


            ///////////////////////////// Hice aclaraciones solo para guiarme /////////////////////////////////
            

            List<Alumno> alumnos = new List<Alumno>(); //hago listas de cursos y alumnos para guardar lo que me ingresa el usuario
            List<Curso> cursos = new List<Curso>();

            //Declaro variables
            string Agregar;
            bool FlagGral = false;
            bool FlagInt = false;
            bool FlagDouble = false;
            string numeroLegajo;
            int numeroLegajoValidado = 0;
            string ranking;
            double rankingValidado;

            string numeroCurso;
            int numeroCursoValidado = 0;
            string capacidadCurso;
            int capacidadCursoValidado = 0;

            //PUNTO A) Y B): AGREGO CURSOS Y ALUMNOS
            //voy validando lo que me ingresa el usuario

            do
            {
                do
                {
                    Console.WriteLine($"Por favor ingrese el número de curso {cursos.Count}: ");
                    numeroCurso = Console.ReadLine();
                    FlagInt = ValidarEntero(numeroCurso, ref numeroCursoValidado);

                } while (FlagInt == false);

                do
                {
                    Console.WriteLine($"Por favor ingrese la capacidad del curso {cursos.Count}: ");
                    capacidadCurso = Console.ReadLine();
                    FlagInt = ValidarEntero(capacidadCurso, ref capacidadCursoValidado);

                } while (FlagInt == false);

                Curso curso = new Curso(); //creo un objeto curso de la clase Curso y le agrego lo que ingreso el usuario validado
                curso.id = numeroCursoValidado;
                curso.capacidad = capacidadCursoValidado;

                cursos.Add(curso); //agrego el curso a la lista

                Console.Write("¿Desea agregar más cursos? s/n: ");
                Agregar = Console.ReadLine();

                if (Agregar == "s")
                {
                    FlagGral = false;
                }
                else if (Agregar == "n")
                {
                    FlagGral = true;
                }

            } while (FlagGral == false);

            do
            {
                do
                {
                    Console.WriteLine($"Por favor ingrese el número de legajo del alumno {alumnos.Count}: ");
                    numeroLegajo = Console.ReadLine();
                    FlagInt = ValidarEntero(numeroLegajo, ref numeroLegajoValidado);

                } while (FlagInt == false);

                do
                {
                    Console.WriteLine($"Por favor ingrese ranking alumno {alumnos.Count}:");
                    ranking = Console.ReadLine();

                    if (!double.TryParse(ranking, out rankingValidado))
                    {
                        Console.WriteLine("Debe ingresar un número.");
                    }
                    else if (rankingValidado <= 0)
                    {
                        Console.WriteLine("Debe ingresar un número positivo.");
                    }
                    else
                    {
                        FlagDouble = true;
                    }

                } while (FlagDouble == false);

                Alumno alumno = new Alumno(); //hago lo mismo con los alumnos (que hice con los cursos)
                alumno.legajo = numeroLegajoValidado;
                alumno.ranking = rankingValidado;

                alumnos.Add(alumno);

                Console.Write("¿Desea agregar más alumnos? s/n: ");
                Agregar = Console.ReadLine();

                if (Agregar == "s")
                {
                    FlagGral = false;
                }
                else if (Agregar == "n")
                {
                    FlagGral = true;
                }

            } while (FlagGral == false);


            bool ValidarEntero(string numeroAValidar, ref int numeroValidado) //metodo para validar
            {
                bool Flag = false;

                if (!int.TryParse(numeroAValidar, out numeroValidado))
                {
                    Console.WriteLine("Debe ingresar un número.");
                }
                else if (numeroValidado <= 0)
                {
                    Console.WriteLine("Debe ingresar un número positivo.");
                }
                else
                {
                    Flag = true;
                }

                return Flag;
            }

            //PUNTO C: ASIGNO

            List<Alumno> listaOrdenada = alumnos.OrderByDescending(o => o.ranking).ToList(); //ordeno mi lista de alumnos segun su ranking (descendente)

            foreach(Alumno alumno in listaOrdenada) //tomo un alumno de mi lista ordenada...
            {                
                foreach(Curso curso in cursos) //... tomo un curso de la lista de cursos...
                {
                    if(curso.AgregarAlumno(alumno)) //y lo intento agregar a la lista de alumnos definida en la clase Curso. Si puede, le digo que salga y tome otro alumno. Si no puede, va a tomar otro curso (no ingresa en el if)
                    {
                        break;
                    }
                }
            }


            //PUNTO D: MUESTRO

            foreach(Curso curso in cursos) //tomo un curso de mi lista de cursos
            {
                Console.WriteLine($"El curso {curso.id} tiene a los alumnos: "); //le digo que muestre que el curso que tome (curso X)

                foreach (Alumno alumno in curso.alumnos) //tomo cada alumno que esta en la lista de mi curso en cuestion (que defini en la clase)...
                {
                     Console.WriteLine($" - {alumno.legajo}."); //... y muestro solo el legajo del alumno
                }
            }

            Console.ReadLine();
            
        }
    }
}
