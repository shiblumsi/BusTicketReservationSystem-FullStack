# BusTicketReservationSystem

A full-stack bus ticket booking system with search, booking, cancellation, and seat plan management.  
Backend is built with .NET 9 Web API and Frontend with Angular 20.

---

##  Features

- Search available buses by route & date
- Book, cancel, and confirm seats
- View seat plan of a bus schedule
- Boarding & dropping point management
- Transaction management & seat status validation

---

##  Tech Stack

- **Backend:** .NET 9 Web API, Entity Framework Core  
- **Frontend:** Angular 20, ngx-toastr for notifications  
- **Database:** PostgreSQL  
- **Testing:** xUnit, Moq  

---

## Setup & Run Instructions

### 1. Clone the repository
```bash
git clone "https://github.com/shiblumsi/BusTicketReservationSystem-FullStack"
cd BusTicketReservationSystem
```
- backend
```bash

cd BusTicketReservationSystem.API
dotnet restore
dotnet build
dotnet run
```
- frontend
```bash
cd ../ClientApp
npm install
ng serve
```
- Test
```bash
cd ../BusTicketReservationSystem.Tests
dotnet test
```
##  Demo Video
Watch the short walkthrough video (Architecture + Workflow + Tests):

 Watch on Google Drive: https://drive.google.com/file/d/1ZISxpBTkXGc27ZqL4aTlpxEuWHgdihDv/view?usp=sharing
