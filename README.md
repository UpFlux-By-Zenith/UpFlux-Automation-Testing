# UpFlux Testing Suite – Backend & Frontend Automation
---


This repository documents the **end-to-end testing** of the UpFlux platform, covering:

- **Backend API Testing** via **Postman**
- **Frontend UI Automation** via **Playwright** in C#
<br>

## Project Structure
📁 UpFluxAutomationTest.sln # Frontend Playwright UI tests (C#)

📁 UpFluxCollection.postman_collection.json # Backend API tests (Postman Collection v2.1)

<br>


## 🔧 Backend Testing – Postman
---

### Overview

The backend testing focuses on verifying the API functionality, security, and expected behaviour under both valid and invalid scenarios.
<br>

### 📋 Test Coverage

The `UpFluxCollection` Postman collection includes:

#### 🔐 Authentication & Authorization
- Admin login (valid/invalid)
- Engineer login with token
- Token parsing and validation (expired, tampered, missing)

#### 🔄 Access Control
- Role-based data access (Admin vs Engineer)
- Unauthorized access scenarios

#### 🔑 Password Management
- Change password validation
- Weak and mismatched password checks

#### 📊 Application & Machine Data
- Retrieve machine access details
- View application versions
- Validate JSON structure and non-empty fields

#### 🔧 Licensing
- Generate machine UUID
- Register new machines
- Token authentication for licensing endpoints

#### 📣 Notification System
- Create notification groups
- Add/Remove device URIs from groups

#### 🛡️ Security Features
- Brute-force protection testing
- Rate limiting using `Retry-After`
- HTTPS enforcement & secure token transmission

---

### ▶️ How to Run Backend Tests

1. **Open Postman.**
2. **Import the collection:**
   - `UpFluxCollection.postman_collection.json`
3. **Set environment variables:**
   - `url`, `AdminEmail`, `AdminPassword`, `engineerEmail`, `engineerToken`, `token`, `uri`
4. **Run using Collection Runner:**
   - Choose a folder (e.g., `Authorization and Authentication`) and run.
5. **Inspect test results** under **"Test Results"** tab.
<br>


## 💻 Frontend Testing – Playwright (C#)
---
### 📌 Overview

Frontend testing ensures that all user interface elements and workflows behave as expected. Tests simulate real-world interactions with the UpFlux web interface.
<br>

### Prerequisites & Required Libraries

Ensure the following dependencies are installed before running the tests:

| Package | Description |
|--------|-------------|
| `Microsoft.Playwright` | Core Playwright library |
| `Microsoft.Playwright.NUnit` or `Microsoft.Playwright.MSTest` | Test runner integration |
| `Microsoft.NET.Test.Sdk` | Required to run tests in .NET |
| `coverlet.collector` (optional) | Code coverage collector |

Install via terminal or NuGet Package Manager:

```bash
dotnet add package Microsoft.Playwright
dotnet add package Microsoft.Playwright.NUnit
dotnet add package Microsoft.NET.Test.Sdk
playwright install
```
<br>

## 🚀 How to Run the Frontend Tests

### 🛠️ Open the Solution
Launch `UpFluxAutomationTest.sln` in **Visual Studio 2022**.

---
<br>

### 📦 Restore NuGet Packages

Use the terminal or Visual Studio's Package Manager Console:

```bash
dotnet restore
```
<br>

### 🏗️ Build the Solution 
▶️ Run the Tests
You can run the tests using either of the following methods:

Option 1: Visual Studio
Open the Test Explorer in Visual Studio and click "Run All Tests".

Option 2: Terminal
Run the following command in the terminal:

```bash
dotnet test UpFluxAutomationTest.sln
```
<br>


### 🧪 Solution Testing Philosophy
The UpFlux testing strategy is built upon:

🔒 Security-first: Focus on authentication, role-based access control, and brute-force protection.

📐 Structure validation: Ensures correct response structure, required fields, and nested objects.

⚙️ Robust UI workflows: Simulates real user interactions including login, dashboard use, and token-based logic.

📊 Automated coverage: Validates key features using automated, repeatable test cases.

🧪 Reliable error handling: Handles invalid credentials, expired tokens, and missing inputs gracefully.

<br>


### 📌 Notes
All tokens used in API tests are stored and injected dynamically via Postman environment variables.

Ensure the backend server is running before starting frontend or backend tests.

Playwright tests require browsers (Chromium, WebKit, Firefox), which are automatically installed with:

```bash
playwright install
```
<br>


### 📫 Authors & Maintainers
👨‍💻 Collaborative Team: UpFlux Final Project Team

🛠️ Tools Used: Postman · Playwright · C# · .NET 7 · Visual Studio 2022
