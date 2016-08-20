using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSA
{
	public class Person
	{
		private int _id; // unique id for every person
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _age;
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}

		private char _gender;
		public char Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		// Used to find individuals in the DB
		private string _fatherName;
		public string FatherName
		{
			get { return _fatherName; }
			set { _fatherName = value; }
		}

		private string _motherName;
		public string MotherName
		{
			get { return _motherName; }
			set { _motherName = value; }
		}

		public Person()
		{
		}
	}
}
