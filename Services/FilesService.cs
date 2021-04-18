using System;
using System.Collections.Generic;
using System.IO;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matterix.Services
{
    public class FilesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        
        
        //Directories' names
        private const string PlusApplications = "PlusApplications";
        private const string Admissions = "Admissions";

        public FilesService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void AddCoursePicture(Course course, IFormFile picture)
        {
            
            if(course == null || picture == null)
                return;
            
            var acceptedFiles = new List<string>(){"image/png", "image/jpeg", "image/jpeg"};
            
            if (!acceptedFiles.Contains(picture.ContentType))
                return;
            
            var random = Guid.NewGuid().ToString();
            var randomSegments = random.Split("-");
            var fileName = course.Code + "-" + randomSegments[0] + randomSegments[1] + "-" + picture.FileName;
            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string fileFolder = "Files";
            const string coursePictures = "CoursePictures";
            
            var pictureTargetPath = Path.Combine(envRoot, root, fileFolder, coursePictures, fileName);
            
            
            var oldPicturePath = "none";
            if (!string.IsNullOrEmpty(course.Picture))
                oldPicturePath = Path.Combine(envRoot, root, fileFolder, coursePictures, course.Picture);
            
            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            if (Directory.GetDirectories(envRoot+"/"+root+"/"+ fileFolder, coursePictures).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+coursePictures));
            
            try
            {
                using (var stream = new FileStream(pictureTargetPath, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }
                
                if (oldPicturePath != "none")
                {
                    try
                    {
                        File.Delete(oldPicturePath);
                    }
                    catch(FileNotFoundException e)
                    {
                        Console.WriteLine(e);
                    }
                }


                course.Picture = fileName;
                
                _context.Update(course);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            





        }
        
        
        public void AddCourseBackground(Course course, IFormFile background)
        {
            
            if(course == null || background == null)
                return;
            
            var acceptedFiles = new List<string>(){"image/png", "image/jpeg", "image/jpeg"};
            
            if (!acceptedFiles.Contains(background.ContentType))
                return;
            
            var random = Guid.NewGuid().ToString();
            var randomSegments = random.Split("-");
            var fileName = course.Code + "-" + randomSegments[0] + randomSegments[1] + "-" + background.FileName;
            
            var envRoot = _environment.ContentRootPath;
            const string root = "wwwroot";
            const string fileFolder = "Files";
            const string courseBackgrounds = "CourseBackgrounds";
            
            var pictureTargetPath = Path.Combine(envRoot, root, fileFolder, courseBackgrounds, fileName);
            
            
            var oldBackgroundPath = "none";
            if (!string.IsNullOrEmpty(course.Background))
                oldBackgroundPath = Path.Combine(envRoot, root, fileFolder, courseBackgrounds, course.Background);
            
            if (Directory.GetDirectories(envRoot+"/"+root, fileFolder).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder));
            if (Directory.GetDirectories(envRoot+"/"+root+"/"+ fileFolder, courseBackgrounds).Length == 0)
                Directory.CreateDirectory(Path.Combine(envRoot+"/"+root+"/"+fileFolder+"/"+courseBackgrounds));
            
            try
            {
                using (var stream = new FileStream(pictureTargetPath, FileMode.Create))
                {
                    background.CopyTo(stream);
                }
                
                if (oldBackgroundPath != "none")
                {
                    try
                    {
                        File.Delete(oldBackgroundPath);
                    }
                    catch(FileNotFoundException e)
                    {
                        Console.WriteLine(e);
                    }
                }


                course.Background = fileName;
                
                _context.Update(course);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

        }

        public bool IsSizeAllowed(EnumList.MatterixFileType fileType, long size)
        {
            return size <= AllowedSize(fileType);
        }
        
        public bool IsTypeAllowed(EnumList.MatterixFileType fileType, string contentType)
        {
            return AllowedType(fileType).Contains(contentType);
        }
        
        public string SaveFileToSystem(IFormFile file, EnumList.MatterixFileType type, string objectReference = "", string oldName = "")
        {
            
            //ToDo :: Check if replaceable, delete the old one and create new | Maybe later when editing all files
            
            var names = GetSaveAndShowNames(type, objectReference, file.FileName);
            
            CreateDirectories(type);
            
            if(string.IsNullOrEmpty(names[0]) || string.IsNullOrEmpty(names[1]))
                return string.Empty;

            var sizeMb = (decimal) (file.Length / 1024.0 / 1024);

            var matterixFile = new MatterixFile
            {
                FileName = names[0], DisplayName = names[1], ContentType = file.ContentType, MbSize = Math.Round(sizeMb, 2),
                RootPath = GetRequiredPath(type, objectReference, names[0])[0], WebPath = GetRequiredPath(type, objectReference, names[0])[1]
                
            };
            
            
            //ToDo :: Try save file to system, if success save matterixFile to database and return its Id
            try
            {
                using (var stream = new FileStream(matterixFile.RootPath, FileMode.Create))
                {
                    file.CopyToAsync(stream).Wait();
                }

                _context.Add(matterixFile);
                _context.SaveChanges();

                return matterixFile.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Error saving file of {type.ToString()} with reference of {objectReference}");
                
                return string.Empty;
            }
            
            
        }

        public bool DeleteFile(string fileId)
        {
            var file = _context.MatterixFiles.Find(fileId);
            if(file == null)
                return false;

            try
            {
                File.Delete(file.RootPath);

                _context.Remove(file);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public MatterixFile GetFileObject(string fileId)
        {
            return _context.MatterixFiles.Find(fileId);
        }
        
        
        private void CreateDirectories(EnumList.MatterixFileType fileType)
        {
            //ToDo :: Reuse this function in all file adding to file system
            var directories = new List<string>();
            
            switch (fileType)
            {
                case EnumList.MatterixFileType.ProfilePicture:
                    break;
                case EnumList.MatterixFileType.CoursePicture:
                    break;
                case EnumList.MatterixFileType.CourseBackground:
                    break;
                case EnumList.MatterixFileType.LectureFile:
                    break;
                case EnumList.MatterixFileType.Homework:
                    break;
                case EnumList.MatterixFileType.JobApplicationCv:
                    break;
                case EnumList.MatterixFileType.MatterixPlusApproval:
                    directories = new List<string>{PlusApplications, Admissions};
                    break;
                default:
                    return;
            }
            
            
            var path = $"{_environment.ContentRootPath}/wwwroot/Files";
            
            foreach (var dir in directories)
            {
                
                if (Directory.GetDirectories(path, dir).Length == 0)
                {
                    Directory.CreateDirectory(Path.Combine($"{path}/{dir}"));
                }
                path += $"/{dir}";
                    
                
            }
        }
        
        private bool DeleteFile(MatterixFile file)
        {
            try
            {
                File.Delete(file.RootPath);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private List<string> GetRequiredPath(EnumList.MatterixFileType fileType, string objectReference, string fileName)
        {
            //ToDo :: Reuse this function in all file adding to file system
            var rootPath = "";
            var webPath = "";
            
            switch (fileType)
            {
                case EnumList.MatterixFileType.ProfilePicture:
                    break;
                case EnumList.MatterixFileType.CoursePicture:
                    break;
                case EnumList.MatterixFileType.CourseBackground:
                    break;
                case EnumList.MatterixFileType.LectureFile:
                    break;
                case EnumList.MatterixFileType.Homework:
                    break;
                case EnumList.MatterixFileType.JobApplicationCv:
                    break;
                case EnumList.MatterixFileType.MatterixPlusApproval:
                    
                    rootPath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Files", PlusApplications, Admissions, fileName);
                    webPath = $"~/Files/{PlusApplications}/{Admissions}/{fileName}";
                    
                    break;
                default:
                    break;
            }
            
            
            return new List<string>{rootPath, webPath};
        }

        private List<string> GetSaveAndShowNames(EnumList.MatterixFileType fileType, string objectReference, string fileName)
        {
            //ToDo :: Reuse this function in all file adding to file system
            //Return value from this function is: func[0] (Unique saved name), func[1] (Given name to show or download)
            
            //ToDo :: Take in the full name of file with .ex
            
            var random = Guid.NewGuid().ToString();
            var extension = fileName.Split(".")[1];
            
            switch (fileType)
            {
                case EnumList.MatterixFileType.ProfilePicture:
                    break;
                case EnumList.MatterixFileType.CoursePicture:
                    break;
                case EnumList.MatterixFileType.CourseBackground:
                    break;
                case EnumList.MatterixFileType.LectureFile:
                    break;
                case EnumList.MatterixFileType.Homework:
                    break;
                case EnumList.MatterixFileType.JobApplicationCv:
                    break;
                case EnumList.MatterixFileType.MatterixPlusApproval:
                    return new List<string> {$"{objectReference} - {random.Split("-")[0]}.{extension}", $"{objectReference} - {fileName}"};
                    break;
                default:
                    return new List<string>{"", ""};
            }
            
            
            return new List<string>{"", ""};
        }

        private int AllowedSize(EnumList.MatterixFileType fileType)
        {
            //ToDo :: Reuse this function in all file adding to file system
            var allowedSize = 0;
            switch (fileType)
            {
                case EnumList.MatterixFileType.ProfilePicture:
                    break;
                case EnumList.MatterixFileType.CoursePicture:
                    break;
                case EnumList.MatterixFileType.CourseBackground:
                    break;
                case EnumList.MatterixFileType.LectureFile:
                    break;
                case EnumList.MatterixFileType.Homework:
                    break;
                case EnumList.MatterixFileType.JobApplicationCv:
                    break;
                case EnumList.MatterixFileType.MatterixPlusApproval:
                    allowedSize = 25;
                    break;
                default:
                    allowedSize = 0;
                    break;
            }

            return allowedSize * 1024 * 1024;
        }
        
        private List<string> AllowedType(EnumList.MatterixFileType fileType)
        {
            //ToDo :: Reuse this function in all file adding to file system
            var allowedType = new List<string>();
            switch (fileType)
            {
                case EnumList.MatterixFileType.ProfilePicture:
                    break;
                case EnumList.MatterixFileType.CoursePicture:
                    break;
                case EnumList.MatterixFileType.CourseBackground:
                    break;
                case EnumList.MatterixFileType.LectureFile:
                    break;
                case EnumList.MatterixFileType.Homework:
                    break;
                case EnumList.MatterixFileType.JobApplicationCv:
                    break;
                case EnumList.MatterixFileType.MatterixPlusApproval:
                    allowedType = new List<string>
                    {
                        "application/vnd.oasis.opendocument.text", "application/octet-stream",
                        "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                        "application/pdf",
                    };
                    break;
                default:
                    break;
            }

            return allowedType;
        }


        public byte[] GetStudentAgreement(EnumList.Language language)
        {
            var env = _environment.ContentRootPath;
            var root = "wwwroot";
            var name = "Agreement-Norsk-V1.pdf";
            if(language == EnumList.Language.Arabic)
                name = "Agreement-Arabic-V1.pdf";
            
            
            return File.ReadAllBytes(Path.Combine(env, root, "SystemFiles", name));
        }

        
    }
}