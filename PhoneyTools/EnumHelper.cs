using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AgiliTrain.PhoneyTools
{
  public static class EnumHelper
  {
    /// <summary>
    /// Gets the names of the Enumeration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>An array of strings that contains the names of the enumerated values</returns>
    /// <remarks>
    /// From StackExchange: http://stackoverflow.com/questions/3935953/how-do-i-bind-an-enum-to-my-listbox
    /// </remarks>
    public static IEnumerable<string> GetNames<T>()
    {
      var type = typeof(T);
      if (!type.IsEnum)
      {
        throw new ArgumentException("Type '" + type.Name + "' is not an enum");
      }

      return (from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
              where field.IsLiteral
              select field.Name).ToList<string>();
    }

    /// <summary>
    /// Gets the dictionary of the names of the element matched with the 
    /// enumeration value.
    /// </summary>
    /// <typeparam name="T">The Enumeration to create a Dictionary for.</typeparam>
    /// <returns>A Dicitonary of the names and values of an Enumeration.</returns>
    public static IDictionary<string, T> GetDictionary<T>()
    {
      var type = typeof(T);
      if (!type.IsEnum)
      {
        throw new ArgumentException("Type '" + type.Name + "' is not an enum");
      }

      return (from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
              where field.IsLiteral
              select field).ToDictionary(f => f.Name) as IDictionary<string,T>;
    }


    /// <summary>
    /// Gets the values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetValues<T>()
    {
      var type = typeof(T);
      if (!type.IsEnum)
      {
        throw new ArgumentException("Type '" + type.Name + "' is not an enum");
      }

      var fields = from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
              where field.IsLiteral
              select field;

      List<T> values = new List<T>();

      foreach (var f in fields)
      {
        values.Add((T)f.GetValue(type));
      }

      return values;
    }

    /// <summary>
    /// Generic Version of Parse.
    /// </summary>
    /// <typeparam name="T">The Enum to parse.</typeparam>
    /// <param name="name">The enumerated value name.</param>
    /// <returns>The Enumerated Value</returns>
    public static T Parse<T>(string name)
    {
      var type = typeof(T);
      if (!type.IsEnum)
      {
        throw new ArgumentException("Type '" + type.Name + "' is not an enum");
      }

      return (T)Enum.Parse(typeof(T), name, true);
    }
  }
}
