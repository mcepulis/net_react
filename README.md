# 🌟 About

This project is for educational purposes to deepen knowledge in React and .NET

Site published at: [https://github.com/mcepulis/net_react](https://github.com/mcepulis/net_react)

## Technologies used 🛠️

- **React** – Frontend JavaScript library
- **Webpack** – Module bundler for JavaScript and assets
- **TypeScript** – A superset of JavaScript with static typing
- **Tailwind CSS** – Utility-first CSS framework
- **Axios** – Promise-based HTTP client for the browser and Node.js
- **React Router DOM** – Declarative routing for React
- **ASP.NET Core** – Cross-platform framework for building modern web applications
- **EF Core** – Object-Relational Mapping (ORM) framework for .NET (In-memory database)

## 🎯 Project features/goals

- React-based frontend
- Webpack for bundling and building
- TypeScript for static typing
- Tailwind CSS for styling
- Axios for handling HTTP requests
- React Router DOM for routing
- ASP.NET Core backend
- EF Core (In-memory database) for data storage
- Quiz functionality with user input
- High score tracking and display
- State management with React hooks
- Backend-Frontend communication via REST API
- Real-time data handling (e.g., quiz results)

## 🧬 Getting Started

Clone the repo:
```bash
git clone https://github.com/mcepulis/net_react.git
```

## 🏃 Installation

### **Download the .NET SDK**:
1. Visit [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
2. Choose the latest version of the .NET SDK.

### **Configuration in `./backend`**:
- Create a project:
  ```bash
  dotnet new webapi
  ```
- Install EF Core:
  ```bash
  dotnet add package Microsoft.EntityFrameworkCore
  dotnet add package Microsoft.EntityFrameworkCore.InMemory
  ```

### **Configuration in `./frontend`**:
1. Initialize npm:
   ```bash
   npm init -y
   ```
2. Install React and other necessary packages:
   ```bash
   npm install react react-dom typescript @types/react @types/react-dom
   ```
3. Install development dependencies:
   ```bash
   npm install --save-dev webpack webpack-cli webpack-dev-server babel-loader @babel/core @babel/preset-env @babel/preset-react typescript ts-loader
   ```
4. Install other useful packages:
   ```bash
   npm install --save-dev html-webpack-plugin style-loader css-loader
   npm install -D tailwindcss postcss autoprefixer
   npx tailwindcss init
   npm install react-router-dom
   npm install axios
   ```

## 🧪 Running tests

There are no tests for this project.

## 🎅 Authors

**Marius**: [Github](https://github.com/mcepulis)

## ⚠️ License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## 🔗 Other resources

No other resources.
