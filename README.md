# Weather-Aware-Task-Manager
The Weather-Aware Task Manager combines task management with weather data to help users plan their activities more effectively. Users can create, view, and manage tasks while also checking the current weather conditions to decide when to schedule outdoor activities or adjust their plans.

# Technical Implementation
- Frontend: Use ASP.NET Core MVC with Bootstrap for a responsive layout.
- Backend: ASP.NET Core for business logic and SQLite for task data storage.
- Weather API: Integrate a weather service API to pull in real-time weather data based on the user's input (e.g., location or postal code).

# Visual Appeal
- Design Consistency: Use a selected color palette and font stack to enhance the application's design. Explore current design trends to ensure modern aesthetics.
- Interactive Elements: Menus, buttons, and forms will follow standard interaction conventions for predictability and ease of use.
- Accessibility: Ensure all text is legible and appropriately spelled, with attention to accessibility guidelines.

# Key Features
- User Authentication: Secure login and account creation for personalized task management.
- Task Management: Users can add, edit, delete, and categorize tasks as "To Do," "In Progress," or "Completed."
- Weather Integration: Fetch and display current weather conditions based on the user's location, helping them plan tasks accordingly.
- Task Filtering: Users can filter tasks by status and view tasks alongside the current weather forecast.
- Responsive Design: A modern, user-friendly interface that works well on both desktop and mobile devices.

# Current WebAPIs being used
- (Weather Data) https://forecast9.p.rapidapi.com/rapidapi/forecast/46.95828/10.87152/summary/
- (Weather Data) https://rapidapi.com/wettercom-wettercom-default/api/forecast9/
- (Geo Latitude & Longitude Data) https://api.my-ip.io/v2/ip.json

# Features Added
- Implement a regular expression (regex) to validate or ensure a field is always stored and displayed in the correct format
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L179

- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L90
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L85

- Write information/data to a text file. Examples: write log files, save to configuration files, or export a database table to CSV.
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L199
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/wwwroot/js/main.js#L41
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L211
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/wwwroot/js/main.js#L44
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/Pages/Home.razor#L223
  - https://github.com/Carter-LL/WeatherCalender/blob/c3fa16a0abac313ad4164b80902f7a71cb729d8e/Calender/Calender/wwwroot/js/main.js#L47

![image](https://github.com/user-attachments/assets/6ae3a8ca-04c7-4d15-af12-b8d0d467ea13)
![image](https://github.com/user-attachments/assets/ab4a12c5-6d40-4bbe-8372-764cc4e64a75)

