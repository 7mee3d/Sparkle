# 🌟 Sparkle – Smart Cleaning Services Management System
---
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![File System](https://img.shields.io/badge/File%20System-5C2D91?style=for-the-badge&logo=files&logoColor=white)
![Guna UI2 WinForms](https://img.shields.io/badge/Guna%20UI2-FB7299?style=for-the-badge&logo=gnu&logoColor=white)

---

## 📌 Overview
**Sparkle** is an all-in-one management system designed for carpet cleaning and car wash businesses.  
It empowers small-to-medium enterprises to automate daily operations — from client registration and order creation to user management, login tracking, and reporting — all through an intuitive, secure, and modern interface.

Built with **C#** on **.NET Framework (Windows Forms)** and enhanced with **Guna UI2**, Sparkle uses structured text files for data storage, making it lightweight, easy to deploy, and ready for future migration to SQL databases.



---



## 🚀 Key Features

### 1. 🧑‍💼 Client Management
- Add new clients with real-time validation (name, email, phone, address).  
- View all clients in a searchable list by ID.  
- Safely edit or delete client records with confirmation prompts.  
- Prevent ID duplication to ensure data integrity.  

---

### 2. 📋 Order Management
**Two service types:**

#### 🧺 Carpet Cleaning:
- Size (Small / Medium / Large)  
- Wash Type (Normal / Deep)  
- Add-ons: Quick Drying (+$5), Home Delivery (+$15)

#### 🚗 Car Wash:
- Size (Small / Medium / Large)  
- Service: Full Wash ($30) or Custom (Exterior, Interior, Engine Cleaning, Polishing)  
- Auto-calculated pricing based on selections.  
- Visual final invoice before confirmation.  
- Orders stored in separate files for better organization.  

---

### 3. 👤 User & Permission Management
- Create users with flexible access levels:  
  - 🔓 **Full Access:** All system sections unlocked.  
  - 🔐 **Custom Permissions:** Toggle access to 9 individual modules (Orders, Clients, Users, History, etc.).  
- Admin account is protected from deletion or modification.  
- Password encryption during storage (simple Caesar cipher).  
- Auto-generate random passwords if none provided.  

---

### 4. 🔍 Smart Search & Tracking
- Search clients, orders, or users by ID or username.  
- Highlight matching records in lists for instant visibility.  
- View login history with decrypted passwords (for admin review only).  

---

### 5. 📊 Modern & Responsive UI
- Sleek design using **Guna UI2** with consistent teal & white theme.  
- Visual dividers and animated elements for better UX.  
- Real-time input validation with **ErrorProvider** & **CorrectProvider**.  
- Balloon notifications (**NotifyIcon**) for key actions (e.g., “Order Added Successfully!”).  

---

### 6. 💾 Smart Local Storage
- Organized text files with custom delimiters:  
  - `;||;` → Clients  
  - `&&//&&` → Carpet Orders  
  - `#|||#` → Car Orders  
  - `||` → Users  
- Files auto-created if missing.  
- Data structure designed for easy SQL migration later.  

---

## 🛡️ Quality Assurance

### ✅ Input Validation
- No letters in numeric fields (phone, ID).  
- No digits in text fields (name, address).  
- Valid email formats only (`@gmail.com`, `@outlook.com`, etc.).  

### ✅ Logical Safeguards
- Prevents Admin deletion.  
- Blocks duplicate IDs/usernames.  
- Requires full form completion before submission.  

### ✅ Stability
- Gracefully handles missing data files.  
- Clean reset & refresh mechanisms.  

### ✅ User Experience
- Instant feedback.  
- Clear error messages.  
- Intuitive workflow.  

---

## 🎯 Target Audience
- Small car wash centers 🚗  
- Home-based carpet cleaning services 🧺  
- Computer Science / IT graduation projects 💻  
- Entrepreneurs seeking a simple, digital solution for service businesses 💼  

---

## 📦 Tech Stack
- **Language:** C#  
- **Framework:** .NET Framework (Windows Forms)  
- **UI Library:** Guna UI2  
- **Storage:** Structured text files (upgrade-ready to SQL)  
- **Security:** Basic password encryption  

---

## 💡 Why Sparkle?
Sparkle isn’t just software — it’s your digital partner to transform paper-based chaos into a smart, scalable, and professional system.  
It saves time, reduces errors, and boosts your business credibility — one clean order at a time.

> ✨ “Clean your business before you clean your carpets!”  
> — *The Sparkle Development Team*


--- 
## 🧹 Section: New Order Creation System 

### 🎯 Main Purpose  
Enables users to create new orders for **carpet cleaning** or **car wash** services through an intelligent, all-in-one interface.  
The system automatically calculates prices, validates input data, and generates a final invoice before saving — all in a single, smooth, and secure process.

---

### ✨ Key Features

#### 🔄 Smart Switching Between Carpet & Car Services
- Radio buttons (`Carpets` / `Cars`) dynamically adjust the interface to show relevant fields for each service.  
- Sections appear or hide automatically based on the selected option.  
- Visual icons enhance usability and clearly indicate the chosen service type.

#### 💰 Accurate Automatic Price Calculation
- **For Carpets:**  
  - Based on size (Small, Medium, Large), wash type (Standard, Deep), extra services (Quick Dry, Home Delivery), and quantity.  
- **For Cars:**  
  - Based on size (Small, Medium, Large), wash type (Full or Custom), and extras (Exterior/Interior wash, Engine Cleaning, Polishing).  
- The total price is displayed instantly and updates automatically with every change.

#### 📋 Intelligent Input Form with Real-Time Validation
- All fields are **required** — submission is disabled unless all inputs are valid.  
- **Live validation while typing**:  
  - 📝 **Names & Addresses**: Do not accept numbers.  
  - 📞 **Phone Numbers**: Accept digits only.  
  - 📧 **Email**: Must contain a valid provider (`@gmail.com`, `@outlook.com`, etc.).  
- Uses `ErrorProvider` and `CorrectProvider` for immediate visual feedback.

#### 🧾 Final Invoice Preview Before Saving
- Clicking **“Add New Order”** opens a final invoice window showing:  
  - 🆔 Order ID  
  - 👤 Client Information  
  - 📦 Service Details (size, type, extras)  
  - 💵 Total Price (highlighted and clearly visible)  
- After confirmation → the order is saved to a text file and the next order ID is auto-generated.

#### 🗑️ Safe Reset Function
- The **“Reset”** button clears all fields and selections without data loss.  
- Restores the interface to its default state, ready for a new entry.

#### 🖌️ Consistent and Modern Visual Design
- A vertical divider separates client information from service details for better visual clarity.  
- Consistent *Sparkle* theme colors (light green + white).  
- The total price is displayed in a colored box beside the service details.

---

### 🛡️ Quality & Performance Assurance

✅ **Secure Sequencing**  
Order IDs are auto-generated as the highest existing value + 1, preventing duplicates.  

✅ **System Stability**  
If the orders file doesn’t exist, it’s automatically created — ensuring smooth operation.  

✅ **Scalability**  
The architecture supports future database integration without requiring major UI or logic changes.  

✅ **Excellent User Experience**  
- Clear, instructive messages  
- Confirmation dialogs  
- Clean, visually organized layout  
- Full compatibility with **Guna UI2**

> 💡 This module is the **operational core** of the Sparkle system, combining **flexibility, precision, and safety** in the order creation process — making it a fundamental component of service management.

---

📌 **Technical Note**  
Orders are stored in two separate local text files:  
- `CarpetsOrders.txt` — for carpet cleaning requests  
- `CarOrders.txt` — for car wash requests  

Each file uses custom separators (`&&//&&` and `#|||#`) for structured data organization.

---

## 📋 Section: Show All Orders 

### 🎯 Main Purpose  
To display all orders registered in the **"Sparkle"** system — whether for **Carpet Cleaning** or **Car Wash** — inside a structured and dynamic table.  
The user can **quickly search by Order ID**, switch between order types with ease, and view detailed order information clearly.

---

### ✨ Key Features

#### 🔍 Instant Search by Order ID
- Allows searching for any order by entering its **unique ID**.
- When found:
  - ⭐ The corresponding row highlights in **yellow**.  
  - 🎯 The table automatically scrolls and focuses on that order.  
  - 🛎️ A success notification appears.  
- If not found → a clear error message guides the user.

#### 🔄 Smart Switching Between Orders (Carpets / Cars)
- Radio buttons (`Carpets` / `Cars`) dynamically switch the table view between both order types.
- Table columns change automatically depending on the selected service.
- Visual icons clarify the selected category to enhance the user experience.

#### 📊 Organized Orders Table Display
- Orders are loaded from **two separate data files**:
  - `CarpetsOrders.txt` — for carpet cleaning orders.  
  - `CarOrders.txt` — for car wash orders.  
- Each service has its own data structure:
  - **Cars:** Car number, model, size, services, total price, etc.  
  - **Carpets:** Size, washing type, extra services, number of carpets, total price, etc.

#### 🔁 Auto Refresh After Any Operation
- Whenever a new order is added, the list **auto-refreshes** upon reloading the section.
- The system **recounts** total orders and displays them in a small status bar next to the document icon.

#### 🖌️ Polished Visual Design
- A decorative separator line between title and table for visual organization.  
- Colors aligned with Sparkle’s branding (Light Green + White).  
- Displays **total number of orders** beside the record/document icon.

---

### 🛡️ Quality and Performance Guarantees

✅ **Security:**  
No operation (Edit/Delete) can be executed without clear mode selection, preventing accidental actions.

✅ **Stability:**  
If an order file does not exist, it is **automatically created** without system crashes.

✅ **Scalability:**  
Code structure is ready for **future database integration** without major interface changes.

✅ **User Experience:**  
- Clear confirmation dialogs.  
- Informative messages.  
- Consistent table layout.  
- Full support for Windows Forms interface.

> 💡 This section acts as the **core interaction point** for order management — combining **viewing, searching, and switching** — forming the backbone of the order management system.

---

### 📌 Technical Note  
All order data is stored in two separate text files:
- `CarpetsOrders.txt` → Carpet cleaning orders  
- `CarOrders.txt` → Car wash orders  
Each file uses **custom delimiters** (`&&//&&` and `#|||#`) to organize data efficiently.

---


## 🧑‍💼 Section: Client Addition Management 

## 🎯 Main Purpose  
Enables users to **register new clients** in the *Sparkle* system through a secure and user-friendly interface, ensuring **data validity** and **logical consistency** before saving.



## ✨ Key Features

#### 🔢 Smart Auto-Increment ID Generation
- Automatically generates a **unique ID** based on the last stored value in the file.  
- Prevents entering or duplicating existing IDs, ensuring **data integrity**.

#### 📋 Intelligent Input Form with Real-Time Validation
- All fields are **required** (Name, Address, Email, Phone).  
- **Live validation while typing**:
  - 📧 **Email**: Only accepts addresses from approved providers (`@gmail.com`, `@outlook.com`, `@yahoo.com`, `@hotmail.com`).  
  - 📞 **Phone Number**: Accepts **numbers only** — rejects any letters or symbols.  
- Uses `ErrorProvider` and `CorrectProvider` to show **instant visual feedback** to the user.

#### 💾 Reliable Local Data Storage
- Data is saved in a structured text file:  
  `InformationClients.txt`
- Each client is stored in a single line, using a custom separator: `;||;`  
  *(Example: `101;||;Crasto;||;USA;||;Crasto@example.com;||;32442213455`)*

#### 🛎️ Enhanced User Experience
- Upon successful client addition:
  - Displays a **balloon tip notification** with operation details.  
  - Clicking the notification **opens the data folder** directly in Windows Explorer.  
- After saving, the form **automatically resets** and is ready for a new client entry.

#### 🧹 Automatic Cleanup & Maintenance
- The “Reset” button (handled internally) clears all fields and removes any error messages.  
- Keeps the interface **clean and distraction-free** after every operation.

---

### 🛡️ Quality Assurance
- ✅ Prevents empty fields  
- ✅ Validates email format  
- ✅ Ensures phone number contains digits only  
- ✅ Avoids duplicate IDs  
- ✅ Maintains stability even if the data file is missing (auto-creates when needed)


--- 

## 📋 Section: Clients List 

### 🎯 Main Purpose  
Displays all registered clients in the *Sparkle* system in a clean, well-organized, and easy-to-navigate interface — with options to **search by ID**, **view client details**, and **delete records** when needed.

---

### ✨ Key Features

#### 🔍 Instant Search by Client ID
- Allows users to find a specific client by entering their **unique ID**.  
- When a client is found:  
  - ⭐ The corresponding row is highlighted in yellow.  
  - 🎯 The view automatically scrolls to and focuses on that client.  
- If no client is found → a clear error message is displayed with user guidance.

#### 📊 Organized Client Data Display
- All clients are loaded from the text file `InformationClients.txt` when the section is opened.  
- Data is displayed in a `ListView` with **five columns**:  
  - 🆔 **ID**  
  - 👤 **Client Name**  
  - 📍 **Address**  
  - 📧 **Email**  
  - 📞 **Phone**

#### 🔄 Auto-Refresh After Any Operation
- When a client is deleted → the list **updates instantly** and the total count is refreshed.  
- The counter (`LblNumberClient`) always reflects the accurate number of clients.

#### 🗑️ Safe & Simple Client Deletion
- Accessible via a **context menu (right-click)** on any client entry.  
- A confirmation dialog is shown before deletion to prevent mistakes.  
- Once confirmed → the client is removed from the file and the list refreshes automatically.

#### 📄 Detailed Client Information Window
- Selecting “Show Information” from the context menu opens a **new form** displaying all client data clearly and neatly.  
- Features an elegant design with a custom background and interactive elements.  
- Includes a smart, color-coordinated close button.

#### 🖌️ Consistent Visual Design
- Uses *Sparkle’s* color theme (light green + white).  
- A decorative line separates the title from the list for better visual organization.  
- The total number of clients is displayed in a small status label beside a user icon.

---

### 🛡️ Quality & Performance Assurance

✅ **Safe Loading**  
If the file doesn’t exist, it is automatically created — no crashes or interruptions.  

✅ **Data Stability**  
Client data is held in memory structures and only rewritten after deletion — no direct edits during viewing.  

✅ **Excellent User Experience**  
- Clear and friendly messages  
- Safety confirmations  
- Clean visual hierarchy  
- Full integration with **Guna UI2** components  

✅ **Scalability**  
The architecture is designed to support migration to a database later without major UI or logic changes.

> 💡 This section serves as the **main interaction hub** for client data — combining **listing, searching, details, and deletion** into one cohesive and intuitive module, making it the backbone of client management within the system.


📌 **Technical Note**  
Client data is stored locally in a text file (`InformationClients.txt`) using the separator `;||;`.  
This storage system can easily be replaced by a database in the future without major interface or logic changes.

---

## 🛠️ Section: Edit or Delete Client 

### 🎯 Main Purpose  
Allows the user to **update client data** or **permanently delete** a client from the “Sparkle” system through an integrated interface.  
The process begins by searching for the client using their **unique ID**, then lets the user choose between **Edit** or **Delete** mode — ensuring **data safety**, **clarity**, and an **intuitive user experience**.

---

### ✨ Key Features

#### 🔍 Smart Search by ID
- Enables the user to search for any client using a **unique ID**.  
- Once the client is found:
  - ✅ An instant success message is displayed.  
  - 🎯 The client’s details are automatically shown in the form fields.  
  - ⚙️ The appropriate mode (Edit/Delete) is automatically activated based on the user’s choice.

#### 🔄 Dual Smart Modes: Edit | Delete
- **Edit Mode (Update Mode):**  
  - All form fields become editable for data modification.  
  - After confirmation → the updated information is saved directly to the file.
- **Delete Mode (Remove Mode):**  
  - Client data is displayed as **read-only** to prevent accidental edits.  
  - After confirmation → the client is removed from the system, and the file is updated automatically.
- **Waiting Mode (None Mode):**  
  - No actions can be taken until a mode is clearly selected.

#### 🧹 Automatic Reset
- After each operation (Edit or Delete) → all fields are cleared and the mode resets to “None.”  
- This ensures **error prevention** and **a smoother workflow**.

#### 📄 Data Preview Before Deletion
- In Delete Mode → client details appear in a **non-editable format** to confirm identity before deletion.  
- Prevents mistaken deletions and ensures user confirmation.

#### 🛡️ Strict Data Validation
- **Real-time validation:**  
  - The `ID` field accepts **numbers only**.  
  - Other fields activate only after a successful search.  
- Uses `ErrorProvider` and `CorrectProvider` to display instant feedback for errors or valid input.

#### 🖌️ Visual Interface Design
- A **divider line** separates the search area from the operation area for better structure.  
- **Color palette:** light green + white (consistent with system identity).  
- Clear icons distinguish between modes (Edit, Delete, None).

---

### 🛡️ Quality and Performance Guarantees

✅ **Security:**  
No operation can be performed unless a clear mode (Edit/Delete) is selected — preventing unintended actions.  

✅ **Stability:**  
If the client data file does not exist, it is **automatically created** to avoid system crashes.  

✅ **Scalability:**  
The system architecture is designed to easily integrate with **external databases** in the future without major interface or logic changes.  

✅ **User Experience Excellence:**  
- Informative messages.  
- Safety confirmations.  
- Visually clear layout.  
- Full compatibility with **Guna UI2 interface**.

> 💡 This section is a **critical management tool** in the system, combining **accuracy, security, and full control** over client data — making it essential for any data-driven system that requires editing or deletion functionality.

---

📌 **Technical Note:**  
All client information is stored in a local text file (`InformationClients.txt`) using the separator `;||;`.  
This structure can easily be migrated to a database system later without major modifications.

---

## 👤 Section: Add New User (UserControlUsers)

### 🎯 Main Purpose  
Allows the administrator to **create new user accounts** in the "Sparkle" system through an integrated interface that defines user permissions (Full Access or Special Permissions).  
It ensures **data integrity**, **prevents duplication**, and provides **precise access control** to different system sections.

---

### ✨ Key Features

#### 🔐 Precise Permission Control
- **Full Access:**  
  - Grants the user unrestricted access to all system sections.
- **Special Permission:**  
  - Enables assigning access rights for each section individually:
    - 📋 `New Order Section`  
    - 📊 `Show All Orders Section`  
    - 👥 `Client List Section`  
    - 🛠️ `Remove/Update Client Section`  
    - 👤 `Users Section`  
    - 🗃️ `Users List Section`  
    - 🔄 `Remove/Update Users Section`  
    - 📜 `History Login Section`

#### 🧩 Password Encryption System
- Passwords are stored in a text file using a simple encryption key (`_KEY_CRYPT = 2`).  
- When displayed, they are automatically decrypted for readability.  
- This approach protects **sensitive data** while maintaining **easy management** when needed.

#### 🚫 Duplicate Prevention & Admin Protection
- The system **blocks creation** of a new `Admin` account if one already exists, ensuring stability.  
- Prevents creating duplicate usernames and displays a clear error message if duplication occurs.

#### 🎲 Random Password Generation
- If the admin does not enter a password, a **random 4-digit password** is automatically generated.  
- This feature speeds up account creation while maintaining security.

#### 🖌️ Modern and Clear Interface
- Clean icons distinguish between access modes (Full / Special).  
- Consistent color scheme matching the Sparkle identity (Light Green + White).  
- Simple, user-friendly form design.

---

### 🛡️ Quality and Performance Guarantees

✅ **Security:**  
A user cannot be created without a username and password — preventing unauthorized actions.

✅ **Stability:**  
If the users file does not exist, it is **automatically created** to prevent system crashes.

✅ **Scalability:**  
The architecture is designed for **easy future database integration** with minimal interface changes.

✅ **User Experience:**  
- Clear confirmation and error messages.  
- Strong visual hierarchy.  
- Integrated with Guna UI2 design components.

> 💡 This section serves as a **core administrative tool**, combining **accuracy, security, and full control** in user creation — essential for systems requiring multi-level permission management.



### 📌 Technical Note  
User data is stored in a local text file (`UsersInformation.txt`) using the delimiter `||`.  
This system can later be replaced with a database without significant structural or interface modifications.

---

## 👥 Section: Users List

### 🎯 Main Purpose  
Displays all user accounts in the "Sparkle" system in an organized and easy-to-browse table, allowing **instant search by username**, while showing each user’s **permission level** and **account status (Locked / Active)** — all through a clean, interactive interface.

---

### ✨ Key Features

#### 🔍 Instant Search by Username
- Allows the admin to search for any user by entering the **Username**.  
- When a match is found:  
  - ⭐ The corresponding row is highlighted in yellow.  
  - 🎯 The table automatically scrolls to focus on that user.  
- If not found → a clear error message is displayed to guide the user.

#### 📊 Organized User Data Display
- Loads all users from the `UsersInformation.txt` file upon section initialization.  
- The table contains **4 main columns**:
  - 👤 **Username**  
  - 🔑 **Password** (encrypted, then decrypted on display)  
  - 🛡️ **User Permissions** (numeric value representing access level)  
  - 🚫 **Account Status** (Locked / Active)

#### 🖌️ Clean Visual Design
- A horizontal line separates the header and the table for better visual structure.  
- Colors match the system’s identity (Light Green + White).  
- The total number of users is displayed in a small label beside a user icon.

#### 🧹 Auto Reset System
- After each search, the input field is automatically cleared and refocused for faster subsequent searches.

#### 🛡️ Special Protection for “Admin”
- The `Admin` account is highlighted in **red** to emphasize its importance.  
- This account **cannot be deleted or modified** from this section (handled exclusively in “Remove or Update User”).

---

### 🛡️ Quality and Performance Guarantees

✅ **Security:**  
Passwords are stored encrypted in the file and only decrypted when displayed — ensuring sensitive data protection.

✅ **Stability:**  
If the users file does not exist, it is automatically created to prevent system failure.

✅ **Scalability:**  
The design is ready for future integration with external databases without major UI or logic changes.

✅ **User Experience:**  
- Clear messages and confirmations.  
- Logical visual hierarchy.  
- Full support for Windows Forms design components.

> 💡 This section serves as a **core interaction hub** for managing user data, combining **display, search, and security** in a unified module — making it the backbone of user management in the Sparkle system.

---

### 📌 Technical Note  
User data is stored locally in a text file (`UsersInformation.txt`) using the delimiter `||`.  
This structure can later be replaced with a database without significant interface or logic modifications.

---

## 👤 Section: Edit or Delete User 

### 🎯 Main Purpose  
Allows the administrator to **manage user accounts** in the “Sparkle” system through an integrated interface.  
The process begins by searching for the user by **username**, then lets the admin choose between **Edit** or **Delete** mode — ensuring **data protection** and preventing **unauthorized actions** (such as modifying or deleting the “Admin” account).

---

### ✨ Key Features

#### 🔍 Smart Search by Username
- Enables the administrator to search for any user by entering their **username**.  
- Once the user is found:
  - ✅ A success notification instantly appears.  
  - 🎯 The user’s details are displayed in the corresponding input fields.  
  - ⚙️ The proper mode (Edit/Delete) is automatically activated based on the admin’s selection.

#### 🔄 Dual Smart Modes: Edit | Delete
- **Edit Mode (Update Mode):**  
  - All fields become editable for updating the password or account status (Lock/Unlock).  
  - The admin can change the password or keep it unchanged.  
  - Account can be **locked** (attempts = 0) or **unlocked** (restored to 3 attempts).  
- **Delete Mode (Remove Mode):**  
  - Displays the user’s data in a **read-only format**.  
  - Upon confirmation → the user is deleted from the system, and the file is updated automatically.  
- **Waiting Mode (None Mode):**  
  - No operations can be performed until a mode is clearly selected.

#### 🛡️ Special Protection for "Admin" Account
- The `Admin` account **cannot be deleted or modified** — ensuring system stability.  
- If an attempt is made to edit or delete the Admin account → a clear error message is shown, and the action is blocked.

#### 🧹 Automatic Reset
- After each operation (Edit or Delete) → all fields are cleared, and the mode resets to “None.”  
- Prevents repeated errors and ensures smoother operation.

#### 📄 Account Status Preview
- In Edit Mode → the system shows whether the account is **locked or active**.  
- Helps the administrator make an informed decision when changing account status.

#### 🖌️ Visual Design
- A **divider line** separates the search and operation areas for better organization.  
- **Color scheme:** light green + white (consistent with system identity).  
- Clear icons distinguish between operation modes (Edit, Delete, None).

---

### 🛡️ Quality and Performance Guarantees

✅ **Security:**  
No operation can be executed without choosing a clear mode (Edit/Delete), preventing random actions.  
The **Admin account is fully protected** from any modifications or deletions.  

✅ **Stability:**  
If the users’ data file does not exist, it is **automatically created** to avoid crashes.  

✅ **Scalability:**  
The system’s structure is designed for **future integration with databases** without major changes to the interface or logic.  

✅ **Excellent User Experience:**  
- Informative feedback messages.  
- Security confirmations.  
- Clean and clear interface design.  
- Full support for **Guna UI2 components**.

> 💡 This section is a **critical management tool** within the system — combining **accuracy, security, and complete control** over user accounts, making it essential for any secure administrative environment.

---

📌 **Technical Note:**  
User data is stored locally in a text file (`UsersInformation.txt`) using the separator `||`.  
The system can later be upgraded to use a database with minimal interface or logic changes.

---

## 📜 Section: User Login History 

### 🎯 Main Purpose  
Tracks and displays all previous user login sessions in the *Sparkle* system, allowing administrators to **search by username**, view **securely encrypted passwords**, and check the **date and time** of each login — ensuring transparency and administrative control.

---

### ✨ Key Features

#### 🔐 Secure Display of Encrypted Passwords
- Passwords are stored in a text file using a simple encryption key (`_KEY_CRYPT = 2`).  
- During display, they are automatically decrypted to show the original text safely.  
- This approach ensures **sensitive data protection** while maintaining **readability when needed**.

#### 🔍 Smart Search by Username
- Supports **partial matching**, allowing users to search by entering part of the username.  
- Clicking “Search” filters and displays only the matching login records.  
- If the search field is empty → a clear warning message appears.

#### 📊 Organized Data Display
- All login records are loaded from the `HistoryLoginSparkle.txt` file when the section is opened.  
- The table contains **three columns**:  
  - 👤 **Username**  
  - 🔑 **Password** (encrypted in file, decrypted for display)  
  - 🕒 **Date Time Login Sparkle**

#### 🔄 Auto-Refresh After Search
- When a new search is performed → the table is cleared and refilled with new results.  
- The counter `LblNumberHistoryLoginSparkle` updates automatically to reflect the number of displayed records.

#### 🖌️ Consistent Visual Design
- A decorative line separates the title from the table for better visual organization.  
- Uses Sparkle’s color palette (light green + white).  
- Displays the total number of login records in a small status label beside a record/document icon.

#### ⚙️ Secure and Stable Data Handling
- If the log file doesn’t exist, it is **automatically created** — preventing any runtime errors.  
- Uses a custom separator (`$$$//$$$`) to distinguish between data fields.  
- The structured data format allows **easy future scalability** (e.g., database integration or additional fields).

---

### 🛡️ Quality & Performance Assurance

✅ **Security**  
Simple encryption prevents passwords from being stored in plain text while allowing safe decryption for viewing.  

✅ **Accuracy**  
Partial search makes it easy to locate users even if their full names are not remembered.  

✅ **Stability**  
No direct file modifications occur during viewing — data is loaded once and safely displayed.  

✅ **Excellent User Experience**  
- Clear and friendly messages  
- Clean, organized interface  
- Visually structured layout  
- Full compatibility with Windows Forms

> 💡 This section acts as a **monitoring and management tool**, providing a **complete access history log** — ideal for verifying user activity, assigning responsibility, and analyzing usage patterns.

---

📌 **Technical Note**  
Login history data is stored locally in `HistoryLoginSparkle.txt` using the separator `$$$//$$$`.  
This structure can later be replaced with a database system without major UI or logic changes.

---

## 🎓 General Note About the Project:
The **Sparkle system**  is a **Training** Project developed for the purpose of learning and practical application of concepts such as system management, user interface design, and file handling.

--- 

# 👨💻 Author

**Ahmed Jehad Ahmed**  


🔗 [GitHub Profile](https://github.com/7mee3d)

📧 [Email Contact](mailto:enginnerahemdjehad2004@gmail.com)
