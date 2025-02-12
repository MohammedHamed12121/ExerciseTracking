using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceTracking.Database
{
	public static class Constants
	{
		public const string DatabaseFilename = "ExerciceTraining.db3";

		public const SQLite.SQLiteOpenFlags Flags = 
					// open database in read write mode
					SQLite.SQLiteOpenFlags.ReadWrite |
					// create database if its not exist
					SQLite.SQLiteOpenFlags.Create | 
					// enable multi-threaded database access
					SQLite.SQLiteOpenFlags.SharedCache;

		public static string DatabasePath => 
				Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
	}
}
