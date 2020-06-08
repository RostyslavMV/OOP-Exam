using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CompanyProvider
    {
        public string Name { get; private set; }

        public CompanyProvider(string name)
        {
            Name = name;
        }


    }

    public class Catalog
    {
        public Collection<File> Files { get; private set; }

        public string Name { get; private set; }

        public Catalog(string name, Collection<File> files)
        {
            Name = name;
            Files = files;
        }

        public Catalog(string name)
        {
            Name = name;
            Files = null;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class File
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

    public class FileRevision
    {
        public DateTime DateOfRevision { get; private set; }

        public FileRevision(DateTime revisionDate)
        {
            DateOfRevision = revisionDate;
        }
    }

    public class CloudStorage : IComparable<CloudStorage>
    {
        public enum FieldForComparing
        {
            Person,
            CompanyProvider,
            Catalog
        }

        public static FieldForComparing fieldForComparing { get; set; } = FieldForComparing.Person;
        public Person Person { get; private set; }
        public CompanyProvider CompanyProvider { get; private set; }
        public Catalog Catalog { get; private set; }

        public override string ToString()
        {
            return Person.ToString() + ", " + CompanyProvider.ToString() + ", " + Catalog.ToString();
        }
        public CloudStorage()
        {
            Person = null;
            CompanyProvider = null;
            Catalog = null;
        }

        public CloudStorage(Person person, CompanyProvider companyProvider, Catalog catalog)
        {
            Person = person;
            CompanyProvider = companyProvider;
            Catalog = catalog;
        }

        public CloudStorage(string personName, string companyName, string catalogName)
            : this(new Person(personName), new CompanyProvider(companyName), new Catalog(catalogName)) { }

        public override bool Equals(object obj)
        {
            return Equals(obj as CloudStorage);
        }
        public  bool Equals(CloudStorage other)
        {
            if (other == null && this != null || this == null&& other!=null) return false;
            return Person.Name == other.Person.Name && CompanyProvider.Name == other.CompanyProvider.Name && Catalog.Name == other.Catalog.Name;
        }
        public int CompareTo(CloudStorage other)
        {
            if (fieldForComparing == FieldForComparing.Person)
            {
                return this.Person.Name.CompareTo(other.Person.Name);
            }
            else if (fieldForComparing == FieldForComparing.CompanyProvider)
            {
                return this.CompanyProvider.Name.CompareTo(other.CompanyProvider.Name);
            }
            else
            {
                return this.Catalog.Name.CompareTo(other.Catalog.Name);
            }
        }
    }

}
