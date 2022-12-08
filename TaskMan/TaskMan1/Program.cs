using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaskEngine;
using TaskEngine.SettingSubsystem;

namespace TaskMan1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestSettingSubsystem();
            
            //TestEngine();

            return;
        }
        /// <summary>
        /// Гест файла настроек - успешно.
        /// </summary>
        private static void TestSettingSubsystem()
        {
            String filePath = "C:\\Temp\\set.xml";
            
            //Обязательно заполнять все поля!
            //Если значение = пустая строка, то в XML-файл выводится сокращенный тег, а не тройка начало-значение-конец.
            //Сокращенный же тег этот класс не читает, выбрасывает исключение "Тег не найден".
            
            TaskEngine.SettingSubsystem.TaskEngineSettings s = new TaskEngine.SettingSubsystem.TaskEngineSettings();
            s.Creator = "Test";
            s.Description = "Description as test";
            s.LinkPrefix = "litest";
            s.Title = "TestTitle";
            s.StoragePath = "C:\\Temp\\";
            s.QualifiedName = "Task.Task1";
            s.StorageType = "Task::Task1";
            s.Store(filePath);

            //load
            TaskEngine.SettingSubsystem.TaskEngineSettings readed = TaskEngineSettings.TryLoad(filePath);
            if (readed != null)
            {
                Console.WriteLine(readed.Title);
                Console.WriteLine(readed.Description);
                Console.WriteLine(readed.LinkPrefix);
            }


            return;
        }

        private static void TestEngine()
        {
            //CEngine engine = new CEngine();
            ////create solution
            //String solutionRoot = "C:\\Temp\\";
            //String solutionTitle = "testSolution";
            //CEngine.SolutionCreate(solutionRoot, solutionTitle);
            ////open solution
            //String solutionPath = Path.Combine(solutionRoot, solutionTitle);
            //engine.SolutionOpen(solutionPath);

            //Console.WriteLine("Opened " + solutionPath);

            //CreateBasicTree(engine);
            ////close solution
            //engine.SolutionClose();
        }

        private static void CreateBasicTree(CEngine engine)
        {
            //TODO: 1. set constructor values by default, remove from here
            //2. move creating elements to engine object
            //3. DONE: first create main categories and tags, then user items (cat, rule and task)
            //4. DONE: use tag for rules and tasks
            //5. catch exceptions
            //6. use valid order for fields: id-type-state-parent-title-descr-remarks
            //7. rename engine.Open() to engine.SolutionOpen and so on. As defined in UAMX ?
            //8. Implement FileSystemManager class for solution file operations.

            engine.DbAdapter.Open(); //open but not close after success transaction, close after rollback.
            //===================INSERT test ======================
            //create category Tasks
            CElement catTasks = new CElement();
            catTasks.Id = 1;
            catTasks.ElementType = EnumElementType.Category;
            catTasks.ElementState = EnumElementState.ProtectedFromDelete;//do not use for user items!
            catTasks.Parent = new CElementRef(0);
            catTasks.Title = "Tasks";
            catTasks.Description = "Tasks main category";
            catTasks.Remarks = "This is a first fixed category, protected from deletion";
            //insert
            engine.DbAdapter.InsertElementWithTransaction(catTasks);

            //create tag category Tags
            CElement tagcat = new CElement();
            tagcat.Id = 5;
            tagcat.Parent = new CElementRef(0);
            tagcat.Title = "Tags";
            tagcat.Description = "Main tag category";
            tagcat.ElementState = EnumElementState.ProtectedFromDelete;
            tagcat.ElementType = EnumElementType.Category;
            tagcat.Remarks = "tag category remarks";
            //insert
            engine.DbAdapter.InsertElementWithTransaction(tagcat);

            //create tag FirstTag
            CElement tag1 = new CElement();
            tag1.Id = 6;
            tag1.Parent = new CElementRef(5);
            tag1.Title = "FirstTag";
            tag1.Description = " First tag";
            tag1.ElementState = EnumElementState.Normal;
            tag1.ElementType = EnumElementType.Tag;
            tag1.Remarks = "First tag remarks";
            //insert
            engine.DbAdapter.InsertElementWithTransaction(tag1);

            //create category CategoryHome
            CElement catHome = new CElement();
            catHome.Id = 2;
            catHome.Parent = new CElementRef(1);
            catHome.Title = "Home";
            catHome.Description = "Tasks subcategory";
            catHome.ElementState = EnumElementState.Normal;
            catHome.ElementType = EnumElementType.Category;
            catHome.Remarks = "This is a first normal category";
            //insert
            engine.DbAdapter.InsertElementWithTransaction(catHome);

            //create Rule rule1
            CElement rule1 = new CElement();
            rule1.Id = 3;
            rule1.Parent = new CElementRef(2);
            rule1.Title = "Rule1";
            rule1.Description = "Rule description text";
            rule1.ElementState = EnumElementState.Normal;
            rule1.ElementType = EnumElementType.Note;
            rule1.Remarks = "Rule remarks";
            rule1.Tags.Add(6, null);
            //insert
            engine.DbAdapter.InsertElementWithTransaction(rule1);

            //create task task1
            CTask task1 = new CTask();
            task1.Id = 4;
            task1.Parent = new CElementRef(2);
            task1.Title = "Task1";
            task1.Description = "Task description text";
            task1.ElementState = EnumElementState.Normal;//must be init in constructor
            task1.ElementType = EnumElementType.Task;//must be init in CTask constructor
            task1.Remarks = "Task remarks";
            //task info
            task1.TaskStartDate = new DateTime(2023, 01, 01);
            task1.TaskCompletionDate = new DateTime(2023, 01, 02);
            task1.TaskResult = "Result for this task";
            task1.TaskState = EnumTaskState.Run;
            //tags
            task1.Tags.Add(6, null);
            //insert
            engine.DbAdapter.InsertElementWithTransaction(task1);
            //=========================UPDATE test===================================
            task1.Description = "Updated task description";
            task1.TaskStartDate = new DateTime(2023, 06, 06);
            engine.DbAdapter.UpdateElementWithTransaction(task1);

            rule1.Title = "UpdatedNote";
            engine.DbAdapter.UpdateElementWithTransaction(rule1);
            //========================SELECT Elements =======================

            List<CElement> elements = engine.DbAdapter.SelectElementsByParentId(0);
            List<CElement> user = engine.DbAdapter.SelectElementsByParentId(2);
            //================DELETE elements ==============================
            engine.DbAdapter.DeleteElementWithTransaction(task1);
            engine.DbAdapter.DeleteElementWithTransaction(rule1);
            List<CElement> user2 = engine.DbAdapter.SelectElementsByParentId(2);
            //==============================================================
            //close connection
            engine.DbAdapter.Close();
        }
    }
}
