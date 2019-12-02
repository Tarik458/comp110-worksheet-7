using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
        // Declare array to store file names.
        public static string[] FileArr;

        // Return the size, in bytes, of the given file.
        public static long GetFileSize(string filePath)
		{
			return new FileInfo(filePath).Length;
		}

		// Return true if the given path points to a directory, false if it points to a file.
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory.
		public static long GetTotalSize(string directory)
		{
            //  Declare size variable.
            long sizeSum = 0;

            // Add files to the array. *.* so only files will be added and not folders.
            FileArr = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            // Get the size of each file in the array and add its size to the sum.
            foreach (string fileName in FileArr)
            {
                sizeSum = sizeSum + GetFileSize(fileName);
            }

            // Return total size.
            return sizeSum;
		}

		// Return the number of files (not counting directories) below the given directory.
		public static int CountFiles(string directory)
		{
            // Add files to the array. *.* so only files will be added and not folders.
            FileArr = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            // Return the amount of items in the array.
            return FileArr.Length;
        }

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            // Array for directories.
            string[] Directories;
            // Declare count variable.
            int depthCount = 0;

            // Add directories to the array.
            Directories = Directory.GetFiles(directory);

            // Increment for each aditional depth.
            foreach (string dir in Directories)
            {
                depthCount++;
            }

            // Return the depth.
            return depthCount;
        }

		// Get the path and size (in bytes) of the smallest file below the given directory.
		public static Tuple<string, long> GetSmallestFile(string directory)
		{
            // Add files to the array. *.* so only files will be added and not folders.
            FileArr = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            // Variables to tuple and return.
            string fileName = FileArr[0];
            long fileSize = GetFileSize(fileName);

            // Check each item in the array and find largest.
            foreach(string file in FileArr)
            {
                if (GetFileSize(file) < fileSize)
                {
                    fileName = file;
                    fileSize = GetFileSize(file);
                }
            }
            
            return new Tuple<string, long>(fileName, fileSize);
		}

		// Get the path and size (in bytes) of the largest file below the given directory.
		public static Tuple<string, long> GetLargestFile(string directory)
		{
            // Add files to the array. *.* so only files will be added and not folders.
            FileArr = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            // Variables to tuple and return.
            string fileName = FileArr[0];
            long fileSize = GetFileSize(fileName);

            // Check each item in the array and find largest.
            foreach (string file in FileArr)
            {
                if (GetFileSize(file) > fileSize)
                {
                    fileName = file;
                    fileSize = GetFileSize(file);
                }
            }

            return new Tuple<string, long>(fileName, fileSize);
        }

		// Get all files whose size is equal to the given value (in bytes) below the given directory.
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
            // Add files to the array. *.* so only files will be added and not folders.
            FileArr = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            // List to store "files of size".
            List<string> FilesOfSize = new List<string>();
            // To store size of file for comparrisons.
            long sizeOfFile;

            // Check each file in the array. If it is the desired size, add it to the list.
            foreach (string fileName in FileArr)
            {
                sizeOfFile = GetFileSize(fileName);
                if (sizeOfFile == size)
                {
                    FilesOfSize.Add(fileName);
                }
            }

            // Return the list
            return FilesOfSize;
        }
	}
}
