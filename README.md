# 🏥 Clinic Management System - API

A **Clinic Management System API** built with **.NET** using **Clean Architecture** and **CQRS**, designed to provide a scalable, maintainable, and secure backend solution.  

This system supports **user authentication, appointment management, notifications, background jobs, logging, profiling, and real-time updates** for clinics.  

---

## 🚀 Features

- **Clean Architecture** for separation of concerns and maintainability  
- **CQRS + MediatR** for handling commands/queries  
- **Entity Framework Core** for database access  
- **ASP.NET Core Identity + JWT Authentication** for secure user management  
- **Role-based Authorization** (Admin, Doctor, Patient)  
- **SignalR** for real-time notifications and messaging  
- **Hangfire** for background job scheduling (e.g., appointment reminders, email sending)  
- **Email Integration** (SMTP / SendGrid / any provider)  
- **MiniProfiler** for performance monitoring  
- **Centralized Logging** (Serilog / Seq / ELK stack)  
- **Global Error Handling & Validation**  
- **Swagger/OpenAPI** for API documentation  

---

## 🛠️ Tech Stack

- **Framework:** .NET 8 (or .NET 7 if needed)  
- **Architecture:** Clean Architecture + CQRS + Repository Pattern  
- **Database:** SQL Server (or PostgreSQL)  
- **ORM:** Entity Framework Core  
- **Authentication:** Identity + JWT  
- **Real-time:** SignalR  
- **Background Jobs:** Hangfire  
- **Logging:** Serilog (with Console, File, Seq, or Elastic integration)  
- **Profiling:** MiniProfiler  
- **Documentation:** Swagger UI  

---

---

## 🔐 Authentication & Authorization

- **JWT Tokens** for securing endpoints  
- Users can **register/login**  
- Roles: **Admin, Doctor, Patient**  
- Example:  
  - `Admin` → Manage doctors, patients, and system settings  
  - `Doctor` → Manage appointments, prescriptions  
  - `Patient` → Book appointments, view records  

---

## 🔔 Notifications & Real-Time

- **SignalR Hub** broadcasts real-time updates (e.g., appointment confirmations, reminders).  
- **Hangfire jobs** send background email/SMS reminders.  

---

## 📊 Monitoring & Logging

- **MiniProfiler** tracks API performance  
- **Serilog** logs structured events (with support for Seq, Elastic, etc.)  
- Global exception handling middleware  

---

## 📧 Email Service

- Configurable SMTP / SendGrid / MailKit  
- Used for:
  - Registration confirmation  
  - Appointment reminders  
  - Notifications  

---


## 📖 API Documentation

- Swagger UI available at:
- <img width="1208" height="3860" alt="localhost_7114_swagger_index html" src="https://github.com/user-attachments/assets/8b6aac54-c488-4332-9373-8eaffad65329" />

  

## 📂 Project Structure

