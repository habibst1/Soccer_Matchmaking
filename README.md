# ⚽ Soccer Matchmaking Platform

A full-stack web platform that connects **soccer players** with **stadium owners**, providing seamless matchmaking experiences and stadium management.  
Players can create or join games, while stadium owners can manage venues and track reservations — all in one place.  

---

## 🚀 Features

- **Matchmaking Modes**
  - **Solo Play (Join/Create)**: Players can create or join open lobbies.
  - **Team vs Team**: Enables full team battles.
  - **Full Game Participation**: Join scheduled matches directly.
- **Player Profiles**
  - Match history, performance statistics, and current game status.
- **Stadium Management**
  - Stadium owners can register venues, add/manage time slots, and track reservations (manual or automatic).
- **Real-Time Availability**
  - Available time slots sync automatically with player reservations.
- **Lobby System**
  - Players can create, view, and join lobbies with dynamic status updates.

---

## ⚙️ How It Works

1. **Stadium Owners**
   - Create an account, register stadiums, and define time slots.
   - Time slots update automatically when games are reserved through the platform.
   
2. **Players**
   - Sign up and build a profile.
   - Join or create matches via matchmaking (solo, team, or full game).
   - Reserved lobbies automatically occupy the corresponding stadium slots.

3. **Match Flow**
   - A lobby is created → players join → once full, the stadium slot is officially booked.
   - Player profiles update automatically with match history and participation details.

---

## 🛠️ Tech Stack

- **Backend & Frontend**: .NET 8 (MVC)
- **Database**: Microsoft SQL Server (SSMS)

---

# 📸 Snapshots from the Project

## Stadium Owner POV:
#### Creating an account
![1](https://github.com/user-attachments/assets/4b3e455f-a049-4f82-8dd4-d6ddfdfee155)

#### Adding his stadium to the platform
![2](https://github.com/user-attachments/assets/76b2ff0f-5dbc-471f-ab62-36e1c268fb55)

#### Adding Time Slots where he can manually modify them (Occupied / Not occupied) or automatically if it is reserved by Players via the platform
![3](https://github.com/user-attachments/assets/3a78f0c5-d9a4-4722-b4fc-728bc4e0ec5f)

## Player POV:
#### Creating an account
![4](https://github.com/user-attachments/assets/d56f9db5-bd50-4f4c-9250-3c31136896ce)

#### Player Profile
![5](https://github.com/user-attachments/assets/a73ba3c0-c895-4ddd-bfdd-c3da61696cf1)

#### Matchmaking Interface
![6](https://github.com/user-attachments/assets/9e7aa452-3cec-42c4-a381-ea6b837c3d0e)

#### Creating a game
![7](https://github.com/user-attachments/assets/df7e25bc-258d-4ba3-8c73-b470fceb26b4)

#### Showing that available time slots are the same created by the Stadium Owner (Not Occupied)
![8](https://github.com/user-attachments/assets/e4eb6490-1383-45e6-a63e-31fbd99da8e1)

#### Showing the Added Lobby before being played (Strating soon)
![9](https://github.com/user-attachments/assets/113f9b0d-82ba-48d9-8400-0f1bb4de84e3)

#### Showing that are the users linked to that lobby are added in their profile
![10](https://github.com/user-attachments/assets/f0f952d0-0d6a-46cd-8dc8-63cce344a19f)

#### Showing a Player that create a game with the type Solo (waiting for others to join it so It become full and occupy officially the Stadium)
![11](https://github.com/user-attachments/assets/574b43af-5472-438b-80a5-5bac29aaba15)

#### Showing the interface for a player who wants to join the previous available Lobby
![13](https://github.com/user-attachments/assets/c9e6f1d9-519e-42a3-ac4f-3639c9f60763)
