using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSA.Data
{
	public static class PersonDatabase
	{
		public static Dictionary<int, Person> _people = new Dictionary<int, Person>();

		internal static int AddPerson( Person newPerson )
		{
			if (newPerson == null)
				return -1;

			int personID = GenerateNewID();	// generating a unique id for the person.
			newPerson.ID = personID;
			_people.Add( personID, newPerson );

			/* We could store the Person objects in a json or xml file format*/
			return personID;
		}

		// Using timestamp millisecond value as unique ID
		private static int GenerateNewID()
		{
			return System.DateTime.Now.Millisecond;
		}

		internal static IEnumerable<Person> GetFather( string fatherName )
		{
			return _people.Values.Where( o => o.Name == fatherName );
		}

		internal static IEnumerable<Person> GetMother( string motherName )
		{
			return from x in _people.Values where x.Name == motherName select x;

		}

		/// <summary>
		/// Method to find a person by first name and last name in the database.
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <returns></returns>
		public static Person GetPerson( string firstName, string lastName )
		{
			/* we would search for the person in the database by either
			first name, last name or any other unique identifier */
			return null;
		}
	}
}
