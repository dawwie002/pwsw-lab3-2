using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3_2
{
    public class Student
    {
        //pola prywatne
        private int index, semester;
        private string name, surname;

        //konstruktor
        public Student()
        {
            index = 0;
            semester = 0;
            name = "brak";
            surname = "brak";
        }

        //metody get
        public int getIndex() { return index; }
        public int getSemester() { return semester; }
        public string getName() { return name; }
        public string getSurname() { return surname; }
        //metody set
        public void setIndex(int value) { index = value; }
        public void setSemester(int value) { semester = value; }
        public void setName(string value) { name = value; }
        public void setSurname(string value) { surname = value; }

        // metoda zwracajaca komunikat z polami obiektu klasy Student
        public void printStudentInfo()
        {
            Console.WriteLine($"Student: {name} {surname}, Nr. indeksu: {index}, Semestr: {semester}.");
        }
    }
}
