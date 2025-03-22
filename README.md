# Georgian College Ticketing System
•	The **Georgian College Ticketing System** is a web-based application designed to streamline the process of submitting and managing support tickets for students and staff at Georgian College. Students can easily submit tickets for issues such as IT support, academic inquiries, or facility maintenance, while administrators can efficiently manage and resolve these tickets through a centralized dashboard. The system ensures transparency and accountability by allowing students to track the status of their tickets in real-time.

# Key Features
•	Student Portal: Submit and track tickets with ease
•	Attachments: Students can upload files (e.g., screenshots, documents) to provide additional context.
•	Real-Time Updates: Track ticket status (Open, In Progress, Resolved).
•	User Authentication: Secure login for students and admins.

# Technologies Used
•	Frontend: HTML, CSS, JavaScript, Bootstrap
•	Backend: ASP.NET Core, Entity Framework Core
•	Database: SQL Server
•	Version Control: GitHub


# Entities
•	Ticket:
Represents a support ticket submitted by a student.
Includes details like title, description, and creation date.
Linked to a  Status  and a  Category.
•	Status:
Represents the current state of a ticket (e.g., Open, In Progress, Resolved).
•	Attachment:
Represents files uploaded by students to provide additional context for a ticket.
Linked to a specific Ticket.
•	Category:
Represents the type of ticket (e.g., IT, Academic, Facilities).
#Relationships
•	A Ticket  has one Status and one Category.
•	A Ticket can have multiple Attachments.
#Workflow

•	Student Submits a Ticket:
o	A student logs in and submits a ticket with a title, description, and category.
o	Optionally, the student can upload attachments (e.g., screenshots).
•	Admin Manages Tickets:
o	Admins view all tickets in the dashboard.
o	Admins update the status of tickets (e.g., Open → In Progress → Resolved)
•	Student Tracks Ticket:
o	Students can view the status of their tickets and any updates made by admins.
# How to Use
Clone the repository:
•	   git clone https://github.com/your-username/GeorgianCollegeTicketingSystem.git
AZURE DEPLOYMENT LINK :https://georgiancollege20250307225844.azurewebsites.net/
