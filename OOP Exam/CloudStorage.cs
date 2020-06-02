using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }
    }

    class CompanyProvider
    {
        public string Name { get; private set; }

        public CompanyProvider(string name)
        {
            Name = name;
        }
    }

    class Catalog
    {
        public List<File> Files { get; private set; }

        public Catalog(List<File> files)
        {
            Files = files;
        }
    }

    class File
    {
        public string Name { get; private set; }
        public int Size { get; private set; }
        public FileRevision CurrentRevision { get; private set; }

        public File(string name)
        {
            Name = name;
            CurrentRevision = new FileRevision(DateTime.Now);
        }

        public File(string name, int size) : this(name)
        {
            Size = size;
        }
    }

    class FileRevision
    {
        public DateTime DateOfRevision { get; private set; }

        public FileRevision(DateTime revisionDate)
        {
            DateOfRevision = revisionDate;
        }
    }
}
