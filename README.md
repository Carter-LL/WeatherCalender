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

# Requirements to Run the Blazor WebAssembly App
## 1. **.NET SDK**
   - **Target Framework**: `.NET 8.0` (ensure you have the .NET 8.0 SDK installed)
   - You can download and install it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet).

## 2. **Blazor WebAssembly**
   - **Microsoft.AspNetCore.Components.WebAssembly**: Version `8.0.11`
   - This package is required to run Blazor WebAssembly applications.

## 3. **Development Server**
   - **Microsoft.AspNetCore.Components.WebAssembly.DevServer**: Version `8.0.11`
   - This package is used during local development to run the WebAssembly app.

## 4. **JSON Serialization**
   - **Newtonsoft.Json**: Version `13.0.3`
   - This package is required for handling JSON serialization and deserialization.
     
## 5. **WebAssembly and Browser Support**
   - The application is built as a **Blazor WebAssembly** app, so it will require a modern web browser to run (e.g., Chrome, Firefox, Edge, Safari).

## 6. **Development Tools**
   - A modern IDE or text editor like **Visual Studio**, **Visual Studio Code**, or another editor with .NET support is recommended.
   - The **Blazor WebAssembly DevServer** will be needed for local development and testing.

### Additional Notes
- Ensure that your system has the necessary resources (e.g., memory, CPU) to run a Blazor WebAssembly app effectively.
- The app depends on web APIs like geolocation, so ensure the user's browser has the necessary permissions to access location services.


# Current WebAPIs being used
- (Weather Data) https://forecast9.p.rapidapi.com/rapidapi/forecast/46.95828/10.87152/summary/
- (Weather Data) https://rapidapi.com/wettercom-wettercom-default/api/forecast9/
- (Geo Latitude & Longitude Data) https://api.my-ip.io/v2/ip.json

![image](https://github.com/user-attachments/assets/5f2fa91a-ee4c-4454-9aa8-85cb25896b9d)
![image](https://github.com/user-attachments/assets/bbb8b3c5-3499-421f-9d9c-1484761fd488)



