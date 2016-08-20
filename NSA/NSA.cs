using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections;
using NSA.IO;
using NSA.Data;

namespace NSA
{
	public class NSA
	{
		public static void Main(string[] args)
		{
			NSA nsa = new NSA();
			ConsoleIO io = new ConsoleIO();

			/* We could expand the application by giving a few option to the user such as,
			 * 1. Add a new person.
			 * 2. Find a person.
			 * 3. Delete a person.
			 * 4. Edit a person details.
			 * 
			 * Depending on the user input, we would perform the required operation.
			 */
			AddNewPerson(nsa, io);

			bool exit = false;
			do
			{
				io.WriteLine("Press Enter to add a new person or Esc to exit.");

				ConsoleKeyInfo keyPress = Console.ReadKey(true);
				if (keyPress.Key == ConsoleKey.Enter)
				{
					AddNewPerson(nsa, io);
				}
				else if (keyPress.Key == ConsoleKey.Escape)
				{
					exit = true;
				}
			}
			while (!exit);
		}

		/// <summary>
		/// Read input from the user, adds the person into the database and writes back to the user.
		/// </summary>
		/// <param name="challenge"></param>
		/// <param name="io"></param>
		private static void AddNewPerson(NSA challenge, ConsoleIO io)
		{
			// Read input from console.
			Person newPerson = challenge.ReadPerson(io);
			if (newPerson == null)
				return;

			// Add person to database.
			PersonDatabase.AddPerson(newPerson);

			// Writes person details to the console.
			challenge.WritePerson(io, newPerson);
		}

		/// <summary>
		/// Reads a user input and creates a Person object.
		/// </summary>
		/// <param name="io"></param>
		/// <returns>A Person object</returns>
		public Person ReadPerson(ConsoleIO io)
		{
			/*we should be validating the user input here. */


			// Using first name as a mandatory field to be added into the database.
			io.WriteLine("What is your first name ?");
			string firstName = io.ReadLine();
			if (string.IsNullOrEmpty(firstName))
			{
				io.WriteLine("You need to enter a first name. Please try again");
				return null;
			}

			io.WriteLine("What is your last name ?");
			string lastName = io.ReadLine();

			io.WriteLine("What is your age ?");
			int age;
			int.TryParse(io.ReadLine(), out age);           // we could also query for their date of birth and calculate their age.

			// M or F
			io.WriteLine("What is your gender? (m/f)");
			char gender;
			if (char.TryParse(io.ReadLine(), out gender))
			{
				if (!gender.Equals('m') && !gender.Equals('f'))
				{
					gender = 'u';
					io.WriteLine("Unknown gender");
				}
			}

			io.WriteLine("What is your dad's name ?");
			string fatherName = io.ReadLine();

			io.WriteLine("What is your mom's name ?");
			string motherName = io.ReadLine();

			Person person = new Person();
			person.Name = string.Format("{0} {1}", firstName, lastName);
			person.Age = age;
			person.Gender = gender;
			person.FatherName = fatherName;
			person.MotherName = motherName;
			return person;
		}

		/// <summary>
		/// Write a given Person object to the console output.
		/// </summary>
		/// <param name="io"></param>
		/// <param name="person"></param>
		public void WritePerson(ConsoleIO io, Person person)
		{
			io.WriteLine(string.Format("Your ID is {0}", person.ID));

			string[] names = person.Name.Split(' ');
			io.WriteLine(string.Format("Your first name is {0}", names[0]));

			io.WriteLine(string.Format("Your last name is {0}", names[1]));
			io.WriteLine(string.Format("Your age is {0}", person.Age));
			if (person.Gender.Equals('u'))
			{
				io.WriteLine(string.Format("Your gender is unknown"));
			}
			else
			{
				io.WriteLine(string.Format("You are a {0}", person.Gender == 'm' ? "Man" : "Woman"));
			}

			// getting father's details.
			var dad = PersonDatabase.GetFather(person.FatherName);
			if (dad != null && dad.Count() >= 1)
			{
				io.WriteLine(string.Format("Your dad's name is {0} and his age is {1}", dad.First().Name, dad.First().Age));
			}
			else
			{
				io.WriteLine(string.Format("Your dad's name is {0}.", person.FatherName));
			}

			// getting mother's details.
			var mom = PersonDatabase.GetMother(person.MotherName);
			if (mom.Count() >= 1)
			{
				io.WriteLine(string.Format("Your mom's name is {0} and age is {1}", mom.First().Name, mom.First().Age));
			}
			else
			{
				io.WriteLine(string.Format("Your mom's name is {0}", person.MotherName));
			}
		}
	}
}
