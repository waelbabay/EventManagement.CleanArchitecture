# EventManagement

EventManagement is a .NET application built using Clean Architecture. The project is structured into multiple layers:

- **Domain** (Core business logic)
- **Application** (Use cases and business rules)
- **Infrastructure** (External services and dependencies)
- **Persistence** (Database access)
- **API** (Exposes endpoints for the application)

## Features

- Manage events and user reviews  
- Detect the language and sentiment of event reviews using Azure AI Text Analysis  
- Generate an event image based on its description using Azure OpenAI & DALL·E 3  
- Modular architecture allowing flexibility in implementation  

## Language & Sentiment Analysis

The **Infrastructure** layer integrates with **Azure AI Text Analysis** to detect the language and sentiment of user reviews for events. This functionality is implemented using an interface, allowing flexibility in replacing the Azure AI service.

## AI-Powered Event Image Generation

When an event is created, the application can generate a relevant image based on the event's description using **Azure OpenAI** and **DALL·E 3**. This ensures visually appealing content without requiring manual image uploads.

## Custom ML Model with ML.NET

Instead of using Azure AI, the language and sentiment detection service can be replaced with a **custom ML model** trained using **ML.NET** and **Model Builder**. This enables on-premise processing without relying on external cloud services.

## Technologies Used

- **.NET 8** (Core framework)
- **Azure AI Text Analysis** (Default language & sentiment detection)
- **Azure OpenAI & DALL·E 3** (AI-powered image generation)
- **ML.NET** (Alternative machine learning model)
- **Entity Framework Core** (Database access)
- **ASP.NET Core Web API** (Backend API)

## Getting Started

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/EventManagement.git
   cd EventManagement
  
2. Run The application
   ```sh
   dotnet run --project src/EventManagement.API