# 6002CEM_SadiYaqubi

Weather App Development.

Motivation:
Living in the UK, where the weather is notoriously unpredictable and often far from ideal, I was inspired to create a weather app that I could rely on in real life. Designing this app felt like the perfect idea, blending practicality with the opportunity to learn and apply advanced development techniques. This module was challenging, but it pushed me to grow as a developer. I’m proud of what I’ve achieved, and I hope you enjoy exploring the app as much as I enjoyed creating it.



In this video, I will demonstrate the features and functionality of my weather app, showcasing its user interface, technical architecture, and seamless integration with external APIs.
The app begins with an overview of its initialization process, which uses dependency injection to manage services like WeatherService and CityService. Navigation is set up through AppShell.xaml, allowing users to easily switch between pages such as the HomePage and FavoriteCitiesPage. The app's structure is designed to provide a smooth and responsive experience.

Home Page Features:
The HomePage serves as the main interface where users can view current weather conditions, hourly forecasts, and a 7-day weather outlook. The data is displayed with dynamic icons, real-time temperature updates, and location-specific details. A key feature here is the pull-to-refresh functionality, which lets users swipe down to update weather data from the API seamlessly. All weather information is dynamically bound to the HomePageViewModel, ensuring the UI updates instantly as data changes.

City Search:
The app includes a robust city search feature, accessible through a popup (CitySearchPopup). Users can search for cities using a custom SearchBarUc control, and the app fetches matching city results from the API. The search functionality is powered by CityRootResponseApiModel, which structures the API response to include city names, country codes, and geo-coordinates. This feature provides users with quick and accurate results, enhancing their experience.

Favorite Cities:
The FavoriteCitiesPage allows users to manage a personalized list of favorite cities. They can add cities directly from the HomePage and view them in the favorites list, which displays key weather information such as temperature and conditions. This data is stored locally in a SQL database, ensuring persistence even when the app is restarted. Users can remove cities from their favorites, and all changes are immediately reflected in the UI.

API Integration:
The app integrates with a weather API to fetch data for various features. It securely manages API authentication using TokenResponseApiModel, which handles token-based access. Weather data is parsed and structured using models like ForecastJsonResponseApiModel, ensuring the information is properly displayed. City filtering and search requests use CityFilterRequestApiModel for efficient interaction with the API.

SQL Database:
The app incorporates a SQL database (WeatherDatabase.cs) to store favorite cities locally. This ensures that users' preferences, such as their saved cities, are accessible offline. The integration of SQLite highlights the app's ability to handle data storage efficiently while enhancing usability.

User Interface:
the app boasts a clean and modern user interface. Weather icons dynamically represent current conditions, while collection views display hourly and daily forecasts in an intuitive, scrollable format. Additionally, the Expander control provides a collapsible section for detailed forecast data, making the UI both functional and visually appealing.


Conclusion:
This demonstration will highlight the app’s modular design, which uses reusable components like SearchBarUc and follows the MVVM (Model-View-ViewModel) architecture. The app’s combination of API integration, local data storage, and responsive UI ensures a seamless and engaging user experience. The project is future-ready, with the potential to incorporate additional features such as weather alerts or interactive maps.

links: https://youtu.be/dQkRNJLKLkc
