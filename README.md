# SchoolBoard
## Project Description
A message board-like collaboration tool for educators.
SchoolBoard is a forum that allows teachers to communicate and work together for the students they share.
##**Installation**
Follow the steps below to install and build the project:
1. Make sure to have both [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/community/) and [Git](https://git-scm.com/downloads) installed on your PC.

1. Navigate to the [main repository](https://github.com/Parker-Anderson/SchoolBoard) and copy the text provided by clicking "Code".

![CloneView](https://user-images.githubusercontent.com/58240410/117258630-2bf8ae80-ae1b-11eb-8dc3-166821034199.PNG)

1. From the Windows command prompt, navigate to the directory in which you want to clone SchoolBoard.  Enter the command 'git clone' followed by the copied text.

![cmdclone](https://user-images.githubusercontent.com/58240410/117258632-2c914500-ae1b-11eb-9cf1-5612326e26db.PNG)

1. This will populate the directory with a SchoolBoard folder.  Within this folder, open SchoolBoard.sln.

1. Global.asax contains a SeedIdentity method that will pre-seed sample Instructor accounts. In Visual Studio, ctrl + F5 to build and run the MVC project.  This will automatically populate the 
ApplicationUser tables in our new database (these are required by key constraints in our other tables.). Immediately stop the application.

1. Open Package Manager Console and change the target project from SchoolBoard.MVC to SchoolBoard.Data. (You may be prompted to restore Nuget Packages. If so, click "Restore")  Run the following command to execute the pending migration and the seed method in Configuration.cs:

![update-database](https://user-images.githubusercontent.com/58240410/117258647-2e5b0880-ae1b-11eb-92ad-48f8bae246d5.PNG)

1. Now run the application again using IIS Browser.  
  1. At the landing page, users are asked to login (or create new account).  
  
  ![SchoolBoardHomeView](https://user-images.githubusercontent.com/58240410/117258642-2dc27200-ae1b-11eb-9427-1923e41515e7.PNG)
  
  1. As an example Instructor account, I have provided the following credentials: 
  UserName: "smith@email.com"
  Password: "Test1!"
  Use these to login and demo the app.
  
  ![SchoolBoardAuthenticated](https://user-images.githubusercontent.com/58240410/117258639-2d29db80-ae1b-11eb-879f-da864700a125.PNG)
  
  1. Once Authenticated, users will be able to access list pages for the specific courses they are assigned, as well as a general list of all courses.
  
  ![MyCourses](https://user-images.githubusercontent.com/58240410/117258637-2c914500-ae1b-11eb-9d76-44b0972c7733.PNG)
  
  1. Each of these Courses directs to a Student list view, filtered by Student performance (determined by Student GPA).
  
  ![CourseView](https://user-images.githubusercontent.com/58240410/117258634-2c914500-ae1b-11eb-962d-8976f1369632.PNG)
  
  1. Each Student view will display the Student's current GPA, and previous postings by all users for that student.  Here the Student's various instructors can communicate  with each other.  A message can be created by clicking "New Post" and filling out the required fields.  
  
  ![StudentDetail](https://user-images.githubusercontent.com/58240410/117258645-2e5b0880-ae1b-11eb-8234-42a1ebd0f807.PNG)

##Resources
*
*
*
*
*
*


  
  

  


