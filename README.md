# Cafe Management System

A comprehensive Windows Forms application for managing the daily operations of a cafe. Built with C# and .NET Framework 4.7.2, this project provides an intuitive interface for both administrators and staff to efficiently handle menu items, process orders, and generate receipts. The system features robust role-based access, ensuring that only authorized users can perform sensitive operations such as adding, updating, or removing menu items.

---

## Overview

The Cafe Management System is tailored for small to medium-sized cafes looking for a digital solution to manage their menu and order workflow. The application connects to a SQL Server database (`mycafe`) to store and retrieve menu items and order information. It is designed to be user-friendly, with clear navigation and helpful prompts, making it easy for staff to learn and use.

### Key Highlights

- **Role-Based Access:** Admin users can manage menu items, while guests have limited access to order placement only.
- **Order Management:** Staff can search for items, select quantities, and place orders quickly.
- **Receipt Printing:** Integrated DataGridView printing for professional-looking receipts.
- **Database Integration:** All data is stored securely in a SQL Server database, ensuring reliability and scalability.
- **Modular Design:** User controls (`AllUserControls/`) make it easy to extend or customize features.

---

## Features

- **User Login:** Secure login for Admin and Guest roles.
- **Dashboard:** Centralized navigation for all major features.
- **Add/Update/Remove Items:** Full CRUD operations for menu management (Admin only).
- **Place Orders:** Search, select, and order menu items with real-time price calculation.
- **Print Receipts:** Generate and print receipts for each order.
- **Responsive UI:** Designed for ease of use in a busy cafe environment.

---

## Technologies Used

- **C#** (.NET Framework 4.7.2)
- **Windows Forms** (WinForms)
- **SQL Server** (Database)
- **DGVPrinterHelper** ([GitHub](https://github.com/shahedbd/dgvprinter))

---

## Typical Workflow

1. **Login:** Staff log in as Admin or Guest.
2. **Dashboard:** Admins can manage menu items; all users can place orders.
3. **Order Placement:** Staff search for items, select quantity, and add to order.
4. **Receipt:** After placing an order, a receipt can be printed for the customer.

---

## Who Is This For?

- Cafe owners and managers seeking a simple, reliable POS (Point of Sale) system.
- Developers looking for a WinForms-based CRUD and order management example.
- Students and educators as a learning project for C# and database integration.

---

## Customization & Extensibility

- **Database:** Easily adapt the connection string in `function.cs` for your SQL Server instance. Your server name can be found in SQL Server Management Studio under the "Connect to Server" dialog.
- **UI:** Modify or extend user controls in the `AllUserControls/` folder to add new features.
- **Authentication:** Admin credentials are hardcoded as `admin` / `pass` in `Login.cs`. You can change them there for your deployment. For production, consider implementing secure authentication and password hashing.
- **Adding More Tables:** To expand the system, add new tables to your database and corresponding user controls/forms in the project.

---

## Database Setup

- **Quick Start:**
  - A backup file `mycafe.bak` is included. You can restore this in SQL Server Management Studio to quickly set up the database with sample data.
  - [How to restore a .bak file in SQL Server](https://learn.microsoft.com/en-us/sql/relational-databases/backup-restore/restore-a-database-backup-using-ssms)
- **Manual Table Creation:**
  - See the `Getting Started` section below for table creation scripts.

---

## Known Issues & Limitations

- The connection string is hardcoded in `function.cs` and uses Windows Authentication. Update as needed for your environment.
- No password hashing or advanced authentication (for demo/educational use only).
- No built-in user management (only Admin/Guest roles).
- No error logging beyond message boxes.

---

## Getting Help

- For setup or usage questions, please open an issue on the repository.
- Contributions, suggestions, and feature requests are welcome!
- For direct contact, visit [mishwani7 on GitHub](https://github.com/mishwani7).

---

## Getting Started

### Prerequisites

- Windows OS
- Visual Studio (2017 or later recommended)
- SQL Server (Express or above)
- .NET Framework 4.7.2

### Setup Instructions

1. **Clone the Repository**

   ```sh
   git clone https://github.com/mishwani7/CafeManagementSystem.git
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
   - Or, restore the provided `mycafe.bak` file for a ready-to-use database.

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
  - `mycafe.bak` - Database backup for quick setup

---

## Cleaning & Rebuilding

- If you encounter build issues, use `Clean Solution` and then `Rebuild Solution` in Visual Studio (from the `Build` menu).

---

## Contribution

Contributions are welcome! Please fork the repository and submit a pull request.

---

## License

This project is licensed under the GNU General Public License (GPL). See the LICENSE file for details.

---

## Support

For questions or support, please open an issue on the repository.
