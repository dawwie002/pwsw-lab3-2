using LAB3_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3_2
{
    public class Uni
    {
        double[] possibleGrades = { 2, 3, 3.5, 4, 4.5, 5 };
        List<Student> Students = new List<Student>();
        List<double[]> Grades = new List<double[]>();

        // metoda dodajaca studenta
        public void addStudent(Student student)
        {
            //dodanie obiektu student do listy
            Students.Add(student);

            //dodanie tablicy ocen do listy
            Console.Write($"Enter grades for student {student.getIndex()}['x' to stop]: ");
            Grades.Add(readGrades());
        }

        // metoda zczytująca oceny - z obsługą dwóch wyjątków
        public double[] readGrades()
        {
            //zakładam że można zdobyć tylko 8 ocen.
            double[] array = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int i = 0;
            do
            {
                try // try - blok "próby" wyjątku, jesli cos nie tak wyrzucany jest wyjatek.
                {
                    string input = Console.ReadLine();
                    if (input == "x") break;
                    if (double.TryParse(input, out double x)){
                        if (possibleGrades.Contains(x))
                        {
                            array[i] = x;
                            i++;
                        }
                        //wyjatek - oceny poza dopuszczalnymi wartosciami
                        else throw new NotSupportedException();
                    }
                    // wyjatek - blad przy parsowaniu input'u
                    else throw new Exception();
                }
                catch (NotSupportedException){
                    Console.WriteLine("\nProvided value is not in {2, 3, 3.5, 4, 4.5, 5}.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.ToString()}\n");
                }
            } while(i<array.Length);

            return array;
        }

        // metoda pokazujaca oceny studenta o wskazanym indeksie
        public void showStudentGrades(int index)
        {
            foreach (Student student in Students)
            {
                if (student.getIndex() == index)
                {
                    double[] tablica = Grades.ElementAt(Students.IndexOf(student));
                    Console.Write($"Grades of student #{index}: ");
                    foreach (double element in tablica)
                    {
                        if(element != 0) Console.Write(element + "; ");
                    }
                    Console.Write("\n");
                    return;
                }
            }
            Console.WriteLine($"Student #{index} not found.\n");
        }

        // metoda zwracająca średnią z ocen studenta
        public double getStudentAverage(int index)
        {
            foreach (Student student in Students)
            {
                if (student.getIndex() == index)
                {
                    double avg = 0;
                    double count = 0;
                    double[] tablica = Grades.ElementAt(Students.IndexOf(student));
                    foreach (double element in tablica)
                    {
                        if(element != 0)
                        {
                            avg += element;
                            count++;
                        }
                    }
                    return avg /= count;
                }
            }
            Console.WriteLine($"Student #{index} not found.");
            return -1;
        }

        // metoda zwracająca średnią wszystkich uczniów
        public double allStudentsAverage()
        {
            double avg = 0;
            int count = 0;
            foreach(Student student in Students)
            {
                avg += getStudentAverage(student.getIndex());
                count++;
            }
            return avg/count;
        }


        // metoda usuwajaca studenta po wskazaniu numeru indeksu (usuwa również jego oceny)
        public bool removeStudent(int index)
        {
            //przeszukanie listy studentow
            foreach (Student student in Students)
            {
                if (student.getIndex() == index)
                {
                    Grades.RemoveAt(Students.IndexOf(student));//usuniecie ocen
                    Students.Remove(student);//usuniecie studenta
                    return true;
                }
            }
            Console.WriteLine($"Student #{index} not found.");
            return false;
        }
    }
}