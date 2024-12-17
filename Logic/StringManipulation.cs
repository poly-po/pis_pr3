using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Themes;

namespace Logic
{
    public static class StringManipulation
    {

        public static ThemesOfTheWorks ObjectOutput(string stroka)
        {
            ThemesOfTheWorks themes = null;

            try
            {
                string[] s = ParseString(stroka);
                if (!new List<string> { "Тема работы", "Работа с наставником", "Статус работы" }.Contains(s[0].Trim('"')))
                {
                    throw new Exception($"Неизвестный вид измерения: {s[0]}");
                }
                else
                {
                    if (s[0].Equals("Тема работы"))
                    {
                        themes = MakeThemesOfWorks(s);
                    }
                    if (s[0].Equals("Работа с наставником"))
                    {
                        themes = MakeWorksWithAMentor(s);
                    }
                    if (s[0].Equals("Статус работы"))
                    {
                        themes = MakeStatusOfWorks(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
            }

            return themes;
        }








        public static string[] ParseString(string input)
        {
            try
            {
                return Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
                         .Cast<Match>()
                         .Select(m => m.Value.Trim('\"'))
                         .ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при парсинге строки: {ex.Message}");
                return Array.Empty<string>();
            }
        }






        public static string[] StrFromFiles(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                return fileContent.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
                return Array.Empty<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при чтении файла: {ex.Message}");
                return Array.Empty<string>();
            }
        }




        //public string ShowObjects(string[] s)
        //{
        //    ThemesOfTheWorks themes = new ThemesOfTheWorks();
        //    if (typeof(ThemesOfTheWorks).Name == themes.GetType().Name)
        //    {
        //        return themes.MakeThemesOfWorks(s);
        //    }

        //}
        




        public static string ToStringDependingOnType(object work)
        {
            if (work is StatusOfWorks statusOfWorks)
            {
                return $"--{statusOfWorks.Type}-- \nИмя студента: {statusOfWorks.StudentsName}, Название темы: {statusOfWorks.TopicName}, Дата выдачи: {statusOfWorks.DateOfIssue:yyyy.MM.dd}, Статус работы: {statusOfWorks.Status}\n";
            }
            else if (work is WorksWithAMentor worksWithMentor)
            {
                return $"--{worksWithMentor.Type}-- \nИмя студента: {worksWithMentor.StudentsName}, Название темы: {worksWithMentor.TopicName}, Дата выдачи: {worksWithMentor.DateOfIssue:yyyy.MM.dd}, Имя наставника: {worksWithMentor.MentorsName}\n";
            }
            else if (work is ThemesOfTheWorks themesOfTheWorks)
            {
                return $"--{themesOfTheWorks.Type}-- \nИмя студента: {themesOfTheWorks.StudentsName}, Название темы: {themesOfTheWorks.TopicName}, Дата выдачи: {themesOfTheWorks.DateOfIssue:yyyy.MM.dd}\n";
            }
            else
            {
                throw new ArgumentException("Неизвестный тип");
            }
        }


        public static ThemesOfTheWorks MakeThemesOfWorks(string[] s)
        {
            ThemesOfTheWorks themesOfTheWorks = new ThemesOfTheWorks
            {
                Type = s[0].Trim('"'),
                StudentsName = s[1].Trim('"'),
                TopicName = s[2].Trim('"'),
                DateOfIssue = DateTime.ParseExact(s[3], "yyyy.MM.dd", null)
            };

            return themesOfTheWorks;
        }

        //public string ThemesOfTheWorksToString(ThemesOfTheWorks t)
        //{
        //    return $"--{t.Type}-- \nИмя студента: {t.StudentsName}, Название темы: {t.TopicName}, Дата выдачи: {t.DateOfIssue:yyyy.MM.dd}\n";
        //}





        public static WorksWithAMentor MakeWorksWithAMentor(string[] s)
        {
            WorksWithAMentor worksWithAMentor = new WorksWithAMentor
            {
                Type = s[0].Trim('"'),
                StudentsName = s[1].Trim('"'),
                TopicName = s[2].Trim('"'),
                DateOfIssue = DateTime.ParseExact(s[3], "yyyy.MM.dd", null),
                MentorsName = s[4].Trim('"')
            };

            return worksWithAMentor;
        }
        //public string WorksWithAMentorToString(WorksWithAMentor m)
        //{
        //    return $"--{m.Type}-- \nИмя студента: {m.StudentsName}, Название темы: {m.TopicName}, Дата выдачи: {m.DateOfIssue:yyyy.MM.dd}, Имя наставника: {m.MentorsName}\n";
        //}





        public static StatusOfWorks MakeStatusOfWorks(string[] s)
        {
            StatusOfWorks statusOfWorks = new StatusOfWorks
            {
                Type = s[0].Trim('"'),
                StudentsName = s[1].Trim('"'),
                TopicName = s[2].Trim('"'),
                DateOfIssue = DateTime.ParseExact(s[3], "yyyy.MM.dd", null),
                Status = s[4].Trim('"')
            };

            return statusOfWorks;
        }
        //public string StatusOfWorksToString(StatusOfWorks s)
        //{
        //    return $"--{s.Type}-- \nИмя студента: {s.StudentsName}, Название темы: {s.TopicName}, Дата выдачи: {s.DateOfIssue:yyyy.MM.dd}, Статус работы: {s.Status}\n";
        //}

    }
}
