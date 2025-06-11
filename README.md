# 📘 Read Functionality – React + ASP.NET Core 9.0 Web API + PostgreSQL

Author: **User**

This document explains the **Read (GET)** functionality of the CRUD system in this full-stack project:

- 🧩 **Frontend**: React
- ⚙️ **Backend**: ASP.NET Core 9.0 **Web API**
- 🗄️ **Database**: PostgreSQL
- 🖼️ **Images**: Stored as Base64-encoded strings (`PhotoUrl`)

---

## 🔧 Backend – ASP.NET Core Web API

### ✅ Controller: `EmployeesController.cs`

#### 📥 Get All Employees
```csharp
[HttpGet]
public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
{
    return await _context.Employees.ToListAsync();
}
```

#### 📥 Get Employee by ID
```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Employee>> GetEmployee(int id)
{
    var employee = await _context.Employees.FindAsync(id);
    if (employee == null)
    {
        return NotFound();
    }
    return employee;
}
```

---

## 💻 Frontend – React

### ✅ File: `EmployeeList.js`

```jsx
import React, { useEffect, useState } from 'react';
import axios from 'axios';

function EmployeeList() {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5001/api/employees')
      .then(response => setEmployees(response.data))
      .catch(error => console.error('Error fetching employees:', error));
  }, []);

  return (
    <div>
      <h2>Employee List</h2>
      <ul>
        {employees.map(emp => (
          <li key={emp.id}>
            <strong>{emp.name}</strong> - {emp.position} <br />
            <img 
              src={`data:image/png;base64,${emp.photoUrl}`} 
              alt="Employee" 
              width="60" 
              style={{ marginTop: '5px' }}
            />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default EmployeeList;
```

---

## ✅ Summary

| Feature         | Endpoint                     | Status |
|----------------|------------------------------|--------|
| Get All        | `GET /api/employees`         | ✅     |
| Get by ID      | `GET /api/employees/{id}`    | ✅     |
| Frontend View  | `EmployeeList.js`            | ✅     |

---

> 📌 Make sure CORS is configured properly and both frontend & backend ports match if testing locally.
