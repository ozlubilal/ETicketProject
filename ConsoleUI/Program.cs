using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

class Hello
{
	static void Main()
	{
		Person person = new Person
		{
			FirstName =null,
			LastName = "zlu",
			SSN = "1",
		};

		BusType busType = new BusType
		{
			BusTypeName = " ",
			NumberOfSeats=23,
		};
		BusTypeManager busTypeManager = new BusTypeManager(new EfBusTypeDal());
		Console.Write(busType.Id);

  
		

//		Console.Write((person.GetType()).GetProperties().GetValue(person).ToString());

			//ObjectDump.Write(person);
        
	}
}


public class Person
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string SSN { get; set; }
}

public static class ObjectDump
{
	public static void Write(object obj)
	{
		if (obj != null)
		{

			//Console.Write("Hash: ");
			//Console.WriteLine(obj.GetHashCode());
			//Console.Write("Type: ");
			//Console.WriteLine(obj.GetType());

			var props = GetProperties(obj);

			if (props.Count > 0)
			{
				Console.WriteLine("-------------------------");
			}

			foreach (var prop in props)
			{
				Console.Write(prop.Key);
				Console.Write(": ");
				Console.WriteLine(prop.Value);
			}
		}
        else
        {
			Console.WriteLine("null obje");
        }
	}

	private static Dictionary<string, string> GetProperties(object obj)
	{
		var props = new Dictionary<string, string>();
		if (obj == null)
			return props;

		var type = obj.GetType();

		foreach (var prop in type.GetProperties())
		{
			if (prop == null)
			{
				Console.WriteLine("prop null");
			}
			else
			{
				var val = prop.GetValue(obj, new object[] { });
				var valStr = val == null ? "" : val.ToString();
				props.Add(prop.Name, valStr);
			}
			
           
		}

		return props;
	}
}