## Intro:
This is an app developed in C# using the MAUI Framework (.NET 8) and leveraging SQLite for a local database. It was developed alongside three of my classmates as the final deliverable of our Intro to Software Development course (then called Object Oriented Principles). Their github handles are listed at the bottom of this README.

This app allows users to track their finances. It supports account creation/login functionality; includes a dashboard that displays transaction history and a reports page with a text box entry point; allows the user to change their password and set a monthly spending cap; and provides an Overview page which offers a broad overview of the user's largest spending categories.

## Installation:
This is a MAUI application, thus it is supported on all major Operating Systems and architectures supported by MAUI. You will need to have .NET 8 SDK or newer downloaded.

If using HTTPS:
- `git clone -b master 'https://github.com/KlintonJ/OtusFinance.git'`

If using SSL:
-  `git clone -b master git@github.com:KlintonJ/OtusFinance.git`

## Walkthrough: 
Upon launching the app, users will arrive at the Login/Create Account page. They will be able to create a login with a custom username and password, or login if they have previously created an account. Upon signing in, users will land on the Dashboard page. If the user has entered transactions before, it will show all transactions and related data. The user may choose to navigate to the Reports, Settings, or Overview pages from the pane on the left of the screen. Navigating to Reports will provide the user with an two input options, with the first being an amount of money in USD and the second being a transaction type dropdown. Navigating to Settings will allow the user to Log Out, change their password, or set their monthly spending cap. Finally, navigating to Overview will offer a pie chart showing the how much the user spends in each spending category.

# Team/Contributors:
- TonyTheAlias (Project Lead, Full Stack Developer)
- kiransilwal10 (Front End Developer)
- CNDevelops (Front End Developer)
- aniJani (Backend Developer)
- KlintonJ (myself, Backend Developer)
