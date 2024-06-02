# EventoWebsite

EventoWebsite is a reliable and secure platform for event ticketing and fan identification. It aims to enhance the user experience for sports and entertainment events by providing a seamless booking process, ensuring ticket authenticity, and offering robust event management features.

## Features

- **Admin Functionality:**
  - Approve or decline new user accounts
  - Manage events, including timings and locations
  - Access comprehensive event data
  - Communicate with event organizers

- **User Functionality:**
  - Register for Evento Fan ID or Evento ID
  - Browse upcoming sports and entertainment events
  - Book tickets, choose seats, and make payments
  - Access purchased tickets with QR codes for entry
  - Leave reviews for attended events

- **Event Organizer Functionality:**
  - Create and manage event listings
  - Track ticket availability and monitor sales
  - Collaborate with Evento for ticketing services and promotions

## Database Design

The database includes tables for Admins, Users, Event Organizers, Bookings, Promotions, Payments, Reviews, Locations, Tickets, Events, and Social Media Links. Relationships between these entities ensure data integrity and support the functionality of EventoWebsite.

## Technology Stack

- **Database:** SQL
- **Front-end:** .NET
- **Back-end:** .NET

## Pages Overview

### Home Page
- Displays important upcoming event details and an introduction to the platform.

### About Us Page
- Provides a small introduction about the platform, contact information, and upcoming events.

### Sign Up Page
- Allows new users to create accounts and existing users to log in.

### Shows and Events Page
- Offers a choice between "Sports" and "Music" events, with sorting options by month.

### Tickets Page
- Displays available tickets with details and options to purchase.

### Profile Page
- Shows user profile, purchased tickets, and allows profile updates.

### Admin Page
- Accessible only to admins, with options to manage events and user data.

### Installation

```bash
# Clone the repository
git clone https://github.com/Abdelateef/EventoWebsite.git

# Navigate to the project directory
cd EventoWebsite

# Open the solution in Visual Studio
EventoWebsite.sln

# Build and run the project
