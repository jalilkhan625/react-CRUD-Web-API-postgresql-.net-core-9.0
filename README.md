# Employee Management CRUD App

## 📝 Project Overview

This project is a **full-stack CRUD application** for managing employees. It allows users to **create, read, update, and delete** employee records. The frontend is built with **React**, the backend is developed using **ASP.NET Core Web API**, and the data is stored in a **PostgreSQL** database.

---

## 📁 Tech Stack

- **Frontend:** React, Material UI
- **Backend:** ASP.NET Core Web API
- **Database:** PostgreSQL
- **Image Storage:** File System (Photo URL saved in the database)

---

## ⚖️ Features

- Add new employees with profile photo
- View all employees in a dynamic, responsive table
- Edit employee details using modals
- Delete employees with confirmation prompts
- Success messages on all operations
- Backend API returns JSON responses including Base64-encoded image strings

---

## 📦 Folder Structure

```
employee-crud-app/
│
├── backend/                  # ASP.NET Core Web API
│   ├── Controllers/          # API controllers
│   ├── Models/               # Data models
│   ├── Services/             # Business logic
│   └── ...                   # Other ASP.NET configuration files
│
├── frontend/                 # React app
│   ├── components/           # React components (EmployeeTable, AddModal, etc.)
│   ├── services/             # API interaction functions
│   └── ...                   # Other React configuration files
│
└── README.md                 # Project documentation
```

---

## 🧠 CRUD Functionality

### ➕ Create

- **Action:** Add a new employee
- **Frontend:** Fill form fields (name, email, position, photo) in a modal
- **Backend Endpoint:** `POST /api/employees`
- **Storage:** Image saved in the filesystem; file path stored in the database

### 📥 Read

- **Action:** Fetch and view employee records in a table
- **Frontend:** Data table with employee details and photos
- **Backend Endpoint:** `GET /api/employees`
- **Behavior:** Loads on page start or after create/update/delete

### ✏️ Update

- **Action:** Edit an existing employee
- **Frontend:** Modal form populated with selected employee’s data
- **Backend Endpoint:** `PUT /api/employees/{id}`
- **Behavior:** Image can also be updated or left unchanged

### ❌ Delete

- **Action:** Remove an employee
- **Frontend:** Click delete icon → confirm via prompt
- **Backend Endpoint:** `DELETE /api/employees/{id}`
- **Behavior:** Deletes record and associated image file

---

## 🔑 API Overview

| Method | Endpoint                  | Description               |
|--------|---------------------------|---------------------------|
| GET    | `/api/employees`          | Get all employees         |
| GET    | `/api/employees/{id}`     | Get employee by ID        |
| POST   | `/api/employees`          | Add new employee          |
| PUT    | `/api/employees/{id}`     | Update existing employee  |
| DELETE | `/api/employees/{id}`     | Delete employee by ID     |

---

## 💾 Setup Instructions

### Backend Setup

1. Navigate to the `backend/` folder
2. Configure the PostgreSQL connection string in `appsettings.json`
3. Run the migrations to create the database schema
4. Start the API server

### Frontend Setup

1. Navigate to the `frontend/` folder
2. Install dependencies using your preferred package manager (npm or yarn)
3. Set the backend API base URL in the `.env` file
4. Start the React development server

---

## 🖼️ Image Handling

- Images are uploaded via the frontend and stored in a directory (e.g., `/Photos/`)
- The backend returns a **Base64-encoded** version of the image string in JSON
- The frontend displays the image using `src={\`data:image/jpeg;base64,...\`}`

---

## ✅ To Do / Enhancements

- Authentication & Authorization (login required to manage employees)
- Pagination & Filtering on the table
- Search functionality
- Image compression and validation
- Switch to cloud storage for images (e.g., Azure Blob Storage, AWS S3)

---

## 📌 Notes

- This project is meant for educational and portfolio use.
- Follows clean architecture practices and separation of concerns.
- All endpoints return consistent and structured API responses.
