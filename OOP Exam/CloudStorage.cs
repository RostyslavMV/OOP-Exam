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
