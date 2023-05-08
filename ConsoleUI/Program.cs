using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

class Hello
{
	static void Main()
	{
		var person = new Person
		{
			FirstName = "Gunnar",
			LastName = "Peipman",
			SSN = "-i"
		};

        	ObjectDump.Write(person);
        
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
		

		Console.Write("Hash: ");
		Console.WriteLine(obj.GetHashCode());
		Console.Write("Type: ");
		Console.WriteLine(obj.GetType());

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

	private static Dictionary<string, string> GetProperties(object obj)
	{
		var props = new Dictionary<string, string>();
		if (obj == null)
			return props;

		var type = obj.GetType();
		foreach (var prop in type.GetProperties())
		{
			var val = prop.GetValue(obj, new object[] { });
			var valStr = val == null ? "" : val.ToString();
			props.Add(prop.Name, valStr);
		}

		return props;
	}
}