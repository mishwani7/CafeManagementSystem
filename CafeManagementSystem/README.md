# Cafe Management System

A Windows Forms application for managing a cafe, built with C# and .NET Framework 4.7.2. This project provides a simple interface for cafe staff to manage menu items, place orders, and print receipts, with role-based access for Admin and Guest users.

---

## Features

- **User Login:** Admin and Guest roles with different access levels
- **Dashboard:** Central hub for all operations
- **Add/Update/Remove Items:** Manage menu items in the cafe
- **Place Orders:** Search, select, and order items
- **Print Receipts:** Print order details using DataGridView printer
- **Database Integration:** Uses SQL Server (`mycafe` database)

---

## Screenshots

> _Add screenshots of the Dashboard, Login, and Order screens here._

---

## Getting Started

### Prerequisites
- Windows OS
- Visual Studio (2017 or later recommended)
- SQL Server (Express or above)
- .NET Framework 4.7.2

### Setup Instructions

1. **Clone the Repository**
   ```
   git clone <your-repo-url>
   ```
2. **Open the Solution**
   - Open `CafeManagementSystem.sln` in Visual Studio.

3. **Restore NuGet Packages**
   - Right-click the solution and select `Restore NuGet Packages` (if prompted).

4. **Configure the Database**
   - Create a SQL Server database named `mycafe`.
   - Update the connection string in `function.cs` if your SQL Server instance name is different:
     ```csharp
     con.ConnectionString = "data source = <YOUR_SERVER>;database = mycafe; integrated security = True";
     ```
   - Create the required tables (example for `Item` table):
     ```sql
     CREATE TABLE Item (
         Id INT PRIMARY KEY IDENTITY,
         Name NVARCHAR(100),
         Category NVARCHAR(100),
         Price INT
     );
     ```
   - Add sample data as needed.

5. **Build and Run**
   - Press `F5` or click `Start` in Visual Studio.

---

## Usage

- **Login:** Use `admin` / `pass` for Admin access, or click Guest for limited access.
- **Dashboard:** Navigate using the sidebar to add, update, remove items, or place orders.
- **Order Placement:** Search for items, select quantity, and print receipts.

---

## Project Structure

- `CafeManagementSystem/` - Main application code
  - `AllUserControls/` - User controls for different features
  - `function.cs` - Database helper functions
  - `DGVPrinter.cs` - Helper for printing DataGridView
  - `Dashboard.cs` - Main dashboard form
  - `Login.cs` - Login form
  - `UC_PlaceOrder.cs` - Order placement logic

---

## Contribution

Contributions are welcome! Please fork the repository and submit a pull request.

---

## License

This project is licensed under the MIT License.

---

## Support

For questions or support, please open an issue on the repository.
